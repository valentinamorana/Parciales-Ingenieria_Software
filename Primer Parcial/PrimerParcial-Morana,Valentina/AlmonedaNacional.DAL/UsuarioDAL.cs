using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AlmonedaNacional.BE;

namespace AlmonedaNacional.DAL
{
    public class UsuarioDAL : AbstractDAL<Usuario>
    {
        public override void Guardar(Usuario usuario)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                if (usuario.Id == 0)
                {
                    var cmd = new SqlCommand(
                        @"INSERT INTO Usuarios (Nombre, Email) VALUES (@nombre, @email);
                          SELECT SCOPE_IDENTITY();", conn);
                    cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@email",  usuario.Email);
                    usuario.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
                else
                {
                    var cmd = new SqlCommand(
                        "UPDATE Usuarios SET Nombre = @nombre, Email = @email WHERE Id = @id", conn);
                    cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@email",  usuario.Email);
                    cmd.Parameters.AddWithValue("@id",     usuario.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public override IList<Usuario> ObtenerTodos()
        {
            var lista = new List<Usuario>();
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Id, Nombre, Email FROM Usuarios ORDER BY Nombre", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        lista.Add(new Usuario
                        {
                            Id     = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Email  = reader.GetString(2)
                        });
                }
            }
            return lista;
        }

        public override Usuario ObtenerPorId(int id)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Id, Nombre, Email FROM Usuarios WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return new Usuario
                        {
                            Id     = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Email  = reader.GetString(2)
                        };
                    return null;
                }
            }
        }

        public override void Eliminar(Usuario entidad)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Usuarios WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", entidad.Id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
