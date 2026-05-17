namespace AlmonedaNacional.Servicios.Observer
{
    // Observer del patrón Observer
    public interface IObservadorSubasta
    {
        void Actualizar(string nombreUnidad, decimal precioActual, string evento);
    }
}
