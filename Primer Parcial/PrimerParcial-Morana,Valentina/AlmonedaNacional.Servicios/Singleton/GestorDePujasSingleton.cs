using System;
using System.Threading;
using AlmonedaNacional.BE;

namespace AlmonedaNacional.Servicios.Singleton
{
    // Patrón Singleton con doble lock (thread-safe)
    // Garantiza un único punto de control para procesar pujas (RF-09)
    public class GestorDePujasSingleton
    {
        private static GestorDePujasSingleton _instancia;
        private static readonly object _lockCreacion = new object();

        // Lock exclusivo para procesar una puja a la vez — evita adjudicaciones simultáneas
        private readonly object _lockPuja = new object();

        // Tiempo máximo de espera antes de lanzar PujaSimultaneaException (ms)
        private const int TimeoutMs = 3000;

        private GestorDePujasSingleton() { }

        public static GestorDePujasSingleton Instancia
        {
            get
            {
                lock (_lockCreacion)
                {
                    if (_instancia == null)
                        _instancia = new GestorDePujasSingleton();
                }
                return _instancia;
            }
        }

        // Ejecuta la operación de puja bajo exclusión mutua.
        // Si el lock no está disponible en TimeoutMs, lanza PujaSimultaneaException.
        public void EjecutarBajoLock(Action operacion)
        {
            if (operacion == null) throw new ArgumentNullException(nameof(operacion));

            bool lockAdquirido = false;
            try
            {
                Monitor.TryEnter(_lockPuja, TimeoutMs, ref lockAdquirido);
                if (!lockAdquirido)
                    throw new PujaSimultaneaException();
                operacion();
            }
            finally
            {
                if (lockAdquirido)
                    Monitor.Exit(_lockPuja);
            }
        }
    }
}
