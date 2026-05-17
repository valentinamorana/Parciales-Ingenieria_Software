using System;
using System.Windows.Forms;

namespace AlmonedaNacional.GUI
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            AbrirCatalogo();
        }

        private void mnuCatalogo_Click(object sender, EventArgs e)
        {
            AbrirCatalogo();
        }

        private void mnuSubasta_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmSubasta());
        }

        private void mnuHistorial_Click(object sender, EventArgs e)
        {
            AbrirForm(new frmHistorial());
        }

        private void AbrirCatalogo()
        {
            AbrirForm(new frmCatalogo());
        }

        private void AbrirForm(Form form)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();

            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }
    }
}
