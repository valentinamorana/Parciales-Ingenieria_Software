using System;
using System.Collections.Generic;
using Interfaces;

namespace Servicios.Composite
{
    // Componente del patrón Composite.
    // Extiende IEntidad — igual a como IPermiso : IEntity en el ejemplo de cátedra.
    public interface IUnidadDeVenta : IEntidad
    {
        string   Nombre       { get; set; }
        DateTime FechaIngreso { get; set; }

        decimal CalcularPrecioBase();
        string ObtenerDescripcion();

        void Agregar(IUnidadDeVenta unidad);
        void Quitar(IUnidadDeVenta unidad);
        IList<IUnidadDeVenta> ObtenerHijos();
    }
}
