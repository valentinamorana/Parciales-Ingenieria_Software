using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using Servicios.Composite;

namespace BLL
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
            sb.AppendLine($"   REPORTE DE JORNADA — {FechaStr(fecha)}");
            sb.AppendLine("   La Almoneda Nacional");
            sb.AppendLine("═══════════════════════════════════════════════════════");
            sb.AppendLine();

            // ── SECCIÓN 1: CATÁLOGO COMPLETO (RF-13 — Composite traversal) ──────
            sb.AppendLine("▌ CATÁLOGO DE PRODUCTOS (Patrón Composite)");
            sb.AppendLine(new string('─', 55));
            foreach (var u in catalogo)
                RecorrerNodo(u, sb, 0);
            sb.AppendLine();

            // ── SECCIÓN 2: ANALYTICS DE VENTAS / SUBASTAS ───────────────────────
            sb.AppendLine("▌ ANALYTICS — VENTAS Y SUBASTAS DE LA JORNADA");
            sb.AppendLine(new string('─', 55));

            IList<ResultadoSubasta> historial = _subastaBll.ObtenerHistorial();

            decimal total    = 0;
            decimal ganancia = 0;
            int     cantidad = 0;
            foreach (var r in historial)
            {
                if (r.FechaHora.Date != fecha.Date) continue;

                cantidad++;
                decimal gan = r.PrecioFinal - r.PrecioBase;
                sb.AppendLine($"  {cantidad,2}. {r.NombreUnidadVenta}");
                sb.AppendLine($"      Precio base:  ${r.PrecioBase:N2}");
                sb.AppendLine($"      Precio final: ${r.PrecioFinal:N2}  (+${gan:N2})");
                sb.AppendLine($"      Ganador:      {r.NombreGanador}");
                sb.AppendLine($"      Hora cierre:  {r.FechaHora:HH:mm:ss}");
                sb.AppendLine();
                total    += r.PrecioFinal;
                ganancia += gan;
            }
            if (cantidad == 0)
                sb.AppendLine("  (sin subastas cerradas en esta jornada)");

            sb.AppendLine(new string('─', 55));
            sb.AppendLine($"  SUBASTAS CERRADAS : {cantidad}");
            sb.AppendLine($"  TOTAL RECAUDADO   : ${total:N2}");
            sb.AppendLine($"  GANANCIA NETA     : ${ganancia:N2}" +
                          (cantidad > 0 ? $"  (avg. ${ganancia / cantidad:N2}/subasta)" : ""));
            sb.AppendLine();

            // ── SECCIÓN 3: PRODUCTOS INGRESADOS HOY ─────────────────────────────
            var ingresados = catalogo
                .Where(u => u.FechaIngreso.Date == fecha.Date)
                .ToList();

            sb.AppendLine("▌ PRODUCTOS INGRESADOS AL CATÁLOGO HOY");
            sb.AppendLine(new string('─', 55));
            if (ingresados.Count == 0)
                sb.AppendLine("  (ningún producto ingresó en esta jornada)");
            else
                foreach (var u in ingresados)
                    sb.AppendLine($"  + [{(u is LoteArticulos ? "LOTE" : "ART ")}] {u.Nombre}  — ${u.CalcularPrecioBase():N2}");

            sb.AppendLine($"  INGRESADOS HOY    : {ingresados.Count}");
            sb.AppendLine();

            sb.AppendLine($"  Generado: {DateTime.Now:dd'/'MM'/'yyyy HH:mm:ss}");
            sb.AppendLine(new string('═', 55));

            return sb.ToString();
        }

        public string GenerarComparacion(IList<IUnidadDeVenta> catalogo, DateTime fecha1, DateTime fecha2)
        {
            IList<ResultadoSubasta> historial = _subastaBll.ObtenerHistorial();

            var sb = new StringBuilder();
            sb.AppendLine("═══════════════════════════════════════════════════════");
            sb.AppendLine($"   COMPARACIÓN DE JORNADAS");
            sb.AppendLine($"   {FechaStr(fecha1)}  vs  {FechaStr(fecha2)}");
            sb.AppendLine("   La Almoneda Nacional");
            sb.AppendLine("═══════════════════════════════════════════════════════");
            sb.AppendLine();

            var (cant1, total1, gan1) = AgregarDetalleJornada(sb, historial, fecha1, "A");
            sb.AppendLine();
            var (cant2, total2, gan2) = AgregarDetalleJornada(sb, historial, fecha2, "B");
            sb.AppendLine();

            int ing1 = catalogo.Count(u => u.FechaIngreso.Date == fecha1.Date);
            int ing2 = catalogo.Count(u => u.FechaIngreso.Date == fecha2.Date);

            string f1 = FechaStr(fecha1);
            string f2 = FechaStr(fecha2);

            sb.AppendLine(new string('═', 57));
            sb.AppendLine("  COMPARATIVO FINAL:");
            sb.AppendLine(new string('─', 57));
            sb.AppendLine($"  {"",20}  {"JORNADA A",14}  {"JORNADA B",14}");
            sb.AppendLine($"  {"Fecha",-20}  {f1,14}  {f2,14}");
            sb.AppendLine($"  {"Subastas",-20}  {cant1,14}  {cant2,14}");
            sb.AppendLine($"  {"Total recaudado",-20}  {"$" + total1.ToString("N2"),14}  {"$" + total2.ToString("N2"),14}");
            sb.AppendLine($"  {"Ganancia neta",-20}  {"$" + gan1.ToString("N2"),14}  {"$" + gan2.ToString("N2"),14}");
            sb.AppendLine($"  {"Prod. ingresados",-20}  {ing1,14}  {ing2,14}");
            sb.AppendLine(new string('─', 57));

            if (gan1 > gan2)
                sb.AppendLine($"  GANADORA: JORNADA A ({f1}) — +${gan1 - gan2:N2} más rentable");
            else if (gan2 > gan1)
                sb.AppendLine($"  GANADORA: JORNADA B ({f2}) — +${gan2 - gan1:N2} más rentable");
            else if (cant1 == 0 && cant2 == 0)
                sb.AppendLine("  Ninguna jornada tuvo subastas registradas.");
            else
                sb.AppendLine("  EMPATE: ambas jornadas tuvieron la misma ganancia neta.");

            sb.AppendLine($"  Generado: {DateTime.Now:dd'/'MM'/'yyyy HH:mm:ss}");
            sb.AppendLine(new string('═', 57));

            return sb.ToString();
        }

        private static (int cant, decimal total, decimal ganancia) AgregarDetalleJornada(
            StringBuilder sb, IList<ResultadoSubasta> historial, DateTime fecha, string letra)
        {
            sb.AppendLine($"──── JORNADA {letra}  ({FechaStr(fecha)}) ──────────────────────────");
            decimal total = 0, ganancia = 0;
            int cant = 0;

            foreach (var r in historial)
            {
                if (r.FechaHora.Date != fecha.Date) continue;
                cant++;
                decimal gan = r.PrecioFinal - r.PrecioBase;
                sb.AppendLine($"  {cant,2}. {r.NombreUnidadVenta}");
                sb.AppendLine($"      Base: ${r.PrecioBase:N2}  →  Final: ${r.PrecioFinal:N2}  (ganancia: +${gan:N2})");
                total    += r.PrecioFinal;
                ganancia += gan;
            }

            if (cant == 0)
                sb.AppendLine("  (sin subastas cerradas en esta jornada)");

            sb.AppendLine($"  ► Subastas: {cant}   Recaudado: ${total:N2}   Ganancia neta: ${ganancia:N2}");
            return (cant, total, ganancia);
        }

        private static void RecorrerNodo(IUnidadDeVenta unidad, StringBuilder sb, int nivel)
        {
            string indent = new string(' ', nivel * 4);
            string bullet = nivel == 0 ? "▸" : "└─";
            string tipo   = unidad is LoteArticulos ? "[LOTE]" : "[ART] ";
            sb.AppendLine($"{indent}{bullet} {tipo} {unidad.Nombre}  — ${unidad.CalcularPrecioBase():N2}");

            foreach (var hijo in unidad.ObtenerHijos())
                RecorrerNodo(hijo, sb, nivel + 1);
        }

        private static string FechaStr(DateTime d) =>
            d.ToString("dd'/'MM'/'yyyy");
    }
}
