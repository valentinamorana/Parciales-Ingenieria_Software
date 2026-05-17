using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using AlmonedaNacional.BLL;
using AlmonedaNacional.Servicios.Composite;

namespace AlmonedaNacional.GUI
{
    // RF-13: Reporte de Jornada — recorre el Composite y muestra historial del día
    public partial class frmReporte : Form
    {
        private readonly ReporteJornada         _servicio;
        private readonly List<IUnidadDeVenta>   _catalogo;

        public frmReporte(List<IUnidadDeVenta> catalogo)
        {
            InitializeComponent();
            _catalogo = catalogo;
            _servicio = new ReporteJornada();
        }

        private void frmReporte_Load(object sender, EventArgs e)
        {
            dtpJornada.Value = DateTime.Today;
            GenerarReporte();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            GenerarReporte();
        }

        private void GenerarReporte()
        {
            try
            {
                string texto = _servicio.Generar(_catalogo, dtpJornada.Value.Date);
                rtbReporte.Text = texto;
                lblStatus.Text = $"Reporte generado — {DateTime.Now:HH:mm:ss}";
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
    }
}
