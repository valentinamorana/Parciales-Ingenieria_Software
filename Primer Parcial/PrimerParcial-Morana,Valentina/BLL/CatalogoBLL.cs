using System;
using System.Collections.Generic;
using DAL;
using Servicios.Composite;

namespace BLL
{
    public class CatalogoBLL
    {
        public List<IUnidadDeVenta> ObtenerCatalogo()
        {
            var dal      = new CatalogoDAL();
            var unidades = dal.ObtenerUnidades();
            var relacs   = dal.ObtenerRelaciones();

            var articulos = new Dictionary<int, ArticuloSimple>();
            var lotes     = new Dictionary<int, LoteArticulos>();

            foreach (System.Data.DataRow fila in unidades.Rows)
            {
                int     id     = (int)fila["Id"];
                string  nombre = (string)fila["Nombre"];
                string  desc   = fila["Descripcion"] == DBNull.Value ? "" : (string)fila["Descripcion"];
                decimal precio = (decimal)fila["PrecioBase"];
                string  tipo   = (string)fila["TipoUnidad"];

                DateTime fechaIngreso = fila["FechaIngreso"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["FechaIngreso"];

                if (tipo == "Articulo")
                    articulos[id] = new ArticuloSimple { Id = id, Nombre = nombre, Descripcion = desc, PrecioBase = precio, FechaIngreso = fechaIngreso };
                else
                    lotes[id]     = new LoteArticulos  { Id = id, Nombre = nombre, FechaIngreso = fechaIngreso };
            }

            var esHijo = new HashSet<int>();
            foreach (System.Data.DataRow fila in relacs.Rows)
            {
                int loteId      = (int)fila["LoteId"];
                int contenidoId = (int)fila["ContenidoId"];
                if (!lotes.ContainsKey(loteId)) continue;

                IUnidadDeVenta hijo = articulos.ContainsKey(contenidoId)
                    ? (IUnidadDeVenta)articulos[contenidoId]
                    : lotes.ContainsKey(contenidoId) ? lotes[contenidoId] : null;

                if (hijo != null) { lotes[loteId].Agregar(hijo); esHijo.Add(contenidoId); }
            }

            var catalogo = new List<IUnidadDeVenta>();
            foreach (var kv in articulos) if (!esHijo.Contains(kv.Key)) catalogo.Add(kv.Value);
            foreach (var kv in lotes)     if (!esHijo.Contains(kv.Key)) catalogo.Add(kv.Value);
            return catalogo;
        }

        // Persiste un artículo simple nuevo en la BD y actualiza su Id.
        public void GuardarArticulo(ArticuloSimple art)
        {
            if (art == null) throw new ArgumentNullException(nameof(art));
            var dal = new CatalogoDAL();
            art.Id = dal.GuardarArticulo(art.Nombre, art.Descripcion, art.PrecioBase, art.FechaIngreso);
        }

        // Persiste un lote nuevo (cabecera + relaciones) en la BD y actualiza su Id.
        // Los hijos deben estar previamente guardados en la BD (tener Id válido).
        public void GuardarLote(LoteArticulos lote)
        {
            if (lote == null) throw new ArgumentNullException(nameof(lote));
            var idsHijos = new System.Collections.Generic.List<int>();
            foreach (var hijo in lote.ObtenerHijos())
                idsHijos.Add(hijo.Id);

            var dal = new CatalogoDAL();
            lote.Id = dal.GuardarLote(lote.Nombre, lote.CalcularPrecioBase(), lote.FechaIngreso, idsHijos);
        }
    }
}
