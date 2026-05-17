using System;
using System.Windows.Forms;
using AlmonedaNacional.Servicios.Strategy;

namespace AlmonedaNacional.GUI
{
    // Estrategia de notificación para la interfaz gráfica.
    // Implementa IEstrategiaNotificacion (patrón Strategy) pero escribe en un RichTextBox.
    // Demostración de Open/Closed: se agrega un nuevo canal sin modificar los existentes.
    public class NotificacionGUI : IEstrategiaNotificacion
    {
        private readonly RichTextBox _log;
        private readonly string _prefijo;

        public NotificacionGUI(RichTextBox log, string prefijo)
        {
            _log    = log    ?? throw new ArgumentNullException(nameof(log));
            _prefijo = prefijo ?? string.Empty;
        }

        public string NombreCanal => $"GUI [{_prefijo}]";

        public void EnviarNotificacion(string destinatario, string mensaje)
        {
            _log.AppendText($"[{DateTime.Now:HH:mm:ss}] [{_prefijo}] {destinatario}: {mensaje}\r\n");
        }
    }
}
