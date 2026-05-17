using System.Collections.Generic;
using AlmonedaNacional.BE;
using AlmonedaNacional.Interfaces;

namespace AlmonedaNacional.DAL
{
    // Igual al AbstractDAL del ejemplo: implementa ICrud<T> y expone ConnectionString.
    public abstract class AbstractDAL<T> : ICrud<T> where T : Entidad
    {
        protected string ConnectionString => Conexion.ConnectionString;

        public abstract void Guardar(T entidad);
        public abstract IList<T> ObtenerTodos();
        public abstract T ObtenerPorId(int id);
        public abstract void Eliminar(T entidad);
    }
}
