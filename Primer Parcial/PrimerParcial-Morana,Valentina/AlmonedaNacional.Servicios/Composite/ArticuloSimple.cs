using System;
using System.Collections.Generic;

namespace AlmonedaNacional.Servicios.Composite
{
    // Hoja (Leaf) del patrón Composite
    public class ArticuloSimple : UnidadDeVentaBase
    {
        public decimal PrecioBase { get; set; }
        public string Descripcion { get; set; }

        public override decimal CalcularPrecioBase() => PrecioBase;

        public override string ObtenerDescripcion()
            => $"[Artículo] {Nombre}: {Descripcion} — ${PrecioBase:N2}";

        // Las hojas no admiten operaciones de composición
        public override void Agregar(IUnidadDeVenta unidad)
            => throw new NotSupportedException("Un artículo simple no puede contener otros artículos.");

        public override void Quitar(IUnidadDeVenta unidad)
            => throw new NotSupportedException("Un artículo simple no puede contener otros artículos.");

        public override IList<IUnidadDeVenta> ObtenerHijos()
            => new List<IUnidadDeVenta>();
    }
}
