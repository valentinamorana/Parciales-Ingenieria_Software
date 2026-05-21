using System.Collections.Generic;

namespace Interfaces
{
    // Contrato de persistencia genérico — igual al ICrud del ejemplo de cátedra.
    // Define las 4 operaciones básicas de acceso a datos para cualquier entidad T.
    //
    // La restricción "where T : IEntidad" garantiza que T siempre tenga Id,
    // lo que permite a AbstractDAL<T> y AbstractBLL<T> operar sin conocer el tipo real.
    //
    // Flujo de dependencias:
    //   ICrud<T>
    //     └── implementado por AbstractDAL<T>  (acceso real a SQL Server)
    //     └── implementado por AbstractBLL<T>  (delega en el DAL — ver AbstractBLL)
    public interface ICrud<T> where T : IEntidad
    {
        T         ObtenerPorId(int id);
        IList<T>  ObtenerTodos();
        void      Guardar(T entidad);
        void      Eliminar(T entidad);
    }
}
