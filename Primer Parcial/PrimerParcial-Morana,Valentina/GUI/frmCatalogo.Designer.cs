namespace GUI
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
            this.panelTop          = new System.Windows.Forms.Panel();
            this.lblTitulo         = new System.Windows.Forms.Label();
            this.lblSubtitulo      = new System.Windows.Forms.Label();
            this.panelStatus       = new System.Windows.Forms.Panel();
            this.lblStatus         = new System.Windows.Forms.Label();
            this.panelIzquierdo     = new System.Windows.Forms.Panel();
            this.pnlHeaderArbol     = new System.Windows.Forms.Panel();
            this.lblTituloArbol     = new System.Windows.Forms.Label();
            this.btnAgregarArticulo = new System.Windows.Forms.Button();
            this.btnAgregarLote     = new System.Windows.Forms.Button();
            this.treeViewCatalogo   = new System.Windows.Forms.TreeView();
            this.btnVerDescripcion  = new System.Windows.Forms.Button();
            this.panelDerecho      = new System.Windows.Forms.Panel();
            this.pnlHeaderGrilla   = new System.Windows.Forms.Panel();
            this.lblTituloGrilla   = new System.Windows.Forms.Label();
            this.dgvCatalogo       = new System.Windows.Forms.DataGridView();
            this.panelDescripcion  = new System.Windows.Forms.Panel();
            this.lblDescTitulo     = new System.Windows.Forms.Label();
            this.rtbDescripcion    = new System.Windows.Forms.RichTextBox();
            this.panelPrecio       = new System.Windows.Forms.Panel();
            this.lblPrecioLabel    = new System.Windows.Forms.Label();
            this.lblPrecioBase     = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelStatus.SuspendLayout();
            this.panelIzquierdo.SuspendLayout();
            this.pnlHeaderArbol.SuspendLayout();
            this.panelDerecho.SuspendLayout();
            this.pnlHeaderGrilla.SuspendLayout();
            this.panelDescripcion.SuspendLayout();
            this.panelPrecio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogo)).BeginInit();
            this.SuspendLayout();
            //
            // panelTop — header rosa brand
            //
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(210, 100, 135);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Controls.Add(this.lblSubtitulo);
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
            this.lblTitulo.Size = new System.Drawing.Size(700, 26);
            this.lblTitulo.Text = "Catálogo de Unidades de Venta";
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize = false;
            this.lblSubtitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(255, 210, 220);
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblSubtitulo.Location = new System.Drawing.Point(12, 34);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(750, 16);
            this.lblSubtitulo.Text = "Patrón COMPOSITE — artículos simples (hojas) y lotes (compuestos) con profundidad ilimitada";
            //
            // panelStatus — barra inferior gris claro
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
            this.lblStatus.Text = "Seleccioná un elemento para ver su descripción y precio base.";
            //
            // panelIzquierdo
            //
            this.panelIzquierdo.BackColor = System.Drawing.Color.FromArgb(245, 245, 250);
            this.panelIzquierdo.Controls.Add(this.btnVerDescripcion);
            this.panelIzquierdo.Controls.Add(this.treeViewCatalogo);
            this.panelIzquierdo.Controls.Add(this.btnAgregarLote);
            this.panelIzquierdo.Controls.Add(this.btnAgregarArticulo);
            this.panelIzquierdo.Controls.Add(this.pnlHeaderArbol);
            this.panelIzquierdo.Location = new System.Drawing.Point(5, 62);
            this.panelIzquierdo.Name = "panelIzquierdo";
            this.panelIzquierdo.Size = new System.Drawing.Size(265, 610);
            //
            // pnlHeaderArbol — sub-header rosa suave
            //
            this.pnlHeaderArbol.BackColor = System.Drawing.Color.FromArgb(235, 185, 200);
            this.pnlHeaderArbol.Controls.Add(this.lblTituloArbol);
            this.pnlHeaderArbol.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderArbol.Height = 28;
            this.pnlHeaderArbol.Name = "pnlHeaderArbol";
            //
            // lblTituloArbol
            //
            this.lblTituloArbol.AutoSize = false;
            this.lblTituloArbol.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloArbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTituloArbol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTituloArbol.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblTituloArbol.Name = "lblTituloArbol";
            this.lblTituloArbol.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblTituloArbol.Text = "Jerarquía del Catálogo";
            this.lblTituloArbol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // treeViewCatalogo
            //
            this.treeViewCatalogo.BackColor = System.Drawing.Color.FromArgb(252, 248, 250);
            this.treeViewCatalogo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewCatalogo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.treeViewCatalogo.Location = new System.Drawing.Point(0, 90);
            this.treeViewCatalogo.Name = "treeViewCatalogo";
            this.treeViewCatalogo.Size = new System.Drawing.Size(265, 480);
            this.treeViewCatalogo.TabIndex = 0;
            this.treeViewCatalogo.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewCatalogo_AfterSelect);
            //
            // btnVerDescripcion
            //
            this.btnVerDescripcion.BackColor = System.Drawing.Color.FromArgb(210, 100, 135);
            this.btnVerDescripcion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerDescripcion.FlatAppearance.BorderSize = 0;
            this.btnVerDescripcion.ForeColor = System.Drawing.Color.White;
            this.btnVerDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnVerDescripcion.Location = new System.Drawing.Point(0, 574);
            this.btnVerDescripcion.Name = "btnVerDescripcion";
            this.btnVerDescripcion.Size = new System.Drawing.Size(265, 32);
            this.btnVerDescripcion.TabIndex = 1;
            this.btnVerDescripcion.Text = "Ver Descripción Completa";
            this.btnVerDescripcion.UseVisualStyleBackColor = false;
            this.btnVerDescripcion.Click += new System.EventHandler(this.btnVerDescripcion_Click);
            //
            // btnAgregarArticulo
            //
            this.btnAgregarArticulo.BackColor = System.Drawing.Color.FromArgb(210, 100, 135);
            this.btnAgregarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarArticulo.FlatAppearance.BorderSize = 0;
            this.btnAgregarArticulo.ForeColor = System.Drawing.Color.White;
            this.btnAgregarArticulo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnAgregarArticulo.Location = new System.Drawing.Point(0, 30);
            this.btnAgregarArticulo.Name = "btnAgregarArticulo";
            this.btnAgregarArticulo.Size = new System.Drawing.Size(265, 28);
            this.btnAgregarArticulo.TabIndex = 2;
            this.btnAgregarArticulo.Text = "+  Artículo Simple";
            this.btnAgregarArticulo.UseVisualStyleBackColor = false;
            this.btnAgregarArticulo.Click += new System.EventHandler(this.btnAgregarArticulo_Click);
            //
            // btnAgregarLote
            //
            this.btnAgregarLote.BackColor = System.Drawing.Color.FromArgb(180, 80, 110);
            this.btnAgregarLote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarLote.FlatAppearance.BorderSize = 0;
            this.btnAgregarLote.ForeColor = System.Drawing.Color.White;
            this.btnAgregarLote.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnAgregarLote.Location = new System.Drawing.Point(0, 60);
            this.btnAgregarLote.Name = "btnAgregarLote";
            this.btnAgregarLote.Size = new System.Drawing.Size(265, 28);
            this.btnAgregarLote.TabIndex = 3;
            this.btnAgregarLote.Text = "+  Lote de Artículos";
            this.btnAgregarLote.UseVisualStyleBackColor = false;
            this.btnAgregarLote.Click += new System.EventHandler(this.btnAgregarLote_Click);
            //
            // panelDerecho
            //
            this.panelDerecho.BackColor = System.Drawing.Color.FromArgb(252, 228, 235);
            this.panelDerecho.Controls.Add(this.panelPrecio);
            this.panelDerecho.Controls.Add(this.panelDescripcion);
            this.panelDerecho.Controls.Add(this.dgvCatalogo);
            this.panelDerecho.Controls.Add(this.pnlHeaderGrilla);
            this.panelDerecho.Location = new System.Drawing.Point(278, 62);
            this.panelDerecho.Name = "panelDerecho";
            this.panelDerecho.Size = new System.Drawing.Size(900, 610);
            //
            // pnlHeaderGrilla
            //
            this.pnlHeaderGrilla.BackColor = System.Drawing.Color.FromArgb(235, 185, 200);
            this.pnlHeaderGrilla.Controls.Add(this.lblTituloGrilla);
            this.pnlHeaderGrilla.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderGrilla.Height = 28;
            this.pnlHeaderGrilla.Name = "pnlHeaderGrilla";
            //
            // lblTituloGrilla
            //
            this.lblTituloGrilla.AutoSize = false;
            this.lblTituloGrilla.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTituloGrilla.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTituloGrilla.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblTituloGrilla.Name = "lblTituloGrilla";
            this.lblTituloGrilla.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblTituloGrilla.Text = "Todas las Unidades de Venta";
            this.lblTituloGrilla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // dgvCatalogo
            //
            this.dgvCatalogo.AllowUserToAddRows = false;
            this.dgvCatalogo.AllowUserToDeleteRows = false;
            this.dgvCatalogo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCatalogo.BackgroundColor = System.Drawing.Color.White;
            this.dgvCatalogo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCatalogo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCatalogo.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 182, 193);
            this.dgvCatalogo.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvCatalogo.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 248, 252);
            this.dgvCatalogo.Location = new System.Drawing.Point(0, 28);
            this.dgvCatalogo.MultiSelect = false;
            this.dgvCatalogo.Name = "dgvCatalogo";
            this.dgvCatalogo.ReadOnly = true;
            this.dgvCatalogo.RowHeadersVisible = false;
            this.dgvCatalogo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCatalogo.Size = new System.Drawing.Size(900, 260);
            this.dgvCatalogo.TabIndex = 2;
            this.dgvCatalogo.SelectionChanged += new System.EventHandler(this.dgvCatalogo_SelectionChanged);
            //
            // panelDescripcion — crema (igual WardrobeFlow detalle)
            //
            this.panelDescripcion.BackColor = System.Drawing.Color.FromArgb(255, 252, 235);
            this.panelDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDescripcion.Controls.Add(this.rtbDescripcion);
            this.panelDescripcion.Controls.Add(this.lblDescTitulo);
            this.panelDescripcion.Location = new System.Drawing.Point(0, 294);
            this.panelDescripcion.Name = "panelDescripcion";
            this.panelDescripcion.Size = new System.Drawing.Size(900, 270);
            //
            // lblDescTitulo
            //
            this.lblDescTitulo.AutoSize = true;
            this.lblDescTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDescTitulo.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblDescTitulo.Location = new System.Drawing.Point(6, 6);
            this.lblDescTitulo.Name = "lblDescTitulo";
            this.lblDescTitulo.Text = "ObtenerDescripcion() — recorre toda la jerarquía (RF-04):";
            //
            // rtbDescripcion
            //
            this.rtbDescripcion.BackColor = System.Drawing.Color.FromArgb(255, 252, 235);
            this.rtbDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDescripcion.Font = new System.Drawing.Font("Consolas", 9F);
            this.rtbDescripcion.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.rtbDescripcion.Location = new System.Drawing.Point(6, 26);
            this.rtbDescripcion.Name = "rtbDescripcion";
            this.rtbDescripcion.ReadOnly = true;
            this.rtbDescripcion.Size = new System.Drawing.Size(886, 236);
            this.rtbDescripcion.TabIndex = 3;
            this.rtbDescripcion.Text = "";
            //
            // panelPrecio
            //
            this.panelPrecio.BackColor = System.Drawing.Color.FromArgb(252, 228, 235);
            this.panelPrecio.Controls.Add(this.lblPrecioLabel);
            this.panelPrecio.Controls.Add(this.lblPrecioBase);
            this.panelPrecio.Location = new System.Drawing.Point(0, 570);
            this.panelPrecio.Name = "panelPrecio";
            this.panelPrecio.Size = new System.Drawing.Size(900, 36);
            //
            // lblPrecioLabel
            //
            this.lblPrecioLabel.AutoSize = true;
            this.lblPrecioLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPrecioLabel.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblPrecioLabel.Location = new System.Drawing.Point(6, 8);
            this.lblPrecioLabel.Name = "lblPrecioLabel";
            this.lblPrecioLabel.Text = "CalcularPrecioBase() (RF-03):";
            //
            // lblPrecioBase
            //
            this.lblPrecioBase.AutoSize = true;
            this.lblPrecioBase.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPrecioBase.ForeColor = System.Drawing.Color.FromArgb(30, 140, 80);
            this.lblPrecioBase.Location = new System.Drawing.Point(230, 6);
            this.lblPrecioBase.Name = "lblPrecioBase";
            this.lblPrecioBase.Text = "—";
            //
            // frmCatalogo
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(252, 228, 235);
            this.ClientSize = new System.Drawing.Size(1190, 700);
            this.Controls.Add(this.panelIzquierdo);
            this.Controls.Add(this.panelDerecho);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.panelTop);
            this.Name = "frmCatalogo";
            this.Text = "Catálogo de Unidades de Venta — Patrón COMPOSITE";
            this.Load += new System.EventHandler(this.frmCatalogo_Load);
            this.panelTop.ResumeLayout(false);
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.panelIzquierdo.ResumeLayout(false);
            this.pnlHeaderArbol.ResumeLayout(false);
            this.panelDerecho.ResumeLayout(false);
            this.pnlHeaderGrilla.ResumeLayout(false);
            this.panelDescripcion.ResumeLayout(false);
            this.panelDescripcion.PerformLayout();
            this.panelPrecio.ResumeLayout(false);
            this.panelPrecio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogo)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panelIzquierdo;
        private System.Windows.Forms.Panel pnlHeaderArbol;
        private System.Windows.Forms.Label lblTituloArbol;
        private System.Windows.Forms.TreeView treeViewCatalogo;
        private System.Windows.Forms.Button btnVerDescripcion;
        private System.Windows.Forms.Button btnAgregarArticulo;
        private System.Windows.Forms.Button btnAgregarLote;
        private System.Windows.Forms.Panel panelDerecho;
        private System.Windows.Forms.Panel pnlHeaderGrilla;
        private System.Windows.Forms.Label lblTituloGrilla;
        private System.Windows.Forms.DataGridView dgvCatalogo;
        private System.Windows.Forms.Panel panelDescripcion;
        private System.Windows.Forms.Label lblDescTitulo;
        private System.Windows.Forms.RichTextBox rtbDescripcion;
        private System.Windows.Forms.Panel panelPrecio;
        private System.Windows.Forms.Label lblPrecioLabel;
        private System.Windows.Forms.Label lblPrecioBase;
    }
}
