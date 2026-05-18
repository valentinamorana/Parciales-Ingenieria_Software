using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Servicios.Composite;

namespace GUI
{
    // Patrón COMPOSITE — demuestra RF-01/02/03/04.
    // El catálogo es compartido con frmSubasta vía frmPrincipal (misma referencia).
    public partial class frmCatalogo : Form
    {
        private readonly List<IUnidadDeVenta> _catalogo;
        private List<IUnidadDeVenta> _vista;

        public frmCatalogo(List<IUnidadDeVenta> catalogo)
        {
            InitializeComponent();
            _catalogo = catalogo;
        }

        private void frmCatalogo_Load(object sender, EventArgs e)
        {
            cmbFiltroTipo.Items.AddRange(new object[] { "Todos", "Artículos", "Lotes" });
            cmbFiltroTipo.SelectedIndex = 0;
            RefrescarVistas();
        }

        // ── Vistas ───────────────────────────────────────────────────────────

        private void RefrescarVistas()
        {
            _vista = AplicarFiltro();
            LlenarTreeView();
            LlenarGrilla();

            int nArticulos = 0, nLotes = 0;
            decimal totalPrecio = 0;
            foreach (var u in _catalogo)
            {
                if (u is ArticuloSimple) nArticulos++;
                else if (u is LoteArticulos) nLotes++;
                totalPrecio += u.CalcularPrecioBase();
            }
            lblContadorCatalogo.Text = $"{nArticulos} artículos  •  {nLotes} lotes  |  ${totalPrecio:N2}";

            bool hayFiltro = _vista.Count != _catalogo.Count;
            lblStatus.Text = hayFiltro
                ? $"Mostrando {_vista.Count} de {_catalogo.Count} unidades."
                : $"{_catalogo.Count} unidades en el catálogo.";
        }

        private List<IUnidadDeVenta> AplicarFiltro()
        {
            string busqueda = txtBuscar.Text.Trim().ToLower();
            string tipo     = cmbFiltroTipo.SelectedItem?.ToString() ?? "Todos";

            decimal precioMin = 0;
            decimal precioMax = decimal.MaxValue;
            if (decimal.TryParse(txtPrecioMin.Text.Trim(), out decimal pMin)) precioMin = pMin;
            if (decimal.TryParse(txtPrecioMax.Text.Trim(), out decimal pMax)) precioMax = pMax;

            var resultado = new List<IUnidadDeVenta>();
            foreach (var u in _catalogo)
            {
                bool matchTipo = tipo == "Todos"
                    || (tipo == "Artículos" && u is ArticuloSimple)
                    || (tipo == "Lotes"     && u is LoteArticulos);
                bool matchNombre = string.IsNullOrEmpty(busqueda)
                    || u.Nombre.ToLower().Contains(busqueda);
                decimal precio = u.CalcularPrecioBase();
                bool matchPrecio = precio >= precioMin && precio <= precioMax;
                if (matchTipo && matchNombre && matchPrecio) resultado.Add(u);
            }
            return resultado;
        }

        private void FiltroChanged(object sender, EventArgs e) => RefrescarVistas();

        private void txtPrecio_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != ',' && e.KeyChar != '.')
                e.Handled = true;
        }

        private void LlenarTreeView()
        {
            treeViewCatalogo.Nodes.Clear();
            var nArticulos = new TreeNode("Artículos Simples");
            var nLotes     = new TreeNode("Lotes");

            foreach (var u in _vista)
            {
                if (u is ArticuloSimple art)
                    nArticulos.Nodes.Add(new TreeNode($"{art.Nombre}  —  ${art.PrecioBase:N2}") { Tag = art });
                else if (u is LoteArticulos lote)
                    nLotes.Nodes.Add(CrearNodoLote(lote));
            }

            treeViewCatalogo.Nodes.Add(nArticulos);
            treeViewCatalogo.Nodes.Add(nLotes);
            treeViewCatalogo.ExpandAll();
        }

        private TreeNode CrearNodoLote(LoteArticulos lote)
        {
            var nodo = new TreeNode($"[LOTE] {lote.Nombre}  —  ${lote.CalcularPrecioBase():N2}") { Tag = lote };
            foreach (var hijo in lote.ObtenerHijos())
            {
                if (hijo is ArticuloSimple art)
                    nodo.Nodes.Add(new TreeNode($"{art.Nombre}  —  ${art.PrecioBase:N2}") { Tag = art });
                else if (hijo is LoteArticulos sublote)
                    nodo.Nodes.Add(CrearNodoLote(sublote));
            }
            return nodo;
        }

        private void LlenarGrilla()
        {
            dgvCatalogo.DataSource = null;
            var tabla = new System.Data.DataTable();
            tabla.Columns.Add("Tipo");
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("Precio Base", typeof(decimal));

            foreach (var u in _vista)
                tabla.Rows.Add(u is LoteArticulos ? "LOTE" : "Artículo", u.Nombre, u.CalcularPrecioBase());

            dgvCatalogo.DataSource = tabla;
            if (dgvCatalogo.Columns.Contains("Precio Base"))
                dgvCatalogo.Columns["Precio Base"].DefaultCellStyle.Format = "C2";
        }

        // ── Eventos de selección ─────────────────────────────────────────────

        private void treeViewCatalogo_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag is IUnidadDeVenta u) MostrarDetalle(u);
        }

        private void dgvCatalogo_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCatalogo.SelectedRows.Count == 0) return;
            string nombre = dgvCatalogo.SelectedRows[0].Cells["Nombre"].Value?.ToString();
            var u = _vista.Find(x => x.Nombre == nombre);
            if (u != null) MostrarDetalle(u);
        }

        private void MostrarDetalle(IUnidadDeVenta unidad)
        {
            rtbDescripcion.Clear();
            rtbDescripcion.AppendText(unidad.ObtenerDescripcion());
            lblPrecioBase.Text = $"$ {unidad.CalcularPrecioBase():N2}";
        }

        // ── RF-01: Agregar artículo ──────────────────────────────────────────

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                var art = DialogoAgregarArticulo();
                if (art == null) return;
                _catalogo.Add(art);
                RefrescarVistas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ArticuloSimple DialogoAgregarArticulo()
        {
            using (var dlg = new Form())
            {
                dlg.Text            = "Nuevo Artículo Simple — RF-01";
                dlg.ClientSize      = new Size(360, 230);
                dlg.StartPosition   = FormStartPosition.CenterParent;
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.MaximizeBox     = false;
                dlg.MinimizeBox     = false;
                dlg.BackColor       = Color.FromArgb(252, 228, 235);

                var header = new Panel { Location = Point.Empty, Size = new Size(360, 38), BackColor = Color.FromArgb(210, 100, 135) };
                var lblH   = new Label  { Text = "Artículo Simple (Composite — Hoja)", Dock = DockStyle.Fill, ForeColor = Color.White, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter };
                header.Controls.Add(lblH);
                dlg.Controls.Add(header);

                TextBox txtNombre = Campo(dlg, "Nombre:",          50);  txtNombre.MaxLength = 200;
                TextBox txtDesc   = Campo(dlg, "Descripción:",     90);  txtDesc.MaxLength   = 500;
                TextBox txtPrecio = Campo(dlg, "Precio Base ($):", 130); txtPrecio.MaxLength = 15;

                var btnOk  = Boton(dlg, "Agregar",   DialogResult.OK,     80, 178, Color.FromArgb(210, 100, 135), Color.White);
                var btnCan = Boton(dlg, "Cancelar",  DialogResult.Cancel, 190, 178, Color.FromArgb(200, 200, 210), Color.FromArgb(64,64,64));
                dlg.AcceptButton = btnOk;
                dlg.CancelButton = btnCan;

                if (dlg.ShowDialog(this) != DialogResult.OK) return null;

                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                    throw new InvalidOperationException("El nombre es obligatorio.");
                if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
                    throw new InvalidOperationException("Ingresá un precio mayor a cero.");

                return new ArticuloSimple
                {
                    Id          = _catalogo.Count + 1,
                    Nombre      = txtNombre.Text.Trim(),
                    Descripcion = txtDesc.Text.Trim(),
                    PrecioBase  = precio
                };
            }
        }

        // ── RF-01/02: Agregar lote ───────────────────────────────────────────

        private void btnAgregarLote_Click(object sender, EventArgs e)
        {
            try
            {
                if (_catalogo.Count == 0)
                {
                    MessageBox.Show("Agregá al menos un artículo antes de crear un lote.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var lote = DialogoAgregarLote();
                if (lote == null) return;
                _catalogo.Add(lote);
                RefrescarVistas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private LoteArticulos DialogoAgregarLote()
        {
            using (var dlg = new Form())
            {
                dlg.Text            = "Nuevo Lote — RF-01/02";
                dlg.ClientSize      = new Size(380, 340);
                dlg.StartPosition   = FormStartPosition.CenterParent;
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.MaximizeBox     = false;
                dlg.MinimizeBox     = false;
                dlg.BackColor       = Color.FromArgb(252, 228, 235);

                var header = new Panel { Location = Point.Empty, Size = new Size(380, 38), BackColor = Color.FromArgb(210, 100, 135) };
                var lblH   = new Label  { Text = "Lote (Composite — Compuesto, RF-02)", Dock = DockStyle.Fill, ForeColor = Color.White, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter };
                header.Controls.Add(lblH);
                dlg.Controls.Add(header);

                TextBox txtNombre = Campo(dlg, "Nombre del lote:", 50);  txtNombre.MaxLength = 200;

                var lblItems = new Label { Text = "Unidades a incluir:", Location = new Point(12, 92), AutoSize = true, Font = new Font("Segoe UI", 9F), ForeColor = Color.FromArgb(64, 64, 64) };
                dlg.Controls.Add(lblItems);

                var clb = new CheckedListBox
                {
                    Location    = new Point(12, 112),
                    Size        = new Size(354, 160),
                    BackColor   = Color.FromArgb(245, 245, 248),
                    BorderStyle = BorderStyle.FixedSingle,
                    Font        = new Font("Segoe UI", 9F)
                };
                foreach (var u in _catalogo) clb.Items.Add(u.Nombre, false);
                dlg.Controls.Add(clb);

                var btnOk  = Boton(dlg, "Crear Lote",  DialogResult.OK,     60, 286, Color.FromArgb(210, 100, 135), Color.White);
                var btnCan = Boton(dlg, "Cancelar",    DialogResult.Cancel, 210, 286, Color.FromArgb(200, 200, 210), Color.FromArgb(64,64,64));
                dlg.AcceptButton = btnOk;
                dlg.CancelButton = btnCan;

                if (dlg.ShowDialog(this) != DialogResult.OK) return null;

                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                    throw new InvalidOperationException("El nombre es obligatorio.");
                if (clb.CheckedItems.Count == 0)
                    throw new InvalidOperationException("Seleccioná al menos una unidad para el lote.");

                var lote = new LoteArticulos { Id = _catalogo.Count + 100, Nombre = txtNombre.Text.Trim() };
                foreach (string nombre in clb.CheckedItems)
                {
                    var u = _catalogo.Find(x => x.Nombre == nombre);
                    if (u != null) lote.Agregar(u);
                }
                return lote;
            }
        }

        // ── Helpers de UI para dialogs inline ────────────────────────────────

        private static TextBox Campo(Form f, string etiqueta, int y)
        {
            f.Controls.Add(new Label { Text = etiqueta, Location = new Point(12, y + 3), AutoSize = true, Font = new Font("Segoe UI", 9F), ForeColor = Color.FromArgb(64, 64, 64) });
            var txt = new TextBox { Location = new Point(160, y), Size = new Size(180, 24), BackColor = Color.FromArgb(245, 245, 248) };
            f.Controls.Add(txt);
            return txt;
        }

        private static Button Boton(Form f, string texto, DialogResult dr, int x, int y, Color bg, Color fg)
        {
            var btn = new Button
            {
                Text = texto, DialogResult = dr,
                Location = new Point(x, y), Size = new Size(100, 30),
                BackColor = bg, ForeColor = fg,
                FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            btn.FlatAppearance.BorderSize = 0;
            f.Controls.Add(btn);
            return btn;
        }
    }
}
