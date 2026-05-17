using System;
using System.Collections.Generic;

namespace Servicios.Composite
{
    // Hoja (Leaf) del patrón Composite
    public class ArticuloSimple : UnidadDeVentaBase
    {
        public decimal PrecioBase { get; set; }
        public string Descripcion { get; set; }

        public override decimal CalcularPrecioBase() => PrecioBase;

        public override string ObtenerDescripcion()
            => $"[Artículo] {Nombre}: {Descripcion} — ${PrecioBase:N2}";

        public override void Agregar(IUnidadDeVenta unidad) { }
        public override void Quitar(IUnidadDeVenta unidad) { }
        public override IList<IUnidadDeVenta> ObtenerHijos() => null;
    }
}
