using System;
using AlmonedaNacional.BE;
using AlmonedaNacional.Servicios.Observer;

namespace AlmonedaNacional.Servicios
{
    // Observer concreto. Recibe el sujeto completo y dispara un evento
    // para que la capa de presentación decida cómo mostrarlo (SRP / DIP).
    public class Interesado : IObservadorSubasta
    {
        private readonly Usuario _usuario;
        private readonly string  _canal;

        // La UI suscribe a este evento; Interesado no conoce nada de WinForms.
        public event Action<string, string> NotificacionRecibida; // (destinatario, mensaje)

        public Interesado(Usuario usuario, string canal)
        {
            _usuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
            _canal   = canal   ?? "—";
        }

        public Usuario Usuario => _usuario;
        public string  Canal   => _canal;

        public void Actualizar(SubastaActiva subasta)
        {
            string mensaje = subasta.EstaActiva
                ? $"Nueva puja en '{subasta.Unidad.Nombre}': ${subasta.PrecioActual:N2}"
                : $"SUBASTA CERRADA — {subasta.Unidad.Nombre} | Precio final: ${subasta.PrecioActual:N2}";

            NotificacionRecibida?.Invoke(_usuario.Nombre, mensaje);
        }
    }
}
