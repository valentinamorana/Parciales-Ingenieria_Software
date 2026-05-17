using System.Collections.Generic;

namespace AlmonedaNacional.Interfaces
{
    // Contrato de persistencia genérico — igual al patrón del ejemplo de cátedra
    public interface ICrud<T> where T : IEntidad
    {
        T ObtenerPorId(int id);
        IList<T> ObtenerTodos();
        void Guardar(T entidad);
        void Eliminar(T entidad);
    }
}
