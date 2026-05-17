using System;

namespace BE
{
    // Registro de cada oferta procesada durante una subasta.
    // Estado indica si fue aceptada (superó el precio vigente) o rechazada.
    public class Puja : Entidad
    {
        public int        IdSubasta      { get; set; }   // se asigna al cerrar la subasta
        public string     NombreUsuario  { get; set; }
        public decimal    Monto          { get; set; }
        public DateTime   FechaHora      { get; set; }
        public EstadoPuja Estado         { get; set; }
        public string     MotivoRechazo  { get; set; }   // null si Aceptada
    }
}
