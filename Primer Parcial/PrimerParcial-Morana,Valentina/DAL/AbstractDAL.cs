using System.Collections.Generic;
using BE;
using Interfaces;

namespace DAL
{
    // ═══════════════════════════════════════════════════════════
    //  PATRÓN TEMPLATE METHOD (variante) — AbstractDAL<T>
    // ═══════════════════════════════════════════════════════════
    // Implementa ICrud<T> y deja los 4 métodos abstractos para que
    // cada DAL concreto (UsuarioDAL, MartilleroDAL, CatalogoDAL, etc.)
    // proporcione el SQL específico de su tabla.
    //
    // Beneficio clave: los DAL concretos heredan _acceso = Acceso.GetInstance()
    // sin tener que llamar GetInstance() ellos mismos, lo que asegura que
    // todos usen el mismo Singleton de BD sin acoplarse a su construcción.
    //
    // La restricción "where T : IEntidad" obliga a que T tenga Id,
    // lo que permite que futuros DAL genéricos operen sobre el Id sin casteos.
    public abstract class AbstractDAL<T> : ICrud<T> where T : IEntidad
    {
        // Referencia al Singleton de acceso a BD — disponible para todos los DAL concretos.
        protected readonly Acceso _acceso = Acceso.GetInstance();

        // Los DAL concretos implementan estos métodos con el SQL de su entidad.
        public abstract void     Guardar(T entidad);
        public abstract IList<T> ObtenerTodos();
        public abstract T        ObtenerPorId(int id);
        public abstract void     Eliminar(T entidad);
    }
}
