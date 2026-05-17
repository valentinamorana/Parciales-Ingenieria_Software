namespace AlmonedaNacional.Servicios.Strategy
{
    // Strategy del patrón Strategy: canal de notificación intercambiable
    public interface IEstrategiaNotificacion
    {
        string NombreCanal { get; }
        void EnviarNotificacion(string destinatario, string mensaje);
    }
}
