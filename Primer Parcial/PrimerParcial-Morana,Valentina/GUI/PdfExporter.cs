using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace GUI
{
    internal static class PdfExporter
    {
        // ── Paleta del sistema ───────────────────────────────────────────────────
        private static readonly BaseColor CBrand    = new BaseColor(210, 100, 135);
        private static readonly BaseColor CBrandDk  = new BaseColor(148,  72, 102);
        private static readonly BaseColor CBrandLt  = new BaseColor(252, 228, 235);
        private static readonly BaseColor CBrandMid = new BaseColor(240, 200, 215);
        private static readonly BaseColor CTextDk   = new BaseColor( 52,  28,  40);
        private static readonly BaseColor CTextMid  = new BaseColor(175,  80, 115);
        private static readonly BaseColor CGray     = new BaseColor(150, 110, 130);
        private static readonly BaseColor CGreen    = new BaseColor( 25, 120,  55);

        // Retenidos para ExportarBitacora
        private static readonly BaseColor ColorHeaderFg = BaseColor.WHITE;
        private static readonly BaseColor ColorRowAlt   = new BaseColor(252, 228, 235);
        private static readonly BaseColor ColorBaja     = new BaseColor(220, 245, 220);
        private static readonly BaseColor ColorMedia    = new BaseColor(255, 250, 210);
        private static readonly BaseColor ColorAlta     = new BaseColor(255, 215, 215);

        // ── Fuentes ──────────────────────────────────────────────────────────────
        private static Font FH1    => FontFactory.GetFont(FontFactory.HELVETICA_BOLD,    20f, BaseColor.WHITE);
        private static Font FH1Sub => FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE,  8f, new BaseColor(255, 215, 228));
        private static Font FSec   => FontFactory.GetFont(FontFactory.HELVETICA_BOLD,    10f, CBrand);
        private static Font FBold  => FontFactory.GetFont(FontFactory.HELVETICA_BOLD,   8.5f, CTextDk);
        private static Font FBody  => FontFactory.GetFont(FontFactory.HELVETICA,         8.5f, CTextDk);
        private static Font FSmall => FontFactory.GetFont(FontFactory.HELVETICA,           8f, CGray);
        private static Font FKpiV  => FontFactory.GetFont(FontFactory.HELVETICA_BOLD,    12f, CBrand);
        private static Font FKpiL  => FontFactory.GetFont(FontFactory.HELVETICA,           7f, CTextMid);
        private static Font FWin   => FontFactory.GetFont(FontFactory.HELVETICA_BOLD,   9.5f, CGreen);
        private static Font FFoot  => FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE,  7f, BaseColor.GRAY);
        private static Font FTblH  => FontFactory.GetFont(FontFactory.HELVETICA_BOLD,     8f, BaseColor.WHITE);

        // ────────────────────────────────────────────────────────────────────────
        //  ENTRY POINT — detecta tipo y despacha
        // ────────────────────────────────────────────────────────────────────────
        public static void ExportarReporte(string rutaArchivo, string titulo, string contenido)
        {
            bool esComp = contenido.Contains("COMPARACIÓN DE JORNADAS");
            using (var doc = new Document(PageSize.A4, 36, 36, 44, 36))
            {
                PdfWriter.GetInstance(doc,
                    new System.IO.FileStream(rutaArchivo, System.IO.FileMode.Create));
                doc.Open();
                AgregarHeaderBar(doc, titulo);
                if (esComp) RenderComparacion(doc, contenido.Split('\n'));
                else        RenderReporteDia(doc, contenido.Split('\n'));
                doc.Close();
            }
        }

        // ── Header bar rosa ───────────────────────────────────────────────────────
        private static void AgregarHeaderBar(Document doc, string titulo)
        {
            var tbl = new PdfPTable(1) { WidthPercentage = 100, SpacingAfter = 14f };
            var cell = new PdfPCell
            {
                BackgroundColor = CBrand,
                Border          = Rectangle.NO_BORDER,
                PaddingLeft = 16f, PaddingRight = 16f,
                PaddingTop  = 14f, PaddingBottom = 16f
            };
            var p = new Paragraph(titulo, FH1) { Leading = 24f };
            p.Add(Chunk.NEWLINE);
            p.Add(new Chunk(
                $"La Almoneda Nacional  ·  Generado: {DateTime.Now:dd/MM/yyyy HH:mm}", FH1Sub));
            cell.AddElement(p);
            tbl.AddCell(cell);
            doc.Add(tbl);
        }

        // ── KPI summary (4 cajas con borde superior brand) ───────────────────────
        private static void AgregarKPIs(Document doc,
            string cerradas, string total, string ganancia, string ingresados)
        {
            var tbl = new PdfPTable(4) { WidthPercentage = 100, SpacingAfter = 14f };
            tbl.SetWidths(new float[] { 1f, 2.2f, 2.2f, 1f });
            KpiCelda(tbl, cerradas,   "SUBASTAS CERRADAS");
            KpiCelda(tbl, total,      "MONTO RECAUDADO");
            KpiCelda(tbl, ganancia,   "GANANCIA NETA");
            KpiCelda(tbl, ingresados, "INGRESADOS HOY");
            doc.Add(tbl);
        }

        private static void KpiCelda(PdfPTable tbl, string valor, string label)
        {
            var cell = new PdfPCell
            {
                BackgroundColor     = CBrandLt,
                Border              = Rectangle.NO_BORDER,
                BorderWidthTop      = 3f,
                BorderColorTop      = CBrand,
                PaddingTop          = 10f,
                PaddingBottom       = 10f,
                HorizontalAlignment = Element.ALIGN_CENTER
            };
            var p = new Paragraph(valor ?? "—", FKpiV)
            { Alignment = Element.ALIGN_CENTER, Leading = 17f };
            p.Add(Chunk.NEWLINE);
            p.Add(new Chunk(label, FKpiL));
            cell.AddElement(p);
            tbl.AddCell(cell);
        }

        // ── Barra de sección ─────────────────────────────────────────────────────
        private static void Seccion(Document doc, string texto)
        {
            var tbl = new PdfPTable(1)
            { WidthPercentage = 100, SpacingBefore = 10f, SpacingAfter = 6f };
            var c = new PdfPCell
            {
                BackgroundColor = CBrandLt,
                Border          = Rectangle.NO_BORDER,
                BorderWidthLeft = 4f,
                BorderColorLeft = CBrand,
                PaddingLeft     = 10f,
                PaddingTop      = 5f,
                PaddingBottom   = 6f
            };
            c.AddElement(new Paragraph(texto, FSec));
            tbl.AddCell(c);
            doc.Add(tbl);
        }

        // ── Celda de tabla helper ────────────────────────────────────────────────
        private static PdfPCell TC(string txt, Font fnt, BaseColor bg,
                                   int align = Element.ALIGN_LEFT)
        {
            return new PdfPCell(new Phrase(txt ?? "—", fnt))
            {
                BackgroundColor     = bg,
                Border              = Rectangle.NO_BORDER,
                BorderWidthBottom   = 0.4f,
                BorderColorBottom   = CBrandMid,
                Padding             = 4.5f,
                HorizontalAlignment = align
            };
        }

        private static PdfPCell TH(string txt, int align = Element.ALIGN_LEFT,
                                   BaseColor bg = null)
        {
            return new PdfPCell(new Phrase(txt, FTblH))
            {
                BackgroundColor     = bg ?? CBrandDk,
                Border              = Rectangle.NO_BORDER,
                Padding             = 5f,
                HorizontalAlignment = align
            };
        }

        // ════════════════════════════════════════════════════════════════════════
        //  REPORTE DE UN DÍA
        // ════════════════════════════════════════════════════════════════════════
        private static void RenderReporteDia(Document doc, string[] lines)
        {
            // Estructuras para recolectar datos mientras parsea
            var catalogo   = new List<(string tipo, string nombre, string precio, int nivel)>();
            var auctions   = new List<(string titulo, string pBase, string pFinal, string gan, string ganador, string hora)>();
            var ingresados = new List<(string tipo, string nombre, string precio)>();

            string kpiCerr = "0", kpiTotal = "—", kpiGan = "—", kpiIng = "0";

            // Acumulador de ítem de subasta en curso
            string aTitle = null, aBase = null, aFinal = null, aGan = null,
                   aGanador = null, aHora = null;

            string estado = "";

            foreach (var raw in lines)
            {
                var t = raw.Trim();
                if (string.IsNullOrWhiteSpace(t)
                    || IsLineSep(t)) continue;

                // Detección de sección
                if (t.StartsWith("▌"))
                {
                    FlushAuction(auctions, ref aTitle, ref aBase, ref aFinal,
                                 ref aGan, ref aGanador, ref aHora);
                    if      (t.Contains("CATÁLOGO"))   estado = "cat";
                    else if (t.Contains("ANALYTICS"))  estado = "ana";
                    else if (t.Contains("INGRESADOS")) estado = "ing";
                    continue;
                }

                // Stats globales (pueden aparecer en cualquier estado)
                if (t.StartsWith("SUBASTAS CERRADAS"))
                { kpiCerr = LastNum(t); continue; }
                if (t.StartsWith("TOTAL RECAUDADO"))
                { kpiTotal = FirstAmount(t); continue; }
                if (t.StartsWith("GANANCIA NETA"))
                { kpiGan = FirstAmount(t); continue; }
                if (t.StartsWith("INGRESADOS HOY"))
                { kpiIng = LastNum(t); continue; }
                if (t.StartsWith("Generado:") || t.StartsWith("═══")) continue;

                switch (estado)
                {
                    case "cat":
                        if (t.StartsWith("▸") || t.StartsWith("└─"))
                        {
                            int nivel = t.StartsWith("└─") ? 1 : 0;
                            var m = Regex.Match(t, @"\[([^\]]+)\]\s+(.+?)\s+—\s+(\$[\d\.,]+)");
                            if (m.Success)
                                catalogo.Add(($"[{m.Groups[1].Value.Trim()}]",
                                              m.Groups[2].Value.Trim(),
                                              m.Groups[3].Value.Trim(), nivel));
                        }
                        break;

                    case "ana":
                        var mNum = Regex.Match(raw, @"^\s+\d+\.\s+(.+)$");
                        if (mNum.Success)
                        {
                            FlushAuction(auctions, ref aTitle, ref aBase, ref aFinal,
                                         ref aGan, ref aGanador, ref aHora);
                            aTitle = mNum.Groups[1].Value.Trim();
                            break;
                        }
                        if (t.StartsWith("Precio base:"))
                        { aBase = FirstAmount(t); break; }
                        if (t.StartsWith("Precio final:"))
                        {
                            var ms = Regex.Matches(t, @"\$[\d\.,]+");
                            aFinal = ms.Count > 0 ? ms[0].Value : null;
                            aGan   = ms.Count > 1 ? "+" + ms[1].Value : null;
                            break;
                        }
                        if (t.StartsWith("Ganador:"))
                        { aGanador = AfterColon(t); break; }
                        if (t.StartsWith("Hora cierre:"))
                        { aHora = AfterColon(t); break; }
                        break;

                    case "ing":
                        if (t.StartsWith("+"))
                        {
                            var m = Regex.Match(t, @"\[([^\]]+)\]\s+(.+?)\s+—\s+(\$[\d\.,]+)");
                            if (m.Success)
                                ingresados.Add(($"[{m.Groups[1].Value.Trim()}]",
                                               m.Groups[2].Value.Trim(),
                                               m.Groups[3].Value.Trim()));
                        }
                        break;
                }
            }
            FlushAuction(auctions, ref aTitle, ref aBase, ref aFinal,
                         ref aGan, ref aGanador, ref aHora);

            // ── Render ───────────────────────────────────────────────────────────
            AgregarKPIs(doc, kpiCerr, kpiTotal, kpiGan, kpiIng);

            // Catálogo
            if (catalogo.Count > 0)
            {
                Seccion(doc, "Catálogo de Productos");
                var tbl = new PdfPTable(3) { WidthPercentage = 100, SpacingAfter = 10f };
                tbl.SetWidths(new float[] { 1.2f, 6f, 1.8f });
                tbl.AddCell(TH("Tipo",       Element.ALIGN_CENTER));
                tbl.AddCell(TH("Nombre",     Element.ALIGN_LEFT));
                tbl.AddCell(TH("Precio base",Element.ALIGN_RIGHT));

                bool par = false;
                foreach (var (tipo, nombre, precio, nivel) in catalogo)
                {
                    var bg = par ? CBrandLt : BaseColor.WHITE; par = !par;
                    bool esLote = tipo.Contains("LOTE");
                    tbl.AddCell(TC(tipo,
                        FSmall, bg, Element.ALIGN_CENTER));
                    tbl.AddCell(TC((nivel > 0 ? "   " : "") + nombre,
                        esLote && nivel == 0 ? FBold : FBody, bg));
                    tbl.AddCell(TC(precio, FBody, bg, Element.ALIGN_RIGHT));
                }
                doc.Add(tbl);
            }

            // Analytics
            Seccion(doc, "Analytics — Ventas y Subastas");
            if (auctions.Count == 0)
            {
                doc.Add(new Paragraph("(sin subastas cerradas en esta jornada)", FSmall)
                { IndentationLeft = 10f, SpacingAfter = 8f });
            }
            else
            {
                var tbl = new PdfPTable(5) { WidthPercentage = 100, SpacingAfter = 10f };
                tbl.SetWidths(new float[] { 0.4f, 3.2f, 1.8f, 1.8f, 2.8f });
                tbl.AddCell(TH("#",         Element.ALIGN_CENTER, CBrand));
                tbl.AddCell(TH("Artículo",  Element.ALIGN_LEFT,   CBrand));
                tbl.AddCell(TH("Base",      Element.ALIGN_RIGHT,  CBrand));
                tbl.AddCell(TH("Final",     Element.ALIGN_RIGHT,  CBrand));
                tbl.AddCell(TH("Ganador",   Element.ALIGN_LEFT,   CBrand));

                bool par = false; int idx = 1;
                foreach (var (titulo, pBase, pFinal, gan, ganador, hora) in auctions)
                {
                    var bg = par ? CBrandLt : BaseColor.WHITE; par = !par;
                    tbl.AddCell(TC(idx.ToString(), FSmall, bg, Element.ALIGN_CENTER));
                    tbl.AddCell(TC(titulo, FBold, bg));
                    tbl.AddCell(TC(pBase  ?? "—", FBody, bg, Element.ALIGN_RIGHT));
                    tbl.AddCell(TC(pFinal ?? "—", FBold, bg, Element.ALIGN_RIGHT));

                    // Ganador + hora cierre juntos
                    var cGan = new PdfPCell
                    {
                        BackgroundColor = bg, Border = Rectangle.NO_BORDER,
                        BorderWidthBottom = 0.4f, BorderColorBottom = CBrandMid,
                        Padding = 4.5f
                    };
                    var pGan = new Paragraph(ganador ?? "—", FBody) { Leading = 12f };
                    if (hora != null)
                    { pGan.Add(Chunk.NEWLINE); pGan.Add(new Chunk("cierre: " + hora, FSmall)); }
                    cGan.AddElement(pGan);
                    tbl.AddCell(cGan);
                    idx++;
                }
                doc.Add(tbl);
            }

            // Ingresados hoy
            Seccion(doc, $"Productos Ingresados Hoy ({kpiIng})");
            if (ingresados.Count == 0)
            {
                doc.Add(new Paragraph("(ningún producto ingresó en esta jornada)", FSmall)
                { IndentationLeft = 10f, SpacingAfter = 8f });
            }
            else
            {
                var tbl = new PdfPTable(3) { WidthPercentage = 100, SpacingAfter = 10f };
                tbl.SetWidths(new float[] { 1.2f, 6f, 1.8f });
                tbl.AddCell(TH("Tipo",       Element.ALIGN_CENTER, CBrandMid));
                tbl.AddCell(TH("Nombre",     Element.ALIGN_LEFT,   CBrandMid));
                tbl.AddCell(TH("Precio base",Element.ALIGN_RIGHT,  CBrandMid));

                bool par = false;
                foreach (var (tipo, nombre, precio) in ingresados)
                {
                    var bg = par ? CBrandLt : BaseColor.WHITE; par = !par;
                    tbl.AddCell(TC(tipo,   FSmall, bg, Element.ALIGN_CENTER));
                    tbl.AddCell(TC(nombre, FBody,  bg));
                    tbl.AddCell(TC(precio, FBody,  bg, Element.ALIGN_RIGHT));
                }
                doc.Add(tbl);
            }

            Pie(doc);
        }

        // ════════════════════════════════════════════════════════════════════════
        //  COMPARACIÓN DE JORNADAS
        // ════════════════════════════════════════════════════════════════════════
        private static void RenderComparacion(Document doc, string[] lines)
        {
            var itemsA = new List<(string nombre, string pBase, string pFinal, string gan)>();
            var itemsB = new List<(string nombre, string pBase, string pFinal, string gan)>();
            string sumA = null, sumB = null;
            var tableRows  = new List<(string label, string vA, string vB)>();
            string winner  = null;

            string estado = "";
            List<(string nombre, string pBase, string pFinal, string gan)> cur = null;
            string curNombre = null;

            foreach (var raw in lines)
            {
                var t = raw.Trim();
                if (string.IsNullOrWhiteSpace(t) || IsLineSep(t)) continue;

                if (t.StartsWith("────") && t.Contains("JORNADA A"))
                { estado = "A"; cur = itemsA; curNombre = null; continue; }
                if (t.StartsWith("────") && t.Contains("JORNADA B"))
                { estado = "B"; cur = itemsB; curNombre = null; continue; }
                if (t.Contains("COMPARATIVO FINAL"))
                { estado = "tabla"; continue; }
                if (t.StartsWith("Generado:")) break;

                switch (estado)
                {
                    case "A":
                    case "B":
                        var mN = Regex.Match(raw, @"^\s+\d+\.\s+(.+)$");
                        if (mN.Success)
                        {
                            curNombre = mN.Groups[1].Value.Trim(); break;
                        }
                        if (t.StartsWith("Base:") && curNombre != null)
                        {
                            var ms = Regex.Matches(t, @"\$[\d\.,]+");
                            string b = ms.Count > 0 ? ms[0].Value : "—";
                            string f = ms.Count > 1 ? ms[1].Value : "—";
                            string g = ms.Count > 2 ? "+" + ms[2].Value : null;
                            cur?.Add((curNombre, b, f, g));
                            curNombre = null; break;
                        }
                        if (t.StartsWith("►"))
                        {
                            if (estado == "A") sumA = t.Substring(1).Trim();
                            else               sumB = t.Substring(1).Trim();
                        }
                        break;

                    case "tabla":
                        if (t.Contains("JORNADA A") && t.Contains("JORNADA B")) break;
                        if (t.StartsWith("GANADORA:") || t.StartsWith("EMPATE:")
                            || t.StartsWith("Ninguna"))
                        { winner = t; break; }

                        // Parseo de posición fija:
                        // [0:2]=" " [2:22]=label(20) [22:24]="  " [24:38]=vA(14) [38:40]="  " [40:54]=vB(14)
                        var row = raw.TrimEnd('\r', '\n');
                        if (row.Length >= 54)
                        {
                            string lbl = row.Substring(2, 20).Trim();
                            string vA  = row.Substring(24, 14).Trim();
                            string vB  = row.Substring(40, 14).Trim();
                            if (!string.IsNullOrEmpty(lbl) && lbl != "")
                                tableRows.Add((lbl, vA, vB));
                        }
                        break;
                }
            }

            // ── Render ───────────────────────────────────────────────────────────
            RenderJornada(doc, "A", itemsA, sumA);
            RenderJornada(doc, "B", itemsB, sumB);

            // Tabla comparativa
            if (tableRows.Count > 0)
            {
                Seccion(doc, "Comparativo Final");
                var tbl = new PdfPTable(3) { WidthPercentage = 100, SpacingAfter = 10f };
                tbl.SetWidths(new float[] { 3f, 2f, 2f });
                tbl.AddCell(TH("",          Element.ALIGN_LEFT,   CBrandDk));
                tbl.AddCell(TH("Jornada A", Element.ALIGN_CENTER, CBrandDk));
                tbl.AddCell(TH("Jornada B", Element.ALIGN_CENTER, CBrandDk));

                bool par = false;
                foreach (var (lbl, vA, vB) in tableRows)
                {
                    var bg = par ? CBrandLt : BaseColor.WHITE; par = !par;
                    tbl.AddCell(TC(lbl, FBold, bg));
                    tbl.AddCell(TC(vA,  FBody, bg, Element.ALIGN_CENTER));
                    tbl.AddCell(TC(vB,  FBody, bg, Element.ALIGN_CENTER));
                }
                doc.Add(tbl);
            }

            // Ganadora / empate
            if (winner != null)
            {
                bool isWin = winner.StartsWith("GANADORA:");
                doc.Add(new Paragraph(winner, isWin ? FWin : FBody)
                { Alignment = Element.ALIGN_RIGHT, SpacingBefore = 4f, SpacingAfter = 12f });
            }

            Pie(doc);
        }

        private static void RenderJornada(Document doc, string letra,
            List<(string nombre, string pBase, string pFinal, string gan)> items, string summary)
        {
            Seccion(doc, $"Jornada {letra}");
            if (items.Count == 0)
            {
                doc.Add(new Paragraph("(sin subastas cerradas en esta jornada)", FSmall)
                { IndentationLeft = 10f, SpacingAfter = 8f });
            }
            else
            {
                var tbl = new PdfPTable(4) { WidthPercentage = 100, SpacingAfter = 6f };
                tbl.SetWidths(new float[] { 0.4f, 4f, 2f, 2.2f });
                tbl.AddCell(TH("#",          Element.ALIGN_CENTER, CBrand));
                tbl.AddCell(TH("Artículo",   Element.ALIGN_LEFT,   CBrand));
                tbl.AddCell(TH("Base",       Element.ALIGN_RIGHT,  CBrand));
                tbl.AddCell(TH("Final",      Element.ALIGN_RIGHT,  CBrand));

                bool par = false; int idx = 1;
                foreach (var (nombre, pBase, pFinal, gan) in items)
                {
                    var bg = par ? CBrandLt : BaseColor.WHITE; par = !par;
                    tbl.AddCell(TC(idx.ToString(), FSmall, bg, Element.ALIGN_CENTER));
                    tbl.AddCell(TC(nombre, FBold, bg));
                    tbl.AddCell(TC(pBase ?? "—", FBody, bg, Element.ALIGN_RIGHT));

                    var cFin = new PdfPCell
                    {
                        BackgroundColor = bg, Border = Rectangle.NO_BORDER,
                        BorderWidthBottom = 0.4f, BorderColorBottom = CBrandMid,
                        Padding = 4.5f, HorizontalAlignment = Element.ALIGN_RIGHT
                    };
                    var pFin = new Paragraph(pFinal ?? "—", FBold)
                    { Leading = 12f, Alignment = Element.ALIGN_RIGHT };
                    if (gan != null)
                    { pFin.Add(Chunk.NEWLINE); pFin.Add(new Chunk(gan, FSmall)); }
                    cFin.AddElement(pFin);
                    tbl.AddCell(cFin);
                    idx++;
                }
                doc.Add(tbl);
            }
            if (summary != null)
                doc.Add(new Paragraph(summary, FSmall)
                { IndentationLeft = 10f, SpacingAfter = 10f });
        }

        // ── Pie de página ─────────────────────────────────────────────────────────
        private static void Pie(Document doc)
        {
            doc.Add(new Paragraph(
                $"Generado: {DateTime.Now:dd/MM/yyyy HH:mm:ss}  ·  La Almoneda Nacional",
                FFoot)
            { Alignment = Element.ALIGN_RIGHT, SpacingBefore = 16f });
        }

        // ── Helpers de parsing ───────────────────────────────────────────────────
        private static bool IsLineSep(string t) =>
            t.Length > 3 && t.Replace("═", "").Replace("─", "").Trim().Length == 0;

        private static string LastNum(string t)
        {
            var m = Regex.Match(t, @"\d+\s*$");
            return m.Success ? m.Value.Trim() : "0";
        }

        private static string FirstAmount(string t)
        {
            var m = Regex.Match(t, @"\$[\d\.,]+");
            return m.Success ? m.Value : "—";
        }

        private static string AfterColon(string t)
        {
            int i = t.IndexOf(':');
            return i >= 0 ? t.Substring(i + 1).Trim() : t;
        }

        private static void FlushAuction(
            List<(string, string, string, string, string, string)> list,
            ref string title, ref string pBase, ref string pFinal,
            ref string gan, ref string ganador, ref string hora)
        {
            if (title == null) return;
            list.Add((title, pBase, pFinal, gan, ganador, hora));
            title = pBase = pFinal = gan = ganador = hora = null;
        }

        // ════════════════════════════════════════════════════════════════════════
        //  BITÁCORA (sin cambios)
        // ════════════════════════════════════════════════════════════════════════
        public static void ExportarBitacora(string rutaArchivo, DataTable datos, string filtrosDesc)
        {
            using (var doc = new Document(PageSize.A4.Rotate(), 30, 30, 45, 35))
            {
                PdfWriter.GetInstance(doc, new System.IO.FileStream(rutaArchivo, System.IO.FileMode.Create));
                doc.Open();

                var fntTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 15, CBrand);
                var fntSub    = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 8,
                                    new BaseColor(100, 100, 120));
                var fntHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8, ColorHeaderFg);
                var fntCell   = FontFactory.GetFont(FontFactory.HELVETICA, 7.5f, BaseColor.BLACK);

                doc.Add(new Paragraph("Bitácora de Operaciones", fntTitulo) { SpacingAfter = 3 });
                doc.Add(new Paragraph(
                    $"La Almoneda Nacional  —  {filtrosDesc}  —  Exportado: {DateTime.Now:dd/MM/yyyy HH:mm}",
                    fntSub) { SpacingAfter = 10 });

                var tabla = new PdfPTable(datos.Columns.Count) { WidthPercentage = 100 };
                tabla.SetWidths(new float[] { 1.5f, 3f, 3.5f, 6f, 2f, 2.5f });

                foreach (DataColumn col in datos.Columns)
                {
                    tabla.AddCell(new PdfPCell(new Phrase(col.ColumnName, fntHeader))
                    {
                        BackgroundColor     = CBrand,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        Padding = 5f, Border = Rectangle.NO_BORDER
                    });
                }

                bool par = false;
                foreach (DataRow row in datos.Rows)
                {
                    string crit = row["Criticidad"]?.ToString();
                    BaseColor bg = crit == "Alta"  ? ColorAlta  :
                                   crit == "Media" ? ColorMedia :
                                   crit == "Baja"  ? ColorBaja  :
                                   (par ? ColorRowAlt : BaseColor.WHITE);
                    par = !par;
                    foreach (DataColumn col in datos.Columns)
                    {
                        tabla.AddCell(new PdfPCell(new Phrase(row[col]?.ToString() ?? "", fntCell))
                        {
                            BackgroundColor   = bg,
                            Padding           = 4f,
                            Border            = Rectangle.NO_BORDER,
                            BorderWidthBottom = 0.3f,
                            BorderColorBottom = new BaseColor(220, 200, 210)
                        });
                    }
                }

                doc.Add(tabla);
                var fntFoot = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 7, BaseColor.GRAY);
                doc.Add(new Paragraph($"\nTotal de registros: {datos.Rows.Count}", fntFoot));
                doc.Close();
            }
        }
    }
}
