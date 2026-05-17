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
            }
            catch (Exception ex)
            {
                // Si no hay BD configurada mostramos mensaje informativo en lugar de crash
                lblTotal.Text = "Sin conexión a BD — mostrando datos de ejemplo";
                CargarDatosDemo();
                _ = ex; // supress warning; real apps would log
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
        }

        private void dgvHistorial_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHistorial.SelectedRows.Count == 0)
            {
                rtbDetalle.Clear();
                return;
            }

            var fila = dgvHistorial.SelectedRows[0];
            rtbDetalle.Clear();
            rtbDetalle.AppendText($"ID Subasta   : {fila.Cells["ID"].Value}\r\n");
            rtbDetalle.AppendText($"Unidad       : {fila.Cells["Unidad de Venta"].Value}\r\n");
            rtbDetalle.AppendText($"Precio Base  : {fila.Cells["Precio Base"].Value:C2}\r\n");
            rtbDetalle.AppendText($"Precio Final : {fila.Cells["Precio Final"].Value:C2}\r\n");
            rtbDetalle.AppendText($"Ganador      : {fila.Cells["Ganador"].Value}\r\n");
            rtbDetalle.AppendText($"Email        : {fila.Cells["Email Ganador"].Value}\r\n");
            rtbDetalle.AppendText($"Fecha/Hora   : {fila.Cells["Fecha / Hora"].Value}\r\n");
        }
    }
}
