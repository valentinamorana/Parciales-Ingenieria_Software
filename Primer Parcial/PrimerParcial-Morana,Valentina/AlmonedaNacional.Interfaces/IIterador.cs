namespace AlmonedaNacional.Interfaces
{
    // Patrón Iterator — contrato genérico para recorrer una colección
    // sin exponer su estructura interna.
    public interface IIterador<T>
    {
        bool TieneSiguiente { get; }
        T    Siguiente();
        void Reiniciar();
    }
}
