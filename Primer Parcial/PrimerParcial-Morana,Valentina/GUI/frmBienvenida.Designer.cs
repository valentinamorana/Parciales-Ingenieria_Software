namespace GUI
{
    partial class frmBienvenida
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
            this.panelTop      = new System.Windows.Forms.Panel();
            this.lblTitulo     = new System.Windows.Forms.Label();
            this.lblSubtitulo  = new System.Windows.Forms.Label();
            this.panelStatus   = new System.Windows.Forms.Panel();
            this.lblVersion    = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.lblFecha      = new System.Windows.Forms.Label();
            this.panelSep      = new System.Windows.Forms.Panel();
            this.btnIngresar   = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelStatus.SuspendLayout();
            this.SuspendLayout();
            //
            // panelTop
            //
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(210, 100, 135);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Controls.Add(this.lblSubtitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 90;
            this.panelTop.Name = "panelTop";
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(0, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(500, 38);
            this.lblTitulo.Text = "La Almoneda Nacional";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = false;
            this.lblSubtitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(255, 210, 220);
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblSubtitulo.Location = new System.Drawing.Point(0, 54);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(500, 20);
            this.lblSubtitulo.Text = "Sistema de Gestión de Subastas";
            this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // panelStatus
            //
            this.panelStatus.BackColor = System.Drawing.Color.FromArgb(230, 230, 240);
            this.panelStatus.Controls.Add(this.lblVersion);
            this.panelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatus.Height = 28;
            this.panelStatus.Name = "panelStatus";
            //
            // lblVersion
            //
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblVersion.ForeColor = System.Drawing.Color.DimGray;
            this.lblVersion.Location = new System.Drawing.Point(8, 7);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Text = "Morana, Valentina — 1er Parcial IS 2026";
            //
            // lblBienvenida
            //
            this.lblBienvenida.AutoSize = false;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblBienvenida.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblBienvenida.Location = new System.Drawing.Point(0, 118);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(500, 30);
            this.lblBienvenida.Text = "Bienvenido, Martillero";
            this.lblBienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblFecha
            //
            this.lblFecha.AutoSize = false;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFecha.ForeColor = System.Drawing.Color.DimGray;
            this.lblFecha.Location = new System.Drawing.Point(0, 152);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(500, 20);
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // panelSep
            //
            this.panelSep.BackColor = System.Drawing.Color.FromArgb(210, 100, 135);
            this.panelSep.Location = new System.Drawing.Point(100, 186);
            this.panelSep.Name = "panelSep";
            this.panelSep.Size = new System.Drawing.Size(300, 2);
            //
            // btnIngresar
            //
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(210, 100, 135);
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnIngresar.Location = new System.Drawing.Point(150, 204);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(200, 46);
            this.btnIngresar.TabIndex = 0;
            this.btnIngresar.Text = "Ingresar  →";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            //
            // frmBienvenida
            //
            this.AcceptButton = this.btnIngresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(252, 228, 235);
            this.ClientSize = new System.Drawing.Size(500, 310);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.panelSep);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBienvenida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "La Almoneda Nacional";
            this.Load += new System.EventHandler(this.frmBienvenida_Load);
            this.panelTop.ResumeLayout(false);
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel     panelTop;
        private System.Windows.Forms.Label     lblTitulo;
        private System.Windows.Forms.Label     lblSubtitulo;
        private System.Windows.Forms.Panel     panelStatus;
        private System.Windows.Forms.Label     lblVersion;
        private System.Windows.Forms.Label     lblBienvenida;
        private System.Windows.Forms.Label     lblFecha;
        private System.Windows.Forms.Panel     panelSep;
        private System.Windows.Forms.Button    btnIngresar;
    }
}
