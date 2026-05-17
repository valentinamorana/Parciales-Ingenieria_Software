using Interfaces;

namespace Servicios
{
    // Idéntico al ServiceEntity del ejemplo de cátedra.
    // Base para objetos de la capa de Servicios que necesitan identidad pero no son BE.
    public class ServiceEntity : IEntidad
    {
        public int Id { get; set; }
    }
}
