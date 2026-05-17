using System;

namespace AlmonedaNacional.Servicios.Strategy
{
    public class NotificacionMovil : IEstrategiaNotificacion
    {
        public string NombreCanal => "MÓVIL";

        public void EnviarNotificacion(string destinatario, string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"    [MÓVIL] → {destinatario}: {mensaje}");
            Console.ResetColor();
        }
    }
}
