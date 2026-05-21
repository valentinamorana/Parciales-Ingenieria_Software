using System;
using BE;

namespace Seguridad
{
    // ═══════════════════════════════════════════════════════════
    //  PATRÓN SINGLETON — SessionManager
    // ═══════════════════════════════════════════════════════════
    // Gestiona la sesión del martillero autenticado. Al ser Singleton,
    // cualquier parte del sistema (GUI, BLL, DAL de auditoría) puede
    // consultar quién está logueado sin recibir el objeto por parámetro.
    //
    // Thread-safe con double-checked locking (igual que GestorDePujasSingleton).
    // 'sealed' impide herencia que podría crear instancias adicionales.
    //
    // Estado de sesión:
    //   - Sin instancia creada:               IsLoggedIn = false  (operador ?. devuelve null)
    //   - Instancia creada, _martillero null: IsLoggedIn = false  (después de Logout)
    //   - Instancia creada, _martillero set:  IsLoggedIn = true   (después de Login)
    //
    // Login/Logout son estáticos para poder llamarlos sin tener la instancia previamente.
    // Internamente usan GetInstance() para obtener/crear la instancia antes de mutar el estado.
    public sealed class SessionManager
    {
        private static volatile SessionManager _instancia;
        private static readonly object   _lock = new object();

        private Martillero _martillero;
        private DateTime   _inicioSesion;

        private SessionManager() { }

        public static SessionManager GetInstance()
        {
            if (_instancia == null)
                lock (_lock)
                    if (_instancia == null)
                        _instancia = new SessionManager();
            return _instancia;
        }

        // Propiedad estática — se puede consultar sin necesitar la instancia directamente.
        // _instancia?._martillero: si no hay instancia aún, devuelve null → false.
        public static bool IsLoggedIn => _instancia?._martillero != null;

        // Lanza si se intenta acceder al martillero sin sesión activa,
        // en lugar de devolver null y causar NullReferenceException más adelante.
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

        // Abre sesión: guarda el martillero y la hora de inicio.
        // Usa lock para que Login no corra en paralelo con Logout.
        public static void Login(Martillero martillero)
        {
            if (martillero == null) throw new ArgumentNullException(nameof(martillero));
            lock (_lock)
            {
                GetInstance()._martillero   = martillero;
                GetInstance()._inicioSesion = DateTime.Now;
            }
        }

        // Cierra sesión poniendo _martillero = null.
        // No destruye la instancia (Singleton no se destruye) — solo limpia el estado.
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
