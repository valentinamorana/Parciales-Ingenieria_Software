using System;
using System.Collections.Generic;
using BE;

namespace Servicios.Composite
{
    // ═══════════════════════════════════════════════════════════
    //  PATRÓN COMPOSITE — Rol: clase base abstracta del Component
    // ═══════════════════════════════════════════════════════════
    // Centraliza los atributos comunes (Nombre, FechaIngreso, Estado)
    // para que no se dupliquen en ArticuloSimple ni en LoteArticulos.
    // No implementa las operaciones del Composite — las declara abstractas
    // para que cada subclase decida su comportamiento:
    //   - ArticuloSimple: CalcularPrecioBase devuelve su propio precio; Agregar/Quitar son no-op.
    //   - LoteArticulos:  CalcularPrecioBase suma recursivamente; Agregar/Quitar modifican _contenido.
    //
    // Hereda de ServiceEntity (que implementa IEntidad con la propiedad Id),
    // igual a como PermisoBase : ServiceEntity, IPermiso en el ejemplo de cátedra.
    public abstract class UnidadDeVentaBase : ServiceEntity, IUnidadDeVenta
    {
        public string       Nombre       { get; set; }
        public DateTime     FechaIngreso { get; set; }

        // Estado inicial = Disponible. El BLL llama a ActualizarEstado cuando
        // la unidad pasa a EnSubasta, Adjudicado, Desierta o Retirado.
        public EstadoUnidad Estado       { get; set; } = EstadoUnidad.Disponible;

        public abstract decimal                CalcularPrecioBase();
        public abstract string                 ObtenerDescripcion();
        public abstract void                   Agregar(IUnidadDeVenta unidad);
        public abstract void                   Quitar(IUnidadDeVenta unidad);
        public abstract IList<IUnidadDeVenta>  ObtenerHijos();

        // ToString devuelve el nombre para que TreeView y ComboBox lo muestren sin format extra.
        public override string ToString() => Nombre;
    }
}
