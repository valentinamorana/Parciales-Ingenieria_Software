using System;

// ============================================================
//  FACTORY METHOD - Ejercicio 1: Logística (Transporte)
//  Una empresa de logística entrega paquetes. Cada sucursal
//  (Nacional o Internacional) decide, según el tipo pedido, si
//  usa un Camion o un Barco. El método fábrica recibe el tipo y
//  devuelve el transporte concreto, ya marcado con su sucursal.
// ============================================================
namespace FactoryMethodEjercicios.Logistica
{
    // ---------- Product (abstracto) ----------
    public abstract class Transporte
    {
        protected string _medio;
        protected string _sucursal;

        public void Entregar()
        {
            Console.WriteLine(string.Format("Entregando con {0} desde la sucursal {1}.", _medio, _sucursal));
        }
    }

    // ---------- Productos concretos ----------
    public class Camion : Transporte
    {
        public Camion(string sucursal)
        {
            _medio = "camión";
            _sucursal = sucursal;
        }
    }

    public class Barco : Transporte
    {
        public Barco(string sucursal)
        {
            _medio = "barco";
            _sucursal = sucursal;
        }
    }

    // ---------- Creator (abstracto) ----------
    public abstract class Logistica
    {
        // Factory Method: recibe el tipo y devuelve el transporte concreto
        public abstract Transporte CrearTransporte(string tipo);
    }

    // ---------- Creators concretos ----------
    public class LogisticaNacional : Logistica
    {
        public override Transporte CrearTransporte(string tipo)
        {
            if (tipo == "camion")
            {
                return new Camion("Nacional");
            }
            else if (tipo == "barco")
            {
                return new Barco("Nacional");
            }
            else
            {
                return null;
            }
        }
    }

    public class LogisticaInternacional : Logistica
    {
        public override Transporte CrearTransporte(string tipo)
        {
            if (tipo == "camion")
            {
                return new Camion("Internacional");
            }
            else if (tipo == "barco")
            {
                return new Barco("Internacional");
            }
            else
            {
                return null;
            }
        }
    }

    // ---------- Demo ----------
    public static class Demo
    {
        public static void Ejecutar()
        {
            Console.WriteLine("=== Factory Method - Ejercicio 1: Logística ===");

            Logistica logistica;
            Transporte transporte;

            logistica = new LogisticaNacional();
            transporte = logistica.CrearTransporte("camion");
            transporte.Entregar();
            transporte = logistica.CrearTransporte("barco");
            transporte.Entregar();

            logistica = new LogisticaInternacional();
            transporte = logistica.CrearTransporte("camion");
            transporte.Entregar();
            transporte = logistica.CrearTransporte("barco");
            transporte.Entregar();

            Console.WriteLine();
        }
    }
}
