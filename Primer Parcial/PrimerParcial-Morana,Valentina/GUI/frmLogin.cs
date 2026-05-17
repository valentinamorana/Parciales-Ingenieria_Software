using System;
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
            this.Icon = LogoHelper.Icono;
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
            bool visible = txtPassword.PasswordChar == '\0';
            txtPassword.PasswordChar = visible ? '●' : '\0';
            btnVerPassword.Text      = visible ? "👁" : "🙈";
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
