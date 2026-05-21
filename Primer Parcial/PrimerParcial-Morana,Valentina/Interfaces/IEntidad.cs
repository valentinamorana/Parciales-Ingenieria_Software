namespace Interfaces
{
    // Contrato base de identidad para todas las entidades del sistema.
    // Toda clase que participe en ICrud<T> debe poder identificarse con un Id,
    // lo que permite que AbstractDAL<T> y AbstractBLL<T> operen de forma genérica
    // sin conocer el tipo concreto. Equivalente al IEntity del ejemplo de cátedra.
    public interface IEntidad
    {
        int Id { get; set; }
    }
}
