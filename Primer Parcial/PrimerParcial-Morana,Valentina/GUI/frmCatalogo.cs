using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BE;
using BLL;
using Servicios.Composite;

namespace GUI
{
    // Patrón COMPOSITE — demuestra RF-01/02/03/04.
    public partial class frmCatalogo : Form
    {
        private readonly CatalogoBLL _bll = new CatalogoBLL();
        private List<IUnidadDeVenta> _catalogo = new List<IUnidadDeVenta>();
        private List<IUnidadDeVenta> _vista;
        private IUnidadDeVenta _seleccionada;

        private Button btnRefrescar;
        private Button btnLimpiarFiltros;
        private Button btnModificar;
        private Button btnRetirar;

        public frmCatalogo()
        {
            InitializeComponent();
        }

        private void frmCatalogo_Load(object sender, EventArgs e)
        {
            cmbFiltroTipo.Items.AddRange(new object[] { "Todos", "Artículos", "Lotes" });
            cmbFiltroTipo.SelectedIndex = 0;
            cmbFiltroEstado.Items.AddRange(new object[] { "Todos", "Disponible", "En Subasta", "Adjudicado", "Desierta", "Retirado" });
            cmbFiltroEstado.SelectedIndex = 0;
            dgvCatalogo.CellFormatting += dgvCatalogo_CellFormatting;

            // Acción buttons en pnlHeaderGrilla (derecha a izquierda)
            lblTituloGrilla.Dock       = DockStyle.None;
            lblTituloGrilla.AutoSize   = true;
            lblTituloGrilla.Location   = new Point(8, 7);
            btnRetirar          = CrearBotonCabecera("Retirar",         1015, Color.FromArgb(180, 70, 70),  btnRetirar_Click,         false);
            btnModificar        = CrearBotonCabecera("Modificar",        921, Color.FromArgb(210, 100, 135), btnModificar_Click,        false);
            btnLimpiarFiltros   = CrearBotonCabecera("Limpiar filtros",  799, Color.FromArgb(140, 120, 170), btnLimpiarFiltros_Click,   true);
            btnRefrescar        = CrearBotonCabecera("Refrescar",        705, Color.FromArgb(80,  140, 190), btnRefrescar_Click,        true);
            var btnIrSubasta    = CrearBotonCabecera("Ir a Subasta",     590, Color.FromArgb(60,  140, 100), btnIrSubasta_Click,        true);
            pnlHeaderGrilla.Controls.Add(btnRetirar);
            pnlHeaderGrilla.Controls.Add(btnModificar);
            pnlHeaderGrilla.Controls.Add(btnLimpiarFiltros);
            pnlHeaderGrilla.Controls.Add(btnRefrescar);
            pnlHeaderGrilla.Controls.Add(btnIrSubasta);

            CargarGrilla();
        }

        private Button CrearBotonCabecera(string texto, int x, Color bg, EventHandler handler, bool habilitado)
        {
            var btn = new Button
            {
                Text      = texto,
                Location  = new Point(x, 3),
                Size      = new Size(texto.Length > 10 ? 110 : 90, 22),
                BackColor = bg,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font      = new Font("Segoe UI", 8F, FontStyle.Bold),
                Enabled   = habilitado,
                Anchor    = AnchorStyles.Top | AnchorStyles.Right
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += handler;
            return btn;
        }

        public void CargarGrilla()
        {
            _seleccionada = null;
            try
            {
                _catalogo = _bll.ObtenerCatalogo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el catálogo:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            string busqueda    = txtBuscar.Text.Trim().ToLower();
            string tipo        = cmbFiltroTipo.SelectedItem?.ToString()    ?? "Todos";
            string estadoFiltro = cmbFiltroEstado.SelectedItem?.ToString() ?? "Todos";

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
                bool matchPrecio  = precio >= precioMin && precio <= precioMax;
                bool matchEstado  = estadoFiltro == "Todos"
                    || EstadoToString(u.Estado) == estadoFiltro;
                if (matchTipo && matchNombre && matchPrecio && matchEstado) resultado.Add(u);
            }
            return resultado;
        }

        private static string EstadoToString(EstadoUnidad estado)
        {
            switch (estado)
            {
                case EstadoUnidad.EnSubasta:  return "En Subasta";
                case EstadoUnidad.Adjudicado: return "Adjudicado";
                case EstadoUnidad.Desierta:   return "Desierta";
                case EstadoUnidad.Retirado:   return "Retirado";
                default:                      return "Disponible";
            }
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
            tabla.Columns.Add("Estado");

            foreach (var u in _vista)
                tabla.Rows.Add(u is LoteArticulos ? "LOTE" : "Artículo", u.Nombre,
                               u.CalcularPrecioBase(), EstadoToString(u.Estado));

            dgvCatalogo.DataSource = tabla;
            if (dgvCatalogo.Columns.Contains("Precio Base"))
                dgvCatalogo.Columns["Precio Base"].DefaultCellStyle.Format = "C2";
        }

        private void dgvCatalogo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (!dgvCatalogo.Columns.Contains("Estado")) return;
            if (e.ColumnIndex != dgvCatalogo.Columns["Estado"].Index) return;

            switch (e.Value?.ToString())
            {
                case "En Subasta":
                    e.CellStyle.ForeColor  = Color.FromArgb(180, 100, 0);
                    e.CellStyle.Font       = new Font(dgvCatalogo.DefaultCellStyle.Font ?? Font, FontStyle.Bold);
                    break;
                case "Adjudicado":
                    e.CellStyle.ForeColor  = Color.FromArgb(180, 0, 0);
                    e.CellStyle.Font       = new Font(dgvCatalogo.DefaultCellStyle.Font ?? Font, FontStyle.Bold);
                    break;
                case "Desierta":
                    e.CellStyle.ForeColor  = Color.FromArgb(100, 100, 180);
                    e.CellStyle.Font       = new Font(dgvCatalogo.DefaultCellStyle.Font ?? Font, FontStyle.Bold);
                    break;
                case "Retirado":
                    e.CellStyle.ForeColor  = Color.FromArgb(140, 140, 140);
                    e.CellStyle.Font       = new Font(dgvCatalogo.DefaultCellStyle.Font ?? Font, FontStyle.Italic);
                    break;
                default:
                    e.CellStyle.ForeColor  = Color.FromArgb(30, 140, 80);
                    e.CellStyle.Font       = new Font(dgvCatalogo.DefaultCellStyle.Font ?? Font, FontStyle.Bold);
                    break;
            }
        }

        // ── Eventos de selección ─────────────────────────────────────────────

        private void treeViewCatalogo_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!(e.Node?.Tag is IUnidadDeVenta u)) return;
            _seleccionada = u;
            MostrarDetalle(u);
            ActualizarBotones();
        }

        private void dgvCatalogo_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCatalogo.SelectedRows.Count == 0) { _seleccionada = null; ActualizarBotones(); return; }
            string nombre = dgvCatalogo.SelectedRows[0].Cells["Nombre"].Value?.ToString();
            var u = _vista?.Find(x => x.Nombre == nombre);
            _seleccionada = u;
            if (u != null) MostrarDetalle(u);
            ActualizarBotones();
        }

        private IUnidadDeVenta UnidadSeleccionada() => _seleccionada;

        private void ActualizarBotones()
        {
            if (btnModificar == null || btnRetirar == null) return;
            var u = UnidadSeleccionada();
            bool operable = u != null &&
                (u.Estado == EstadoUnidad.Disponible || u.Estado == EstadoUnidad.Desierta);
            btnModificar.Enabled = operable && u is ArticuloSimple;
            btnRetirar.Enabled   = operable;
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
                _bll.GuardarArticulo(art);
                CargarGrilla();
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
                    Nombre       = txtNombre.Text.Trim(),
                    Descripcion  = txtDesc.Text.Trim(),
                    PrecioBase   = precio,
                    FechaIngreso = DateTime.Now
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
                _bll.GuardarLote(lote);
                CargarGrilla();
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

                var lote = new LoteArticulos { Nombre = txtNombre.Text.Trim(), FechaIngreso = DateTime.Now };
                foreach (string nombre in clb.CheckedItems)
                {
                    var u = _catalogo.Find(x => x.Nombre == nombre);
                    if (u != null) lote.Agregar(u);
                }
                return lote;
            }
        }

        // ── RF-Refresh / Limpiar filtros / Modificar / Retirar ──────────────

        private void btnIrSubasta_Click(object sender, EventArgs e)
        {
            (this.MdiParent as frmPrincipal)?.AbrirSubasta();
        }

        private void btnRefrescar_Click(object sender, EventArgs e) => CargarGrilla();

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            txtPrecioMin.Clear();
            txtPrecioMax.Clear();
            cmbFiltroTipo.SelectedIndex    = 0;
            cmbFiltroEstado.SelectedIndex  = 0;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            var u = UnidadSeleccionada();
            if (!(u is ArticuloSimple art)) return;
            try
            {
                if (!DialogoModificarArticulo(art, out string nombre, out string desc, out decimal precio)) return;
                _bll.ModificarArticulo(art.Id, nombre, desc, precio);
                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool DialogoModificarArticulo(ArticuloSimple art, out string nombre, out string desc, out decimal precio)
        {
            nombre = null; desc = null; precio = 0;
            using (var dlg = new Form())
            {
                dlg.Text            = "Modificar Artículo";
                dlg.ClientSize      = new Size(360, 230);
                dlg.StartPosition   = FormStartPosition.CenterParent;
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.MaximizeBox     = false;
                dlg.MinimizeBox     = false;
                dlg.BackColor       = Color.FromArgb(252, 228, 235);

                var header = new Panel { Location = Point.Empty, Size = new Size(360, 38), BackColor = Color.FromArgb(210, 100, 135) };
                var lblH   = new Label  { Text = "Editar Artículo Simple", Dock = DockStyle.Fill, ForeColor = Color.White, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter };
                header.Controls.Add(lblH);
                dlg.Controls.Add(header);

                TextBox txtNombre = Campo(dlg, "Nombre:",          50);  txtNombre.Text = art.Nombre;
                TextBox txtDesc   = Campo(dlg, "Descripción:",     90);  txtDesc.Text   = art.Descripcion;
                TextBox txtPrecio = Campo(dlg, "Precio Base ($):", 130); txtPrecio.Text = art.PrecioBase.ToString("F2");

                var btnOk  = Boton(dlg, "Guardar",   DialogResult.OK,     80, 178, Color.FromArgb(210, 100, 135), Color.White);
                var btnCan = Boton(dlg, "Cancelar",  DialogResult.Cancel, 190, 178, Color.FromArgb(200, 200, 210), Color.FromArgb(64, 64, 64));
                dlg.AcceptButton = btnOk;
                dlg.CancelButton = btnCan;

                if (dlg.ShowDialog(this) != DialogResult.OK) return false;

                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                    throw new InvalidOperationException("El nombre es obligatorio.");
                if (!decimal.TryParse(txtPrecio.Text.Replace('.', ','), out precio) || precio <= 0)
                    throw new InvalidOperationException("Ingresá un precio mayor a cero.");

                nombre = txtNombre.Text.Trim();
                desc   = txtDesc.Text.Trim();
                return true;
            }
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            var u = UnidadSeleccionada();
            if (u == null) return;
            var resp = MessageBox.Show(
                $"¿Retirás \"{u.Nombre}\" del catálogo?\nSu estado pasará a Retirado.",
                "Confirmar retiro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (resp != DialogResult.Yes) return;
            try
            {
                _bll.RetirarUnidad(u);
                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
