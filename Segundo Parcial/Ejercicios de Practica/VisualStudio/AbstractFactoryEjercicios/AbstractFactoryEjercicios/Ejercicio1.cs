using System;

// ============================================================
//  ABSTRACT FACTORY - Ejercicio 1: Facciones de un videojuego
//  Un juego de estrategia tiene distintas facciones (Humanos u
//  Orcos). Cada facción produce su propio Soldado y su propio
//  Vehiculo. No se mezclan: la fábrica entrega una FAMILIA
//  coherente de unidades de la misma facción.
// ============================================================

namespace AbstractFactoryEjercicios.Juego
{
    // ---------- Productos abstractos ----------
    public abstract class Soldado
    {
        public abstract string Atacar();
    }

    public abstract class Vehiculo
    {
        public abstract string Mover();
    }

    // ---------- Familia Humanos ----------
    public class SoldadoHumano : Soldado
    {
        public override string Atacar() => "Soldado humano dispara su rifle.";
    }

    public class VehiculoHumano : Vehiculo
    {
        public override string Mover() => "Tanque humano avanza sobre sus orugas.";
    }

    // ---------- Familia Orcos ----------
    public class SoldadoOrco : Soldado
    {
        public override string Atacar() => "Soldado orco ataca con su hacha.";
    }

    public class VehiculoOrco : Vehiculo
    {
        public override string Mover() => "Catapulta orca rueda hacia el enemigo.";
    }

    // ---------- Fábrica abstracta (crea VARIOS productos) ----------
    public abstract class FabricaFaccion
    {
        public abstract Soldado CrearSoldado();
        public abstract Vehiculo CrearVehiculo();
    }

    // ---------- Fábricas concretas ----------
    public class FabricaHumanos : FabricaFaccion
    {
        public override Soldado CrearSoldado() => new SoldadoHumano();
        public override Vehiculo CrearVehiculo() => new VehiculoHumano();
    }

    public class FabricaOrcos : FabricaFaccion
    {
        public override Soldado CrearSoldado() => new SoldadoOrco();
        public override Vehiculo CrearVehiculo() => new VehiculoOrco();
    }

    // ---------- Demo ----------
    public static class Demo
    {
        public static void Ejecutar()
        {
            Console.WriteLine("=== Abstract Factory - Ejercicio 1: Facciones ===");

            FabricaFaccion fabrica = new FabricaHumanos();
            Console.WriteLine(fabrica.CrearSoldado().Atacar());
            Console.WriteLine(fabrica.CrearVehiculo().Mover());

            fabrica = new FabricaOrcos();
            Console.WriteLine(fabrica.CrearSoldado().Atacar());
            Console.WriteLine(fabrica.CrearVehiculo().Mover());

            Console.WriteLine();
        }
    }
}
