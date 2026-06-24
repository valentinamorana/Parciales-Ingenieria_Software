using System;

namespace DecoratorEjercicios
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizzas.Demo.Ejecutar();
            Notificaciones.Demo.Ejecutar();

            Console.WriteLine("Presioná una tecla para salir...");
            Console.ReadKey();
        }
    }
}
