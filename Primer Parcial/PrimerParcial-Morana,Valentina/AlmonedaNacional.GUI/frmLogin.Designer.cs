namespace AlmonedaNacional.GUI
{
    partial class frmLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelCard      = new System.Windows.Forms.Panel();
            this.panelHeader    = new System.Windows.Forms.Panel();
            this.lblTitulo      = new System.Windows.Forms.Label();
            this.lblSubtitulo   = new System.Windows.Forms.Label();
            this.lblFecha       = new System.Windows.Forms.Label();
            this.lblUsuarioLbl  = new System.Windows.Forms.Label();
            this.txtUsuario     = new System.Windows.Forms.TextBox();
            this.lblPasswordLbl = new System.Windows.Forms.Label();
            this.txtPassword    = new System.Windows.Forms.TextBox();
            this.btnVerPassword = new System.Windows.Forms.Button();
            this.lblError       = new System.Windows.Forms.Label();
            this.btnIngresar    = new System.Windows.Forms.Button();
            this.panelStatus    = new System.Windows.Forms.Panel();
            this.lblStatus      = new System.Windows.Forms.Label();
            this.panelCard.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelStatus.SuspendLayout();
            this.SuspendLayout();
            //
            // panelStatus — barra inferior gris (igual resto de forms)
            //
            this.panelStatus.BackColor = System.Drawing.Color.FromArgb(230, 230, 240);
            this.panelStatus.Controls.Add(this.lblStatus);
            this.panelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatus.Height = 28;
            this.panelStatus.Name = "panelStatus";
            //
            // lblStatus
            //
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatus.Location = new System.Drawing.Point(8, 6);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "Morana, Valentina — 1er Parcial IS 2026";
            //
            // panelCard — tarjeta blanca centrada
            //
            this.panelCard.BackColor = System.Drawing.Color.White;
            this.panelCard.Controls.Add(this.panelHeader);
            this.panelCard.Controls.Add(this.lblFecha);
            this.panelCard.Controls.Add(this.lblUsuarioLbl);
            this.panelCard.Controls.Add(this.txtUsuario);
            this.panelCard.Controls.Add(this.lblPasswordLbl);
            this.panelCard.Controls.Add(this.txtPassword);
            this.panelCard.Controls.Add(this.btnVerPassword);
            this.panelCard.Controls.Add(this.lblError);
            this.panelCard.Controls.Add(this.btnIngresar);
            this.panelCard.Location = new System.Drawing.Point(40, 50);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(400, 390);
            //
            // panelHeader — cabecera rosa brand
            //
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(210, 100, 135);
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Controls.Add(this.lblSubtitulo);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(400, 62);
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(0, 6);
            this.lblTitulo.Size = new System.Drawing.Size(400, 28);
            this.lblTitulo.Text = "La Almoneda Nacional";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = false;
            this.lblSubtitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(255, 210, 225);
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblSubtitulo.Location = new System.Drawing.Point(0, 36);
            this.lblSubtitulo.Size = new System.Drawing.Size(400, 20);
            this.lblSubtitulo.Text = "Sistema de Gestión de Subastas";
            this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblFecha
            //
            this.lblFecha.AutoSize = false;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(150, 100, 120);
            this.lblFecha.Location = new System.Drawing.Point(20, 74);
            this.lblFecha.Size = new System.Drawing.Size(360, 18);
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFecha.Name = "lblFecha";
            //
            // lblUsuarioLbl
            //
            this.lblUsuarioLbl.AutoSize = true;
            this.lblUsuarioLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsuarioLbl.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblUsuarioLbl.Location = new System.Drawing.Point(20, 106);
            this.lblUsuarioLbl.Text = "Usuario:";
            //
            // txtUsuario
            //
            this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(245, 245, 248);
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsuario.Location = new System.Drawing.Point(20, 124);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(360, 28);
            //
            // lblPasswordLbl
            //
            this.lblPasswordLbl.AutoSize = true;
            this.lblPasswordLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPasswordLbl.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblPasswordLbl.Location = new System.Drawing.Point(20, 164);
            this.lblPasswordLbl.Text = "Contraseña:";
            //
            // txtPassword
            //
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(245, 245, 248);
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(20, 182);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(316, 28);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            //
            // btnVerPassword
            //
            this.btnVerPassword.BackColor = System.Drawing.Color.FromArgb(245, 245, 248);
            this.btnVerPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerPassword.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 210);
            this.btnVerPassword.FlatAppearance.BorderSize = 1;
            this.btnVerPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnVerPassword.Location = new System.Drawing.Point(340, 182);
            this.btnVerPassword.Name = "btnVerPassword";
            this.btnVerPassword.Size = new System.Drawing.Size(40, 28);
            this.btnVerPassword.Text = "👁";
            this.btnVerPassword.Click += new System.EventHandler(this.btnVerPassword_Click);
            //
            // lblError — mensaje de error debajo de los campos
            //
            this.lblError.AutoSize = false;
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(180, 30, 30);
            this.lblError.Location = new System.Drawing.Point(20, 220);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(360, 50);
            this.lblError.Visible = false;
            //
            // btnIngresar
            //
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(210, 100, 135);
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIngresar.Location = new System.Drawing.Point(20, 280);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(360, 42);
            this.btnIngresar.Text = "Ingresar  →";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            //
            // frmLogin
            //
            this.AcceptButton = this.btnIngresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(130, 40, 70);
            this.ClientSize = new System.Drawing.Size(480, 520);
            this.Controls.Add(this.panelCard);
            this.Controls.Add(this.panelStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "La Almoneda Nacional — Ingreso";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel     panelCard;
        private System.Windows.Forms.Panel     panelHeader;
        private System.Windows.Forms.Label     lblTitulo;
        private System.Windows.Forms.Label     lblSubtitulo;
        private System.Windows.Forms.Label     lblFecha;
        private System.Windows.Forms.Label     lblUsuarioLbl;
        private System.Windows.Forms.TextBox   txtUsuario;
        private System.Windows.Forms.Label     lblPasswordLbl;
        private System.Windows.Forms.TextBox   txtPassword;
        private System.Windows.Forms.Button    btnVerPassword;
        private System.Windows.Forms.Label     lblError;
        private System.Windows.Forms.Button    btnIngresar;
        private System.Windows.Forms.Panel     panelStatus;
        private System.Windows.Forms.Label     lblStatus;
    }
}
