using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AlmonedaNacional.BE;

namespace AlmonedaNacional.DAL
{
    public class SubastaDAL : AbstractDAL<ResultadoSubasta>
    {
        // Persiste el resultado final de la subasta (RF: producto, precio final, ganador, fecha/hora)
        public override void Guardar(ResultadoSubasta resultado)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"INSERT INTO Subastas (NombreUnidadVenta, PrecioBase, PrecioFinal, NombreGanador, EmailGanador, FechaHora)
                      VALUES (@nombre, @base, @final, @ganador, @email, @fecha);
                      SELECT SCOPE_IDENTITY();", conn);

                cmd.Parameters.AddWithValue("@nombre",  resultado.NombreUnidadVenta);
                cmd.Parameters.AddWithValue("@base",    resultado.PrecioBase);
                cmd.Parameters.AddWithValue("@final",   resultado.PrecioFinal);
                cmd.Parameters.AddWithValue("@ganador", resultado.NombreGanador);
                cmd.Parameters.AddWithValue("@email",   resultado.EmailGanador);
                cmd.Parameters.AddWithValue("@fecha",   resultado.FechaHora);

                resultado.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // RF-13: reporte consolidado de todas las subastas
        public override IList<ResultadoSubasta> ObtenerTodos()
        {
            var lista = new List<ResultadoSubasta>();
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"SELECT Id, NombreUnidadVenta, PrecioBase, PrecioFinal, NombreGanador, EmailGanador, FechaHora
                      FROM Subastas
                      ORDER BY FechaHora DESC", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new ResultadoSubasta
                        {
                            Id                = reader.GetInt32(0),
                            NombreUnidadVenta = reader.GetString(1),
                            PrecioBase        = reader.GetDecimal(2),
                            PrecioFinal       = reader.GetDecimal(3),
                            NombreGanador     = reader.GetString(4),
                            EmailGanador      = reader.GetString(5),
                            FechaHora         = reader.GetDateTime(6)
                        });
                    }
                }
            }
            return lista;
        }

        public override ResultadoSubasta ObtenerPorId(int id)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"SELECT Id, NombreUnidadVenta, PrecioBase, PrecioFinal, NombreGanador, EmailGanador, FechaHora
                      FROM Subastas WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new ResultadoSubasta
                        {
                            Id                = reader.GetInt32(0),
                            NombreUnidadVenta = reader.GetString(1),
                            PrecioBase        = reader.GetDecimal(2),
                            PrecioFinal       = reader.GetDecimal(3),
                            NombreGanador     = reader.GetString(4),
                            EmailGanador      = reader.GetString(5),
                            FechaHora         = reader.GetDateTime(6)
                        };
                    }
                    return null;
                }
            }
        }

        public override void Eliminar(ResultadoSubasta entidad)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Subastas WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", entidad.Id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
