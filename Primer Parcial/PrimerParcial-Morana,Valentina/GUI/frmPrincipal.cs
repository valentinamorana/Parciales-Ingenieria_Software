using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using BE;
using BLL;
using Servicios.Composite;
using Seguridad;

namespace GUI
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
            var m = SessionManager.GetInstance().Martillero;
            string nombre = !string.IsNullOrWhiteSpace(m.Nombre) ? m.Nombre : m.Username;
            this.Text = $"La Almoneda Nacional — {nombre} — 1er Parcial IS 2026";

            foreach (Control c in Controls)
            {
                if (c.GetType().Name == "MdiClient")
                {
                    c.BackColor             = Color.FromArgb(252, 228, 235);
                    c.BackgroundImage       = GenerarTileAN();
                    c.BackgroundImageLayout = ImageLayout.Tile;
                    break;
                }
            }

            CargarCatalogo();
            AbrirCatalogo();
        }

        private static Bitmap GenerarTileAN()
        {
            const int TW = 80, TH = 74;
            var bmp = new Bitmap(TW * 2, TH * 2);

            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(252, 228, 235));
                g.SmoothingMode     = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.AntiAlias;

                var tinta = Color.FromArgb(35, 210, 100, 135);

                using (var fontA = new Font("Georgia", 22, FontStyle.Bold, GraphicsUnit.Point))
                using (var fontN = new Font("Georgia", 18, FontStyle.Bold, GraphicsUnit.Point))
                using (var br    = new SolidBrush(tinta))
                {
                    // Fila 0 — sin offset
                    g.DrawString("A", fontA, br, 0,            0);
                    g.DrawString("N", fontN, br, 24,           20);
                    g.DrawString("A", fontA, br, TW,           0);
                    g.DrawString("N", fontN, br, TW + 24,      20);

                    // Fila 1 — offset medio tile (patrón ladrillo)
                    g.DrawString("A", fontA, br, TW / 2f,           TH);
                    g.DrawString("N", fontN, br, TW / 2f + 24,      TH + 20);
                    g.DrawString("A", fontA, br, TW / 2f + TW,      TH);
                    g.DrawString("N", fontN, br, TW / 2f + TW + 24, TH + 20);
                }
            }

            return bmp;
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
                $"Cierre de sesión — usuario: {SessionManager.GetInstance().Martillero.Username}",
                CriticidadEvento.Baja);

            SessionManager.Logout();
            Application.Restart();
        }

        private void AbrirCatalogo() => AbrirForm(new frmCatalogo(_catalogo));

        private void AbrirForm(Form form)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            form.MdiParent      = this;
            form.StartPosition  = FormStartPosition.CenterParent;
            form.Show();
        }
    }
}
