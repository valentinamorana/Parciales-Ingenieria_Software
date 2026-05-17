using System;
using System.Collections.Generic;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace GUI
{
    internal static class PdfExporter
    {
        private static readonly BaseColor ColorBrand    = new BaseColor(210, 100, 135);
        private static readonly BaseColor ColorHeaderFg = BaseColor.WHITE;
        private static readonly BaseColor ColorRowAlt   = new BaseColor(252, 228, 235);
        private static readonly BaseColor ColorBaja     = new BaseColor(220, 245, 220);
        private static readonly BaseColor ColorMedia    = new BaseColor(255, 250, 210);
        private static readonly BaseColor ColorAlta     = new BaseColor(255, 215, 215);

        // ── Reporte de Jornada (texto plano con fuente monoespaciada) ──────────
        public static void ExportarReporte(string rutaArchivo, string titulo, string contenido)
        {
            using (var doc = new Document(PageSize.A4, 40, 40, 50, 40))
            {
                PdfWriter.GetInstance(doc, new System.IO.FileStream(rutaArchivo, System.IO.FileMode.Create));
                doc.Open();

                // Encabezado
                var fntTitulo  = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, ColorBrand);
                var fntSub     = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 9,
                                     new BaseColor(150, 100, 120));
                var fntCuerpo  = FontFactory.GetFont(FontFactory.COURIER, 8, BaseColor.WHITE);

                doc.Add(new Paragraph(titulo, fntTitulo) { SpacingAfter = 4 });
                doc.Add(new Paragraph($"La Almoneda Nacional  —  Generado: {DateTime.Now:dd/MM/yyyy HH:mm}",
                    fntSub) { SpacingAfter = 12 });

                // Cuerpo en cuadro oscuro (simula consola)
                var fntMono    = FontFactory.GetFont(FontFactory.COURIER, 7.5f, BaseColor.WHITE);
                var cell       = new PdfPCell(new Phrase(contenido, fntMono))
                {
                    BackgroundColor = new BaseColor(22, 22, 22),
                    Border          = Rectangle.NO_BORDER,
                    Padding         = 10f
                };
                var tabla = new PdfPTable(1) { WidthPercentage = 100 };
                tabla.AddCell(cell);
                doc.Add(tabla);

                doc.Close();
            }
        }

        // ── Bitácora (tabla con columnas y colores por criticidad) ────────────
        public static void ExportarBitacora(string rutaArchivo, DataTable datos, string filtrosDesc)
        {
            using (var doc = new Document(PageSize.A4.Rotate(), 30, 30, 45, 35))
            {
                PdfWriter.GetInstance(doc, new System.IO.FileStream(rutaArchivo, System.IO.FileMode.Create));
                doc.Open();

                var fntTitulo  = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 15, ColorBrand);
                var fntSub     = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 8,
                                     new BaseColor(100, 100, 120));
                var fntHeader  = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8, ColorHeaderFg);
                var fntCell    = FontFactory.GetFont(FontFactory.HELVETICA, 7.5f, BaseColor.BLACK);

                doc.Add(new Paragraph("Bitácora de Operaciones", fntTitulo) { SpacingAfter = 3 });
                doc.Add(new Paragraph(
                    $"La Almoneda Nacional  —  {filtrosDesc}  —  Exportado: {DateTime.Now:dd/MM/yyyy HH:mm}",
                    fntSub) { SpacingAfter = 10 });

                var tabla = new PdfPTable(datos.Columns.Count) { WidthPercentage = 100 };
                tabla.SetWidths(new float[] { 1.5f, 3f, 3.5f, 6f, 2f, 2.5f });

                // Encabezados
                foreach (DataColumn col in datos.Columns)
                {
                    var h = new PdfPCell(new Phrase(col.ColumnName, fntHeader))
                    {
                        BackgroundColor = ColorBrand,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        Padding = 5f,
                        Border  = Rectangle.NO_BORDER
                    };
                    tabla.AddCell(h);
                }

                // Filas
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
                        var c = new PdfPCell(new Phrase(row[col]?.ToString() ?? "", fntCell))
                        {
                            BackgroundColor = bg,
                            Padding         = 4f,
                            Border          = Rectangle.NO_BORDER,
                            BorderWidthBottom = 0.3f,
                            BorderColorBottom = new BaseColor(220, 200, 210)
                        };
                        tabla.AddCell(c);
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
