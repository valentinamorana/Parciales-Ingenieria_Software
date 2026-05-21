using System.Collections.Generic;
using Interfaces;

namespace BLL
{
    // ═══════════════════════════════════════════════════════════
    //  PATRÓN TEMPLATE METHOD (variante) — AbstractBLL<T>
    // ═══════════════════════════════════════════════════════════
    // Implementa ICrud<T> delegando en _crud (el DAL concreto).
    // Los BLL concretos (UsuarioBLL, MartilleroBLL, etc.) asignan
    // _crud en su constructor y pueden sobreescribir o extender los
    // métodos heredados con lógica de negocio adicional.
    //
    // Flujo de llamada para una operación CRUD estándar:
    //   GUI → BLL concreto (hereda de AbstractBLL)
    //             → _crud.ObtenerPorId()  (AbstractDAL concreto)
    //                     → Acceso.GetInstance().Leer()  (Singleton BD)
    //
    // Al implementar ICrud<T>, el BLL presenta la misma interfaz que el DAL,
    // lo que permite que la GUI no sepa si está hablando con BLL o directamente
    // con el DAL — intercambiables en pruebas (principio DIP).
    public abstract class AbstractBLL<T> : ICrud<T> where T : IEntidad
    {
        // Referencia al DAL concreto; los subclases la asignan en su constructor.
        protected ICrud<T> _crud;

        // Delegación pura al DAL — los BLL concretos pueden agregar validaciones
        // sobreescribiendo estos métodos antes o después de llamar a base.Guardar().
        public T         ObtenerPorId(int id) => _crud.ObtenerPorId(id);
        public IList<T>  ObtenerTodos()        => _crud.ObtenerTodos();
        public void      Guardar(T entidad)    => _crud.Guardar(entidad);
        public void      Eliminar(T entidad)   => _crud.Eliminar(entidad);
    }
}
