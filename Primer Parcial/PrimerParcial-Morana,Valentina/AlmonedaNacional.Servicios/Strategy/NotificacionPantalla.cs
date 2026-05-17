using System;

namespace AlmonedaNacional.Servicios.Strategy
{
    public class NotificacionPantalla : IEstrategiaNotificacion
    {
        public string NombreCanal => "PANTALLA SALA";

        public void EnviarNotificacion(string destinatario, string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    [PANTALLA SALA] → {destinatario}: {mensaje}");
            Console.ResetColor();
        }
    }
}
