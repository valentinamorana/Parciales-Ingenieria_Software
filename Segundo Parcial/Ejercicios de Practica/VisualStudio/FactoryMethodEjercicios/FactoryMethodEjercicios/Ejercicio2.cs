using System;

// ============================================================
//  FACTORY METHOD - Ejercicio 2: Notificaciones
//  Una aplicación envía notificaciones. Cada app (Tienda o Banco)
//  decide, según el tipo pedido, si crea una notificación de
//  Email, SMS o Push. El método fábrica recibe el tipo y devuelve
//  la notificación concreta, ya marcada con su remitente.
// ============================================================
namespace FactoryMethodEjercicios.Notificaciones
{
    // ---------- Product (abstracto) ----------
    public abstract class Notificacion
    {
        protected string _canal;
        protected string _remitente;

        public void Notificar()
        {
            Console.WriteLine(string.Format("Enviando notificación por {0} desde {1}.", _canal, _remitente));
        }
    }

    // ---------- Productos concretos ----------
    public class NotificacionEmail : Notificacion
    {
        public NotificacionEmail(string remitente)
        {
            _canal = "Email";
            _remitente = remitente;
        }
    }

    public class NotificacionSms : Notificacion
    {
        public NotificacionSms(string remitente)
        {
            _canal = "SMS";
            _remitente = remitente;
        }
    }

    public class NotificacionPush : Notificacion
    {
        public NotificacionPush(string remitente)
        {
            _canal = "Push";
            _remitente = remitente;
        }
    }

    // ---------- Creator (abstracto) ----------
    public abstract class Aplicacion
    {
        // Factory Method: recibe el tipo y devuelve la notificación concreta
        public abstract Notificacion CrearNotificacion(string tipo);
    }

    // ---------- Creators concretos ----------
    public class AppTienda : Aplicacion
    {
        public override Notificacion CrearNotificacion(string tipo)
        {
            if (tipo == "email")
            {
                return new NotificacionEmail("Tienda");
            }
            else if (tipo == "sms")
            {
                return new NotificacionSms("Tienda");
            }
            else if (tipo == "push")
            {
                return new NotificacionPush("Tienda");
            }
            else
            {
                return null;
            }
        }
    }

    public class AppBanco : Aplicacion
    {
        public override Notificacion CrearNotificacion(string tipo)
        {
            if (tipo == "email")
            {
                return new NotificacionEmail("Banco");
            }
            else if (tipo == "sms")
            {
                return new NotificacionSms("Banco");
            }
            else if (tipo == "push")
            {
                return new NotificacionPush("Banco");
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
            Console.WriteLine("=== Factory Method - Ejercicio 2: Notificaciones ===");

            Aplicacion app;
            Notificacion notificacion;

            app = new AppTienda();
            notificacion = app.CrearNotificacion("email");
            notificacion.Notificar();
            notificacion = app.CrearNotificacion("push");
            notificacion.Notificar();

            app = new AppBanco();
            notificacion = app.CrearNotificacion("sms");
            notificacion.Notificar();
            notificacion = app.CrearNotificacion("email");
            notificacion.Notificar();

            Console.WriteLine();
        }
    }
}
