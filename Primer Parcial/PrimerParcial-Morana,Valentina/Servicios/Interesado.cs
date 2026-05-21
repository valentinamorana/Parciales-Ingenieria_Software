using System;
using BE;

namespace Servicios
{
    // Observer concreto. Recibe el sujeto completo y dispara un evento
    // para que la capa de presentación decida cómo mostrarlo (SRP / DIP).
    public class Interesado : IObservadorSubasta
    {
        private readonly Usuario _usuario;

        // La UI suscribe a este evento; Interesado no conoce nada de WinForms.
        public event Action<string, string> NotificacionRecibida; // (destinatario, mensaje)

        public Interesado(Usuario usuario)
        {
            _usuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
        }

        public Usuario Usuario => _usuario;

        public void Actualizar(SubastaActiva subasta)
        {
            string mensaje = subasta.EstaActiva
                ? $"Nueva puja de {subasta.UltimoPujador?.Nombre} en '{subasta.Unidad.Nombre}': ${subasta.PrecioActual:N2}"
                : $"SUBASTA CERRADA — {subasta.Unidad.Nombre} | Precio final: ${subasta.PrecioActual:N2}";

            NotificacionRecibida?.Invoke(_usuario.Nombre, mensaje);
        }
    }
}
