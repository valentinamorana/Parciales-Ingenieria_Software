using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AlmonedaNacional.Servicios.Composite;

namespace AlmonedaNacional.GUI
{
    public partial class frmPrincipal : Form
    {
        // Catálogo compartido entre frmCatalogo y frmSubasta (misma referencia).
        private readonly List<IUnidadDeVenta> _catalogo = new List<IUnidadDeVenta>();

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            InicializarCatalogo();
            AbrirCatalogo();
        }

        // Datos de demo precargados — el martillero puede agregar más desde frmCatalogo.
        private void InicializarCatalogo()
        {
            var taladro    = new ArticuloSimple { Id = 1, Nombre = "Taladro Industrial",  Descripcion = "Bosch 1500W",           PrecioBase = 15000m };
            var amoladora  = new ArticuloSimple { Id = 2, Nombre = "Amoladora",           Descripcion = "Makita 9\"",             PrecioBase =  8000m };
            var repuestos  = new ArticuloSimple { Id = 3, Nombre = "Set de Repuestos",    Descripcion = "200 unidades",           PrecioBase =  5000m };
            var maquinaCNC = new ArticuloSimple { Id = 4, Nombre = "Máquina CNC",         Descripcion = "Control numérico 3 ejes", PrecioBase = 250000m };

            var loteHerr = new LoteArticulos { Id = 10, Nombre = "Lote Herramientas" };
            loteHerr.Agregar(taladro);
            loteHerr.Agregar(amoladora);

            var seccion = new LoteArticulos { Id = 11, Nombre = "Sección Producción Completa" };
            seccion.Agregar(loteHerr);
            seccion.Agregar(repuestos);
            seccion.Agregar(maquinaCNC);

            _catalogo.AddRange(new IUnidadDeVenta[] { taladro, amoladora, repuestos, maquinaCNC, loteHerr, seccion });
        }

        private void mnuCatalogo_Click(object sender, EventArgs e) => AbrirCatalogo();

        private void mnuSubasta_Click(object sender, EventArgs e) => AbrirForm(new frmSubasta(_catalogo));

        private void mnuHistorial_Click(object sender, EventArgs e) => AbrirForm(new frmHistorial());

        private void AbrirCatalogo() => AbrirForm(new frmCatalogo(_catalogo));

        private void AbrirForm(Form form)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            form.MdiParent   = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }
    }
}
