using System;
using System.Collections.Generic;
using BE;
using Servicios.Composite;
using Servicios.Observer;
using Servicios.Singleton;

namespace Servicios
{
    // Sujeto del patrón Observer.
    // Usa IUnidadDeVenta (Composite) como elemento subastado.
    // Delega el control de concurrencia al GestorDePujasSingleton (RF-09).
    // Acumula en memoria todas las pujas (aceptadas y rechazadas)
    // para que el BLL las persista en bloque al cerrar la subasta.
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

        // Copia de sólo lectura — el BLL persiste estas pujas al cerrar
        public IReadOnlyList<Puja> Pujas => _pujas.AsReadOnly();

        // RF-05
        public void Suscribir(IObservadorSubasta observador)
        {
            if (observador == null) throw new ArgumentNullException(nameof(observador));
            if (_observadores.Contains(observador))
                throw new InvalidOperationException("El usuario ya está suscripto a esta subasta.");
            _observadores.Add(observador);
        }

        // RF-08
        public void Desuscribir(IObservadorSubasta observador)
        {
            if (observador == null) throw new ArgumentNullException(nameof(observador));
            if (!_observadores.Contains(observador))
                throw new InvalidOperationException("El usuario no está suscripto a esta subasta.");
            _observadores.Remove(observador);
        }

        // RF-06 / RF-07
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

        // RF-10: valida y procesa oferta bajo lock del Singleton (RF-09).
        // Registra la puja (Aceptada o Rechazada) en la lista interna.
        // Lanza excepción tipada si es rechazada para que el formulario informe al usuario.
        public void RealizarOferta(Usuario usuario, decimal monto)
        {
            if (!_estaActiva)
                throw new SubastaNoActivaException("No se pueden realizar ofertas: la subasta está cerrada.");
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            GestorDePujasSingleton.Instancia.EjecutarBajoLock(() =>
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
