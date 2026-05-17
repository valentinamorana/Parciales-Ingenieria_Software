using System;
using System.Security.Cryptography;
using System.Text;

namespace Seguridad
{
    public static class Encriptador
    {
        public static string HashSHA256(string texto)
        {
            using (var sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(texto));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}
