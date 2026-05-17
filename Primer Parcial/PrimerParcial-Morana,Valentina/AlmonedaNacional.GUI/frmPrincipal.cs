using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AlmonedaNacional.BE;
using AlmonedaNacional.BLL;
using AlmonedaNacional.Servicios.Composite;
using AlmonedaNacional.Servicios.Seguridad;

namespace AlmonedaNacional.GUI
{
    public partial class frmPrincipal : Form
    {
        private readonly List<IUnidadDeVenta> _catalogo  = new List<IUnidadDeVenta>();
        private readonly BitacoraBLL          _bitacora  = new BitacoraBLL();

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            CargarCatalogo();
            AbrirCatalogo();
        }

        private void CargarCatalogo()
        {
            try
            {
                var items = new CatalogoBLL().ObtenerCatalogo();
                _catalogo.Clear();
                _catalogo.AddRange(items);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo cargar el catálogo desde la BD:\n{ex.Message}",
                    "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuCatalogo_Click(object sender, EventArgs e)  => AbrirCatalogo();
        private void mnuSubasta_Click(object sender, EventArgs e)   => AbrirForm(new frmSubasta(_catalogo));
        private void mnuHistorial_Click(object sender, EventArgs e) => AbrirForm(new frmHistorial());
        private void mnuBitacora_Click(object sender, EventArgs e)  => AbrirForm(new frmBitacora());
        private void mnuReporte_Click(object sender, EventArgs e)   => AbrirForm(new frmReporte(_catalogo));

        private void mnuCerrarSesion_Click(object sender, EventArgs e)
        {
            var resp = MessageBox.Show(
                "¿Cerrar la sesión actual?",
                "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp != DialogResult.Yes) return;

            _bitacora.Registrar("LOGOUT",
                $"Cierre de sesión — usuario: {SessionManager.Instancia.Martillero.Username}",
                CriticidadEvento.Baja);

            SessionManager.Logout();
            Application.Restart();
        }

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
