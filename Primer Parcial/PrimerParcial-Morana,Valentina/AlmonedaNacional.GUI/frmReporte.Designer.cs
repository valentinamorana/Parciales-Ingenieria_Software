namespace AlmonedaNacional.GUI
{
    partial class frmReporte
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
            this.lblPatron     = new System.Windows.Forms.Label();
            this.panelControles= new System.Windows.Forms.Panel();
            this.lblJornada    = new System.Windows.Forms.Label();
            this.dtpJornada    = new System.Windows.Forms.DateTimePicker();
            this.btnGenerar    = new System.Windows.Forms.Button();
            this.btnExportar   = new System.Windows.Forms.Button();
            this.btnExportarPdf= new System.Windows.Forms.Button();
            this.rtbReporte    = new System.Windows.Forms.RichTextBox();
            this.panelStatus   = new System.Windows.Forms.Panel();
            this.lblStatus     = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelControles.SuspendLayout();
            this.panelStatus.SuspendLayout();
            this.SuspendLayout();
            //
            // panelTop
            //
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(210, 100, 135);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Controls.Add(this.lblPatron);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 56;
            this.panelTop.Name = "panelTop";
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 6);
            this.lblTitulo.Size = new System.Drawing.Size(700, 26);
            this.lblTitulo.Text = "Reporte de Jornada";
            //
            // lblPatron
            //
            this.lblPatron.AutoSize = false;
            this.lblPatron.BackColor = System.Drawing.Color.Transparent;
            this.lblPatron.ForeColor = System.Drawing.Color.FromArgb(255, 210, 220);
            this.lblPatron.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblPatron.Location = new System.Drawing.Point(12, 34);
            this.lblPatron.Size = new System.Drawing.Size(900, 16);
            this.lblPatron.Text = "RF-13 — Recorre el catálogo (Composite) y lista todas las subastas cerradas de la jornada";
            //
            // panelControles
            //
            this.panelControles.BackColor = System.Drawing.Color.FromArgb(252, 228, 235);
            this.panelControles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelControles.Controls.Add(this.lblJornada);
            this.panelControles.Controls.Add(this.dtpJornada);
            this.panelControles.Controls.Add(this.btnGenerar);
            this.panelControles.Controls.Add(this.btnExportar);
            this.panelControles.Controls.Add(this.btnExportarPdf);
            this.panelControles.Location = new System.Drawing.Point(10, 66);
            this.panelControles.Name = "panelControles";
            this.panelControles.Size = new System.Drawing.Size(1160, 50);
            //
            // lblJornada
            //
            this.lblJornada.AutoSize = true;
            this.lblJornada.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblJornada.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblJornada.Location = new System.Drawing.Point(10, 15);
            this.lblJornada.Text = "Jornada:";
            //
            // dtpJornada
            //
            this.dtpJornada.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpJornada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpJornada.Location = new System.Drawing.Point(72, 12);
            this.dtpJornada.Name = "dtpJornada";
            this.dtpJornada.Size = new System.Drawing.Size(120, 24);
            //
            // btnGenerar
            //
            this.btnGenerar.BackColor = System.Drawing.Color.FromArgb(210, 100, 135);
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.FlatAppearance.BorderSize = 0;
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGenerar.Location = new System.Drawing.Point(210, 11);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(160, 28);
            this.btnGenerar.Text = "↻  Generar Reporte";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            //
            // btnExportar
            //
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(200, 200, 210);
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportar.Location = new System.Drawing.Point(382, 11);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(140, 28);
            this.btnExportar.Text = "Exportar .txt";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            //
            // btnExportarPdf
            //
            this.btnExportarPdf.BackColor = System.Drawing.Color.FromArgb(160, 60, 100);
            this.btnExportarPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarPdf.FlatAppearance.BorderSize = 0;
            this.btnExportarPdf.ForeColor = System.Drawing.Color.White;
            this.btnExportarPdf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportarPdf.Location = new System.Drawing.Point(534, 11);
            this.btnExportarPdf.Name = "btnExportarPdf";
            this.btnExportarPdf.Size = new System.Drawing.Size(140, 28);
            this.btnExportarPdf.Text = "Exportar PDF";
            this.btnExportarPdf.UseVisualStyleBackColor = false;
            this.btnExportarPdf.Click += new System.EventHandler(this.btnExportarPdf_Click);
            //
            // rtbReporte — consola oscura igual que notificaciones en frmSubasta
            //
            this.rtbReporte.BackColor = System.Drawing.Color.FromArgb(22, 22, 22);
            this.rtbReporte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbReporte.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.rtbReporte.ForeColor = System.Drawing.Color.FromArgb(200, 240, 200);
            this.rtbReporte.Location = new System.Drawing.Point(10, 126);
            this.rtbReporte.Name = "rtbReporte";
            this.rtbReporte.ReadOnly = true;
            this.rtbReporte.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbReporte.Size = new System.Drawing.Size(1160, 520);
            //
            // panelStatus
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
            this.lblStatus.Text = "Listo.";
            //
            // frmReporte
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(252, 228, 235);
            this.ClientSize = new System.Drawing.Size(1180, 685);
            this.Controls.Add(this.rtbReporte);
            this.Controls.Add(this.panelControles);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.panelTop);
            this.Name = "frmReporte";
            this.Text = "Reporte de Jornada — RF-13";
            this.Load += new System.EventHandler(this.frmReporte_Load);
            this.panelTop.ResumeLayout(false);
            this.panelControles.ResumeLayout(false);
            this.panelControles.PerformLayout();
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel        panelTop;
        private System.Windows.Forms.Label        lblTitulo;
        private System.Windows.Forms.Label        lblPatron;
        private System.Windows.Forms.Panel        panelControles;
        private System.Windows.Forms.Label        lblJornada;
        private System.Windows.Forms.DateTimePicker dtpJornada;
        private System.Windows.Forms.Button       btnGenerar;
        private System.Windows.Forms.Button       btnExportar;
        private System.Windows.Forms.Button       btnExportarPdf;
        private System.Windows.Forms.RichTextBox  rtbReporte;
        private System.Windows.Forms.Panel        panelStatus;
        private System.Windows.Forms.Label        lblStatus;
    }
}
