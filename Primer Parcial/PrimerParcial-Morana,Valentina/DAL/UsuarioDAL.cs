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

    }
}
