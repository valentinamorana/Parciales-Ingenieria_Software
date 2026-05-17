namespace AlmonedaNacional.GUI
{
    partial class frmCatalogo
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
            this.panelIzquierdo     = new System.Windows.Forms.Panel();
            this.lblPatron          = new System.Windows.Forms.Label();
            this.lblTituloArbol     = new System.Windows.Forms.Label();
            this.treeViewCatalogo   = new System.Windows.Forms.TreeView();
            this.btnVerDescripcion  = new System.Windows.Forms.Button();
            this.panelDerecho       = new System.Windows.Forms.Panel();
            this.lblTituloGrilla    = new System.Windows.Forms.Label();
            this.dgvCatalogo        = new System.Windows.Forms.DataGridView();
            this.lblDescTitulo      = new System.Windows.Forms.Label();
            this.rtbDescripcion     = new System.Windows.Forms.RichTextBox();
            this.lblPrecioLabel     = new System.Windows.Forms.Label();
            this.lblPrecioBase      = new System.Windows.Forms.Label();
            this.panelIzquierdo.SuspendLayout();
            this.panelDerecho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogo)).BeginInit();
            this.SuspendLayout();
            //
            // panelIzquierdo
            //
            this.panelIzquierdo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelIzquierdo.Controls.Add(this.btnVerDescripcion);
            this.panelIzquierdo.Controls.Add(this.treeViewCatalogo);
            this.panelIzquierdo.Controls.Add(this.lblTituloArbol);
            this.panelIzquierdo.Controls.Add(this.lblPatron);
            this.panelIzquierdo.Location = new System.Drawing.Point(5, 5);
            this.panelIzquierdo.Name = "panelIzquierdo";
            this.panelIzquierdo.Size = new System.Drawing.Size(260, 680);
            //
            // lblPatron
            //
            this.lblPatron.AutoSize = false;
            this.lblPatron.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lblPatron.ForeColor = System.Drawing.Color.White;
            this.lblPatron.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPatron.Location = new System.Drawing.Point(5, 5);
            this.lblPatron.Name = "lblPatron";
            this.lblPatron.Size = new System.Drawing.Size(248, 24);
            this.lblPatron.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPatron.Text = "Patrón: COMPOSITE";
            //
            // lblTituloArbol
            //
            this.lblTituloArbol.AutoSize = true;
            this.lblTituloArbol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTituloArbol.Location = new System.Drawing.Point(5, 36);
            this.lblTituloArbol.Name = "lblTituloArbol";
            this.lblTituloArbol.Text = "Jerarquía del Catálogo:";
            //
            // treeViewCatalogo
            //
            this.treeViewCatalogo.Location = new System.Drawing.Point(5, 56);
            this.treeViewCatalogo.Name = "treeViewCatalogo";
            this.treeViewCatalogo.Size = new System.Drawing.Size(248, 540);
            this.treeViewCatalogo.TabIndex = 0;
            this.treeViewCatalogo.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewCatalogo_AfterSelect);
            //
            // btnVerDescripcion
            //
            this.btnVerDescripcion.Location = new System.Drawing.Point(5, 604);
            this.btnVerDescripcion.Name = "btnVerDescripcion";
            this.btnVerDescripcion.Size = new System.Drawing.Size(248, 32);
            this.btnVerDescripcion.TabIndex = 1;
            this.btnVerDescripcion.Text = "Ver Descripción Completa";
            this.btnVerDescripcion.UseVisualStyleBackColor = true;
            this.btnVerDescripcion.Click += new System.EventHandler(this.btnVerDescripcion_Click);
            //
            // panelDerecho
            //
            this.panelDerecho.Controls.Add(this.lblPrecioBase);
            this.panelDerecho.Controls.Add(this.lblPrecioLabel);
            this.panelDerecho.Controls.Add(this.rtbDescripcion);
            this.panelDerecho.Controls.Add(this.lblDescTitulo);
            this.panelDerecho.Controls.Add(this.dgvCatalogo);
            this.panelDerecho.Controls.Add(this.lblTituloGrilla);
            this.panelDerecho.Location = new System.Drawing.Point(275, 5);
            this.panelDerecho.Name = "panelDerecho";
            this.panelDerecho.Size = new System.Drawing.Size(900, 680);
            //
            // lblTituloGrilla
            //
            this.lblTituloGrilla.AutoSize = true;
            this.lblTituloGrilla.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTituloGrilla.Location = new System.Drawing.Point(5, 5);
            this.lblTituloGrilla.Name = "lblTituloGrilla";
            this.lblTituloGrilla.Text = "Todas las Unidades de Venta:";
            //
            // dgvCatalogo
            //
            this.dgvCatalogo.AllowUserToAddRows = false;
            this.dgvCatalogo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCatalogo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCatalogo.Location = new System.Drawing.Point(5, 25);
            this.dgvCatalogo.MultiSelect = false;
            this.dgvCatalogo.Name = "dgvCatalogo";
            this.dgvCatalogo.ReadOnly = true;
            this.dgvCatalogo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCatalogo.Size = new System.Drawing.Size(888, 280);
            this.dgvCatalogo.TabIndex = 2;
            this.dgvCatalogo.SelectionChanged += new System.EventHandler(this.dgvCatalogo_SelectionChanged);
            //
            // lblDescTitulo
            //
            this.lblDescTitulo.AutoSize = true;
            this.lblDescTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDescTitulo.Location = new System.Drawing.Point(5, 315);
            this.lblDescTitulo.Name = "lblDescTitulo";
            this.lblDescTitulo.Text = "ObtenerDescripcion() — recorre toda la jerarquía (RF-04):";
            //
            // rtbDescripcion
            //
            this.rtbDescripcion.BackColor = System.Drawing.Color.White;
            this.rtbDescripcion.Font = new System.Drawing.Font("Consolas", 9F);
            this.rtbDescripcion.Location = new System.Drawing.Point(5, 335);
            this.rtbDescripcion.Name = "rtbDescripcion";
            this.rtbDescripcion.ReadOnly = true;
            this.rtbDescripcion.Size = new System.Drawing.Size(888, 280);
            this.rtbDescripcion.TabIndex = 3;
            this.rtbDescripcion.Text = "";
            //
            // lblPrecioLabel
            //
            this.lblPrecioLabel.AutoSize = true;
            this.lblPrecioLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPrecioLabel.Location = new System.Drawing.Point(5, 625);
            this.lblPrecioLabel.Name = "lblPrecioLabel";
            this.lblPrecioLabel.Text = "CalcularPrecioBase() (RF-03):";
            //
            // lblPrecioBase
            //
            this.lblPrecioBase.AutoSize = true;
            this.lblPrecioBase.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPrecioBase.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblPrecioBase.Location = new System.Drawing.Point(220, 623);
            this.lblPrecioBase.Name = "lblPrecioBase";
            this.lblPrecioBase.Text = "—";
            //
            // frmCatalogo
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 700);
            this.Controls.Add(this.panelIzquierdo);
            this.Controls.Add(this.panelDerecho);
            this.Name = "frmCatalogo";
            this.Text = "Catálogo de Unidades de Venta — Patrón COMPOSITE";
            this.Load += new System.EventHandler(this.frmCatalogo_Load);
            this.panelIzquierdo.ResumeLayout(false);
            this.panelIzquierdo.PerformLayout();
            this.panelDerecho.ResumeLayout(false);
            this.panelDerecho.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogo)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelIzquierdo;
        private System.Windows.Forms.Panel panelDerecho;
        private System.Windows.Forms.Label lblPatron;
        private System.Windows.Forms.Label lblTituloArbol;
        private System.Windows.Forms.TreeView treeViewCatalogo;
        private System.Windows.Forms.Button btnVerDescripcion;
        private System.Windows.Forms.Label lblTituloGrilla;
        private System.Windows.Forms.DataGridView dgvCatalogo;
        private System.Windows.Forms.Label lblDescTitulo;
        private System.Windows.Forms.RichTextBox rtbDescripcion;
        private System.Windows.Forms.Label lblPrecioLabel;
        private System.Windows.Forms.Label lblPrecioBase;
    }
}
