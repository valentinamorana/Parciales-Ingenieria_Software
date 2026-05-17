using System;
using AlmonedaNacional.BE;

namespace AlmonedaNacional.Seguridad
{
    // SINGLETON — sesión única del martillero activo durante toda la ejecución.
    public sealed class SessionManager
    {
        private static SessionManager    _instancia;
        private static readonly object   _lock = new object();

        private Martillero _martillero;
        private DateTime   _inicioSesion;

        private SessionManager() { }

        public static SessionManager Instancia
        {
            get
            {
                if (_instancia == null)
                    lock (_lock)
                        if (_instancia == null)
                            _instancia = new SessionManager();
                return _instancia;
            }
        }

        public static bool IsLoggedIn => _instancia?._martillero != null;

        public Martillero Martillero
        {
            get
            {
                if (_martillero == null)
                    throw new InvalidOperationException("No hay sesión activa.");
                return _martillero;
            }
        }

        public DateTime InicioSesion => _inicioSesion;

        public static void Login(Martillero martillero)
        {
            if (martillero == null) throw new ArgumentNullException(nameof(martillero));
            lock (_lock)
            {
                Instancia._martillero   = martillero;
                Instancia._inicioSesion = DateTime.Now;
            }
        }

        public static void Logout()
        {
            lock (_lock)
            {
                if (_instancia != null)
                    _instancia._martillero = null;
            }
        }
    }
}
