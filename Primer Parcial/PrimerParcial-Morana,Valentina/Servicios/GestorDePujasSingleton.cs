using System;
using System.Threading;
using BE;

namespace Servicios
{
    // ═══════════════════════════════════════════════════════════
    //  PATRÓN SINGLETON — GestorDePujasSingleton (RF-09)
    // ═══════════════════════════════════════════════════════════
    // Garantiza que exista exactamente UNA instancia de este gestor
    // durante toda la ejecución de la aplicación.
    //
    // Responsabilidad principal: serializar el acceso a la lógica de pujas.
    // Sin este lock, dos pujas simultáneas podrían pasar la validación de
    // monto al mismo tiempo y ambas quedar "aceptadas", produciendo una
    // adjudicación inválida (condición de carrera / race condition).
    //
    // Implementación Singleton thread-safe con double-checked locking:
    //   1. Primer check sin lock (fast path — la instancia ya existe).
    //   2. Lock de creación (_lockCreacion) solo si _instancia es null.
    //   3. Segundo check dentro del lock (evita que dos hilos creen la instancia a la vez).
    //   4. volatile en _instancia para que los cambios sean visibles a todos los hilos.
    //
    // EjecutarBajoLock() serializa la acción de puja con _lockPuja (distinto de _lockCreacion):
    //   - _lockCreacion: protege la creación de la instancia (una sola vez).
    //   - _lockPuja:     protege cada operación de puja (se adquiere y libera por puja).
    //
    // Si el lock no se obtiene en TimeoutMs ms, lanza PujaSimultaneaException
    // (en lugar de bloquear indefinidamente — evita deadlocks de UI).
    public sealed class GestorDePujasSingleton
    {
        private static volatile GestorDePujasSingleton _instancia;
        private static readonly object _lockCreacion = new object();

        // Lock exclusivo por operación de puja — garantiza exclusión mutua entre pujas.
        private readonly object _lockPuja = new object();

        // Timeout razonable para una app de escritorio; evita congelar la UI indefinidamente.
        private const int TimeoutMs = 3000;

        // Constructor privado: impide que cualquier código externo cree instancias.
        private GestorDePujasSingleton() { }

        // Punto de acceso global — siempre devuelve la misma instancia.
        public static GestorDePujasSingleton GetInstance()
        {
            if (_instancia == null)
            {
                lock (_lockCreacion)
                {
                    if (_instancia == null)
                        _instancia = new GestorDePujasSingleton();
                }
            }
            return _instancia;
        }

        // Ejecuta la operación de puja bajo exclusión mutua.
        // SubastaActiva.RealizarOferta() usa este método para que toda la
        // validación y registro de puja ocurra de forma atómica.
        // Si el lock no se obtiene en TimeoutMs ms → PujaSimultaneaException.
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
                // finally garantiza que el lock siempre se libere, incluso si operacion() lanza.
                if (lockAdquirido)
                    Monitor.Exit(_lockPuja);
            }
        }
    }
}
