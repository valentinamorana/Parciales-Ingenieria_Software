using System;
using System.Collections.Generic;
using BE;
using Servicios.Composite;

namespace Servicios
{
    // ═══════════════════════════════════════════════════════════
    //  PATRÓN OBSERVER — Rol: ConcreteSubject (Sujeto concreto)
    //  PATRÓN SINGLETON — usa GestorDePujasSingleton (RF-09)
    //  PATRÓN COMPOSITE — opera sobre IUnidadDeVenta como elemento subastado
    // ═══════════════════════════════════════════════════════════
    // SubastaActiva implementa ISujetoSubasta y mantiene la lista
    // de observadores (_observadores). Cada vez que se acepta una puja
    // o se cierra la subasta, llama a Notificar() para avisar a todos.
    //
    // Integración con los otros patrones:
    //   - Composite: acepta cualquier IUnidadDeVenta (artículo simple o lote),
    //     sin conocer la estructura interna del árbol.
    //   - Singleton: todas las pujas pasan por GestorDePujasSingleton.EjecutarBajoLock()
    //     para garantizar que nunca se procesen dos pujas al mismo tiempo (RF-09).
    //
    // Las pujas se acumulan en _pujas (en memoria) durante la subasta.
    // SubastaBLL las persiste en bloque en una sola transacción SQL al cerrar,
    // lo que garantiza atomicidad: o se guardan todas o no se guarda ninguna.
    public class SubastaActiva : ISujetoSubasta
    {
        private readonly IUnidadDeVenta              _unidad;
        private readonly IList<IObservadorSubasta>   _observadores;
        private readonly List<Puja>                  _pujas;
        private decimal  _precioActual;
        private Usuario  _ultimoPujador;
        private bool     _estaActiva;

        public SubastaActiva(IUnidadDeVenta unidad)
        {
            _unidad       = unidad ?? throw new ArgumentNullException(nameof(unidad));
            _observadores = new List<IObservadorSubasta>();
            _pujas        = new List<Puja>();
            _precioActual = unidad.CalcularPrecioBase();
            _estaActiva   = true;
        }

        public IUnidadDeVenta    Unidad        => _unidad;
        public decimal           PrecioActual  => _precioActual;
        public Usuario           UltimoPujador => _ultimoPujador;
        public bool              EstaActiva    => _estaActiva;

        // Exposición de sólo lectura para que SubastaBLL persista las pujas al cerrar.
        // AsReadOnly() evita que el BLL pueda mutar la lista interna.
        public IReadOnlyList<Puja> Pujas => _pujas.AsReadOnly();

        // RF-05: registra un Interesado como observador de esta subasta.
        // Impide duplicados para que un usuario no reciba doble notificación.
        public void Suscribir(IObservadorSubasta observador)
        {
            if (observador == null) throw new ArgumentNullException(nameof(observador));
            if (_observadores.Contains(observador))
                throw new InvalidOperationException("El usuario ya está suscripto a esta subasta.");
            _observadores.Add(observador);
        }

        // RF-08: elimina al observador de la lista. Lanza si no estaba suscripto.
        public void Desuscribir(IObservadorSubasta observador)
        {
            if (observador == null) throw new ArgumentNullException(nameof(observador));
            if (!_observadores.Contains(observador))
                throw new InvalidOperationException("El usuario no está suscripto a esta subasta.");
            _observadores.Remove(observador);
        }

        // RF-06 / RF-07: avisa a todos los observadores del estado actual.
        // Itera sobre una copia de _observadores para que Desuscribir durante
        // una notificación no cause InvalidOperationException en el foreach.
        // Los errores de un observador individual no interrumpen a los demás.
        public void Notificar()
        {
            var copia = new List<IObservadorSubasta>(_observadores);
            foreach (var obs in copia)
            {
                try { obs.Actualizar(this); }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"[SubastaActiva.Notificar] Error en observer: {ex.Message}");
                }
            }
        }

        // RF-10: valida y registra una oferta con exclusión mutua.
        // Toda la lógica de validación corre dentro del lock del Singleton (RF-09)
        // para que dos pujas simultáneas no puedan ganar al mismo tiempo.
        // Si la puja es rechazada, igual se registra en _pujas para el historial,
        // y se lanza OfertaInvalidaException para que la GUI informe al usuario.
        public void RealizarOferta(Usuario usuario, decimal monto)
        {
            if (!_estaActiva)
                throw new SubastaNoActivaException("No se pueden realizar ofertas: la subasta está cerrada.");
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            GestorDePujasSingleton.GetInstance().EjecutarBajoLock(() =>
            {
                if (_ultimoPujador != null && usuario.Id == _ultimoPujador.Id)
                {
                    _pujas.Add(new Puja
                    {
                        NombreUsuario = usuario.Nombre,
                        Monto         = monto,
                        FechaHora     = DateTime.Now,
                        Estado        = EstadoPuja.Rechazada,
                        MotivoRechazo = $"{usuario.Nombre} ya es el pujador actual."
                    });
                    throw new OfertaInvalidaException(
                        $"{usuario.Nombre} ya tiene la oferta más alta. Debe esperar a que otro puje.");
                }

                if (monto <= _precioActual)
                {
                    // Puja rechazada — la registramos antes de lanzar la excepción
                    _pujas.Add(new Puja
                    {
                        NombreUsuario = usuario.Nombre,
                        Monto         = monto,
                        FechaHora     = DateTime.Now,
                        Estado        = EstadoPuja.Rechazada,
                        MotivoRechazo = $"${monto:N2} no supera el precio vigente ${_precioActual:N2}."
                    });
                    throw new OfertaInvalidaException(
                        $"La oferta de ${monto:N2} debe superar el precio actual de ${_precioActual:N2}.");
                }

                _pujas.Add(new Puja
                {
                    NombreUsuario = usuario.Nombre,
                    Monto         = monto,
                    FechaHora     = DateTime.Now,
                    Estado        = EstadoPuja.Aceptada
                });

                _precioActual  = monto;
                _ultimoPujador = usuario;
                Notificar();
            });
        }

        // Cierra la subasta: pone _estaActiva=false, notifica a los observadores
        // (que así saben que es cierre por EstaActiva=false) y construye el ResultadoSubasta
        // que SubastaBLL usará para persistir en la BD.
        // No persiste directamente — eso es responsabilidad del BLL (SRP).
        public ResultadoSubasta Cerrar()
        {
            if (!_estaActiva)
                throw new SubastaNoActivaException("La subasta ya está cerrada.");
            if (_ultimoPujador == null)
                throw new SubastaNoActivaException("No se puede cerrar la subasta: no se registraron ofertas.");

            _estaActiva = false;
            Notificar();

            return new ResultadoSubasta
            {
                NombreUnidadVenta = _unidad.Nombre,
                PrecioBase        = _unidad.CalcularPrecioBase(),
                PrecioFinal       = _precioActual,
                NombreGanador     = _ultimoPujador.Nombre,
                EmailGanador      = _ultimoPujador.Email,
                FechaHora         = DateTime.Now
            };
        }
    }
}
