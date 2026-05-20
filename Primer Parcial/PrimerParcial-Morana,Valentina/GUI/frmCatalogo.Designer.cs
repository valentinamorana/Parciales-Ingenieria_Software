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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCatalogo));
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panelIzquierdo = new System.Windows.Forms.Panel();
            this.lblContadorCatalogo = new System.Windows.Forms.Label();
            this.treeViewCatalogo = new System.Windows.Forms.TreeView();
            this.btnAgregarLote = new System.Windows.Forms.Button();
            this.btnAgregarArticulo = new System.Windows.Forms.Button();
            this.pnlHeaderArbol = new System.Windows.Forms.Panel();
            this.lblTituloArbol = new System.Windows.Forms.Label();
            this.panelDerecho = new System.Windows.Forms.Panel();
            this.panelPrecio = new System.Windows.Forms.Panel();
            this.lblPrecioLabel = new System.Windows.Forms.Label();
            this.lblPrecioBase = new System.Windows.Forms.Label();
            this.panelDescripcion = new System.Windows.Forms.Panel();
            this.rtbDescripcion = new System.Windows.Forms.RichTextBox();
            this.lblDescTitulo = new System.Windows.Forms.Label();
            this.dgvCatalogo = new System.Windows.Forms.DataGridView();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblTipoFiltro = new System.Windows.Forms.Label();
            this.cmbFiltroTipo = new System.Windows.Forms.ComboBox();
            this.lblPrecioMin = new System.Windows.Forms.Label();
            this.txtPrecioMin = new System.Windows.Forms.TextBox();
            this.lblGuion = new System.Windows.Forms.Label();
            this.txtPrecioMax = new System.Windows.Forms.TextBox();
            this.lblEstadoFiltro = new System.Windows.Forms.Label();
            this.cmbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.pnlHeaderGrilla = new System.Windows.Forms.Panel();
            this.lblTituloGrilla = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelStatus.SuspendLayout();
            this.panelIzquierdo.SuspendLayout();
            this.pnlHeaderArbol.SuspendLayout();
            this.panelDerecho.SuspendLayout();
            this.panelPrecio.SuspendLayout();
            this.panelDescripcion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogo)).BeginInit();
            this.panelFiltros.SuspendLayout();
            this.pnlHeaderGrilla.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(100)))), ((int)(((byte)(135)))));
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Controls.Add(this.lblSubtitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1223, 56);
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
            this.lblTitulo.Text = "Catálogo de Unidades de Venta";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(12, 34);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(750, 16);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Artículos simples y lotes anidados con profundidad ilimitada";
            // 
            // panelStatus
            // 
            this.panelStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.panelStatus.Controls.Add(this.lblStatus);
            this.panelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatus.Location = new System.Drawing.Point(0, 672);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(1223, 28);
            this.panelStatus.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatus.Location = new System.Drawing.Point(8, 6);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(332, 15);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Seleccioná un elemento para ver su descripción y precio base.";
            // 
            // panelIzquierdo
            // 
            this.panelIzquierdo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.panelIzquierdo.Controls.Add(this.lblContadorCatalogo);
            this.panelIzquierdo.Controls.Add(this.treeViewCatalogo);
            this.panelIzquierdo.Controls.Add(this.btnAgregarLote);
            this.panelIzquierdo.Controls.Add(this.btnAgregarArticulo);
            this.panelIzquierdo.Controls.Add(this.pnlHeaderArbol);
            this.panelIzquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelIzquierdo.Location = new System.Drawing.Point(0, 56);
            this.panelIzquierdo.Name = "panelIzquierdo";
            this.panelIzquierdo.Size = new System.Drawing.Size(310, 616);
            this.panelIzquierdo.TabIndex = 0;
            // 
            // lblContadorCatalogo
            // 
            this.lblContadorCatalogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContadorCatalogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(185)))), ((int)(((byte)(200)))));
            this.lblContadorCatalogo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblContadorCatalogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblContadorCatalogo.Location = new System.Drawing.Point(0, 1090);
            this.lblContadorCatalogo.Name = "lblContadorCatalogo";
            this.lblContadorCatalogo.Size = new System.Drawing.Size(310, 32);
            this.lblContadorCatalogo.TabIndex = 1;
            this.lblContadorCatalogo.Text = "—";
            this.lblContadorCatalogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // treeViewCatalogo
            // 
            this.treeViewCatalogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewCatalogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.treeViewCatalogo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewCatalogo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.treeViewCatalogo.Location = new System.Drawing.Point(0, 90);
            this.treeViewCatalogo.Name = "treeViewCatalogo";
            this.treeViewCatalogo.Size = new System.Drawing.Size(310, 996);
            this.treeViewCatalogo.TabIndex = 0;
            this.treeViewCatalogo.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewCatalogo_AfterSelect);
            // 
            // btnAgregarLote
            // 
            this.btnAgregarLote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarLote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(80)))), ((int)(((byte)(110)))));
            this.btnAgregarLote.FlatAppearance.BorderSize = 0;
            this.btnAgregarLote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarLote.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnAgregarLote.ForeColor = System.Drawing.Color.White;
            this.btnAgregarLote.Location = new System.Drawing.Point(0, 60);
            this.btnAgregarLote.Name = "btnAgregarLote";
            this.btnAgregarLote.Size = new System.Drawing.Size(310, 28);
            this.btnAgregarLote.TabIndex = 3;
            this.btnAgregarLote.Text = "+  Lote de Artículos";
            this.btnAgregarLote.UseVisualStyleBackColor = false;
            this.btnAgregarLote.Click += new System.EventHandler(this.btnAgregarLote_Click);
            // 
            // btnAgregarArticulo
            // 
            this.btnAgregarArticulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(100)))), ((int)(((byte)(135)))));
            this.btnAgregarArticulo.FlatAppearance.BorderSize = 0;
            this.btnAgregarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarArticulo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnAgregarArticulo.ForeColor = System.Drawing.Color.White;
            this.btnAgregarArticulo.Location = new System.Drawing.Point(0, 30);
            this.btnAgregarArticulo.Name = "btnAgregarArticulo";
            this.btnAgregarArticulo.Size = new System.Drawing.Size(310, 28);
            this.btnAgregarArticulo.TabIndex = 2;
            this.btnAgregarArticulo.Text = "+  Artículo Simple";
            this.btnAgregarArticulo.UseVisualStyleBackColor = false;
            this.btnAgregarArticulo.Click += new System.EventHandler(this.btnAgregarArticulo_Click);
            // 
            // pnlHeaderArbol
            // 
            this.pnlHeaderArbol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(185)))), ((int)(((byte)(200)))));
            this.pnlHeaderArbol.Controls.Add(this.lblTituloArbol);
            this.pnlHeaderArbol.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderArbol.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderArbol.Name = "pnlHeaderArbol";
            this.pnlHeaderArbol.Size = new System.Drawing.Size(310, 28);
            this.pnlHeaderArbol.TabIndex = 4;
            // 
            // lblTituloArbol
            // 
            this.lblTituloArbol.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloArbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTituloArbol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTituloArbol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTituloArbol.Location = new System.Drawing.Point(0, 0);
            this.lblTituloArbol.Name = "lblTituloArbol";
            this.lblTituloArbol.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblTituloArbol.Size = new System.Drawing.Size(310, 28);
            this.lblTituloArbol.TabIndex = 0;
            this.lblTituloArbol.Text = "Jerarquía del Catálogo";
            this.lblTituloArbol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelDerecho
            // 
            this.panelDerecho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(235)))));
            this.panelDerecho.Controls.Add(this.panelPrecio);
            this.panelDerecho.Controls.Add(this.panelDescripcion);
            this.panelDerecho.Controls.Add(this.dgvCatalogo);
            this.panelDerecho.Controls.Add(this.panelFiltros);
            this.panelDerecho.Controls.Add(this.pnlHeaderGrilla);
            this.panelDerecho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDerecho.Location = new System.Drawing.Point(310, 56);
            this.panelDerecho.Name = "panelDerecho";
            this.panelDerecho.Anchor = ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Top    |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left   |
                System.Windows.Forms.AnchorStyles.Right));
            this.panelDerecho.Size = new System.Drawing.Size(1113, 616);
            this.panelDerecho.TabIndex = 1;
            // 
            // panelPrecio
            // 
            this.panelPrecio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(235)))));
            this.panelPrecio.Controls.Add(this.lblPrecioLabel);
            this.panelPrecio.Controls.Add(this.lblPrecioBase);
            this.panelPrecio.Location = new System.Drawing.Point(8, 570);
            this.panelPrecio.Name = "panelPrecio";
            this.panelPrecio.Size = new System.Drawing.Size(900, 36);
            this.panelPrecio.TabIndex = 0;
            // 
            // lblPrecioLabel
            // 
            this.lblPrecioLabel.AutoSize = true;
            this.lblPrecioLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPrecioLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPrecioLabel.Location = new System.Drawing.Point(6, 8);
            this.lblPrecioLabel.Name = "lblPrecioLabel";
            this.lblPrecioLabel.Size = new System.Drawing.Size(74, 15);
            this.lblPrecioLabel.TabIndex = 0;
            this.lblPrecioLabel.Text = "Precio Base:";
            // 
            // lblPrecioBase
            // 
            this.lblPrecioBase.AutoSize = true;
            this.lblPrecioBase.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPrecioBase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(80)))));
            this.lblPrecioBase.Location = new System.Drawing.Point(230, 6);
            this.lblPrecioBase.Name = "lblPrecioBase";
            this.lblPrecioBase.Size = new System.Drawing.Size(24, 20);
            this.lblPrecioBase.TabIndex = 1;
            this.lblPrecioBase.Text = "—";
            // 
            // panelDescripcion
            // 
            this.panelDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(235)))));
            this.panelDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDescripcion.Controls.Add(this.rtbDescripcion);
            this.panelDescripcion.Controls.Add(this.lblDescTitulo);
            this.panelDescripcion.Location = new System.Drawing.Point(8, 294);
            this.panelDescripcion.Name = "panelDescripcion";
            this.panelDescripcion.Size = new System.Drawing.Size(900, 270);
            this.panelDescripcion.TabIndex = 1;
            // 
            // rtbDescripcion
            // 
            this.rtbDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(235)))));
            this.rtbDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDescripcion.Font = new System.Drawing.Font("Consolas", 9F);
            this.rtbDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rtbDescripcion.Location = new System.Drawing.Point(6, 26);
            this.rtbDescripcion.Name = "rtbDescripcion";
            this.rtbDescripcion.ReadOnly = true;
            this.rtbDescripcion.Size = new System.Drawing.Size(886, 236);
            this.rtbDescripcion.TabIndex = 3;
            this.rtbDescripcion.Text = "";
            // 
            // lblDescTitulo
            // 
            this.lblDescTitulo.AutoSize = true;
            this.lblDescTitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDescTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDescTitulo.Location = new System.Drawing.Point(6, 6);
            this.lblDescTitulo.Name = "lblDescTitulo";
            this.lblDescTitulo.Size = new System.Drawing.Size(130, 15);
            this.lblDescTitulo.TabIndex = 4;
            this.lblDescTitulo.Text = "Descripción completa:";
            // 
            // dgvCatalogo
            // 
            this.dgvCatalogo.AllowUserToAddRows = false;
            this.dgvCatalogo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.dgvCatalogo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCatalogo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCatalogo.BackgroundColor = System.Drawing.Color.White;
            this.dgvCatalogo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(100)))), ((int)(((byte)(135)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCatalogo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCatalogo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(182)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCatalogo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCatalogo.EnableHeadersVisualStyles = false;
            this.dgvCatalogo.Location = new System.Drawing.Point(8, 66);
            this.dgvCatalogo.MultiSelect = false;
            this.dgvCatalogo.Name = "dgvCatalogo";
            this.dgvCatalogo.ReadOnly = true;
            this.dgvCatalogo.RowHeadersVisible = false;
            this.dgvCatalogo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCatalogo.Size = new System.Drawing.Size(1060, 222);
            this.dgvCatalogo.TabIndex = 2;
            this.dgvCatalogo.SelectionChanged += new System.EventHandler(this.dgvCatalogo_SelectionChanged);
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(232)))), ((int)(((byte)(238)))));
            this.panelFiltros.Controls.Add(this.lblBuscar);
            this.panelFiltros.Controls.Add(this.txtBuscar);
            this.panelFiltros.Controls.Add(this.lblTipoFiltro);
            this.panelFiltros.Controls.Add(this.cmbFiltroTipo);
            this.panelFiltros.Controls.Add(this.lblPrecioMin);
            this.panelFiltros.Controls.Add(this.txtPrecioMin);
            this.panelFiltros.Controls.Add(this.lblGuion);
            this.panelFiltros.Controls.Add(this.txtPrecioMax);
            this.panelFiltros.Controls.Add(this.lblEstadoFiltro);
            this.panelFiltros.Controls.Add(this.cmbFiltroEstado);
            this.panelFiltros.Location = new System.Drawing.Point(8, 28);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(1060, 36);
            this.panelFiltros.TabIndex = 3;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBuscar.Location = new System.Drawing.Point(10, 10);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(47, 15);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuscar.Location = new System.Drawing.Point(68, 7);
            this.txtBuscar.MaxLength = 200;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(300, 23);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.FiltroChanged);
            // 
            // lblTipoFiltro
            // 
            this.lblTipoFiltro.AutoSize = true;
            this.lblTipoFiltro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTipoFiltro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTipoFiltro.Location = new System.Drawing.Point(386, 10);
            this.lblTipoFiltro.Name = "lblTipoFiltro";
            this.lblTipoFiltro.Size = new System.Drawing.Size(34, 15);
            this.lblTipoFiltro.TabIndex = 2;
            this.lblTipoFiltro.Text = "Tipo:";
            // 
            // cmbFiltroTipo
            // 
            this.cmbFiltroTipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            this.cmbFiltroTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroTipo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFiltroTipo.Location = new System.Drawing.Point(430, 7);
            this.cmbFiltroTipo.Name = "cmbFiltroTipo";
            this.cmbFiltroTipo.Size = new System.Drawing.Size(150, 23);
            this.cmbFiltroTipo.TabIndex = 3;
            this.cmbFiltroTipo.SelectedIndexChanged += new System.EventHandler(this.FiltroChanged);
            // 
            // lblPrecioMin
            // 
            this.lblPrecioMin.AutoSize = true;
            this.lblPrecioMin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPrecioMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPrecioMin.Location = new System.Drawing.Point(598, 10);
            this.lblPrecioMin.Name = "lblPrecioMin";
            this.lblPrecioMin.Size = new System.Drawing.Size(55, 15);
            this.lblPrecioMin.TabIndex = 4;
            this.lblPrecioMin.Text = "Precio $:";
            // 
            // txtPrecioMin
            // 
            this.txtPrecioMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            this.txtPrecioMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioMin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPrecioMin.Location = new System.Drawing.Point(660, 7);
            this.txtPrecioMin.MaxLength = 15;
            this.txtPrecioMin.Name = "txtPrecioMin";
            this.txtPrecioMin.Size = new System.Drawing.Size(80, 23);
            this.txtPrecioMin.TabIndex = 5;
            this.txtPrecioMin.TextChanged += new System.EventHandler(this.FiltroChanged);
            this.txtPrecioMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // lblGuion
            // 
            this.lblGuion.AutoSize = true;
            this.lblGuion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGuion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGuion.Location = new System.Drawing.Point(744, 10);
            this.lblGuion.Name = "lblGuion";
            this.lblGuion.Size = new System.Drawing.Size(19, 15);
            this.lblGuion.TabIndex = 6;
            this.lblGuion.Text = "—";
            // 
            // txtPrecioMax
            // 
            this.txtPrecioMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            this.txtPrecioMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioMax.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPrecioMax.Location = new System.Drawing.Point(768, 6);
            this.txtPrecioMax.MaxLength = 15;
            this.txtPrecioMax.Name = "txtPrecioMax";
            this.txtPrecioMax.Size = new System.Drawing.Size(80, 23);
            this.txtPrecioMax.TabIndex = 7;
            this.txtPrecioMax.TextChanged += new System.EventHandler(this.FiltroChanged);
            this.txtPrecioMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            //
            // lblEstadoFiltro
            //
            this.lblEstadoFiltro.AutoSize = true;
            this.lblEstadoFiltro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstadoFiltro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEstadoFiltro.Location = new System.Drawing.Point(858, 10);
            this.lblEstadoFiltro.Name = "lblEstadoFiltro";
            this.lblEstadoFiltro.Size = new System.Drawing.Size(47, 15);
            this.lblEstadoFiltro.TabIndex = 8;
            this.lblEstadoFiltro.Text = "Estado:";
            //
            // cmbFiltroEstado
            //
            this.cmbFiltroEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            this.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFiltroEstado.Location = new System.Drawing.Point(910, 7);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(140, 23);
            this.cmbFiltroEstado.TabIndex = 9;
            this.cmbFiltroEstado.SelectedIndexChanged += new System.EventHandler(this.FiltroChanged);
            //
            // pnlHeaderGrilla
            // 
            this.pnlHeaderGrilla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(185)))), ((int)(((byte)(200)))));
            this.pnlHeaderGrilla.Controls.Add(this.lblTituloGrilla);
            this.pnlHeaderGrilla.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderGrilla.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderGrilla.Name = "pnlHeaderGrilla";
            this.pnlHeaderGrilla.Size = new System.Drawing.Size(913, 28);
            this.pnlHeaderGrilla.TabIndex = 4;
            // 
            // lblTituloGrilla
            // 
            this.lblTituloGrilla.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTituloGrilla.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTituloGrilla.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTituloGrilla.Location = new System.Drawing.Point(0, 0);
            this.lblTituloGrilla.Name = "lblTituloGrilla";
            this.lblTituloGrilla.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblTituloGrilla.Size = new System.Drawing.Size(913, 28);
            this.lblTituloGrilla.TabIndex = 0;
            this.lblTituloGrilla.Text = "Todas las Unidades de Venta";
            this.lblTituloGrilla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmCatalogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(1423, 700);
            this.Controls.Add(this.panelDerecho);
            this.Controls.Add(this.panelIzquierdo);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCatalogo";
            this.Text = "Catálogo de Unidades de Venta";
            this.Load += new System.EventHandler(this.frmCatalogo_Load);
            this.panelTop.ResumeLayout(false);
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.panelIzquierdo.ResumeLayout(false);
            this.pnlHeaderArbol.ResumeLayout(false);
            this.panelDerecho.ResumeLayout(false);
            this.panelPrecio.ResumeLayout(false);
            this.panelPrecio.PerformLayout();
            this.panelDescripcion.ResumeLayout(false);
            this.panelDescripcion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogo)).EndInit();
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.pnlHeaderGrilla.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblContadorCatalogo;
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
        private System.Windows.Forms.Label     lblPrecioLabel;
        private System.Windows.Forms.Label     lblPrecioBase;
        private System.Windows.Forms.Panel     panelFiltros;
        private System.Windows.Forms.Label     lblBuscar;
        private System.Windows.Forms.TextBox   txtBuscar;
        private System.Windows.Forms.Label     lblTipoFiltro;
        private System.Windows.Forms.ComboBox  cmbFiltroTipo;
        private System.Windows.Forms.Label      lblPrecioMin;
        private System.Windows.Forms.TextBox    txtPrecioMin;
        private System.Windows.Forms.Label      lblGuion;
        private System.Windows.Forms.TextBox    txtPrecioMax;
        private System.Windows.Forms.Label      lblEstadoFiltro;
        private System.Windows.Forms.ComboBox   cmbFiltroEstado;
    }
}
