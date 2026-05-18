using System;
using System.Collections.Generic;

namespace Servicios.Composite
{
    // Clase abstracta del Composite.
    // Extiende ServiceEntity e implementa IUnidadDeVenta —
    // igual a como PermisoCompuesto : ServiceEntity, IPermiso en el ejemplo de cátedra.
    public abstract class UnidadDeVentaBase : ServiceEntity, IUnidadDeVenta
    {
        public string   Nombre       { get; set; }
        public DateTime FechaIngreso { get; set; }

        public abstract decimal CalcularPrecioBase();
        public abstract string ObtenerDescripcion();
        public abstract void Agregar(IUnidadDeVenta unidad);
        public abstract void Quitar(IUnidadDeVenta unidad);
        public abstract IList<IUnidadDeVenta> ObtenerHijos();

        public override string ToString() => Nombre;
    }
}
