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
        private readonly ReporteJornada         _servicio;
        private readonly List<IUnidadDeVenta>   _catalogo;
        private readonly SubastaBLL             _subastaBll = new SubastaBLL();

        // KPI cards
        private Label _kpiTotalVal, _kpiCerradasVal, _kpiDesiertoVal, _kpiMontoVal, _kpiIngresadosVal;

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

            // ── Panel de KPIs ────────────────────────────────────────────────
            const int gap = 10, n = 5, panelH = 74;
            int cardW = (1360 - (n + 1) * gap) / n;  // ~258px

            var panelKPI = new Panel
            {
                Location  = new Point(10, 158),
                Size      = new Size(1360, panelH),
                BackColor = Color.Transparent
            };

            panelKPI.Controls.Add(CrearTarjetaKPI("Ítems en Catálogo", Color.FromArgb(225, 225, 235), Color.FromArgb(60, 60, 90),   0, cardW, gap, out _kpiTotalVal));
            panelKPI.Controls.Add(CrearTarjetaKPI("Subastas Cerradas", Color.FromArgb(210, 240, 215), Color.FromArgb(30, 100, 50),  1, cardW, gap, out _kpiCerradasVal));
            panelKPI.Controls.Add(CrearTarjetaKPI("Desiertos",         Color.FromArgb(255, 235, 200), Color.FromArgb(140, 80, 0),   2, cardW, gap, out _kpiDesiertoVal));
            panelKPI.Controls.Add(CrearTarjetaKPI("Monto Recaudado",   Color.FromArgb(255, 215, 230), Color.FromArgb(160, 40, 80),  3, cardW, gap, out _kpiMontoVal));
            panelKPI.Controls.Add(CrearTarjetaKPI("Ingresados Hoy",    Color.FromArgb(210, 235, 255), Color.FromArgb(30, 80, 160),  4, cardW, gap, out _kpiIngresadosVal));

            this.Controls.Add(panelKPI);
            // Mover rtbReporte para hacer lugar a los KPIs
            rtbReporte.Top    += panelH + 4;
            rtbReporte.Height -= panelH + 4;

            GenerarReporte();
        }

        private static Panel CrearTarjetaKPI(string titulo, Color bg, Color fg,
                                              int indice, int cardW, int gap,
                                              out Label lblValor)
        {
            var card = new Panel
            {
                Location  = new Point(gap + indice * (cardW + gap), 0),
                Size      = new Size(cardW, 70),
                BackColor = bg
            };

            card.Controls.Add(new Label
            {
                Text      = titulo,
                Location  = new Point(0, 7),
                Size      = new Size(cardW, 18),
                Font      = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = fg,
                TextAlign = ContentAlignment.MiddleCenter
            });

            lblValor = new Label
            {
                Text      = "—",
                Location  = new Point(0, 27),
                Size      = new Size(cardW, 38),
                Font      = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = fg,
                TextAlign = ContentAlignment.MiddleCenter
            };
            card.Controls.Add(lblValor);
            return card;
        }

        private void ActualizarKPIs(DateTime fecha)
        {
            try
            {
                var historial = _subastaBll.ObtenerHistorial();
                var deHoy     = historial.Where(r => r.FechaHora.Date == fecha.Date).ToList();
                int cerradas  = deHoy.Count;
                decimal monto = deHoy.Sum(r => r.PrecioFinal);
                int desiertos = _catalogo.Count(u => u.Estado == EstadoUnidad.Desierta);
                int ingresados = _catalogo.Count(u => u.FechaIngreso.Date == fecha.Date);

                _kpiTotalVal.Text      = _catalogo.Count.ToString();
                _kpiCerradasVal.Text   = cerradas.ToString();
                _kpiDesiertoVal.Text   = desiertos.ToString();
                _kpiMontoVal.Text      = $"${monto:N0}";
                _kpiIngresadosVal.Text = ingresados.ToString();
            }
            catch { /* silencioso — no interrumpe el reporte de texto */ }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            GenerarReporte();
        }

        private void dtpJornada_ValueChanged(object sender, EventArgs e)
        {
            GenerarReporte();
        }

        private void btnComparar_Click(object sender, EventArgs e)
        {
            try
            {
                string texto = _servicio.GenerarComparacion(_catalogo, dtpJornada.Value.Date, dtpJornada2.Value.Date);
                rtbReporte.Text = texto;
                lblStatus.Text = $"Comparación generada — {DateTime.Now:HH:mm:ss}";
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

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dlg = new SaveFileDialog())
                {
                    dlg.Title            = "Exportar reporte";
                    dlg.Filter           = "Archivo de texto (*.txt)|*.txt";
                    dlg.FileName         = $"ReporteJornada_{dtpJornada.Value:yyyyMMdd}.txt";
                    dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(dlg.FileName, rtbReporte.Text, System.Text.Encoding.UTF8);
                        lblStatus.Text = $"Exportado: {Path.GetFileName(dlg.FileName)}";
                        MessageBox.Show($"Reporte exportado:\n{dlg.FileName}", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al exportar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dlg = new SaveFileDialog())
                {
                    dlg.Title            = "Exportar reporte como PDF";
                    dlg.Filter           = "PDF (*.pdf)|*.pdf";
                    dlg.FileName         = $"ReporteJornada_{dtpJornada.Value:yyyyMMdd}.pdf";
                    dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        PdfExporter.ExportarReporte(
                            dlg.FileName,
                            $"Reporte de Jornada — {dtpJornada.Value:dd/MM/yyyy}",
                            rtbReporte.Text);
                        lblStatus.Text = $"PDF exportado: {Path.GetFileName(dlg.FileName)}";
                        MessageBox.Show($"PDF exportado:\n{dlg.FileName}", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al exportar PDF", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
