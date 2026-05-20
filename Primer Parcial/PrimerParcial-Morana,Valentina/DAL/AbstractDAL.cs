using System.Collections.Generic;
using BE;
using Interfaces;

namespace DAL
{
    // Igual al AbstractDAL del ejemplo: implementa ICrud<T>.
    // Todos los DAL concretos acceden a la BD a través del Singleton Acceso.
    public abstract class AbstractDAL<T> : ICrud<T> where T : Entidad
    {
        protected readonly Acceso _acceso = Acceso.GetInstance();

        public abstract void Guardar(T entidad);
        public abstract IList<T> ObtenerTodos();
        public abstract T ObtenerPorId(int id);
        public abstract void Eliminar(T entidad);
    }
}
