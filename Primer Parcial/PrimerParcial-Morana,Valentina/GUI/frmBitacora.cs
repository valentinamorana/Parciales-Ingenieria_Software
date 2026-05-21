using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BE;
using BLL;

namespace GUI
{
    // Auditoría del sistema — RF plus: registro y consulta de todas las operaciones
    public partial class frmBitacora : Form
    {
        private readonly BitacoraBLL _bll = new BitacoraBLL();
        private DataTable _tablaActual;

        public frmBitacora()
        {
            InitializeComponent();
        }

        private void frmBitacora_Load(object sender, EventArgs e)
        {
            CargarFiltros();
            Buscar();
            // Conectar después del Buscar() inicial para no disparar queries extra al cargar
            cmbCriticidad.SelectedIndexChanged += (s, ev) => Buscar();
            cmbOperacion.SelectedIndexChanged  += (s, ev) => Buscar();
            nudDias.ValueChanged               += (s, ev) => Buscar();
        }

        private void CargarFiltros()
        {
            cmbCriticidad.Items.Clear();
            cmbCriticidad.Items.AddRange(new object[] { "Todas", "Baja", "Media", "Alta", "IntentosLogin", "BloqueosCuenta" });
            cmbCriticidad.SelectedIndex = 0;

            cmbOperacion.Items.Clear();
            cmbOperacion.Items.AddRange(new object[]
            {
                "Todas", "LOGIN", "LOGIN_FALLIDO", "BLOQUEO_CUENTA", "INICIAR_SUBASTA",
                "CERRAR_SUBASTA", "CIERRE_AUTOMATICO",
                "OFERTA_ACEPTADA", "OFERTA_RECHAZADA", "LOGOUT"
            });
            cmbOperacion.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e) => Buscar();

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            nudDias.Value = 0;
            cmbCriticidad.SelectedIndex = 0;
            cmbOperacion.SelectedIndex  = 0;
            Buscar();
        }

        private void Buscar()
        {
            try
            {
                int    dias      = (int)nudDias.Value;
                string crit      = cmbCriticidad.SelectedItem?.ToString();
                string operacion = cmbOperacion.SelectedItem?.ToString();

                IList<EventoBitacora> lista = _bll.ObtenerFiltrado(dias, crit, operacion);
                CargarGrilla(lista);
                lblConteo.Text = $"Registros: {lista.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrilla(IList<EventoBitacora> lista)
        {
            dgvBitacora.DataSource = null;

            var tabla = new System.Data.DataTable();
            tabla.Columns.Add("ID",          typeof(int));
            tabla.Columns.Add("Fecha/Hora");
            tabla.Columns.Add("Operación");
            tabla.Columns.Add("Detalle");
            tabla.Columns.Add("Criticidad");
            tabla.Columns.Add("Martillero");

            foreach (var e in lista)
                tabla.Rows.Add(
                    e.Id,
                    e.Fecha.ToString("dd/MM/yyyy HH:mm:ss"),
                    e.Operacion,
                    e.Detalle,
                    e.Criticidad.ToString(),
                    e.NombreMartillero);

            dgvBitacora.DataSource = tabla;
            _tablaActual = tabla;
        }

        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            try
            {
                if (_tablaActual == null || _tablaActual.Rows.Count == 0)
                {
                    MessageBox.Show("No hay registros para exportar.", "Sin datos",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (var dlg = new SaveFileDialog())
                {
                    dlg.Title            = "Exportar bitácora como PDF";
                    dlg.Filter           = "PDF (*.pdf)|*.pdf";
                    dlg.FileName         = $"Bitacora_{DateTime.Now:yyyyMMdd_HHmm}.pdf";
                    dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        string crit = cmbCriticidad.SelectedItem?.ToString() ?? "Todas";
                        string op   = cmbOperacion.SelectedItem?.ToString()  ?? "Todas";
                        int    dias = (int)nudDias.Value;
                        string filtros = $"Criticidad: {crit}  |  Operación: {op}  |  Días: {(dias == 0 ? "todos" : dias.ToString())}";

                        PdfExporter.ExportarBitacora(dlg.FileName, _tablaActual, filtros);
                        lblConteo.Text = $"Registros: {_tablaActual.Rows.Count}  —  PDF exportado";
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

        // Coloreo de filas por criticidad (igual a WardrobeFlow Bitácora)
        private void dgvBitacora_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvBitacora.Rows[e.RowIndex].IsNewRow) return;

            string crit = dgvBitacora.Rows[e.RowIndex].Cells["Criticidad"].Value?.ToString();
            switch (crit)
            {
                case "Baja":
                    dgvBitacora.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(220, 245, 220);
                    dgvBitacora.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(30, 100, 30);
                    break;
                case "Media":
                    dgvBitacora.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 250, 210);
                    dgvBitacora.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(120, 80, 0);
                    break;
                case "Alta":
                    dgvBitacora.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 215, 215);
                    dgvBitacora.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(140, 20, 20);
                    break;
                case "IntentosLogin":
                    dgvBitacora.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 200);
                    dgvBitacora.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(150, 80, 0);
                    break;
                case "BloqueosCuenta":
                    dgvBitacora.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(230, 200, 255);
                    dgvBitacora.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(80, 0, 140);
                    break;
            }
        }
    }
}
