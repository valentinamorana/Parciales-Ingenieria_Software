using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios.Composite
{
    // ═══════════════════════════════════════════════════════════
    //  PATRÓN COMPOSITE — Rol: Composite (nodo con hijos) (RF-02)
    // ═══════════════════════════════════════════════════════════
    // LoteArticulos es el nodo interno del árbol. Puede contener
    // ArticuloSimple y/u otros LoteArticulos (anidamiento sin límite de profundidad).
    //
    // _contenido almacena los hijos directos. Las operaciones que
    // LoteArticulos sobrescribe con comportamiento real son:
    //   - Agregar / Quitar: modifican _contenido con validaciones.
    //   - ObtenerHijos: devuelve una copia defensiva (el llamador no puede mutar _contenido).
    //   - CalcularPrecioBase: itera _contenido llamando a CalcularPrecioBase() en cada hijo.
    //     Si un hijo es otro LoteArticulos, éste a su vez recorre sus propios hijos —
    //     la recursión termina cuando se llega a hojas ArticuloSimple (RF-03).
    //   - ObtenerDescripcion: recorrido en profundidad, construye el árbol como texto (RF-04).
    //
    // La clave del patrón: ni CalcularPrecioBase ni ObtenerDescripcion saben si
    // sus hijos son simples o compuestos — llaman a la interfaz IUnidadDeVenta y
    // el polimorfismo resuelve el tipo en tiempo de ejecución.
    public class LoteArticulos : UnidadDeVentaBase
    {
        // Lista privada de hijos directos; se puebla desde BD vía CatalogoBLL o en tiempo de creación.
        private readonly IList<IUnidadDeVenta> _contenido;

        public LoteArticulos()
        {
            _contenido = new List<IUnidadDeVenta>();
        }

        // RF-03: recorre recursivamente todos los hijos sumando sus precios.
        // Si _contenido contiene otro LoteArticulos, éste a su vez suma sus propios hijos.
        public override decimal CalcularPrecioBase()
        {
            decimal total = 0;
            foreach (var item in _contenido)
                total += item.CalcularPrecioBase();
            return total;
        }

        // RF-04: árbol de texto con sangría; el recorrido es en profundidad.
        // Cada hijo llama a su propio ObtenerDescripcion(), que si es otro Lote
        // produce sus propias líneas con └─, logrando el efecto visual de árbol.
        public override string ObtenerDescripcion()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"[Lote] {Nombre} — Total: ${CalcularPrecioBase():N2}");
            foreach (var item in _contenido)
                sb.AppendLine($"  └─ {item.ObtenerDescripcion()}");
            return sb.ToString().TrimEnd();
        }

        // Agrega un hijo. Lanza si el hijo ya está para evitar referencias duplicadas.
        public override void Agregar(IUnidadDeVenta unidad)
        {
            if (unidad == null) throw new ArgumentNullException(nameof(unidad));
            if (_contenido.Contains(unidad))
                throw new InvalidOperationException($"'{unidad.Nombre}' ya forma parte de este lote.");
            _contenido.Add(unidad);
        }

        // Quita un hijo. Lanza si el hijo no pertenece al lote.
        public override void Quitar(IUnidadDeVenta unidad)
        {
            if (unidad == null) throw new ArgumentNullException(nameof(unidad));
            if (!_contenido.Contains(unidad))
                throw new InvalidOperationException($"'{unidad.Nombre}' no forma parte de este lote.");
            _contenido.Remove(unidad);
        }

        // Devuelve copia defensiva de _contenido para que el llamador no modifique la lista interna.
        public override IList<IUnidadDeVenta> ObtenerHijos()
            => new List<IUnidadDeVenta>(_contenido);
    }
}
