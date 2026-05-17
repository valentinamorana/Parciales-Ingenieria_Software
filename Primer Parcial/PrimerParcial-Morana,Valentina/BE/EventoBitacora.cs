using System;

namespace BE
{
    public class EventoBitacora : Entidad
    {
        public DateTime         Fecha            { get; set; }
        public string           Operacion        { get; set; }
        public string           Detalle          { get; set; }
        public CriticidadEvento Criticidad       { get; set; }
        public string           NombreMartillero { get; set; }
    }
}
