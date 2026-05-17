using System;
using System.Collections.Generic;
using System.Text;
using AlmonedaNacional.BE;
using AlmonedaNacional.Servicios.Composite;
using AlmonedaNacional.Servicios.Iterator;

namespace AlmonedaNacional.BLL
{
    // RF-13: servicio independiente que recorre el Composite recursivamente
    // y lista todas las subastas de la jornada seleccionada.
    public class ReporteJornada
    {
        private readonly SubastaBLL _subastaBll = new SubastaBLL();

        public string Generar(IList<IUnidadDeVenta> catalogo, DateTime fecha)
        {
            var sb = new StringBuilder();
            sb.AppendLine("═══════════════════════════════════════════════════════");
            sb.AppendLine($"   REPORTE DE JORNADA — {fecha:dd/MM/yyyy}");
            sb.AppendLine("   La Almoneda Nacional");
            sb.AppendLine("═══════════════════════════════════════════════════════");
            sb.AppendLine();

            // 1. Recorrido Composite del catálogo — usando Patrón Iterator (RF-13)
            sb.AppendLine("CATÁLOGO (Patrón Iterator sobre Composite — recorrido transparente):");
            sb.AppendLine(new string('─', 55));
            var iterador = new CatalogoIterador(catalogo);
            while (iterador.TieneSiguiente)
            {
                var unidad = iterador.Siguiente();
                int nivel  = iterador.NivelActual;
                string indent  = new string(' ', nivel * 4);
                string bullet  = nivel == 0 ? "▸" : "└─";
                string tipo    = unidad.ObtenerHijos() != null ? "[LOTE]" : "[ART] ";
                sb.AppendLine($"{indent}{bullet} {tipo} {unidad.Nombre}  — ${unidad.CalcularPrecioBase():N2}");
            }
            sb.AppendLine();

            // 2. Subastas del día
            sb.AppendLine("SUBASTAS DE LA JORNADA:");
            sb.AppendLine(new string('─', 55));

            IList<ResultadoSubasta> historial = _subastaBll.ObtenerHistorial();

            decimal total    = 0;
            int     cantidad = 0;
            foreach (var r in historial)
            {
                if (r.FechaHora.Date == fecha.Date)
                {
                    cantidad++;
                    sb.AppendLine($"  {cantidad,2}. {r.NombreUnidadVenta}");
                    sb.AppendLine($"      Precio base:  ${r.PrecioBase:N2}");
                    sb.AppendLine($"      Precio final: ${r.PrecioFinal:N2}  (+${r.PrecioFinal - r.PrecioBase:N2})");
                    sb.AppendLine($"      Ganador:      {r.NombreGanador}");
                    sb.AppendLine($"      Hora cierre:  {r.FechaHora:HH:mm:ss}");
                    sb.AppendLine();
                    total += r.PrecioFinal;
                }
            }
            if (cantidad == 0)
                sb.AppendLine("  (sin subastas cerradas en esta jornada)");

            sb.AppendLine(new string('═', 55));
            sb.AppendLine($"  SUBASTAS CERRADAS : {cantidad}");
            sb.AppendLine($"  TOTAL RECAUDADO   : ${total:N2}");
            sb.AppendLine($"  Generado          : {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            sb.AppendLine(new string('═', 55));

            return sb.ToString();
        }

    }
}
