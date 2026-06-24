using System;

// ============================================================
//  DECORATOR - Ejercicio 2: Notificaciones con canales extra
//  Una notificación base se envía por la app. Se le pueden
//  "decorar" canales adicionales (Email y/o SMS). Cada decorador
//  agrega su envío al del componente que envuelve.
// ============================================================
namespace DecoratorEjercicios.Notificaciones
{
    // ---------- Component ----------
    public abstract class Notificador
    {
        public abstract string Enviar(string mensaje);
    }

    // ---------- Componente concreto (base) ----------
    public class NotificadorBase : Notificador
    {
        public override string Enviar(string mensaje) => $"App: {mensaje}";
    }

    // ---------- Decorador abstracto ----------
    public abstract class NotificadorDecorator : Notificador
    {
        protected Notificador _notificador;
        public NotificadorDecorator(Notificador notificador)
        {
            _notificador = notificador;
        }
    }

    // ---------- Decoradores concretos ----------
    public class DecoradorEmail : NotificadorDecorator
    {
        public DecoradorEmail(Notificador n) : base(n) { }
        public override string Enviar(string mensaje)
            => _notificador.Enviar(mensaje) + $" | Email: {mensaje}";
    }

    public class DecoradorSms : NotificadorDecorator
    {
        public DecoradorSms(Notificador n) : base(n) { }
        public override string Enviar(string mensaje)
            => _notificador.Enviar(mensaje) + $" | SMS: {mensaje}";
    }

    // ---------- Demo ----------
    public static class Demo
    {
        public static void Ejecutar()
        {
            Console.WriteLine("=== Decorator - Ejercicio 2: Notificaciones ===");

            Notificador n = new NotificadorBase();
            n = new DecoradorEmail(n);
            n = new DecoradorSms(n);

            Console.WriteLine(n.Enviar("Tenés una alerta"));

            Console.WriteLine();
        }
    }
}
