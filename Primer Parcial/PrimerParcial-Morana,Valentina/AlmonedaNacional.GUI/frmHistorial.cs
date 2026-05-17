using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AlmonedaNacional.BE;
using AlmonedaNacional.BLL;

namespace AlmonedaNacional.GUI
{
    public partial class frmHistorial : Form
    {
        private SubastaBLL _bll;

        public frmHistorial()
        {
            InitializeComponent();
            _bll = new SubastaBLL();
        }

        private void frmHistorial_Load(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        private void CargarHistorial()
        {
            try
            {
                IList<ResultadoSubasta> lista = _bll.ObtenerHistorial();

                dgvHistorial.DataSource = null;

                var tabla = new System.Data.DataTable();
                tabla.Columns.Add("ID",             typeof(int));
                tabla.Columns.Add("Unidad de Venta");
                tabla.Columns.Add("Precio Base",    typeof(decimal));
                tabla.Columns.Add("Precio Final",   typeof(decimal));
                tabla.Columns.Add("Ganador");
                tabla.Columns.Add("Email Ganador");
                tabla.Columns.Add("Fecha / Hora");

                foreach (var r in lista)
                    tabla.Rows.Add(
                        r.Id, r.NombreUnidadVenta, r.PrecioBase, r.PrecioFinal,
                        r.NombreGanador, r.EmailGanador,
                        r.FechaHora.ToString("dd/MM/yyyy HH:mm:ss"));

                dgvHistorial.DataSource = tabla;

                if (dgvHistorial.Columns.Contains("Precio Base"))
                    dgvHistorial.Columns["Precio Base"].DefaultCellStyle.Format  = "C2";
                if (dgvHistorial.Columns.Contains("Precio Final"))
                    dgvHistorial.Columns["Precio Final"].DefaultCellStyle.Format = "C2";

                lblTotal.Text   = $"Total de subastas registradas: {lista.Count}";
                dgvPujas.DataSource = null;
            }
            catch (Exception ex)
            {
                lblTotal.Text = $"Error al conectar con la BD: {ex.Message}";
                dgvHistorial.DataSource = null;
                dgvPujas.DataSource     = null;
            }
        }

        private void dgvHistorial_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHistorial.SelectedRows.Count == 0) { dgvPujas.DataSource = null; return; }

            var idCell = dgvHistorial.SelectedRows[0].Cells["ID"].Value;
            if (idCell == null || idCell == DBNull.Value) return;

            int idSubasta = Convert.ToInt32(idCell);
            try
            {
                IList<Puja> pujas = _bll.ObtenerPujas(idSubasta);
                CargarTablasPujas(pujas);
            }
            catch (Exception ex)
            {
                dgvPujas.DataSource = null;
                MessageBox.Show($"Error al cargar pujas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarTablasPujas(IList<Puja> pujas)
        {
            var tabla = BuildTablaPujas();
            foreach (var p in pujas)
                tabla.Rows.Add(
                    p.NombreUsuario, p.Monto,
                    p.FechaHora.ToString("dd/MM/yyyy HH:mm:ss"),
                    p.Estado.ToString(), p.MotivoRechazo ?? "—");

            dgvPujas.DataSource = tabla;
            if (dgvPujas.Columns.Contains("Monto"))
                dgvPujas.Columns["Monto"].DefaultCellStyle.Format = "C2";
        }

        private static System.Data.DataTable BuildTablaPujas()
        {
            var t = new System.Data.DataTable();
            t.Columns.Add("Usuario");
            t.Columns.Add("Monto",      typeof(decimal));
            t.Columns.Add("Fecha/Hora");
            t.Columns.Add("Estado");
            t.Columns.Add("Motivo");
            return t;
        }

        private void dgvPujas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvPujas.Rows[e.RowIndex].IsNewRow) return;

            var estado = dgvPujas.Rows[e.RowIndex].Cells["Estado"].Value?.ToString();
            if (estado == "Aceptada")
            {
                dgvPujas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(210, 240, 210);
                dgvPujas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(30, 100, 30);
            }
            else if (estado == "Rechazada")
            {
                dgvPujas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(250, 210, 210);
                dgvPujas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(140, 20, 20);
            }
        }
    }
}
