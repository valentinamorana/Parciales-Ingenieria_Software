using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios.Composite
{
    // Compuesto (Composite) del patrón Composite
    // Puede contener ArticuloSimple y/u otros LoteArticulos sin límite de profundidad (RF-02)
    public class LoteArticulos : UnidadDeVentaBase
    {
        private readonly IList<IUnidadDeVenta> _contenido;

        public LoteArticulos()
        {
            _contenido = new List<IUnidadDeVenta>();
        }

        // RF-03: calcula el precio base sumando recursivamente todos sus hijos
        public override decimal CalcularPrecioBase()
        {
            decimal total = 0;
            foreach (var item in _contenido)
                total += item.CalcularPrecioBase();
            return total;
        }

        // RF-04: devuelve nombre + desglose completo del contenido
        public override string ObtenerDescripcion()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"[Lote] {Nombre} — Total: ${CalcularPrecioBase():N2}");
            foreach (var item in _contenido)
                sb.AppendLine($"  └─ {item.ObtenerDescripcion()}");
            return sb.ToString().TrimEnd();
        }

        public override void Agregar(IUnidadDeVenta unidad)
        {
            if (unidad == null) throw new ArgumentNullException(nameof(unidad));
            if (_contenido.Contains(unidad))
                throw new InvalidOperationException($"'{unidad.Nombre}' ya forma parte de este lote.");
            _contenido.Add(unidad);
        }

        public override void Quitar(IUnidadDeVenta unidad)
        {
            if (unidad == null) throw new ArgumentNullException(nameof(unidad));
            if (!_contenido.Contains(unidad))
                throw new InvalidOperationException($"'{unidad.Nombre}' no forma parte de este lote.");
            _contenido.Remove(unidad);
        }

        public override IList<IUnidadDeVenta> ObtenerHijos()
            => new List<IUnidadDeVenta>(_contenido);
    }
}
