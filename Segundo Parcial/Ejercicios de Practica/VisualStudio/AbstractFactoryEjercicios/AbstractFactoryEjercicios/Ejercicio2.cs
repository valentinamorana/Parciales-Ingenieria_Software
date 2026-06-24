using System;

// ============================================================
//  ABSTRACT FACTORY - Ejercicio 2: Mobiliario por estilo
//  Una tienda arma juegos de muebles. Según el estilo (Moderno
//  o Clásico) entrega una Silla y una Mesa que combinan entre sí.
// ============================================================
namespace AbstractFactoryEjercicios.Muebles
{
    // ---------- Productos abstractos ----------
    public abstract class Silla
    {
        public abstract string Describir();
    }

    public abstract class Mesa
    {
        public abstract string Describir();
    }

    // ---------- Familia Moderna ----------
    public class SillaModerna : Silla
    {
        public override string Describir() => "Silla minimalista de metal";
    }

    public class MesaModerna : Mesa
    {
        public override string Describir() => "Mesa de vidrio templado";
    }

    // ---------- Familia Clásica ----------
    public class SillaClasica : Silla
    {
        public override string Describir() => "Silla de madera tallada";
    }

    public class MesaClasica : Mesa
    {
        public override string Describir() => "Mesa de roble macizo";
    }

    // ---------- Fábrica abstracta ----------
    public abstract class FabricaMuebles
    {
        public abstract Silla CrearSilla();
        public abstract Mesa CrearMesa();
    }

    // ---------- Fábricas concretas ----------
    public class FabricaModerna : FabricaMuebles
    {
        public override Silla CrearSilla() => new SillaModerna();
        public override Mesa CrearMesa() => new MesaModerna();
    }

    public class FabricaClasica : FabricaMuebles
    {
        public override Silla CrearSilla() => new SillaClasica();
        public override Mesa CrearMesa() => new MesaClasica();
    }

    // ---------- Demo ----------
    public static class Demo
    {
        public static void Ejecutar()
        {
            Console.WriteLine("=== Abstract Factory - Ejercicio 2: Mobiliario ===");

            FabricaMuebles fabrica = new FabricaModerna();
            Console.WriteLine(fabrica.CrearSilla().Describir());
            Console.WriteLine(fabrica.CrearMesa().Describir());

            fabrica = new FabricaClasica();
            Console.WriteLine(fabrica.CrearSilla().Describir());
            Console.WriteLine(fabrica.CrearMesa().Describir());

            Console.WriteLine();
        }
    }
}
