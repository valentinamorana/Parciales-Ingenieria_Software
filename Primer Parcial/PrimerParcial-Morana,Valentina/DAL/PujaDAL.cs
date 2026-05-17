using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class PujaDAL : AbstractDAL<Puja>
    {
        // Inserta la puja y asigna su Id
        public override void Guardar(Puja puja)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@idSubasta",     puja.IdSubasta),
                new SqlParameter("@nombreUsuario", puja.NombreUsuario),
                new SqlParameter("@monto",         puja.Monto),
                new SqlParameter("@fechaHora",     puja.FechaHora),
                new SqlParameter("@estado",        puja.Estado.ToString()),
                new SqlParameter("@motivo",        (object)puja.MotivoRechazo ?? DBNull.Value)
            };

            puja.Id = _acceso.EjecutarEscalar(
                @"INSERT INTO Pujas (SubastaId, NombreUsuario, Monto, FechaHora, Estado, MotivoRechazo)
                  VALUES (@idSubasta, @nombreUsuario, @monto, @fechaHora, @estado, @motivo);
                  SELECT SCOPE_IDENTITY();", p);
        }

        // Todas las pujas de una subasta (aceptadas + rechazadas)
        public IList<Puja> ObtenerPorSubasta(int idSubasta)
        {
            var tabla = _acceso.Leer(
                "SELECT Id, SubastaId, NombreUsuario, Monto, FechaHora, Estado, MotivoRechazo " +
                "FROM Pujas WHERE SubastaId = @id ORDER BY FechaHora",
                new[] { new SqlParameter("@id", idSubasta) });

            var lista = new List<Puja>();
            foreach (System.Data.DataRow fila in tabla.Rows)
                lista.Add(MapearFila(fila));
            return lista;
        }

        public override IList<Puja> ObtenerTodos()
        {
            var tabla = _acceso.Leer(
                "SELECT Id, SubastaId, NombreUsuario, Monto, FechaHora, Estado, MotivoRechazo " +
                "FROM Pujas ORDER BY FechaHora DESC");

            var lista = new List<Puja>();
            foreach (System.Data.DataRow fila in tabla.Rows)
                lista.Add(MapearFila(fila));
            return lista;
        }

        public override Puja ObtenerPorId(int id)
        {
            var tabla = _acceso.Leer(
                "SELECT Id, SubastaId, NombreUsuario, Monto, FechaHora, Estado, MotivoRechazo " +
                "FROM Pujas WHERE Id = @id",
                new[] { new SqlParameter("@id", id) });

            return tabla.Rows.Count == 0 ? null : MapearFila(tabla.Rows[0]);
        }

        public override void Eliminar(Puja entidad)
        {
            _acceso.Escribir("DELETE FROM Pujas WHERE Id = @id",
                new[] { new SqlParameter("@id", entidad.Id) });
        }

        private static Puja MapearFila(System.Data.DataRow fila) => new Puja
        {
            Id            = (int)fila["Id"],
            IdSubasta     = (int)fila["SubastaId"],
            NombreUsuario = (string)fila["NombreUsuario"],
            Monto         = (decimal)fila["Monto"],
            FechaHora     = (DateTime)fila["FechaHora"],
            Estado        = (EstadoPuja)Enum.Parse(typeof(EstadoPuja), (string)fila["Estado"]),
            MotivoRechazo = fila["MotivoRechazo"] == DBNull.Value ? null : (string)fila["MotivoRechazo"]
        };
    }
}
