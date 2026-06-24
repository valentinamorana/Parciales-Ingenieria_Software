using System;

namespace AdapterEjercicios
{
    class Program
    {
        static void Main(string[] args)
        {
            Pagos.Demo.Ejecutar();
            Temperatura.Demo.Ejecutar();

            Console.WriteLine("Presioná una tecla para salir...");
            Console.ReadKey();
        }
    }
}
