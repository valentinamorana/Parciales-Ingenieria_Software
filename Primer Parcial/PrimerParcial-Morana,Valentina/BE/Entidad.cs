using Interfaces;

namespace BE
{
    // Misma cadena que el ejemplo: IEntidad → Entidad → entidades de negocio
    public abstract class Entidad : IEntidad
    {
        public int Id { get; set; }
    }
}
