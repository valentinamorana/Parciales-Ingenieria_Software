namespace AlmonedaNacional.GUI
{
    partial class frmBitacora
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
            this.panelTop       = new System.Windows.Forms.Panel();
            this.lblTitulo      = new System.Windows.Forms.Label();
            this.lblPatron      = new System.Windows.Forms.Label();
            this.panelFiltros   = new System.Windows.Forms.Panel();
            this.lblDias        = new System.Windows.Forms.Label();
            this.nudDias        = new System.Windows.Forms.NumericUpDown();
            this.lblDias2       = new System.Windows.Forms.Label();
            this.lblCritLbl     = new System.Windows.Forms.Label();
            this.cmbCriticidad  = new System.Windows.Forms.ComboBox();
            this.lblOpLbl       = new System.Windows.Forms.Label();
            this.cmbOperacion   = new System.Windows.Forms.ComboBox();
            this.btnBuscar      = new System.Windows.Forms.Button();
            this.btnLimpiar     = new System.Windows.Forms.Button();
            this.btnExportarPdf = new System.Windows.Forms.Button();
            this.dgvBitacora    = new System.Windows.Forms.DataGridView();
            this.panelStatus    = new System.Windows.Forms.Panel();
            this.lblConteo      = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).BeginInit();
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
            this.lblTitulo.Size = new System.Drawing.Size(600, 26);
            this.lblTitulo.Text = "Bitácora de Operaciones";
            //
            // lblPatron
            //
            this.lblPatron.AutoSize = false;
            this.lblPatron.BackColor = System.Drawing.Color.Transparent;
            this.lblPatron.ForeColor = System.Drawing.Color.FromArgb(255, 210, 220);
            this.lblPatron.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblPatron.Location = new System.Drawing.Point(12, 34);
            this.lblPatron.Size = new System.Drawing.Size(800, 16);
            this.lblPatron.Text = "Auditoría del sistema — registro completo de operaciones con filtros por criticidad y tipo";
            //
            // panelFiltros
            //
            this.panelFiltros.BackColor = System.Drawing.Color.FromArgb(252, 228, 235);
            this.panelFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFiltros.Controls.Add(this.lblDias);
            this.panelFiltros.Controls.Add(this.nudDias);
            this.panelFiltros.Controls.Add(this.lblDias2);
            this.panelFiltros.Controls.Add(this.lblCritLbl);
            this.panelFiltros.Controls.Add(this.cmbCriticidad);
            this.panelFiltros.Controls.Add(this.lblOpLbl);
            this.panelFiltros.Controls.Add(this.cmbOperacion);
            this.panelFiltros.Controls.Add(this.btnBuscar);
            this.panelFiltros.Controls.Add(this.btnLimpiar);
            this.panelFiltros.Controls.Add(this.btnExportarPdf);
            this.panelFiltros.Location = new System.Drawing.Point(10, 66);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(1160, 52);
            //
            // lblDias
            //
            this.lblDias.AutoSize = true;
            this.lblDias.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDias.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblDias.Location = new System.Drawing.Point(10, 16);
            this.lblDias.Text = "Últimos";
            //
            // nudDias
            //
            this.nudDias.BackColor = System.Drawing.Color.FromArgb(245, 245, 248);
            this.nudDias.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudDias.Location = new System.Drawing.Point(68, 14);
            this.nudDias.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
            this.nudDias.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.nudDias.Name = "nudDias";
            this.nudDias.Size = new System.Drawing.Size(60, 24);
            this.nudDias.Value = new decimal(new int[] { 0, 0, 0, 0 });
            //
            // lblDias2
            //
            this.lblDias2.AutoSize = true;
            this.lblDias2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDias2.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblDias2.Location = new System.Drawing.Point(134, 16);
            this.lblDias2.Text = "días  (0 = todos)";
            //
            // lblCritLbl
            //
            this.lblCritLbl.AutoSize = true;
            this.lblCritLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCritLbl.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblCritLbl.Location = new System.Drawing.Point(280, 16);
            this.lblCritLbl.Text = "Criticidad:";
            //
            // cmbCriticidad
            //
            this.cmbCriticidad.BackColor = System.Drawing.Color.FromArgb(245, 245, 248);
            this.cmbCriticidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCriticidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCriticidad.Location = new System.Drawing.Point(354, 13);
            this.cmbCriticidad.Name = "cmbCriticidad";
            this.cmbCriticidad.Size = new System.Drawing.Size(110, 24);
            //
            // lblOpLbl
            //
            this.lblOpLbl.AutoSize = true;
            this.lblOpLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOpLbl.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblOpLbl.Location = new System.Drawing.Point(480, 16);
            this.lblOpLbl.Text = "Operación:";
            //
            // cmbOperacion
            //
            this.cmbOperacion.BackColor = System.Drawing.Color.FromArgb(245, 245, 248);
            this.cmbOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperacion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbOperacion.Location = new System.Drawing.Point(556, 13);
            this.cmbOperacion.Name = "cmbOperacion";
            this.cmbOperacion.Size = new System.Drawing.Size(180, 24);
            //
            // btnBuscar
            //
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(210, 100, 135);
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.Location = new System.Drawing.Point(754, 11);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 28);
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            //
            // btnLimpiar
            //
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(200, 200, 210);
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.Location = new System.Drawing.Point(862, 11);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 28);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            //
            // btnExportarPdf
            //
            this.btnExportarPdf.BackColor = System.Drawing.Color.FromArgb(160, 60, 100);
            this.btnExportarPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarPdf.FlatAppearance.BorderSize = 0;
            this.btnExportarPdf.ForeColor = System.Drawing.Color.White;
            this.btnExportarPdf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportarPdf.Location = new System.Drawing.Point(970, 11);
            this.btnExportarPdf.Name = "btnExportarPdf";
            this.btnExportarPdf.Size = new System.Drawing.Size(140, 28);
            this.btnExportarPdf.Text = "Exportar PDF";
            this.btnExportarPdf.UseVisualStyleBackColor = false;
            this.btnExportarPdf.Click += new System.EventHandler(this.btnExportarPdf_Click);
            //
            // dgvBitacora
            //
            this.dgvBitacora.AllowUserToAddRows = false;
            this.dgvBitacora.AllowUserToDeleteRows = false;
            this.dgvBitacora.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBitacora.BackgroundColor = System.Drawing.Color.White;
            this.dgvBitacora.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBitacora.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 182, 193);
            this.dgvBitacora.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvBitacora.Location = new System.Drawing.Point(10, 128);
            this.dgvBitacora.MultiSelect = false;
            this.dgvBitacora.Name = "dgvBitacora";
            this.dgvBitacora.ReadOnly = true;
            this.dgvBitacora.RowHeadersVisible = false;
            this.dgvBitacora.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBitacora.Size = new System.Drawing.Size(1160, 520);
            this.dgvBitacora.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBitacora_CellFormatting);
            //
            // panelStatus
            //
            this.panelStatus.BackColor = System.Drawing.Color.FromArgb(230, 230, 240);
            this.panelStatus.Controls.Add(this.lblConteo);
            this.panelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatus.Height = 28;
            this.panelStatus.Name = "panelStatus";
            //
            // lblConteo
            //
            this.lblConteo.AutoSize = true;
            this.lblConteo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblConteo.ForeColor = System.Drawing.Color.DimGray;
            this.lblConteo.Location = new System.Drawing.Point(8, 6);
            this.lblConteo.Name = "lblConteo";
            this.lblConteo.Text = "Registros: —";
            //
            // frmBitacora
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(252, 228, 235);
            this.ClientSize = new System.Drawing.Size(1180, 685);
            this.Controls.Add(this.dgvBitacora);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.panelTop);
            this.Name = "frmBitacora";
            this.Text = "Bitácora de Operaciones";
            this.Load += new System.EventHandler(this.frmBitacora_Load);
            this.panelTop.ResumeLayout(false);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).EndInit();
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel           panelTop;
        private System.Windows.Forms.Label           lblTitulo;
        private System.Windows.Forms.Label           lblPatron;
        private System.Windows.Forms.Panel           panelFiltros;
        private System.Windows.Forms.Label           lblDias;
        private System.Windows.Forms.NumericUpDown   nudDias;
        private System.Windows.Forms.Label           lblDias2;
        private System.Windows.Forms.Label           lblCritLbl;
        private System.Windows.Forms.ComboBox        cmbCriticidad;
        private System.Windows.Forms.Label           lblOpLbl;
        private System.Windows.Forms.ComboBox        cmbOperacion;
        private System.Windows.Forms.Button          btnBuscar;
        private System.Windows.Forms.Button          btnLimpiar;
        private System.Windows.Forms.Button          btnExportarPdf;
        private System.Windows.Forms.DataGridView    dgvBitacora;
        private System.Windows.Forms.Panel           panelStatus;
        private System.Windows.Forms.Label           lblConteo;
    }
}
