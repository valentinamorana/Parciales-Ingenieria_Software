using System;

// ============================================================
//  ADAPTER - Ejercicio 2: Sensor de temperatura
//  El tablero muestra la temperatura en Celsius vía
//  Termometro.LeerCelsius(). Tenemos un sensor importado que
//  sólo devuelve Fahrenheit. El Adapter convierte la unidad.
// ============================================================
namespace AdapterEjercicios.Temperatura
{
    // ---------- Target ----------
    public abstract class Termometro
    {
        public abstract double LeerCelsius();
    }

    // ---------- Adaptee: sólo sabe de Fahrenheit ----------
    public class SensorFahrenheit
    {
        public double ObtenerFahrenheit() => 98.6; // valor simulado
    }

    // ---------- Adapter ----------
    public class SensorFahrenheitAdapter : Termometro
    {
        private SensorFahrenheit _sensor = new SensorFahrenheit();

        public override double LeerCelsius()
        {
            double f = _sensor.ObtenerFahrenheit();
            return (f - 32) * 5 / 9; // conversión F -> C
        }
    }

    // ---------- Demo ----------
    public static class Demo
    {
        public static void Ejecutar()
        {
            Console.WriteLine("=== Adapter - Ejercicio 2: Temperatura ===");

            Termometro termometro = new SensorFahrenheitAdapter();
            Console.WriteLine($"Temperatura: {termometro.LeerCelsius():0.0} °C");

            Console.WriteLine();
        }
    }
}
