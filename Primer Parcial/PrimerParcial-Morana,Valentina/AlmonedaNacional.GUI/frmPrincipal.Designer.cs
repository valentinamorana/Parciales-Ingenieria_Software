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
            this.menuStrip1        = new System.Windows.Forms.MenuStrip();
            this.mnuCatalogo       = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSubasta        = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHistorial      = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            //
            // menuStrip1
            //
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuCatalogo,
                this.mnuSubasta,
                this.mnuHistorial });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 24);
            this.menuStrip1.Text = "menuStrip1";
            //
            // mnuCatalogo
            //
            this.mnuCatalogo.Name = "mnuCatalogo";
            this.mnuCatalogo.Size = new System.Drawing.Size(185, 20);
            this.mnuCatalogo.Text = "Catálogo  [Patrón: COMPOSITE]";
            this.mnuCatalogo.Click += new System.EventHandler(this.mnuCatalogo_Click);
            //
            // mnuSubasta
            //
            this.mnuSubasta.Name = "mnuSubasta";
            this.mnuSubasta.Size = new System.Drawing.Size(220, 20);
            this.mnuSubasta.Text = "Subasta  [OBSERVER + SINGLETON + STRATEGY]";
            this.mnuSubasta.Click += new System.EventHandler(this.mnuSubasta_Click);
            //
            // mnuHistorial
            //
            this.mnuHistorial.Name = "mnuHistorial";
            this.mnuHistorial.Size = new System.Drawing.Size(130, 20);
            this.mnuHistorial.Text = "Historial de Subastas  [RF-13]";
            this.mnuHistorial.Click += new System.EventHandler(this.mnuHistorial_Click);
            //
            // frmPrincipal
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuCatalogo;
        private System.Windows.Forms.ToolStripMenuItem mnuSubasta;
        private System.Windows.Forms.ToolStripMenuItem mnuHistorial;
    }
}
