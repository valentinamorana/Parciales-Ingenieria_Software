using System;
using AlmonedaNacional.BE;
using AlmonedaNacional.Servicios.Observer;
using AlmonedaNacional.Servicios.Strategy;

namespace AlmonedaNacional.Servicios
{
    // Observer concreto. Cada interesado elige su canal de notificación (Strategy).
    public class Interesado : IObservadorSubasta
    {
        private readonly Usuario _usuario;
        private readonly IEstrategiaNotificacion _estrategia;

        public Interesado(Usuario usuario, IEstrategiaNotificacion estrategia)
        {
            _usuario   = usuario   ?? throw new ArgumentNullException(nameof(usuario));
            _estrategia = estrategia ?? throw new ArgumentNullException(nameof(estrategia));
        }

        public Usuario Usuario      => _usuario;
        public string NombreCanal   => _estrategia.NombreCanal;

        // Recibe el sujeto completo y extrae su estado (Observer canónico)
        public void Actualizar(SubastaActiva subasta)
        {
            string mensaje = subasta.EstaActiva
                ? $"Nueva puja en '{subasta.Unidad.Nombre}': ${subasta.PrecioActual:N2}"
                : $"SUBASTA CERRADA — {subasta.Unidad.Nombre} | Precio final: ${subasta.PrecioActual:N2}";

            _estrategia.EnviarNotificacion(_usuario.Nombre, mensaje);
        }
    }
}
