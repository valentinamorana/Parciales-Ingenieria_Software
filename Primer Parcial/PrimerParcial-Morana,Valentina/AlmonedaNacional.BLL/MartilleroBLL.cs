using System;
using AlmonedaNacional.BE;
using AlmonedaNacional.DAL;
using AlmonedaNacional.Servicios.Seguridad;

namespace AlmonedaNacional.BLL
{
    public class MartilleroBLL
    {
        private const int    MAX_INTENTOS    = 3;
        private const int    MINUTOS_BLOQUEO = 10;
        private const string DEMO_USER       = "martillero";
        private const string DEMO_PASS       = "Admin1234";

        public Martillero Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException("Ingresá un nombre de usuario.");
            if (string.IsNullOrWhiteSpace(password))  throw new ArgumentException("Ingresá una contraseña.");

            try
            {
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
            catch (InvalidOperationException) { throw; }
            catch (ArgumentException)         { throw; }
            catch
            {
                return LoginDemo(username.Trim(), password);
            }
        }

        private static Martillero LoginDemo(string username, string password)
        {
            if (!username.Equals(DEMO_USER, StringComparison.OrdinalIgnoreCase) ||
                password != DEMO_PASS)
                throw new InvalidOperationException(
                    $"Sin conexión a BD — modo demo.\n  Usuario: {DEMO_USER}\n  Clave: {DEMO_PASS}");

            return new Martillero
            {
                Id           = 0,
                Username     = DEMO_USER,
                PasswordHash = Encriptador.HashSHA256(DEMO_PASS)
            };
        }
    }
}
