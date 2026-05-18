namespace GUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuCatalogo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSubasta = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHistoricos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHistorial = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBitacora = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSepHistoricos = new System.Windows.Forms.ToolStripSeparator();
            this.mnuReporte = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeparador = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(100)))), ((int)(((byte)(135)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.ForeColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCatalogo,
            this.mnuSubasta,
            this.mnuHistoricos,
            this.mnuSeparador,
            this.mnuCerrarSesion});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuCatalogo
            // 
            this.mnuCatalogo.ForeColor = System.Drawing.Color.White;
            this.mnuCatalogo.Name = "mnuCatalogo";
            this.mnuCatalogo.Size = new System.Drawing.Size(75, 23);
            this.mnuCatalogo.Text = "Catálogo";
            this.mnuCatalogo.Click += new System.EventHandler(this.mnuCatalogo_Click);
            // 
            // mnuSubasta
            // 
            this.mnuSubasta.ForeColor = System.Drawing.Color.White;
            this.mnuSubasta.Name = "mnuSubasta";
            this.mnuSubasta.Size = new System.Drawing.Size(68, 23);
            this.mnuSubasta.Text = "Subasta";
            this.mnuSubasta.Click += new System.EventHandler(this.mnuSubasta_Click);
            // 
            // mnuHistoricos
            // 
            this.mnuHistoricos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHistorial,
            this.mnuBitacora,
            this.mnuSepHistoricos,
            this.mnuReporte});
            this.mnuHistoricos.ForeColor = System.Drawing.Color.White;
            this.mnuHistoricos.Name = "mnuHistoricos";
            this.mnuHistoricos.Size = new System.Drawing.Size(102, 23);
            this.mnuHistoricos.Text = "Históricos  ▾";
            // 
            // mnuHistorial
            // 
            this.mnuHistorial.Name = "mnuHistorial";
            this.mnuHistorial.Size = new System.Drawing.Size(225, 22);
            this.mnuHistorial.Text = "Historial de Subastas";
            this.mnuHistorial.Click += new System.EventHandler(this.mnuHistorial_Click);
            // 
            // mnuBitacora
            // 
            this.mnuBitacora.Name = "mnuBitacora";
            this.mnuBitacora.Size = new System.Drawing.Size(225, 22);
            this.mnuBitacora.Text = "Bitácora de Operaciones";
            this.mnuBitacora.Click += new System.EventHandler(this.mnuBitacora_Click);
            // 
            // mnuSepHistoricos
            // 
            this.mnuSepHistoricos.Name = "mnuSepHistoricos";
            this.mnuSepHistoricos.Size = new System.Drawing.Size(222, 6);
            // 
            // mnuReporte
            // 
            this.mnuReporte.Name = "mnuReporte";
            this.mnuReporte.Size = new System.Drawing.Size(225, 22);
            this.mnuReporte.Text = "Reporte de Jornada";
            this.mnuReporte.Click += new System.EventHandler(this.mnuReporte_Click);
            // 
            // mnuSeparador
            // 
            this.mnuSeparador.Name = "mnuSeparador";
            this.mnuSeparador.Size = new System.Drawing.Size(6, 23);
            // 
            // mnuCerrarSesion
            // 
            this.mnuCerrarSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.mnuCerrarSesion.Name = "mnuCerrarSesion";
            this.mnuCerrarSesion.Size = new System.Drawing.Size(101, 23);
            this.mnuCerrarSesion.Text = "Cerrar Sesión";
            this.mnuCerrarSesion.Click += new System.EventHandler(this.mnuCerrarSesion_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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

        private System.Windows.Forms.MenuStrip           menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem   mnuCatalogo;
        private System.Windows.Forms.ToolStripMenuItem   mnuSubasta;
        private System.Windows.Forms.ToolStripMenuItem   mnuHistoricos;
        private System.Windows.Forms.ToolStripMenuItem   mnuHistorial;
        private System.Windows.Forms.ToolStripMenuItem   mnuBitacora;
        private System.Windows.Forms.ToolStripSeparator  mnuSepHistoricos;
        private System.Windows.Forms.ToolStripMenuItem   mnuReporte;
        private System.Windows.Forms.ToolStripSeparator  mnuSeparador;
        private System.Windows.Forms.ToolStripMenuItem   mnuCerrarSesion;
    }
}
