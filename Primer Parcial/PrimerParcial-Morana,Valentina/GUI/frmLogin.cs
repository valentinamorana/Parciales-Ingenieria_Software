using System;
using System.Drawing;
using System.Windows.Forms;
using BE;
using BLL;
using Seguridad;

namespace GUI
{
    public partial class frmLogin : Form
    {
        private readonly MartilleroBLL _bll = new MartilleroBLL();
        private readonly BitacoraBLL   _bitacora = new BitacoraBLL();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString(
                "dddd, dd 'de' MMMM 'de' yyyy",
                new System.Globalization.CultureInfo("es-AR"));
            txtUsuario.Focus();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            MostrarError(null);
            btnIngresar.Enabled = false;

            try
            {
                var martillero = _bll.Login(txtUsuario.Text, txtPassword.Text);
                SessionManager.Login(martillero);
                _bitacora.Registrar("LOGIN", $"Ingreso al sistema — usuario: {martillero.Username}", CriticidadEvento.Baja);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                bool bloqueado = ex.Message.Contains("bloqueada");
                _bitacora.Registrar(
                    bloqueado ? "BLOQUEO_CUENTA" : "LOGIN_FALLIDO",
                    $"Intento fallido — usuario: {txtUsuario.Text.Trim()}",
                    bloqueado ? CriticidadEvento.BloqueosCuenta : CriticidadEvento.IntentosLogin);
                MostrarError(ex.Message);
            }
            finally
            {
                btnIngresar.Enabled = true;
            }
        }

        private void btnVerPassword_Click(object sender, EventArgs e)
        {
            bool mostrando = txtPassword.PasswordChar == '\0';
            txtPassword.PasswordChar = mostrando ? '●' : '\0';
            btnVerPassword.ForeColor = mostrando
                ? Color.DimGray
                : Color.FromArgb(210, 100, 135);
        }

        private void frmLogin_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            // Líneas diagonales sutiles sobre el fondo oscuro
            using (var pen = new Pen(Color.FromArgb(20, 255, 255, 255), 1f))
                for (int i = -this.Height; i < this.Width + this.Height; i += 18)
                    g.DrawLine(pen, i, 0, i + this.Height, this.Height);

            // Sombra suave detrás de la card
            var shadow = new Rectangle(panelCard.Left + 5, panelCard.Top + 6,
                                       panelCard.Width, panelCard.Height);
            using (var b = new SolidBrush(Color.FromArgb(55, 0, 0, 0)))
                g.FillRectangle(b, shadow);
        }

        private void MostrarError(string mensaje)
        {
            lblError.Text    = mensaje ?? string.Empty;
            lblError.Visible = !string.IsNullOrEmpty(mensaje);
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnIngresar_Click(sender, e);
        }
    }
}
