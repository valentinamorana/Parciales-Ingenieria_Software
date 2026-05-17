using System;

namespace AlmonedaNacional.BE
{
    public class ResultadoSubasta : Entidad
    {
        public string NombreUnidadVenta { get; set; }
        public decimal PrecioBase       { get; set; }
        public decimal PrecioFinal      { get; set; }
        public string NombreGanador     { get; set; }
        public string EmailGanador      { get; set; }
        public DateTime FechaHora       { get; set; }

        public override string ToString()
            => $"[{FechaHora:dd/MM/yyyy HH:mm}] {NombreUnidadVenta} | Base: ${PrecioBase:N2} | Final: ${PrecioFinal:N2} | Ganador: {NombreGanador}";
    }
}
