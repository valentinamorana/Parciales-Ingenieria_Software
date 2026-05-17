using System;

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

        private GestorDePujasSingleton() { }

        public static GestorDePujasSingleton Instancia
        {
            get
            {
                lock (_lockCreacion)
                {
                    if (_instancia == null)
                        _instancia = new GestorDePujasSingleton();
                    return _instancia;
                }
            }
        }

        // Ejecuta la operación de puja bajo exclusión mutua para garantizar unicidad de transacción
        public void EjecutarBajoLock(Action operacion)
        {
            if (operacion == null) throw new ArgumentNullException(nameof(operacion));
            lock (_lockPuja)
            {
                operacion();
            }
        }
    }
}
