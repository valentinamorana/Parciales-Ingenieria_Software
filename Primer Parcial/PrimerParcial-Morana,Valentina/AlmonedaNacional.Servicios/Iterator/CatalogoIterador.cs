using System;
using System.Collections.Generic;
using AlmonedaNacional.Interfaces;
using AlmonedaNacional.Servicios.Composite;

namespace AlmonedaNacional.Servicios.Iterator
{
    // Patrón Iterator sobre el árbol Composite del catálogo.
    // Aplana la jerarquía en profundidad (DFS) para que el cliente
    // recorra artículos y lotes sin conocer la estructura interna.
    // NivelActual devuelve la profundidad del último nodo devuelto por Siguiente().
    public class CatalogoIterador : IIterador<IUnidadDeVenta>
    {
        private readonly List<IUnidadDeVenta> _nodos  = new List<IUnidadDeVenta>();
        private readonly List<int>            _niveles = new List<int>();
        private int _posicion;

        public CatalogoIterador(IList<IUnidadDeVenta> catalogo)
        {
            if (catalogo == null) throw new ArgumentNullException(nameof(catalogo));
            foreach (var u in catalogo)
                Aplanar(u, 0);
        }

        private void Aplanar(IUnidadDeVenta unidad, int nivel)
        {
            _nodos.Add(unidad);
            _niveles.Add(nivel);
            var hijos = unidad.ObtenerHijos();
            if (hijos != null)
                foreach (var hijo in hijos)
                    Aplanar(hijo, nivel + 1);
        }

        public bool TieneSiguiente => _posicion < _nodos.Count;

        // Nivel de profundidad del nodo devuelto por la última llamada a Siguiente().
        public int NivelActual => _posicion > 0 ? _niveles[_posicion - 1] : 0;

        public IUnidadDeVenta Siguiente()
        {
            if (!TieneSiguiente)
                throw new InvalidOperationException("El iterador llegó al final del catálogo.");
            return _nodos[_posicion++];
        }

        public void Reiniciar() => _posicion = 0;
    }
}
