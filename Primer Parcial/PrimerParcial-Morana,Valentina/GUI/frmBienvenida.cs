using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmBienvenida : Form
    {
        public frmBienvenida()
        {
            InitializeComponent();
        }

        private void frmBienvenida_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy",
                new System.Globalization.CultureInfo("es-AR"));
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
