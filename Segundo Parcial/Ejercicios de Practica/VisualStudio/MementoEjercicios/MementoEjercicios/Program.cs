using System;

namespace MementoEjercicios
{
    class Program
    {
        static void Main(string[] args)
        {
            Editor.Demo.Ejecutar();
            Juego.Demo.Ejecutar();

            Console.WriteLine("Presioná una tecla para salir...");
            Console.ReadKey();
        }
    }
}
