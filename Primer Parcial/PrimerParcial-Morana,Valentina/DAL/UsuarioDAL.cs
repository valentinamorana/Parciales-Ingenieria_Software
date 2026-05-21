using System.Collections.Generic;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class UsuarioDAL : AbstractDAL<Usuario>
    {
        public override void Guardar(Usuario usuario)
        {
            if (usuario.Id == 0)
            {
                SqlParameter[] p =
                {
                    new SqlParameter("@nombre", usuario.Nombre),
                    new SqlParameter("@email",  usuario.Email)
                };
                usuario.Id = _acceso.EjecutarEscalar(
                    "INSERT INTO Usuarios (Nombre, Email) VALUES (@nombre, @email); SELECT SCOPE_IDENTITY();", p);
            }
            else
            {
                SqlParameter[] p =
                {
                    new SqlParameter("@nombre", usuario.Nombre),
                    new SqlParameter("@email",  usuario.Email),
                    new SqlParameter("@id",     usuario.Id)
                };
                _acceso.Escribir("UPDATE Usuarios SET Nombre = @nombre, Email = @email WHERE Id = @id", p);
            }
        }

        public override IList<Usuario> ObtenerTodos()
        {
            var tabla = _acceso.Leer("SELECT Id, Nombre, Email FROM Usuarios ORDER BY Nombre");
            var lista = new List<Usuario>();
            foreach (System.Data.DataRow fila in tabla.Rows)
                lista.Add(MapearFila(fila));
            return lista;
        }

        public override Usuario ObtenerPorId(int id)
        {
            var tabla = _acceso.Leer("SELECT Id, Nombre, Email FROM Usuarios WHERE Id = @id",
                new[] { new SqlParameter("@id", id) });

            return tabla.Rows.Count == 0 ? null : MapearFila(tabla.Rows[0]);
        }

        private static Usuario MapearFila(System.Data.DataRow fila) => new Usuario
        {
            Id     = (int)fila["Id"],
            Nombre = (string)fila["Nombre"],
            Email  = (string)fila["Email"]
        };

        public override void Eliminar(Usuario entidad)
        {
            _acceso.Escribir("DELETE FROM Usuarios WHERE Id = @id",
                new[] { new SqlParameter("@id", entidad.Id) });
        }

        public System.Data.DataTable ObtenerConStats()
        {
            return _acceso.Leer(@"
                SELECT
                    u.Id, u.Nombre, u.Email, u.FechaAlta,
                    ISNULL((SELECT COUNT(*) FROM Pujas   p  WHERE p.NombreUsuario  = u.Nombre), 0) AS CantPujas,
                    ISNULL((SELECT COUNT(*) FROM Subastas s  WHERE s.EmailGanador   = u.Email),  0) AS CantGanadas,
                    ISNULL((SELECT SUM(s2.PrecioFinal) FROM Subastas s2 WHERE s2.EmailGanador = u.Email), 0) AS MontoGanado,
                    (SELECT MAX(p2.FechaHora) FROM Pujas p2 WHERE p2.NombreUsuario = u.Nombre) AS UltimaActividad
                FROM Usuarios u
                ORDER BY u.Nombre");
        }

        public System.Data.DataRow ObtenerResumenKPI()
        {
            return _acceso.Leer(@"
                SELECT
                    (SELECT COUNT(*) FROM Usuarios) AS Total,
                    ISNULL((SELECT COUNT(DISTINCT p.NombreUsuario) FROM Pujas p), 0) AS Participaron,
                    ISNULL((SELECT COUNT(DISTINCT s.EmailGanador) FROM Subastas s
                            WHERE s.EmailGanador IN (SELECT Email FROM Usuarios)), 0) AS Ganadores,
                    ISNULL((SELECT SUM(PrecioFinal) FROM Subastas), 0) AS MontoTotal")
                .Rows[0];
        }
    }
}
