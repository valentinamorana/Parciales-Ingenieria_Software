namespace Servicios
{
    // ═══════════════════════════════════════════════════════════
    //  PATRÓN OBSERVER — Rol: Observer (Observador) — interfaz
    // ═══════════════════════════════════════════════════════════
    // Contrato que deben implementar todos los observadores.
    // El único observador concreto es Interesado.
    //
    // Actualizar recibe el sujeto completo (SubastaActiva) en lugar de
    // solo los datos cambiados, siguiendo la variante "push" del GoF:
    // el observador extrae lo que necesita (EstaActiva, PrecioActual, etc.)
    // sin necesidad de consultas adicionales al sujeto.
    //
    // Al recibir SubastaActiva por parámetro, el observador puede
    // distinguir si la notificación es por nueva puja (EstaActiva=true)
    // o por cierre de subasta (EstaActiva=false) — ver Interesado.Actualizar().
    public interface IObservadorSubasta
    {
        void Actualizar(SubastaActiva subasta);
    }
}
