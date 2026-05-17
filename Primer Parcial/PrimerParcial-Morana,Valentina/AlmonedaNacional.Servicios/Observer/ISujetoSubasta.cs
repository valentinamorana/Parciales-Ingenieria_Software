namespace AlmonedaNacional.Servicios.Observer
{
    // Sujeto del patrón Observer
    public interface ISujetoSubasta
    {
        void Suscribir(IObservadorSubasta observador);    // RF-05
        void Desuscribir(IObservadorSubasta observador);  // RF-08
        void Notificar(string evento);                    // RF-06 / RF-07
    }
}
