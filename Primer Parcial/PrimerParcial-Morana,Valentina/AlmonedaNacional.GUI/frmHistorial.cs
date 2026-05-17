using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AlmonedaNacional.BE;
using AlmonedaNacional.BLL;

namespace AlmonedaNacional.GUI
{
    // RF-13: Historial de subastas cerradas — lee desde la BD vía SubastaBLL
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
                {
                    tabla.Rows.Add(
                        r.Id,
                        r.NombreUnidadVenta,
                        r.PrecioBase,
                        r.PrecioFinal,
                        r.NombreGanador,
                        r.EmailGanador,
                        r.FechaHora.ToString("dd/MM/yyyy HH:mm:ss"));
                }

                dgvHistorial.DataSource = tabla;

                if (dgvHistorial.Columns.Contains("Precio Base"))
                    dgvHistorial.Columns["Precio Base"].DefaultCellStyle.Format  = "C2";
                if (dgvHistorial.Columns.Contains("Precio Final"))
                    dgvHistorial.Columns["Precio Final"].DefaultCellStyle.Format = "C2";

                lblTotal.Text = $"Total de subastas registradas: {lista.Count}";
                dgvPujas.DataSource = null;
            }
            catch (Exception ex)
            {
                lblTotal.Text = "Sin conexión a BD — mostrando datos de ejemplo";
                CargarDatosDemo();
                _ = ex;
            }
        }

        private void CargarDatosDemo()
        {
            var tabla = new System.Data.DataTable();
            tabla.Columns.Add("ID",             typeof(int));
            tabla.Columns.Add("Unidad de Venta");
            tabla.Columns.Add("Precio Base",    typeof(decimal));
            tabla.Columns.Add("Precio Final",   typeof(decimal));
            tabla.Columns.Add("Ganador");
            tabla.Columns.Add("Email Ganador");
            tabla.Columns.Add("Fecha / Hora");

            tabla.Rows.Add(1, "Taladro Industrial",            15000m,  21500m, "Carlos Méndez",   "carlos@web.com",  "15/05/2026 10:30:00");
            tabla.Rows.Add(2, "Lote Herramientas Manuales",    23000m,  38000m, "Laura Rodríguez", "laura@movil.com", "15/05/2026 11:45:00");
            tabla.Rows.Add(3, "Máquina CNC",                  250000m, 310000m, "Tomás García",    "tomas@sala.com",  "15/05/2026 14:00:00");

            dgvHistorial.DataSource = tabla;

            if (dgvHistorial.Columns.Contains("Precio Base"))
                dgvHistorial.Columns["Precio Base"].DefaultCellStyle.Format  = "C2";
            if (dgvHistorial.Columns.Contains("Precio Final"))
                dgvHistorial.Columns["Precio Final"].DefaultCellStyle.Format = "C2";

            dgvPujas.DataSource = null;
            CargarPujasDemo(1);
        }

        // ── Selección de subasta → cargar sus pujas ──────────────────────────

        private void dgvHistorial_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHistorial.SelectedRows.Count == 0)
            {
                dgvPujas.DataSource = null;
                return;
            }

            var idCell = dgvHistorial.SelectedRows[0].Cells["ID"].Value;
            if (idCell == null || idCell == DBNull.Value) return;

            int idSubasta = Convert.ToInt32(idCell);

            try
            {
                IList<Puja> pujas = _bll.ObtenerPujas(idSubasta);
                CargarTablasPujas(pujas);
            }
            catch
            {
                CargarPujasDemo(idSubasta);
            }
        }

        private void CargarTablasPujas(IList<Puja> pujas)
        {
            var tabla = BuildTablaPujas();
            foreach (var p in pujas)
                tabla.Rows.Add(
                    p.NombreUsuario,
                    p.Monto,
                    p.FechaHora.ToString("dd/MM/yyyy HH:mm:ss"),
                    p.Estado.ToString(),
                    p.MotivoRechazo ?? "—");

            dgvPujas.DataSource = tabla;
            if (dgvPujas.Columns.Contains("Monto"))
                dgvPujas.Columns["Monto"].DefaultCellStyle.Format = "C2";
        }

        private void CargarPujasDemo(int idSubasta)
        {
            var tabla = BuildTablaPujas();
            tabla.Rows.Add("Carlos Méndez",   16000m, "15/05/2026 10:12:00", "Aceptada",  "—");
            tabla.Rows.Add("Laura Rodríguez", 15500m, "15/05/2026 10:13:00", "Rechazada", "Monto inferior al precio actual");
            tabla.Rows.Add("Tomás García",    18000m, "15/05/2026 10:20:00", "Aceptada",  "—");
            tabla.Rows.Add("Carlos Méndez",   21500m, "15/05/2026 10:28:00", "Aceptada",  "—");

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

        // ── Color de fila según estado ────────────────────────────────────────

        private void dgvPujas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvPujas.Rows[e.RowIndex].IsNewRow) return;

            var estadoCell = dgvPujas.Rows[e.RowIndex].Cells["Estado"].Value?.ToString();
            if (estadoCell == "Aceptada")
            {
                dgvPujas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(210, 240, 210);
                dgvPujas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(30, 100, 30);
            }
            else if (estadoCell == "Rechazada")
            {
                dgvPujas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(250, 210, 210);
                dgvPujas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(140, 20, 20);
            }
        }
    }
}
