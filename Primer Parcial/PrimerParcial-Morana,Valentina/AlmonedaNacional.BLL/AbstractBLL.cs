using System.Collections.Generic;
using AlmonedaNacional.Interfaces;

namespace AlmonedaNacional.BLL
{
    // Igual al AbstractBLL del ejemplo de cátedra:
    // implementa ICrud<T> y delega en _crud (el DAL concreto).
    public abstract class AbstractBLL<T> : ICrud<T> where T : IEntidad
    {
        protected ICrud<T> _crud;

        public T ObtenerPorId(int id)        => _crud.ObtenerPorId(id);
        public IList<T> ObtenerTodos()        => _crud.ObtenerTodos();
        public void Guardar(T entidad)        => _crud.Guardar(entidad);
        public void Eliminar(T entidad)       => _crud.Eliminar(entidad);
    }
}
