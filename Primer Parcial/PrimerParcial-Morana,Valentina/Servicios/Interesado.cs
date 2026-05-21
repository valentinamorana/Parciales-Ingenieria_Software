using System;
using BE;

namespace Servicios
{
    // ═══════════════════════════════════════════════════════════
    //  PATRÓN OBSERVER — Rol: ConcreteObserver (Observador concreto) (RF-05 a RF-08)
    // ═══════════════════════════════════════════════════════════
    // Interesado representa a un usuario que se suscribe a una SubastaActiva
    // para recibir notificaciones de cambios (nuevas pujas o cierre).
    //
    // Implementa IObservadorSubasta.Actualizar(): recibe el sujeto completo
    // (variante "push" del GoF), arma el mensaje y dispara NotificacionRecibida.
    //
    // El evento NotificacionRecibida desacopla la capa de Servicios de WinForms:
    //   - Interesado no sabe nada de MessageBox ni de controles visuales (SRP).
    //   - frmSubasta suscribe al evento y decide cómo mostrar la notificación (DIP).
    //
    // Distinción en Actualizar:
    //   EstaActiva = true  → nueva puja aceptada (RF-06)
    //   EstaActiva = false → subasta cerrada, mensaje de precio final (RF-07)
    public class Interesado : IObservadorSubasta
    {
        private readonly Usuario _usuario;

        // La GUI suscribe a este evento para mostrar notificaciones sin que
        // Interesado tenga que conocer los controles de WinForms.
        // Firma: (nombreDestinatario, mensajeTexto)
        public event Action<string, string> NotificacionRecibida;

        public Interesado(Usuario usuario)
        {
            _usuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
        }

        public Usuario Usuario => _usuario;

        // Llamado por SubastaActiva.Notificar() cada vez que cambia el estado.
        // Construye el mensaje según si la subasta sigue activa o ya cerró,
        // luego dispara el evento para que la GUI lo procese.
        public void Actualizar(SubastaActiva subasta)
        {
            string mensaje = subasta.EstaActiva
                ? $"Nueva puja de {subasta.UltimoPujador?.Nombre} en '{subasta.Unidad.Nombre}': ${subasta.PrecioActual:N2}"
                : $"SUBASTA CERRADA — {subasta.Unidad.Nombre} | Precio final: ${subasta.PrecioActual:N2}";

            NotificacionRecibida?.Invoke(_usuario.Nombre, mensaje);
        }
    }
}
