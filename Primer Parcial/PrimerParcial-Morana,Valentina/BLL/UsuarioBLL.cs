using System;
using BE;
using DAL;

namespace BLL
{
    // Igual al UsuarioBLL del ejemplo: extiende AbstractBLL<T>
    // y asigna _crud = new UsuarioDAL() en el constructor.
    public class UsuarioBLL : AbstractBLL<Usuario>
    {
        public UsuarioBLL()
        {
            _crud = new UsuarioDAL();
        }

        public void Registrar(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));
            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                throw new ArgumentException("El nombre del usuario no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(usuario.Email))
                throw new ArgumentException("El email del usuario no puede estar vacío.");

            _crud.Guardar(usuario);
        }
    }
}
