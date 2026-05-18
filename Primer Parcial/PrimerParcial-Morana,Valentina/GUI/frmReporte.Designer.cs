namespace GUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporte));
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblPatron = new System.Windows.Forms.Label();
            this.panelControles = new System.Windows.Forms.Panel();
            this.lblJornada = new System.Windows.Forms.Label();
            this.dtpJornada = new System.Windows.Forms.DateTimePicker();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnExportarPdf = new System.Windows.Forms.Button();
            this.rtbReporte = new System.Windows.Forms.RichTextBox();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelControles.SuspendLayout();
            this.panelStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(100)))), ((int)(((byte)(135)))));
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Controls.Add(this.lblPatron);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1180, 56);
            this.panelTop.TabIndex = 3;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(12, 6);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(700, 26);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Reporte de Jornada";
            // 
            // lblPatron
            // 
            this.lblPatron.BackColor = System.Drawing.Color.Transparent;
            this.lblPatron.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblPatron.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.lblPatron.Location = new System.Drawing.Point(12, 34);
            this.lblPatron.Name = "lblPatron";
            this.lblPatron.Size = new System.Drawing.Size(900, 16);
            this.lblPatron.TabIndex = 1;
            this.lblPatron.Text = "Subastas cerradas de la jornada con exportación a TXT y PDF";
            // 
            // panelControles
            // 
            this.panelControles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(232)))), ((int)(((byte)(238)))));
            this.panelControles.Controls.Add(this.lblJornada);
            this.panelControles.Controls.Add(this.dtpJornada);
            this.panelControles.Controls.Add(this.btnGenerar);
            this.panelControles.Controls.Add(this.btnExportar);
            this.panelControles.Controls.Add(this.btnExportarPdf);
            this.panelControles.Location = new System.Drawing.Point(10, 66);
            this.panelControles.Name = "panelControles";
            this.panelControles.Size = new System.Drawing.Size(1160, 50);
            this.panelControles.TabIndex = 1;
            // 
            // lblJornada
            // 
            this.lblJornada.AutoSize = true;
            this.lblJornada.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblJornada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblJornada.Location = new System.Drawing.Point(10, 15);
            this.lblJornada.Name = "lblJornada";
            this.lblJornada.Size = new System.Drawing.Size(53, 15);
            this.lblJornada.TabIndex = 0;
            this.lblJornada.Text = "Jornada:";
            // 
            // dtpJornada
            // 
            this.dtpJornada.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpJornada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpJornada.Location = new System.Drawing.Point(72, 12);
            this.dtpJornada.Name = "dtpJornada";
            this.dtpJornada.Size = new System.Drawing.Size(120, 23);
            this.dtpJornada.TabIndex = 1;
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(100)))), ((int)(((byte)(135)))));
            this.btnGenerar.FlatAppearance.BorderSize = 0;
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.Location = new System.Drawing.Point(210, 11);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(160, 28);
            this.btnGenerar.TabIndex = 2;
            this.btnGenerar.Text = "↻  Generar Reporte";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExportar.Location = new System.Drawing.Point(382, 11);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(140, 28);
            this.btnExportar.TabIndex = 3;
            this.btnExportar.Text = "Exportar .txt";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnExportarPdf
            // 
            this.btnExportarPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(60)))), ((int)(((byte)(100)))));
            this.btnExportarPdf.FlatAppearance.BorderSize = 0;
            this.btnExportarPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarPdf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportarPdf.ForeColor = System.Drawing.Color.White;
            this.btnExportarPdf.Location = new System.Drawing.Point(534, 11);
            this.btnExportarPdf.Name = "btnExportarPdf";
            this.btnExportarPdf.Size = new System.Drawing.Size(140, 28);
            this.btnExportarPdf.TabIndex = 4;
            this.btnExportarPdf.Text = "Exportar PDF";
            this.btnExportarPdf.UseVisualStyleBackColor = false;
            this.btnExportarPdf.Click += new System.EventHandler(this.btnExportarPdf_Click);
            // 
            // rtbReporte
            // 
            this.rtbReporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(235)))));
            this.rtbReporte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbReporte.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.rtbReporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.rtbReporte.Location = new System.Drawing.Point(10, 126);
            this.rtbReporte.Name = "rtbReporte";
            this.rtbReporte.ReadOnly = true;
            this.rtbReporte.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbReporte.Size = new System.Drawing.Size(1160, 520);
            this.rtbReporte.TabIndex = 0;
            this.rtbReporte.Text = "";
            // 
            // panelStatus
            // 
            this.panelStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.panelStatus.Controls.Add(this.lblStatus);
            this.panelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatus.Location = new System.Drawing.Point(0, 657);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(1180, 28);
            this.panelStatus.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatus.Location = new System.Drawing.Point(8, 6);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 15);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Listo.";
            // 
            // frmReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(1180, 685);
            this.Controls.Add(this.rtbReporte);
            this.Controls.Add(this.panelControles);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReporte";
            this.Text = "Reporte de Jornada";
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
