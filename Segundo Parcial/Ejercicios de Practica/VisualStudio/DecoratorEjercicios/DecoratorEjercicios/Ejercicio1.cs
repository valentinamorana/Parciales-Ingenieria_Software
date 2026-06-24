using System;

// ============================================================
//  DECORATOR - Ejercicio 1: Pizza con ingredientes extra
//  Una pizza base tiene costo y descripción. Le podés agregar
//  ingredientes (queso extra, jamón, aceitunas) que suman al
//  precio y a la descripción. Los agregados se apilan.
// ============================================================
namespace DecoratorEjercicios.Pizzas
{
    // ---------- Component ----------
    public abstract class Pizza
    {
        public abstract double Costo { get; }
        public abstract string Descripcion { get; }
    }

    // ---------- Componente concreto (base) ----------
    public class PizzaMuzzarella : Pizza
    {
        public override double Costo => 2000;
        public override string Descripcion => "Pizza de muzzarella";
    }

    // ---------- Decorador abstracto ----------
    public abstract class IngredienteDecorator : Pizza
    {
        protected Pizza _pizza;
        public IngredienteDecorator(Pizza pizza)
        {
            _pizza = pizza;
        }
    }

    // ---------- Decoradores concretos ----------
    public class QuesoExtra : IngredienteDecorator
    {
        public QuesoExtra(Pizza pizza) : base(pizza) { }
        public override double Costo => _pizza.Costo + 500;
        public override string Descripcion => $"{_pizza.Descripcion}, queso extra";
    }

    public class Jamon : IngredienteDecorator
    {
        public Jamon(Pizza pizza) : base(pizza) { }
        public override double Costo => _pizza.Costo + 700;
        public override string Descripcion => $"{_pizza.Descripcion}, jamón";
    }

    public class Aceitunas : IngredienteDecorator
    {
        public Aceitunas(Pizza pizza) : base(pizza) { }
        public override double Costo => _pizza.Costo + 300;
        public override string Descripcion => $"{_pizza.Descripcion}, aceitunas";
    }

    // ---------- Demo ----------
    public static class Demo
    {
        public static void Ejecutar()
        {
            Console.WriteLine("=== Decorator - Ejercicio 1: Pizza ===");

            Pizza pizza = new PizzaMuzzarella();
            pizza = new QuesoExtra(pizza);
            pizza = new Jamon(pizza);
            pizza = new Aceitunas(pizza);

            Console.WriteLine($"{pizza.Descripcion} = ${pizza.Costo}");

            Console.WriteLine();
        }
    }
}
