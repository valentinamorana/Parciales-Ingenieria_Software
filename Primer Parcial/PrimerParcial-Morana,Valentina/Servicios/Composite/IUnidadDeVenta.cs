using System;
using System.Collections.Generic;
using BE;
using Interfaces;

namespace Servicios.Composite
{
    // ═══════════════════════════════════════════════════════════
    //  PATRÓN COMPOSITE — Rol: Component (RF-01 a RF-04)
    // ═══════════════════════════════════════════════════════════
    // IUnidadDeVenta es la interfaz común que comparten tanto los
    // elementos hoja (ArticuloSimple) como los nodos compuestos
    // (LoteArticulos). Al definir la misma interfaz para ambos,
    // el cliente (GUI, BLL, ReporteJornada) puede tratar una unidad
    // simple y un lote anidado de forma exactamente igual —
    // sin usar instanceof ni casteos.
    //
    // Hereda de IEntidad para participar en ICrud<T> y tener Id.
    // Equivalente al rol "Component" del GoF:
    //   Component  → IUnidadDeVenta
    //   Leaf       → ArticuloSimple
    //   Composite  → LoteArticulos
    //
    // Métodos del patrón:
    //   CalcularPrecioBase()  — operación uniforme sobre árbol (RF-03)
    //   ObtenerDescripcion()  — recorrido recursivo de la jerarquía (RF-04)
    //   Agregar / Quitar      — gestión de hijos (no-op en la hoja)
    //   ObtenerHijos          — acceso a subárbol (lista vacía en la hoja)
    public interface IUnidadDeVenta : IEntidad
    {
        string       Nombre       { get; set; }
        DateTime     FechaIngreso { get; set; }
        EstadoUnidad Estado       { get; set; }

        // Calcula el precio: en ArticuloSimple devuelve PrecioBase directamente;
        // en LoteArticulos suma recursivamente los precios de todos sus hijos.
        decimal CalcularPrecioBase();

        // Devuelve descripción textual; en LoteArticulos recorre el árbol en profundidad.
        string ObtenerDescripcion();

        // Gestión de hijos — sólo LoteArticulos hace algo útil aquí.
        // ArticuloSimple los implementa como no-op (Leaf no tiene hijos).
        void Agregar(IUnidadDeVenta unidad);
        void Quitar(IUnidadDeVenta unidad);

        // Retorna los hijos directos. En ArticuloSimple devuelve lista vacía.
        IList<IUnidadDeVenta> ObtenerHijos();
    }
}
