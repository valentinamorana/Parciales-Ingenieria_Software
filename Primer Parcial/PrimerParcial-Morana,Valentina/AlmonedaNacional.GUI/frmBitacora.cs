using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AlmonedaNacional.BE;
using AlmonedaNacional.BLL;

namespace AlmonedaNacional.GUI
{
    // Auditoría del sistema — RF plus: registro y consulta de todas las operaciones
    public partial class frmBitacora : Form
    {
        private readonly BitacoraBLL _bll = new BitacoraBLL();

        public frmBitacora()
        {
            InitializeComponent();
        }

        private void frmBitacora_Load(object sender, EventArgs e)
        {
            CargarFiltros();
            Buscar();
        }

        private void CargarFiltros()
        {
            cmbCriticidad.Items.Clear();
            cmbCriticidad.Items.AddRange(new object[] { "Todas", "Baja", "Media", "Alta" });
            cmbCriticidad.SelectedIndex = 0;

            cmbOperacion.Items.Clear();
            cmbOperacion.Items.AddRange(new object[]
            {
                "Todas", "LOGIN", "LOGIN_FALLIDO", "INICIAR_SUBASTA",
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
            }
        }
    }
}
