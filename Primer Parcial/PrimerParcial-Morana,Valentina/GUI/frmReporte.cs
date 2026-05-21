using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BE;
using BLL;
using Servicios.Composite;

namespace GUI
{
    // RF-13: Reporte de Jornada — recorre el Composite y muestra historial del día
    public partial class frmReporte : Form
    {
        private readonly ReporteJornada       _servicio;
        private readonly List<IUnidadDeVenta> _catalogo;
        private readonly SubastaBLL           _subastaBll = new SubastaBLL();

        // KPI banner value labels
        private Label _kpiTotalVal, _kpiCerradasVal, _kpiDesiertoVal, _kpiMontoVal, _kpiIngresadosVal;

        // Export context menus
        private ContextMenuStrip _menuExportar;
        private ContextMenuStrip _menuExportarComp;

        public frmReporte(List<IUnidadDeVenta> catalogo)
        {
            InitializeComponent();
            _catalogo = catalogo;
            _servicio = new ReporteJornada();
        }

        private void frmReporte_Load(object sender, EventArgs e)
        {
            dtpJornada.Value  = DateTime.Today;
            dtpJornada2.Value = DateTime.Today.AddDays(-1);

            CrearBannerKPIs();
            ConfigurarMenusExportar();
            GenerarReporte();
        }

        // ── Banner de KPIs ──────────────────────────────────────────────────────
        private void CrearBannerKPIs()
        {
            const int panelH = 66, n = 5;
            int cellW = 1360 / n;

            // Strip con la paleta del sistema: fondo casi-blanco rosado, borde inferior en brand pink
            var banner = new Panel
            {
                Location  = new Point(10, 158),
                Size      = new Size(1360, panelH),
                BackColor = Color.FromArgb(250, 242, 246)
            };

            banner.Paint += (s, pe) =>
            {
                var g = pe.Graphics;
                // Franja inferior en brand pink
                using (var br = new SolidBrush(Color.FromArgb(210, 100, 135)))
                    g.FillRectangle(br, 0, panelH - 3, banner.Width, 3);
                // Separadores verticales muy suaves
                using (var pen = new Pen(Color.FromArgb(230, 210, 220), 1))
                    for (int i = 1; i < n; i++)
                        g.DrawLine(pen, i * cellW, 8, i * cellW, panelH - 10);
            };

            var titulos = new[] { "Ítems en catálogo", "Subastas cerradas", "Desiertos", "Monto recaudado", "Ingresados hoy" };
            var valLabels = new Label[n];

            for (int i = 0; i < n; i++)
            {
                int x = i * cellW;

                var lblVal = new Label
                {
                    Text      = "—",
                    Location  = new Point(x, 6),
                    Size      = new Size(cellW, 33),
                    Font      = new Font("Segoe UI", 15F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(52, 28, 40),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.Transparent
                };
                var lblTit = new Label
                {
                    Text      = titulos[i],
                    Location  = new Point(x, 39),
                    Size      = new Size(cellW, 19),
                    Font      = new Font("Segoe UI", 7.5F, FontStyle.Regular),
                    ForeColor = Color.FromArgb(175, 80, 115),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.Transparent
                };

                banner.Controls.Add(lblVal);
                banner.Controls.Add(lblTit);
                valLabels[i] = lblVal;
            }

            _kpiTotalVal      = valLabels[0];
            _kpiCerradasVal   = valLabels[1];
            _kpiDesiertoVal   = valLabels[2];
            _kpiMontoVal      = valLabels[3];
            _kpiIngresadosVal = valLabels[4];

            this.Controls.Add(banner);
            banner.BringToFront();

            rtbReporte.Top    += panelH + 4;
            rtbReporte.Height -= panelH + 4;
        }

        private void ActualizarKPIs(DateTime fecha)
        {
            try
            {
                var historial  = _subastaBll.ObtenerHistorial();
                var deHoy      = historial.Where(r => r.FechaHora.Date == fecha.Date).ToList();
                int cerradas   = deHoy.Count;
                decimal monto  = deHoy.Sum(r => r.PrecioFinal);
                int desiertos  = _catalogo.Count(u => u.Estado == EstadoUnidad.Desierta);
                int ingresados = _catalogo.Count(u => u.FechaIngreso.Date == fecha.Date);

                _kpiTotalVal.Text      = _catalogo.Count.ToString();
                _kpiCerradasVal.Text   = cerradas.ToString();
                _kpiDesiertoVal.Text   = desiertos.ToString();
                _kpiMontoVal.Text      = $"${monto:N0}";
                _kpiIngresadosVal.Text = ingresados.ToString();
            }
            catch { /* silencioso */ }
        }

        // ── Menús de exportación ────────────────────────────────────────────────
        private void ConfigurarMenusExportar()
        {
            _menuExportar = new ContextMenuStrip();
            _menuExportar.Items.Add("Guardar como .TXT", null, (s, e) => ExportarContenido(esPdf: false, esComparacion: false));
            _menuExportar.Items.Add("Guardar como PDF",  null, (s, e) => ExportarContenido(esPdf: true,  esComparacion: false));

            _menuExportarComp = new ContextMenuStrip();
            _menuExportarComp.Items.Add("Guardar comparación como .TXT", null, (s, e) => ExportarContenido(esPdf: false, esComparacion: true));
            _menuExportarComp.Items.Add("Guardar comparación como PDF",  null, (s, e) => ExportarContenido(esPdf: true,  esComparacion: true));
        }

        private void ExportarContenido(bool esPdf, bool esComparacion)
        {
            try
            {
                string extension = esPdf ? "pdf" : "txt";
                string filtro    = esPdf
                    ? "PDF (*.pdf)|*.pdf"
                    : "Archivo de texto (*.txt)|*.txt";

                string nombreBase = esComparacion
                    ? $"Comparacion_{dtpJornada.Value:yyyyMMdd}_vs_{dtpJornada2.Value:yyyyMMdd}"
                    : $"ReporteJornada_{dtpJornada.Value:yyyyMMdd}";

                string titulo = esComparacion
                    ? $"Comparación de Jornadas — {dtpJornada.Value:dd/MM/yyyy} vs {dtpJornada2.Value:dd/MM/yyyy}"
                    : $"Reporte de Jornada — {dtpJornada.Value:dd/MM/yyyy}";

                using (var dlg = new SaveFileDialog())
                {
                    dlg.Title            = esPdf ? "Exportar como PDF" : "Exportar como TXT";
                    dlg.Filter           = filtro;
                    dlg.FileName         = $"{nombreBase}.{extension}";
                    dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                    if (dlg.ShowDialog() != DialogResult.OK) return;

                    if (esPdf)
                        PdfExporter.ExportarReporte(dlg.FileName, titulo, rtbReporte.Text);
                    else
                        File.WriteAllText(dlg.FileName, rtbReporte.Text, System.Text.Encoding.UTF8);

                    lblStatus.Text = $"Exportado: {Path.GetFileName(dlg.FileName)}";
                    MessageBox.Show($"Archivo exportado:\n{dlg.FileName}", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al exportar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Handlers de botones ─────────────────────────────────────────────────
        private void btnGenerar_Click(object sender, EventArgs e) => GenerarReporte();

        private void dtpJornada_ValueChanged(object sender, EventArgs e) => GenerarReporte();

        private void btnExportar_Click(object sender, EventArgs e)
        {
            _menuExportar.Show(btnExportar, new Point(0, btnExportar.Height));
        }

        private void btnExportarComp_Click(object sender, EventArgs e)
        {
            _menuExportarComp.Show(btnExportarComp, new Point(0, btnExportarComp.Height));
        }

        private void btnLimpiar_Click(object sender, EventArgs e) => GenerarReporte();

        private void btnComparar_Click(object sender, EventArgs e)
        {
            try
            {
                string texto = _servicio.GenerarComparacion(_catalogo, dtpJornada.Value.Date, dtpJornada2.Value.Date);
                rtbReporte.Text = texto;
                lblStatus.Text  = $"Comparación generada — {DateTime.Now:HH:mm:ss}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarReporte()
        {
            try
            {
                var fecha = dtpJornada.Value.Date;
                string texto = _servicio.Generar(_catalogo, fecha);
                rtbReporte.Text = texto;
                lblStatus.Text  = $"Reporte generado — {DateTime.Now:HH:mm:ss}";
                if (_kpiTotalVal != null) ActualizarKPIs(fecha);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
