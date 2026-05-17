namespace AlmonedaNacional.GUI
{
    partial class frmHistorial
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
            this.panelTop         = new System.Windows.Forms.Panel();
            this.lblTitulo        = new System.Windows.Forms.Label();
            this.lblPatron        = new System.Windows.Forms.Label();
            this.btnActualizar    = new System.Windows.Forms.Button();
            this.lblTotal         = new System.Windows.Forms.Label();
            this.dgvHistorial     = new System.Windows.Forms.DataGridView();
            this.panelDetalle     = new System.Windows.Forms.Panel();
            this.lblDetalleTitulo = new System.Windows.Forms.Label();
            this.rtbDetalle       = new System.Windows.Forms.RichTextBox();
            this.panelStatus      = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            this.panelDetalle.SuspendLayout();
            this.panelStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            //
            // panelTop — rosa brand (igual header de WardrobeFlow)
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
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(500, 26);
            this.lblTitulo.Text = "Historial de Subastas";
            //
            // lblPatron
            //
            this.lblPatron.AutoSize = false;
            this.lblPatron.BackColor = System.Drawing.Color.Transparent;
            this.lblPatron.ForeColor = System.Drawing.Color.FromArgb(255, 210, 220);
            this.lblPatron.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblPatron.Location = new System.Drawing.Point(12, 34);
            this.lblPatron.Name = "lblPatron";
            this.lblPatron.Size = new System.Drawing.Size(600, 16);
            this.lblPatron.Text = "RF-13 — Consulta historial de subastas cerradas (lectura desde BD vía SubastaBLL)";
            //
            // panelStatus — barra inferior gris claro (igual WardrobeFlow)
            //
            this.panelStatus.BackColor = System.Drawing.Color.FromArgb(230, 230, 240);
            this.panelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatus.Height = 28;
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Controls.Add(this.lblTotal);
            //
            // lblTotal
            //
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTotal.ForeColor = System.Drawing.Color.DimGray;
            this.lblTotal.Location = new System.Drawing.Point(8, 6);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Text = "Total de subastas registradas: —";
            //
            // btnActualizar
            //
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(210, 100, 135);
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.Location = new System.Drawing.Point(10, 66);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(160, 28);
            this.btnActualizar.TabIndex = 0;
            this.btnActualizar.Text = "↻  Actualizar desde BD";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            //
            // dgvHistorial
            //
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 182, 193);
            this.dgvHistorial.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvHistorial.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 248, 252);
            this.dgvHistorial.Location = new System.Drawing.Point(10, 104);
            this.dgvHistorial.MultiSelect = false;
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersVisible = false;
            this.dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.Size = new System.Drawing.Size(1160, 350);
            this.dgvHistorial.TabIndex = 1;
            this.dgvHistorial.SelectionChanged += new System.EventHandler(this.dgvHistorial_SelectionChanged);
            //
            // panelDetalle
            //
            this.panelDetalle.BackColor = System.Drawing.Color.FromArgb(255, 252, 235);
            this.panelDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDetalle.Controls.Add(this.rtbDetalle);
            this.panelDetalle.Controls.Add(this.lblDetalleTitulo);
            this.panelDetalle.Location = new System.Drawing.Point(10, 464);
            this.panelDetalle.Name = "panelDetalle";
            this.panelDetalle.Size = new System.Drawing.Size(1160, 185);
            //
            // lblDetalleTitulo
            //
            this.lblDetalleTitulo.AutoSize = true;
            this.lblDetalleTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDetalleTitulo.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblDetalleTitulo.Location = new System.Drawing.Point(6, 6);
            this.lblDetalleTitulo.Name = "lblDetalleTitulo";
            this.lblDetalleTitulo.Text = "Detalle del registro seleccionado:";
            //
            // rtbDetalle
            //
            this.rtbDetalle.BackColor = System.Drawing.Color.FromArgb(255, 252, 235);
            this.rtbDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDetalle.Font = new System.Drawing.Font("Consolas", 9F);
            this.rtbDetalle.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.rtbDetalle.Location = new System.Drawing.Point(6, 26);
            this.rtbDetalle.Name = "rtbDetalle";
            this.rtbDetalle.ReadOnly = true;
            this.rtbDetalle.Size = new System.Drawing.Size(1146, 152);
            this.rtbDetalle.TabIndex = 0;
            this.rtbDetalle.Text = "";
            //
            // frmHistorial
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(252, 228, 235);
            this.ClientSize = new System.Drawing.Size(1180, 685);
            this.Controls.Add(this.panelDetalle);
            this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.panelTop);
            this.Name = "frmHistorial";
            this.Text = "Historial de Subastas — RF-13";
            this.Load += new System.EventHandler(this.frmHistorial_Load);
            this.panelTop.ResumeLayout(false);
            this.panelDetalle.ResumeLayout(false);
            this.panelDetalle.PerformLayout();
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblPatron;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Panel panelDetalle;
        private System.Windows.Forms.Label lblDetalleTitulo;
        private System.Windows.Forms.RichTextBox rtbDetalle;
        private System.Windows.Forms.Panel panelStatus;
    }
}
