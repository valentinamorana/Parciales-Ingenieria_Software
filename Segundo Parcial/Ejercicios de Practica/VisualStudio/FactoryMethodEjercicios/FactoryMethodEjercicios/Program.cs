using System;

namespace FactoryMethodEjercicios
{
    class Program
    {
        static void Main(string[] args)
        {
            Logistica.Demo.Ejecutar();
            Notificaciones.Demo.Ejecutar();

            Console.WriteLine("Presioná una tecla para salir...");
            Console.ReadKey();
        }
    }
}
