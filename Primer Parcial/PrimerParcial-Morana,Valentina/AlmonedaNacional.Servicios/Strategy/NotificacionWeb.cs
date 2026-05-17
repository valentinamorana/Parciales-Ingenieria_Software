using System;

namespace AlmonedaNacional.Servicios.Strategy
{
    public class NotificacionWeb : IEstrategiaNotificacion
    {
        public string NombreCanal => "WEB";

        public void EnviarNotificacion(string destinatario, string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"    [WEB] → {destinatario}: {mensaje}");
            Console.ResetColor();
        }
    }
}
