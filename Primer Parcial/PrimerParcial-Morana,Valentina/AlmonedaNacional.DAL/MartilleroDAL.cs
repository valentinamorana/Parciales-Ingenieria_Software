using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AlmonedaNacional.BE;

namespace AlmonedaNacional.DAL
{
    public class MartilleroDAL : AbstractDAL<Martillero>
    {
        public Martillero ObtenerPorUsername(string username)
        {
            var tabla = _acceso.Leer(
                "SELECT Id, Username, PasswordHash, IntentosFallidos, BloqueadoHasta " +
                "FROM Martilleros WHERE Username = @u",
                new[] { new SqlParameter("@u", username) });

            return tabla.Rows.Count == 0 ? null : MapearFila(tabla.Rows[0]);
        }

        public void ActualizarIntentos(Martillero m)
        {
            _acceso.Escribir(
                "UPDATE Martilleros SET IntentosFallidos=@if, BloqueadoHasta=@bh WHERE Username=@u",
                new SqlParameter[]
                {
                    new SqlParameter("@if", m.IntentosFallidos),
                    new SqlParameter("@bh", (object)m.BloqueadoHasta ?? DBNull.Value),
                    new SqlParameter("@u",  m.Username)
                });
        }

        public override void Guardar(Martillero m)
        {
            _acceso.Escribir(
                @"IF EXISTS (SELECT 1 FROM Martilleros WHERE Username=@u)
                      UPDATE Martilleros SET PasswordHash=@ph, IntentosFallidos=@if, BloqueadoHasta=@bh WHERE Username=@u
                  ELSE
                      INSERT INTO Martilleros (Username, PasswordHash, IntentosFallidos, BloqueadoHasta)
                      VALUES (@u, @ph, @if, @bh)",
                new SqlParameter[]
                {
                    new SqlParameter("@u",  m.Username),
                    new SqlParameter("@ph", m.PasswordHash),
                    new SqlParameter("@if", m.IntentosFallidos),
                    new SqlParameter("@bh", (object)m.BloqueadoHasta ?? DBNull.Value)
                });
        }

        public override IList<Martillero> ObtenerTodos()
        {
            var tabla = _acceso.Leer(
                "SELECT Id, Username, PasswordHash, IntentosFallidos, BloqueadoHasta FROM Martilleros");
            var lista = new List<Martillero>();
            foreach (System.Data.DataRow f in tabla.Rows)
                lista.Add(MapearFila(f));
            return lista;
        }

        public override Martillero ObtenerPorId(int id)
        {
            var tabla = _acceso.Leer(
                "SELECT Id, Username, PasswordHash, IntentosFallidos, BloqueadoHasta FROM Martilleros WHERE Id=@id",
                new[] { new SqlParameter("@id", id) });
            return tabla.Rows.Count == 0 ? null : MapearFila(tabla.Rows[0]);
        }

        public override void Eliminar(Martillero m)
            => _acceso.Escribir("DELETE FROM Martilleros WHERE Id=@id",
                new[] { new SqlParameter("@id", m.Id) });

        private static Martillero MapearFila(System.Data.DataRow f) => new Martillero
        {
            Id               = (int)f["Id"],
            Username         = (string)f["Username"],
            PasswordHash     = (string)f["PasswordHash"],
            IntentosFallidos = (int)f["IntentosFallidos"],
            BloqueadoHasta   = f["BloqueadoHasta"] == DBNull.Value
                               ? (DateTime?)null
                               : (DateTime)f["BloqueadoHasta"]
        };
    }
}
