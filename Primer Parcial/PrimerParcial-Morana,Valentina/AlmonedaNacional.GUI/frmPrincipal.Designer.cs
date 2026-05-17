namespace AlmonedaNacional.GUI
{
    partial class frmPrincipal
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
            this.menuStrip1      = new System.Windows.Forms.MenuStrip();
            this.mnuCatalogo     = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSubasta      = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHistorial    = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBitacora     = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReporte      = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeparador    = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            //
            // menuStrip1  — fondo rosa brand igual que WardrobeFlow
            //
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(210, 100, 135);
            this.menuStrip1.ForeColor = System.Drawing.Color.White;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuCatalogo, this.mnuSubasta, this.mnuHistorial,
                this.mnuBitacora, this.mnuReporte,
                this.mnuSeparador, this.mnuCerrarSesion });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 26);
            this.menuStrip1.Text = "menuStrip1";
            //
            // mnuCatalogo
            //
            this.mnuCatalogo.ForeColor = System.Drawing.Color.White;
            this.mnuCatalogo.Name = "mnuCatalogo";
            this.mnuCatalogo.Size = new System.Drawing.Size(185, 22);
            this.mnuCatalogo.Text = "Catálogo  [Patrón: COMPOSITE]";
            this.mnuCatalogo.Click += new System.EventHandler(this.mnuCatalogo_Click);
            //
            // mnuSubasta
            //
            this.mnuSubasta.ForeColor = System.Drawing.Color.White;
            this.mnuSubasta.Name = "mnuSubasta";
            this.mnuSubasta.Size = new System.Drawing.Size(220, 22);
            this.mnuSubasta.Text = "Subasta  [OBSERVER + SINGLETON]";
            this.mnuSubasta.Click += new System.EventHandler(this.mnuSubasta_Click);
            //
            // mnuHistorial
            //
            this.mnuHistorial.ForeColor = System.Drawing.Color.White;
            this.mnuHistorial.Name = "mnuHistorial";
            this.mnuHistorial.Size = new System.Drawing.Size(130, 22);
            this.mnuHistorial.Text = "Historial de Subastas";
            this.mnuHistorial.Click += new System.EventHandler(this.mnuHistorial_Click);
            //
            // mnuBitacora
            //
            this.mnuBitacora.ForeColor = System.Drawing.Color.White;
            this.mnuBitacora.Name = "mnuBitacora";
            this.mnuBitacora.Size = new System.Drawing.Size(120, 22);
            this.mnuBitacora.Text = "Bitácora";
            this.mnuBitacora.Click += new System.EventHandler(this.mnuBitacora_Click);
            //
            // mnuReporte
            //
            this.mnuReporte.ForeColor = System.Drawing.Color.White;
            this.mnuReporte.Name = "mnuReporte";
            this.mnuReporte.Size = new System.Drawing.Size(200, 22);
            this.mnuReporte.Text = "Reporte de Jornada  [RF-13]";
            this.mnuReporte.Click += new System.EventHandler(this.mnuReporte_Click);
            //
            // mnuSeparador
            //
            this.mnuSeparador.Name = "mnuSeparador";
            //
            // mnuCerrarSesion
            //
            this.mnuCerrarSesion.ForeColor = System.Drawing.Color.FromArgb(255, 200, 210);
            this.mnuCerrarSesion.Name = "mnuCerrarSesion";
            this.mnuCerrarSesion.Size = new System.Drawing.Size(130, 22);
            this.mnuCerrarSesion.Text = "Cerrar Sesión";
            this.mnuCerrarSesion.Click += new System.EventHandler(this.mnuCerrarSesion_Click);
            //
            // frmPrincipal
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(252, 228, 235);
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.Text = "La Almoneda Nacional — Morana, Valentina — 1er Parcial IS 2026";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip          menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem  mnuCatalogo;
        private System.Windows.Forms.ToolStripMenuItem  mnuSubasta;
        private System.Windows.Forms.ToolStripMenuItem  mnuHistorial;
        private System.Windows.Forms.ToolStripMenuItem  mnuBitacora;
        private System.Windows.Forms.ToolStripMenuItem  mnuReporte;
        private System.Windows.Forms.ToolStripSeparator mnuSeparador;
        private System.Windows.Forms.ToolStripMenuItem  mnuCerrarSesion;
    }
}
