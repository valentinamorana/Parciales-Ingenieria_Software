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
            this.panelTop           = new System.Windows.Forms.Panel();
            this.lblPatron          = new System.Windows.Forms.Label();
            this.lblTitulo          = new System.Windows.Forms.Label();
            this.btnActualizar      = new System.Windows.Forms.Button();
            this.lblTotal           = new System.Windows.Forms.Label();
            this.dgvHistorial       = new System.Windows.Forms.DataGridView();
            this.panelDetalle       = new System.Windows.Forms.Panel();
            this.lblDetalleTitulo   = new System.Windows.Forms.Label();
            this.rtbDetalle         = new System.Windows.Forms.RichTextBox();
            this.panelTop.SuspendLayout();
            this.panelDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            //
            // panelTop
            //
            this.panelTop.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Controls.Add(this.lblPatron);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 55;
            this.panelTop.Name = "panelTop";
            //
            // lblPatron
            //
            this.lblPatron.AutoSize = false;
            this.lblPatron.BackColor = System.Drawing.Color.Transparent;
            this.lblPatron.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblPatron.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblPatron.Location = new System.Drawing.Point(10, 32);
            this.lblPatron.Name = "lblPatron";
            this.lblPatron.Size = new System.Drawing.Size(400, 16);
            this.lblPatron.Text = "RF-13 — Consulta historial de subastas cerradas (lectura desde BD vía SubastaBLL)";
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(10, 6);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(450, 26);
            this.lblTitulo.Text = "Historial de Subastas";
            //
            // btnActualizar
            //
            this.btnActualizar.Location = new System.Drawing.Point(10, 65);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(150, 30);
            this.btnActualizar.TabIndex = 0;
            this.btnActualizar.Text = "Actualizar desde BD";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            //
            // lblTotal
            //
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblTotal.Location = new System.Drawing.Point(175, 73);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Text = "Total de subastas registradas: —";
            //
            // dgvHistorial
            //
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(10, 105);
            this.dgvHistorial.MultiSelect = false;
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.Size = new System.Drawing.Size(1160, 380);
            this.dgvHistorial.TabIndex = 1;
            this.dgvHistorial.SelectionChanged += new System.EventHandler(this.dgvHistorial_SelectionChanged);
            //
            // panelDetalle
            //
            this.panelDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDetalle.Controls.Add(this.rtbDetalle);
            this.panelDetalle.Controls.Add(this.lblDetalleTitulo);
            this.panelDetalle.Location = new System.Drawing.Point(10, 495);
            this.panelDetalle.Name = "panelDetalle";
            this.panelDetalle.Size = new System.Drawing.Size(1160, 180);
            //
            // lblDetalleTitulo
            //
            this.lblDetalleTitulo.AutoSize = true;
            this.lblDetalleTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDetalleTitulo.Location = new System.Drawing.Point(5, 5);
            this.lblDetalleTitulo.Name = "lblDetalleTitulo";
            this.lblDetalleTitulo.Text = "Detalle del registro seleccionado:";
            //
            // rtbDetalle
            //
            this.rtbDetalle.BackColor = System.Drawing.Color.White;
            this.rtbDetalle.Font = new System.Drawing.Font("Consolas", 9F);
            this.rtbDetalle.Location = new System.Drawing.Point(5, 25);
            this.rtbDetalle.Name = "rtbDetalle";
            this.rtbDetalle.ReadOnly = true;
            this.rtbDetalle.Size = new System.Drawing.Size(1148, 148);
            this.rtbDetalle.TabIndex = 0;
            this.rtbDetalle.Text = "";
            //
            // frmHistorial
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 685);
            this.Controls.Add(this.panelDetalle);
            this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.panelTop);
            this.Name = "frmHistorial";
            this.Text = "Historial de Subastas — RF-13";
            this.Load += new System.EventHandler(this.frmHistorial_Load);
            this.panelTop.ResumeLayout(false);
            this.panelDetalle.ResumeLayout(false);
            this.panelDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblPatron;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Panel panelDetalle;
        private System.Windows.Forms.Label lblDetalleTitulo;
        private System.Windows.Forms.RichTextBox rtbDetalle;
    }
}
