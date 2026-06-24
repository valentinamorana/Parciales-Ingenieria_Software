using System;

namespace AbstractFactoryEjercicios
{
    class Program
    {
        static void Main(string[] args)
        {
            Juego.Demo.Ejecutar();
            Muebles.Demo.Ejecutar();

            Console.WriteLine("Presioná una tecla para salir...");
            Console.ReadKey();
        }
    }
}
