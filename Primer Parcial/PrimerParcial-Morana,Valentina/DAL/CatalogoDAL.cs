using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    // Retorna DataTables crudas — la construcción del árbol Composite
    // la hace CatalogoBLL (que tiene referencia a Servicios).
    // DAL no conoce Servicios.Composite: recibe únicamente tipos primitivos.
    public class CatalogoDAL
    {
        private readonly Acceso _acceso = Acceso.GetInstance();

        public DataTable ObtenerUnidades() =>
            _acceso.Leer(
                "SELECT Id, Nombre, Descripcion, PrecioBase, TipoUnidad, FechaIngreso, Estado FROM UnidadesDeVenta");

        public DataTable ObtenerRelaciones() =>
            _acceso.Leer("SELECT LoteId, ContenidoId FROM LoteContenido");

        public void ActualizarEstado(int id, string estado)
        {
            _acceso.Escribir(
                "UPDATE UnidadesDeVenta SET Estado = @estado WHERE Id = @id",
                new[]
                {
                    new SqlParameter("@estado", estado),
                    new SqlParameter("@id",     id)
                });
        }

        public void ModificarArticulo(int id, string nombre, string descripcion, decimal precioBase)
        {
            _acceso.Escribir(
                "UPDATE UnidadesDeVenta SET Nombre = @nombre, Descripcion = @desc, PrecioBase = @precio WHERE Id = @id",
                new[]
                {
                    new SqlParameter("@nombre", nombre),
                    new SqlParameter("@desc",   (object)descripcion ?? DBNull.Value),
                    new SqlParameter("@precio", precioBase),
                    new SqlParameter("@id",     id)
                });
        }

        // Persiste un artículo simple y devuelve el Id asignado por la BD.
        public int GuardarArticulo(string nombre, string descripcion, decimal precioBase, DateTime fechaIngreso)
        {
            return _acceso.EjecutarEscalar(
                @"INSERT INTO UnidadesDeVenta (Nombre, Descripcion, PrecioBase, TipoUnidad, FechaIngreso)
                  VALUES (@nombre, @desc, @precio, 'Articulo', @fecha);
                  SELECT SCOPE_IDENTITY();",
                new[]
                {
                    new SqlParameter("@nombre", nombre),
                    new SqlParameter("@desc",   (object)descripcion ?? DBNull.Value),
                    new SqlParameter("@precio", precioBase),
                    new SqlParameter("@fecha",  fechaIngreso)
                });
        }

        // Persiste un lote (cabecera + relaciones con sus hijos directos) en una transacción atómica.
        // idsHijos: Ids de las UnidadesDeVenta que ya existen en la BD.
        public int GuardarLote(string nombre, decimal precioBase, DateTime fechaIngreso, IEnumerable<int> idsHijos)
        {
            int nuevoId = 0;

            _acceso.EjecutarTransaccion((conn, tx) =>
            {
                // 1. Cabecera del lote
                using (var cmd = new SqlCommand(
                    @"INSERT INTO UnidadesDeVenta (Nombre, Descripcion, PrecioBase, TipoUnidad, FechaIngreso)
                      VALUES (@nombre, NULL, @precio, 'Lote', @fecha);
                      SELECT SCOPE_IDENTITY();", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@precio", precioBase);
                    cmd.Parameters.AddWithValue("@fecha",  fechaIngreso);
                    nuevoId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // 2. Relaciones con cada hijo directo
                foreach (int hijoId in idsHijos)
                {
                    using (var cmd = new SqlCommand(
                        "INSERT INTO LoteContenido (LoteId, ContenidoId) VALUES (@loteId, @hijoId)",
                        conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@loteId", nuevoId);
                        cmd.Parameters.AddWithValue("@hijoId", hijoId);
                        cmd.ExecuteNonQuery();
                    }
                }
            });

            return nuevoId;
        }
    }
}
