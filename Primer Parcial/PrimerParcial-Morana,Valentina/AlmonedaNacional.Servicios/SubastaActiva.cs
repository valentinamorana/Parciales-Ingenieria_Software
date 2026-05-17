using System;
using System.Collections.Generic;
using AlmonedaNacional.BE;
using AlmonedaNacional.Servicios.Composite;
using AlmonedaNacional.Servicios.Observer;
using AlmonedaNacional.Servicios.Singleton;

namespace AlmonedaNacional.Servicios
{
    // Sujeto del patrón Observer.
    // Usa IUnidadDeVenta (Composite) como elemento subastado.
    // Delega el control de concurrencia al GestorDePujasSingleton.
    public class SubastaActiva : ISujetoSubasta
    {
        private readonly IUnidadDeVenta _unidad;
        private readonly IList<IObservadorSubasta> _observadores;
        private decimal _precioActual;
        private Usuario _ultimoPujador;
        private bool _estaActiva;

        public SubastaActiva(IUnidadDeVenta unidad)
        {
            _unidad       = unidad ?? throw new ArgumentNullException(nameof(unidad));
            _observadores = new List<IObservadorSubasta>();
            _precioActual = unidad.CalcularPrecioBase();
            _estaActiva   = true;
        }

        public IUnidadDeVenta Unidad      => _unidad;
        public decimal PrecioActual       => _precioActual;
        public Usuario UltimoPujador      => _ultimoPujador;
        public bool EstaActiva            => _estaActiva;

        // RF-05: suscribir interesado
        public void Suscribir(IObservadorSubasta observador)
        {
            if (observador == null) throw new ArgumentNullException(nameof(observador));
            if (_observadores.Contains(observador))
                throw new InvalidOperationException("El usuario ya está suscripto a esta subasta.");
            _observadores.Add(observador);
        }

        // RF-08: desuscribir interesado
        public void Desuscribir(IObservadorSubasta observador)
        {
            if (observador == null) throw new ArgumentNullException(nameof(observador));
            if (!_observadores.Contains(observador))
                throw new InvalidOperationException("El usuario no está suscripto a esta subasta.");
            _observadores.Remove(observador);
        }

        // RF-06 / RF-07: notifica a todos los suscriptores
        public void Notificar(string evento)
        {
            foreach (var obs in _observadores)
                obs.Actualizar(_unidad.Nombre, _precioActual, evento);
        }

        // RF-10: valida y procesa oferta bajo lock del Singleton (RF-09)
        public void RealizarOferta(Usuario usuario, decimal monto)
        {
            if (!_estaActiva)
                throw new InvalidOperationException("No se pueden realizar ofertas: la subasta está cerrada.");
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            GestorDePujasSingleton.Instancia.EjecutarBajoLock(() =>
            {
                if (monto <= _precioActual)
                    throw new InvalidOperationException(
                        $"La oferta de ${monto:N2} debe superar el precio actual de ${_precioActual:N2}.");

                _precioActual  = monto;
                _ultimoPujador = usuario;
                Notificar("NUEVA_PUJA");
            });
        }

        // Cierra la subasta y retorna el resultado para persistir
        public ResultadoSubasta Cerrar()
        {
            if (!_estaActiva)
                throw new InvalidOperationException("La subasta ya está cerrada.");
            if (_ultimoPujador == null)
                throw new InvalidOperationException("No se puede cerrar la subasta: no se registraron ofertas.");

            _estaActiva = false;
            Notificar("SUBASTA_CERRADA");

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
