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
            this.panelTop        = new System.Windows.Forms.Panel();
            this.lblTitulo       = new System.Windows.Forms.Label();
            this.lblPatron       = new System.Windows.Forms.Label();
            this.panelControles  = new System.Windows.Forms.Panel();
            this.lblJornada      = new System.Windows.Forms.Label();
            this.dtpJornada      = new System.Windows.Forms.DateTimePicker();
            this.btnGenerar      = new System.Windows.Forms.Button();
            this.btnExportar     = new System.Windows.Forms.Button();
            this.lblComparar     = new System.Windows.Forms.Label();
            this.dtpJornada2     = new System.Windows.Forms.DateTimePicker();
            this.btnComparar     = new System.Windows.Forms.Button();
            this.btnExportarComp = new System.Windows.Forms.Button();
            this.btnLimpiar      = new System.Windows.Forms.Button();
            this.rtbReporte      = new System.Windows.Forms.RichTextBox();
            this.panelStatus     = new System.Windows.Forms.Panel();
            this.lblStatus       = new System.Windows.Forms.Label();
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
            this.lblPatron.ForeColor = System.Drawing.Color.FromArgb(255, 210, 220);
            this.lblPatron.Location = new System.Drawing.Point(12, 34);
            this.lblPatron.Name = "lblPatron";
            this.lblPatron.Size = new System.Drawing.Size(900, 16);
            this.lblPatron.TabIndex = 1;
            this.lblPatron.Text = "Subastas cerradas de la jornada con exportación a TXT y PDF";
            //
            // panelControles
            //
            this.panelControles.BackColor = System.Drawing.Color.FromArgb(240, 232, 238);
            this.panelControles.Controls.Add(this.lblJornada);
            this.panelControles.Controls.Add(this.dtpJornada);
            this.panelControles.Controls.Add(this.btnGenerar);
            this.panelControles.Controls.Add(this.btnExportar);
            this.panelControles.Controls.Add(this.lblComparar);
            this.panelControles.Controls.Add(this.dtpJornada2);
            this.panelControles.Controls.Add(this.btnComparar);
            this.panelControles.Controls.Add(this.btnExportarComp);
            this.panelControles.Controls.Add(this.btnLimpiar);
            this.panelControles.Location = new System.Drawing.Point(10, 66);
            this.panelControles.Name = "panelControles";
            this.panelControles.Size = new System.Drawing.Size(1360, 88);
            this.panelControles.TabIndex = 1;
            //
            // lblJornada
            //
            this.lblJornada.AutoSize = true;
            this.lblJornada.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblJornada.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblJornada.Location = new System.Drawing.Point(10, 15);
            this.lblJornada.Name = "lblJornada";
            this.lblJornada.Size = new System.Drawing.Size(53, 15);
            this.lblJornada.TabIndex = 0;
            this.lblJornada.Text = "Jornada:";
            //
            // dtpJornada
            //
            this.dtpJornada.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpJornada.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpJornada.CustomFormat = "dd'/'MM'/'yyyy";
            this.dtpJornada.Location = new System.Drawing.Point(72, 12);
            this.dtpJornada.Name = "dtpJornada";
            this.dtpJornada.Size = new System.Drawing.Size(120, 23);
            this.dtpJornada.TabIndex = 1;
            this.dtpJornada.ValueChanged += new System.EventHandler(this.dtpJornada_ValueChanged);
            //
            // btnGenerar
            //
            this.btnGenerar.BackColor = System.Drawing.Color.FromArgb(210, 100, 135);
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
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(148, 72, 102);
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(382, 11);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(170, 28);
            this.btnExportar.TabIndex = 3;
            this.btnExportar.Text = "⬇  Exportar reporte...";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            //
            // lblComparar
            //
            this.lblComparar.AutoSize = true;
            this.lblComparar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblComparar.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblComparar.Location = new System.Drawing.Point(10, 55);
            this.lblComparar.Name = "lblComparar";
            this.lblComparar.Size = new System.Drawing.Size(88, 15);
            this.lblComparar.TabIndex = 5;
            this.lblComparar.Text = "Comparar con:";
            //
            // dtpJornada2
            //
            this.dtpJornada2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpJornada2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpJornada2.CustomFormat = "dd'/'MM'/'yyyy";
            this.dtpJornada2.Location = new System.Drawing.Point(108, 51);
            this.dtpJornada2.Name = "dtpJornada2";
            this.dtpJornada2.Size = new System.Drawing.Size(120, 23);
            this.dtpJornada2.TabIndex = 6;
            //
            // btnComparar
            //
            this.btnComparar.BackColor = System.Drawing.Color.FromArgb(175, 90, 125);
            this.btnComparar.FlatAppearance.BorderSize = 0;
            this.btnComparar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComparar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnComparar.ForeColor = System.Drawing.Color.White;
            this.btnComparar.Location = new System.Drawing.Point(246, 49);
            this.btnComparar.Name = "btnComparar";
            this.btnComparar.Size = new System.Drawing.Size(200, 28);
            this.btnComparar.TabIndex = 7;
            this.btnComparar.Text = "⚖  Comparar Jornadas";
            this.btnComparar.UseVisualStyleBackColor = false;
            this.btnComparar.Click += new System.EventHandler(this.btnComparar_Click);
            //
            // btnExportarComp
            //
            this.btnExportarComp.BackColor = System.Drawing.Color.FromArgb(148, 72, 102);
            this.btnExportarComp.FlatAppearance.BorderSize = 0;
            this.btnExportarComp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarComp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportarComp.ForeColor = System.Drawing.Color.White;
            this.btnExportarComp.Location = new System.Drawing.Point(458, 49);
            this.btnExportarComp.Name = "btnExportarComp";
            this.btnExportarComp.Size = new System.Drawing.Size(185, 28);
            this.btnExportarComp.TabIndex = 8;
            this.btnExportarComp.Text = "⬇  Exportar comparación...";
            this.btnExportarComp.UseVisualStyleBackColor = false;
            this.btnExportarComp.Click += new System.EventHandler(this.btnExportarComp_Click);
            //
            // btnLimpiar
            //
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(215, 190, 200);
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(72, 38, 52);
            this.btnLimpiar.Location = new System.Drawing.Point(655, 49);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(175, 28);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "↩  Volver al reporte";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            //
            // rtbReporte
            //
            this.rtbReporte.BackColor = System.Drawing.Color.FromArgb(255, 252, 235);
            this.rtbReporte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbReporte.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.rtbReporte.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.rtbReporte.Anchor = ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Top    |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left   |
                System.Windows.Forms.AnchorStyles.Right));
            this.rtbReporte.Location = new System.Drawing.Point(10, 164);
            this.rtbReporte.Name = "rtbReporte";
            this.rtbReporte.ReadOnly = true;
            this.rtbReporte.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbReporte.Size = new System.Drawing.Size(1360, 482);
            this.rtbReporte.TabIndex = 0;
            this.rtbReporte.Text = "";
            //
            // panelStatus
            //
            this.panelStatus.BackColor = System.Drawing.Color.FromArgb(230, 230, 240);
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
            this.BackColor = System.Drawing.Color.FromArgb(252, 228, 235);
            this.ClientSize = new System.Drawing.Size(1380, 720);
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

        private System.Windows.Forms.Panel           panelTop;
        private System.Windows.Forms.Label           lblTitulo;
        private System.Windows.Forms.Label           lblPatron;
        private System.Windows.Forms.Panel           panelControles;
        private System.Windows.Forms.Label           lblJornada;
        private System.Windows.Forms.DateTimePicker  dtpJornada;
        private System.Windows.Forms.Button          btnGenerar;
        private System.Windows.Forms.Button          btnExportar;
        private System.Windows.Forms.Label           lblComparar;
        private System.Windows.Forms.DateTimePicker  dtpJornada2;
        private System.Windows.Forms.Button          btnComparar;
        private System.Windows.Forms.Button          btnExportarComp;
        private System.Windows.Forms.Button          btnLimpiar;
        private System.Windows.Forms.RichTextBox     rtbReporte;
        private System.Windows.Forms.Panel           panelStatus;
        private System.Windows.Forms.Label           lblStatus;
    }
}
