using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class SubastaDAL : AbstractDAL<ResultadoSubasta>
    {
        public override void Guardar(ResultadoSubasta resultado)
        {
            resultado.Id = _acceso.EjecutarEscalar(InsertSql, BuildParametros(resultado));
        }

        public void GuardarEnTransaccion(ResultadoSubasta resultado,
                                         SqlConnection conn, SqlTransaction tx)
        {
            resultado.Id = _acceso.EjecutarEscalarEnTransaccion(InsertSql, BuildParametros(resultado), conn, tx);
        }

        private static readonly string InsertSql =
            @"INSERT INTO Subastas (NombreUnidadVenta, PrecioBase, PrecioFinal, NombreGanador, EmailGanador, FechaHora)
              VALUES (@nombre, @base, @final, @ganador, @email, @fecha);
              SELECT SCOPE_IDENTITY();";

        private static SqlParameter[] BuildParametros(ResultadoSubasta r) => new[]
        {
            new SqlParameter("@nombre",  r.NombreUnidadVenta),
            new SqlParameter("@base",    r.PrecioBase),
            new SqlParameter("@final",   r.PrecioFinal),
            new SqlParameter("@ganador", r.NombreGanador),
            new SqlParameter("@email",   r.EmailGanador),
            new SqlParameter("@fecha",   r.FechaHora)
        };

        public override IList<ResultadoSubasta> ObtenerTodos()
        {
            var tabla = _acceso.Leer(
                "SELECT Id, NombreUnidadVenta, PrecioBase, PrecioFinal, NombreGanador, EmailGanador, FechaHora " +
                "FROM Subastas ORDER BY FechaHora DESC");

            var lista = new List<ResultadoSubasta>();
            foreach (System.Data.DataRow fila in tabla.Rows)
            {
                lista.Add(new ResultadoSubasta
                {
                    Id                = (int)fila["Id"],
                    NombreUnidadVenta = (string)fila["NombreUnidadVenta"],
                    PrecioBase        = (decimal)fila["PrecioBase"],
                    PrecioFinal       = (decimal)fila["PrecioFinal"],
                    NombreGanador     = (string)fila["NombreGanador"],
                    EmailGanador      = (string)fila["EmailGanador"],
                    FechaHora         = (DateTime)fila["FechaHora"]
                });
            }
            return lista;
        }

        public override ResultadoSubasta ObtenerPorId(int id)
        {
            var tabla = _acceso.Leer(
                "SELECT Id, NombreUnidadVenta, PrecioBase, PrecioFinal, NombreGanador, EmailGanador, FechaHora " +
                "FROM Subastas WHERE Id = @id",
                new[] { new SqlParameter("@id", id) });

            if (tabla.Rows.Count == 0) return null;
            var fila = tabla.Rows[0];
            return new ResultadoSubasta
            {
                Id                = (int)fila["Id"],
                NombreUnidadVenta = (string)fila["NombreUnidadVenta"],
                PrecioBase        = (decimal)fila["PrecioBase"],
                PrecioFinal       = (decimal)fila["PrecioFinal"],
                NombreGanador     = (string)fila["NombreGanador"],
                EmailGanador      = (string)fila["EmailGanador"],
                FechaHora         = (DateTime)fila["FechaHora"]
            };
        }

        public override void Eliminar(ResultadoSubasta entidad)
        {
            _acceso.Escribir("DELETE FROM Subastas WHERE Id = @id",
                new[] { new SqlParameter("@id", entidad.Id) });
        }
    }
}
