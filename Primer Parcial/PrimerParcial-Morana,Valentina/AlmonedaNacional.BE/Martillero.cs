using System;

namespace AlmonedaNacional.BE
{
    public class Martillero : Entidad
    {
        public string    Username         { get; set; }
        public string    PasswordHash     { get; set; }
        public int       IntentosFallidos { get; set; }
        public DateTime? BloqueadoHasta   { get; set; }

        public bool EstaBloqueado =>
            BloqueadoHasta.HasValue && DateTime.Now < BloqueadoHasta.Value;
    }
}
