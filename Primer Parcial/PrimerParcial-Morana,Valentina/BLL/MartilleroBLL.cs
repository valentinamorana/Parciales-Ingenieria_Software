using System;
using BE;
using DAL;
using Seguridad;

namespace BLL
{
    public class MartilleroBLL
    {
        private const int MAX_INTENTOS    = 3;
        private const int MINUTOS_BLOQUEO = 10;

        public Martillero Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException("Ingresá un nombre de usuario.");
            if (string.IsNullOrWhiteSpace(password))  throw new ArgumentException("Ingresá una contraseña.");

            var dal = new MartilleroDAL();
            var m   = dal.ObtenerPorUsername(username.Trim());

            if (m == null)
                throw new InvalidOperationException("Usuario no encontrado.");

            if (m.EstaBloqueado)
                throw new InvalidOperationException(
                    $"Cuenta bloqueada hasta las {m.BloqueadoHasta:HH:mm:ss}.\nVolvé a intentar en unos minutos.");

            string hash = Encriptador.HashSHA256(password);
            if (m.PasswordHash != hash)
            {
                m.IntentosFallidos++;
                if (m.IntentosFallidos >= MAX_INTENTOS)
                {
                    m.BloqueadoHasta   = DateTime.Now.AddMinutes(MINUTOS_BLOQUEO);
                    m.IntentosFallidos = 0;
                    dal.ActualizarIntentos(m);
                    throw new InvalidOperationException(
                        $"Demasiados intentos fallidos.\nCuenta bloqueada por {MINUTOS_BLOQUEO} minutos.");
                }
                dal.ActualizarIntentos(m);
                int restantes = MAX_INTENTOS - m.IntentosFallidos;
                throw new InvalidOperationException(
                    $"Contraseña incorrecta. {restantes} intento(s) restante(s).");
            }

            if (m.IntentosFallidos > 0)
            {
                m.IntentosFallidos = 0;
                m.BloqueadoHasta   = null;
                dal.ActualizarIntentos(m);
            }

            return m;
        }
    }
}
