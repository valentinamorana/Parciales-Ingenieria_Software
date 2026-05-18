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

            foreach (System.Data.DataRow f in unidades.Rows)
            {
                int     id     = (int)f["Id"];
                string  nombre = (string)f["Nombre"];
                string  desc   = f["Descripcion"] == DBNull.Value ? "" : (string)f["Descripcion"];
                decimal precio = (decimal)f["PrecioBase"];
                string  tipo   = (string)f["TipoUnidad"];

                DateTime fechaIngreso = f["FechaIngreso"] == DBNull.Value ? DateTime.MinValue : (DateTime)f["FechaIngreso"];

                if (tipo == "Articulo")
                    articulos[id] = new ArticuloSimple { Id = id, Nombre = nombre, Descripcion = desc, PrecioBase = precio, FechaIngreso = fechaIngreso };
                else
                    lotes[id]     = new LoteArticulos  { Id = id, Nombre = nombre, FechaIngreso = fechaIngreso };
            }

            var esHijo = new HashSet<int>();
            foreach (System.Data.DataRow f in relacs.Rows)
            {
                int loteId      = (int)f["LoteId"];
                int contenidoId = (int)f["ContenidoId"];
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
    }
}
