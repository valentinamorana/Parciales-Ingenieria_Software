using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AlmonedaNacional.Servicios.Composite;

namespace AlmonedaNacional.GUI
{
    // Demuestra el patrón COMPOSITE:
    //   - TreeView muestra la jerarquía artículo/lote sin límite de profundidad (RF-02)
    //   - ObtenerDescripcion() recorre toda la estructura recursivamente (RF-04)
    //   - CalcularPrecioBase() suma recursivamente todos los hijos (RF-03)
    public partial class frmCatalogo : Form
    {
        private List<IUnidadDeVenta> _catalogo;

        public frmCatalogo()
        {
            InitializeComponent();
            _catalogo = new List<IUnidadDeVenta>();
        }

        private void frmCatalogo_Load(object sender, EventArgs e)
        {
            CargarCatalogo();
        }

        private void CargarCatalogo()
        {
            // ── Artículos simples (hojas del Composite) ──────────────────────────
            var taladro   = new ArticuloSimple { Id = 1, Nombre = "Taladro Industrial",  Descripcion = "Bosch 1500W",             PrecioBase = 15000m };
            var amoladora = new ArticuloSimple { Id = 2, Nombre = "Amoladora",           Descripcion = "Makita 9\"",               PrecioBase =  8000m };
            var repuestos = new ArticuloSimple { Id = 3, Nombre = "Set de Repuestos",    Descripcion = "200 unidades",             PrecioBase =  5000m };
            var maquinaCNC= new ArticuloSimple { Id = 4, Nombre = "Máquina CNC",         Descripcion = "Control numérico 3 ejes", PrecioBase = 250000m };

            // ── Lote nivel 1 (compuesto del Composite) ───────────────────────────
            var loteHerr = new LoteArticulos { Id = 10, Nombre = "Lote Herramientas Manuales" };
            loteHerr.Agregar(taladro);
            loteHerr.Agregar(amoladora);

            // ── Lote nivel 2 (lote dentro de lote — RF-02 sin límite de profundidad) ─
            var seccion = new LoteArticulos { Id = 11, Nombre = "Sección Producción Completa" };
            seccion.Agregar(loteHerr);    // lote dentro de lote
            seccion.Agregar(repuestos);
            seccion.Agregar(maquinaCNC);

            _catalogo.Clear();
            _catalogo.Add(taladro);
            _catalogo.Add(amoladora);
            _catalogo.Add(repuestos);
            _catalogo.Add(maquinaCNC);
            _catalogo.Add(loteHerr);
            _catalogo.Add(seccion);

            LlenarTreeView();
            LlenarGrilla();
        }

        private void LlenarTreeView()
        {
            treeViewCatalogo.Nodes.Clear();

            var articulos = new TreeNode("Artículos Simples (Hojas)");
            var lotes     = new TreeNode("Lotes (Compuestos)");

            foreach (var u in _catalogo)
            {
                if (u is ArticuloSimple art)
                {
                    articulos.Nodes.Add(new TreeNode($"{art.Nombre}  —  ${art.PrecioBase:N2}") { Tag = art });
                }
                else if (u is LoteArticulos lote)
                {
                    var nodo = CrearNodoLote(lote);
                    lotes.Nodes.Add(nodo);
                }
            }

            treeViewCatalogo.Nodes.Add(articulos);
            treeViewCatalogo.Nodes.Add(lotes);
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

            var filas = new System.Data.DataTable();
            filas.Columns.Add("Tipo");
            filas.Columns.Add("Nombre");
            filas.Columns.Add("Precio Base", typeof(decimal));

            foreach (var u in _catalogo)
            {
                filas.Rows.Add(
                    u is LoteArticulos ? "LOTE" : "Artículo",
                    u.Nombre,
                    u.CalcularPrecioBase());
            }

            dgvCatalogo.DataSource = filas;
            dgvCatalogo.Columns["Precio Base"].DefaultCellStyle.Format = "C2";
        }

        private void treeViewCatalogo_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag is IUnidadDeVenta unidad)
                MostrarDetalle(unidad);
        }

        private void dgvCatalogo_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCatalogo.SelectedRows.Count == 0) return;
            string nombre = dgvCatalogo.SelectedRows[0].Cells["Nombre"].Value?.ToString();
            var unidad = _catalogo.Find(u => u.Nombre == nombre);
            if (unidad != null)
                MostrarDetalle(unidad);
        }

        private void MostrarDetalle(IUnidadDeVenta unidad)
        {
            rtbDescripcion.Clear();
            rtbDescripcion.AppendText(unidad.ObtenerDescripcion());
            lblPrecioBase.Text = $"$ {unidad.CalcularPrecioBase():N2}";
        }

        private void btnVerDescripcion_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeViewCatalogo.SelectedNode?.Tag is IUnidadDeVenta unidad)
                    MostrarDetalle(unidad);
                else
                    MessageBox.Show("Seleccione una unidad en el árbol.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
