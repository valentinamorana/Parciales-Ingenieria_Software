using System;
using System.Collections.Generic;

namespace Servicios.Composite
{
    // ═══════════════════════════════════════════════════════════
    //  PATRÓN COMPOSITE — Rol: Leaf (hoja) (RF-01)
    // ═══════════════════════════════════════════════════════════
    // ArticuloSimple es el nodo terminal del árbol Composite.
    // No puede contener otras IUnidadDeVenta, por eso:
    //   - Agregar y Quitar son no-op (no lanzan excepción para respetar
    //     la interfaz uniforme sin romper el polimorfismo del cliente).
    //   - ObtenerHijos devuelve una lista vacía (sin hijos que recorrer).
    //   - CalcularPrecioBase devuelve directamente su PrecioBase propio.
    //
    // Clave del patrón: el cliente (BLL, GUI, ReporteJornada) llama a
    // CalcularPrecioBase() sobre cualquier IUnidadDeVenta sin saber si
    // es un artículo o un lote — el árbol se recorre de forma transparente.
    public class ArticuloSimple : UnidadDeVentaBase
    {
        public decimal PrecioBase  { get; set; }
        public string  Descripcion { get; set; }

        // El precio de un artículo simple es su valor propio (no suma hijos).
        public override decimal CalcularPrecioBase() => PrecioBase;

        public override string ObtenerDescripcion()
            => $"[Artículo] {Nombre}: {Descripcion} — ${PrecioBase:N2}";

        // No-op: un artículo simple (hoja) no puede tener hijos.
        // Se implementan para satisfacer IUnidadDeVenta sin casteos en el cliente.
        public override void Agregar(IUnidadDeVenta unidad) { }
        public override void Quitar(IUnidadDeVenta unidad) { }
        public override IList<IUnidadDeVenta> ObtenerHijos() => new List<IUnidadDeVenta>();
    }
}
