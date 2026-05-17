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

        // Recibe la notificación del Sujeto y la entrega por el canal elegido (Strategy)
        public void Actualizar(string nombreUnidad, decimal precioActual, string evento)
        {
            string mensaje;
            if (evento == "SUBASTA_CERRADA")
                mensaje = $"SUBASTA CERRADA — {nombreUnidad} | Precio final: ${precioActual:N2}";
            else
                mensaje = $"Nueva puja en '{nombreUnidad}': ${precioActual:N2}";

            _estrategia.EnviarNotificacion(_usuario.Nombre, mensaje);
        }
    }
}
