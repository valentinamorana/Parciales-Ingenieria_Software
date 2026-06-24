using System;

// ============================================================
//  ADAPTER - Ejercicio 1: Pasarela de pagos
//  Nuestro sistema procesa pagos con ProcesadorPago.Pagar(monto).
//  Queremos integrar la librería externa PayPalApi, que tiene
//  otra interfaz (Login + RealizarTransaccion). No la podemos
//  modificar: creamos un Adapter que traduce.
// ============================================================
namespace AdapterEjercicios.Pagos
{
    // ---------- Target: lo que nuestro sistema espera ----------
    public abstract class ProcesadorPago
    {
        public abstract void Pagar(double monto);
    }

    // ---------- Adaptee: librería externa con OTRA interfaz ----------
    public class PayPalApi
    {
        public void Login()
        {
            Console.WriteLine("PayPal: sesión iniciada.");
        }

        public void RealizarTransaccion(double total)
        {
            Console.WriteLine($"PayPal: transacción de ${total} realizada.");
        }
    }

    // ---------- Adapter: implementa Target y ENVUELVE al Adaptee ----------
    public class PayPalAdapter : ProcesadorPago
    {
        private PayPalApi _paypal = new PayPalApi();

        public override void Pagar(double monto)
        {
            // Traducimos la secuencia que PayPal necesita a un solo método
            _paypal.Login();
            _paypal.RealizarTransaccion(monto);
        }
    }

    // ---------- Demo ----------
    public static class Demo
    {
        public static void Ejecutar()
        {
            Console.WriteLine("=== Adapter - Ejercicio 1: Pagos ===");

            ProcesadorPago procesador = new PayPalAdapter();
            procesador.Pagar(1500);

            Console.WriteLine();
        }
    }
}
