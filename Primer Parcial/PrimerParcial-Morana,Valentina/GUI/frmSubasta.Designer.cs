namespace GUI
{
    partial class frmSubasta
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubasta));
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grpIniciar = new System.Windows.Forms.GroupBox();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.cmbUnidad = new System.Windows.Forms.ComboBox();
            this.btnIniciarSubasta = new System.Windows.Forms.Button();
            this.grpEstado = new System.Windows.Forms.GroupBox();
            this.lblNombreLabel = new System.Windows.Forms.Label();
            this.lblNombreSubasta = new System.Windows.Forms.Label();
            this.lblBaseLabel = new System.Windows.Forms.Label();
            this.lblPrecioBase = new System.Windows.Forms.Label();
            this.lblActualLabel = new System.Windows.Forms.Label();
            this.lblPrecioActual = new System.Windows.Forms.Label();
            this.lblPujadorLabel = new System.Windows.Forms.Label();
            this.lblUltimoPujador = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.grpInteresados = new System.Windows.Forms.GroupBox();
            this.lblPatronObs = new System.Windows.Forms.Label();
            this.lstInteresados = new System.Windows.Forms.ListBox();
            this.lblUsuarioSusc = new System.Windows.Forms.Label();
            this.cmbUsuarioSuscribir = new System.Windows.Forms.ComboBox();
            this.lblCanal = new System.Windows.Forms.Label();
            this.cmbCanal = new System.Windows.Forms.ComboBox();
            this.btnSuscribir = new System.Windows.Forms.Button();
            this.btnDesuscribir = new System.Windows.Forms.Button();
            this.grpOferta = new System.Windows.Forms.GroupBox();
            this.lblPatronSing = new System.Windows.Forms.Label();
            this.lblOfertante = new System.Windows.Forms.Label();
            this.cmbOfertante = new System.Windows.Forms.ComboBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.btnOfertar = new System.Windows.Forms.Button();
            this.grpNotificaciones = new System.Windows.Forms.GroupBox();
            this.rtbNotificaciones = new System.Windows.Forms.RichTextBox();
            this.btnCerrarSubasta = new System.Windows.Forms.Button();
            this._timer = new System.Windows.Forms.Timer(this.components);
            this.panelTop.SuspendLayout();
            this.panelStatus.SuspendLayout();
            this.grpIniciar.SuspendLayout();
            this.grpEstado.SuspendLayout();
            this.grpInteresados.SuspendLayout();
            this.grpOferta.SuspendLayout();
            this.grpNotificaciones.SuspendLayout();
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
            this.panelTop.Size = new System.Drawing.Size(1180, 56);
            this.panelTop.TabIndex = 7;
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
            this.lblTitulo.Text = "Gestión de Subasta";
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
            this.lblSubtitulo.Text = "Temporizador regresivo + Anti-Sniping automático";
            // 
            // panelStatus
            // 
            this.panelStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.panelStatus.Controls.Add(this.lblStatus);
            this.panelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatus.Location = new System.Drawing.Point(0, 692);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(1180, 28);
            this.panelStatus.TabIndex = 6;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatus.Location = new System.Drawing.Point(8, 6);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(297, 15);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Iniciá una subasta, suscribí interesados y realizá ofertas.";
            // 
            // grpIniciar
            // 
            this.grpIniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(235)))));
            this.grpIniciar.Controls.Add(this.lblUnidad);
            this.grpIniciar.Controls.Add(this.cmbUnidad);
            this.grpIniciar.Controls.Add(this.btnIniciarSubasta);
            this.grpIniciar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpIniciar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpIniciar.Location = new System.Drawing.Point(10, 66);
            this.grpIniciar.Name = "grpIniciar";
            this.grpIniciar.Anchor = ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Top  |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right));
            this.grpIniciar.Size = new System.Drawing.Size(1350, 60);
            this.grpIniciar.TabIndex = 4;
            this.grpIniciar.TabStop = false;
            this.grpIniciar.Text = "1. Seleccionar Unidad de Venta";
            // 
            // lblUnidad
            // 
            this.lblUnidad.AutoSize = true;
            this.lblUnidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUnidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblUnidad.Location = new System.Drawing.Point(10, 26);
            this.lblUnidad.Name = "lblUnidad";
            this.lblUnidad.Size = new System.Drawing.Size(49, 15);
            this.lblUnidad.TabIndex = 0;
            this.lblUnidad.Text = "Unidad:";
            // 
            // cmbUnidad
            // 
            this.cmbUnidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            this.cmbUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnidad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbUnidad.Location = new System.Drawing.Point(75, 23);
            this.cmbUnidad.Name = "cmbUnidad";
            this.cmbUnidad.Size = new System.Drawing.Size(690, 25);
            this.cmbUnidad.TabIndex = 1;
            // 
            // btnIniciarSubasta
            // 
            this.btnIniciarSubasta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(100)))), ((int)(((byte)(135)))));
            this.btnIniciarSubasta.FlatAppearance.BorderSize = 0;
            this.btnIniciarSubasta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarSubasta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnIniciarSubasta.ForeColor = System.Drawing.Color.White;
            this.btnIniciarSubasta.Location = new System.Drawing.Point(780, 20);
            this.btnIniciarSubasta.Name = "btnIniciarSubasta";
            this.btnIniciarSubasta.Size = new System.Drawing.Size(356, 28);
            this.btnIniciarSubasta.TabIndex = 2;
            this.btnIniciarSubasta.Text = "▶  Iniciar Subasta";
            this.btnIniciarSubasta.UseVisualStyleBackColor = false;
            this.btnIniciarSubasta.Click += new System.EventHandler(this.btnIniciarSubasta_Click);
            // 
            // grpEstado
            // 
            this.grpEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(235)))));
            this.grpEstado.Controls.Add(this.lblNombreLabel);
            this.grpEstado.Controls.Add(this.lblNombreSubasta);
            this.grpEstado.Controls.Add(this.lblBaseLabel);
            this.grpEstado.Controls.Add(this.lblPrecioBase);
            this.grpEstado.Controls.Add(this.lblActualLabel);
            this.grpEstado.Controls.Add(this.lblPrecioActual);
            this.grpEstado.Controls.Add(this.lblPujadorLabel);
            this.grpEstado.Controls.Add(this.lblUltimoPujador);
            this.grpEstado.Controls.Add(this.lblTimer);
            this.grpEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpEstado.Location = new System.Drawing.Point(10, 136);
            this.grpEstado.Name = "grpEstado";
            this.grpEstado.Anchor = ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Top  |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right));
            this.grpEstado.Size = new System.Drawing.Size(1350, 78);
            this.grpEstado.TabIndex = 3;
            this.grpEstado.TabStop = false;
            this.grpEstado.Text = "Estado de la Subasta Activa";
            // 
            // lblNombreLabel
            // 
            this.lblNombreLabel.AutoSize = true;
            this.lblNombreLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNombreLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNombreLabel.Location = new System.Drawing.Point(10, 24);
            this.lblNombreLabel.Name = "lblNombreLabel";
            this.lblNombreLabel.Size = new System.Drawing.Size(54, 15);
            this.lblNombreLabel.TabIndex = 0;
            this.lblNombreLabel.Text = "Artículo:";
            // 
            // lblNombreSubasta
            // 
            this.lblNombreSubasta.AutoSize = true;
            this.lblNombreSubasta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombreSubasta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(100)))), ((int)(((byte)(135)))));
            this.lblNombreSubasta.Location = new System.Drawing.Point(78, 24);
            this.lblNombreSubasta.Name = "lblNombreSubasta";
            this.lblNombreSubasta.Size = new System.Drawing.Size(19, 15);
            this.lblNombreSubasta.TabIndex = 1;
            this.lblNombreSubasta.Text = "—";
            // 
            // lblBaseLabel
            // 
            this.lblBaseLabel.AutoSize = true;
            this.lblBaseLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblBaseLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBaseLabel.Location = new System.Drawing.Point(400, 24);
            this.lblBaseLabel.Name = "lblBaseLabel";
            this.lblBaseLabel.Size = new System.Drawing.Size(74, 15);
            this.lblBaseLabel.TabIndex = 2;
            this.lblBaseLabel.Text = "Precio Base:";
            // 
            // lblPrecioBase
            // 
            this.lblPrecioBase.AutoSize = true;
            this.lblPrecioBase.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPrecioBase.ForeColor = System.Drawing.Color.DimGray;
            this.lblPrecioBase.Location = new System.Drawing.Point(490, 24);
            this.lblPrecioBase.Name = "lblPrecioBase";
            this.lblPrecioBase.Size = new System.Drawing.Size(19, 15);
            this.lblPrecioBase.TabIndex = 3;
            this.lblPrecioBase.Text = "—";
            // 
            // lblActualLabel
            // 
            this.lblActualLabel.AutoSize = true;
            this.lblActualLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblActualLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblActualLabel.Location = new System.Drawing.Point(10, 50);
            this.lblActualLabel.Name = "lblActualLabel";
            this.lblActualLabel.Size = new System.Drawing.Size(83, 15);
            this.lblActualLabel.TabIndex = 4;
            this.lblActualLabel.Text = "Precio Actual:";
            // 
            // lblPrecioActual
            // 
            this.lblPrecioActual.AutoSize = true;
            this.lblPrecioActual.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblPrecioActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(80)))));
            this.lblPrecioActual.Location = new System.Drawing.Point(106, 47);
            this.lblPrecioActual.Name = "lblPrecioActual";
            this.lblPrecioActual.Size = new System.Drawing.Size(35, 30);
            this.lblPrecioActual.TabIndex = 5;
            this.lblPrecioActual.Text = "—";
            // 
            // lblPujadorLabel
            // 
            this.lblPujadorLabel.AutoSize = true;
            this.lblPujadorLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPujadorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPujadorLabel.Location = new System.Drawing.Point(400, 50);
            this.lblPujadorLabel.Name = "lblPujadorLabel";
            this.lblPujadorLabel.Size = new System.Drawing.Size(93, 15);
            this.lblPujadorLabel.TabIndex = 6;
            this.lblPujadorLabel.Text = "Último Pujador:";
            // 
            // lblUltimoPujador
            // 
            this.lblUltimoPujador.AutoSize = true;
            this.lblUltimoPujador.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblUltimoPujador.ForeColor = System.Drawing.Color.DimGray;
            this.lblUltimoPujador.Location = new System.Drawing.Point(506, 50);
            this.lblUltimoPujador.Name = "lblUltimoPujador";
            this.lblUltimoPujador.Size = new System.Drawing.Size(19, 15);
            this.lblUltimoPujador.TabIndex = 7;
            this.lblUltimoPujador.Text = "—";
            // 
            // lblTimer
            // 
            this.lblTimer.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTimer.ForeColor = System.Drawing.Color.DimGray;
            this.lblTimer.Location = new System.Drawing.Point(870, 14);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(268, 52);
            this.lblTimer.TabIndex = 8;
            this.lblTimer.Text = "⏱  --:--";
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpInteresados
            // 
            this.grpInteresados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(235)))));
            this.grpInteresados.Controls.Add(this.lblPatronObs);
            this.grpInteresados.Controls.Add(this.lstInteresados);
            this.grpInteresados.Controls.Add(this.lblUsuarioSusc);
            this.grpInteresados.Controls.Add(this.cmbUsuarioSuscribir);
            this.grpInteresados.Controls.Add(this.lblCanal);
            this.grpInteresados.Controls.Add(this.cmbCanal);
            this.grpInteresados.Controls.Add(this.btnSuscribir);
            this.grpInteresados.Controls.Add(this.btnDesuscribir);
            this.grpInteresados.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpInteresados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpInteresados.Location = new System.Drawing.Point(10, 224);
            this.grpInteresados.Name = "grpInteresados";
            this.grpInteresados.Size = new System.Drawing.Size(560, 208);
            this.grpInteresados.TabIndex = 2;
            this.grpInteresados.TabStop = false;
            this.grpInteresados.Text = "2. Interesados Suscriptos";
            // 
            // lblPatronObs
            // 
            this.lblPatronObs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(100)))), ((int)(((byte)(135)))));
            this.lblPatronObs.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblPatronObs.ForeColor = System.Drawing.Color.White;
            this.lblPatronObs.Location = new System.Drawing.Point(6, 18);
            this.lblPatronObs.Name = "lblPatronObs";
            this.lblPatronObs.Size = new System.Drawing.Size(546, 18);
            this.lblPatronObs.TabIndex = 0;
            this.lblPatronObs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstInteresados
            // 
            this.lstInteresados.BackColor = System.Drawing.Color.White;
            this.lstInteresados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstInteresados.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstInteresados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lstInteresados.ItemHeight = 15;
            this.lstInteresados.Location = new System.Drawing.Point(6, 40);
            this.lstInteresados.Name = "lstInteresados";
            this.lstInteresados.Size = new System.Drawing.Size(238, 152);
            this.lstInteresados.TabIndex = 1;
            // 
            // lblUsuarioSusc
            // 
            this.lblUsuarioSusc.AutoSize = true;
            this.lblUsuarioSusc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsuarioSusc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblUsuarioSusc.Location = new System.Drawing.Point(254, 40);
            this.lblUsuarioSusc.Name = "lblUsuarioSusc";
            this.lblUsuarioSusc.Size = new System.Drawing.Size(52, 15);
            this.lblUsuarioSusc.TabIndex = 2;
            this.lblUsuarioSusc.Text = "Usuario:";
            // 
            // cmbUsuarioSuscribir
            // 
            this.cmbUsuarioSuscribir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            this.cmbUsuarioSuscribir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuarioSuscribir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbUsuarioSuscribir.Location = new System.Drawing.Point(254, 58);
            this.cmbUsuarioSuscribir.Name = "cmbUsuarioSuscribir";
            this.cmbUsuarioSuscribir.Size = new System.Drawing.Size(294, 25);
            this.cmbUsuarioSuscribir.TabIndex = 3;
            // 
            // lblCanal
            // 
            this.lblCanal.AutoSize = true;
            this.lblCanal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCanal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCanal.Location = new System.Drawing.Point(254, 90);
            this.lblCanal.Name = "lblCanal";
            this.lblCanal.Size = new System.Drawing.Size(124, 15);
            this.lblCanal.TabIndex = 4;
            this.lblCanal.Text = "Canal de notificación:";
            // 
            // cmbCanal
            // 
            this.cmbCanal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            this.cmbCanal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCanal.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbCanal.Location = new System.Drawing.Point(254, 108);
            this.cmbCanal.Name = "cmbCanal";
            this.cmbCanal.Size = new System.Drawing.Size(294, 25);
            this.cmbCanal.TabIndex = 5;
            // 
            // btnSuscribir
            // 
            this.btnSuscribir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(100)))), ((int)(((byte)(135)))));
            this.btnSuscribir.FlatAppearance.BorderSize = 0;
            this.btnSuscribir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuscribir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSuscribir.ForeColor = System.Drawing.Color.White;
            this.btnSuscribir.Location = new System.Drawing.Point(254, 140);
            this.btnSuscribir.Name = "btnSuscribir";
            this.btnSuscribir.Size = new System.Drawing.Size(140, 28);
            this.btnSuscribir.TabIndex = 6;
            this.btnSuscribir.Text = "Suscribir";
            this.btnSuscribir.UseVisualStyleBackColor = false;
            this.btnSuscribir.Click += new System.EventHandler(this.btnSuscribir_Click);
            // 
            // btnDesuscribir
            // 
            this.btnDesuscribir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnDesuscribir.FlatAppearance.BorderSize = 0;
            this.btnDesuscribir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesuscribir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDesuscribir.ForeColor = System.Drawing.Color.White;
            this.btnDesuscribir.Location = new System.Drawing.Point(404, 140);
            this.btnDesuscribir.Name = "btnDesuscribir";
            this.btnDesuscribir.Size = new System.Drawing.Size(144, 28);
            this.btnDesuscribir.TabIndex = 7;
            this.btnDesuscribir.Text = "Desuscribir";
            this.btnDesuscribir.UseVisualStyleBackColor = false;
            this.btnDesuscribir.Click += new System.EventHandler(this.btnDesuscribir_Click);
            // 
            // grpOferta
            // 
            this.grpOferta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(235)))));
            this.grpOferta.Controls.Add(this.lblPatronSing);
            this.grpOferta.Controls.Add(this.lblOfertante);
            this.grpOferta.Controls.Add(this.cmbOfertante);
            this.grpOferta.Controls.Add(this.lblMonto);
            this.grpOferta.Controls.Add(this.txtMonto);
            this.grpOferta.Controls.Add(this.btnOfertar);
            this.grpOferta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpOferta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpOferta.Location = new System.Drawing.Point(580, 224);
            this.grpOferta.Name = "grpOferta";
            this.grpOferta.Size = new System.Drawing.Size(580, 208);
            this.grpOferta.TabIndex = 1;
            this.grpOferta.TabStop = false;
            this.grpOferta.Text = "3. Realizar Oferta";
            // 
            // lblPatronSing
            // 
            this.lblPatronSing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(80)))));
            this.lblPatronSing.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblPatronSing.ForeColor = System.Drawing.Color.White;
            this.lblPatronSing.Location = new System.Drawing.Point(6, 18);
            this.lblPatronSing.Name = "lblPatronSing";
            this.lblPatronSing.Size = new System.Drawing.Size(566, 18);
            this.lblPatronSing.TabIndex = 0;
            this.lblPatronSing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOfertante
            // 
            this.lblOfertante.AutoSize = true;
            this.lblOfertante.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOfertante.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblOfertante.Location = new System.Drawing.Point(10, 44);
            this.lblOfertante.Name = "lblOfertante";
            this.lblOfertante.Size = new System.Drawing.Size(66, 15);
            this.lblOfertante.TabIndex = 1;
            this.lblOfertante.Text = "Ofertante:";
            // 
            // cmbOfertante
            // 
            this.cmbOfertante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            this.cmbOfertante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOfertante.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbOfertante.Location = new System.Drawing.Point(10, 62);
            this.cmbOfertante.Name = "cmbOfertante";
            this.cmbOfertante.Size = new System.Drawing.Size(554, 25);
            this.cmbOfertante.TabIndex = 2;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMonto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMonto.Location = new System.Drawing.Point(10, 96);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(127, 15);
            this.lblMonto.TabIndex = 3;
            this.lblMonto.Text = "Monto de la oferta:  $";
            // 
            // txtMonto
            // 
            this.txtMonto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            this.txtMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMonto.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMonto.Location = new System.Drawing.Point(10, 116);
            this.txtMonto.MaxLength = 15;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(554, 27);
            this.txtMonto.TabIndex = 4;
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // btnOfertar
            // 
            this.btnOfertar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(140)))), ((int)(((byte)(80)))));
            this.btnOfertar.FlatAppearance.BorderSize = 0;
            this.btnOfertar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOfertar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOfertar.ForeColor = System.Drawing.Color.White;
            this.btnOfertar.Location = new System.Drawing.Point(10, 152);
            this.btnOfertar.Name = "btnOfertar";
            this.btnOfertar.Size = new System.Drawing.Size(554, 36);
            this.btnOfertar.TabIndex = 5;
            this.btnOfertar.Text = "Realizar Oferta";
            this.btnOfertar.UseVisualStyleBackColor = false;
            this.btnOfertar.Click += new System.EventHandler(this.btnOfertar_Click);
            // 
            // grpNotificaciones
            // 
            this.grpNotificaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(235)))));
            this.grpNotificaciones.Controls.Add(this.rtbNotificaciones);
            this.grpNotificaciones.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpNotificaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grpNotificaciones.Location = new System.Drawing.Point(10, 442);
            this.grpNotificaciones.Name = "grpNotificaciones";
            this.grpNotificaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left   |
                System.Windows.Forms.AnchorStyles.Right));
            this.grpNotificaciones.Size = new System.Drawing.Size(1350, 220);
            this.grpNotificaciones.TabIndex = 0;
            this.grpNotificaciones.TabStop = false;
            this.grpNotificaciones.Text = "Notificaciones";
            // 
            // rtbNotificaciones
            // 
            this.rtbNotificaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.rtbNotificaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbNotificaciones.Font = new System.Drawing.Font("Consolas", 9F);
            this.rtbNotificaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(255)))), ((int)(((byte)(180)))));
            this.rtbNotificaciones.Location = new System.Drawing.Point(6, 18);
            this.rtbNotificaciones.Name = "rtbNotificaciones";
            this.rtbNotificaciones.ReadOnly = true;
            this.rtbNotificaciones.Size = new System.Drawing.Size(1136, 196);
            this.rtbNotificaciones.TabIndex = 0;
            this.rtbNotificaciones.Text = "";
            // 
            // btnCerrarSubasta
            // 
            this.btnCerrarSubasta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnCerrarSubasta.FlatAppearance.BorderSize = 0;
            this.btnCerrarSubasta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSubasta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrarSubasta.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSubasta.Location = new System.Drawing.Point(10, 670);
            this.btnCerrarSubasta.Name = "btnCerrarSubasta";
            this.btnCerrarSubasta.Anchor = ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left   |
                System.Windows.Forms.AnchorStyles.Right));
            this.btnCerrarSubasta.Size = new System.Drawing.Size(1350, 38);
            this.btnCerrarSubasta.TabIndex = 5;
            this.btnCerrarSubasta.Text = "Cerrar Subasta";
            this.btnCerrarSubasta.UseVisualStyleBackColor = false;
            this.btnCerrarSubasta.Click += new System.EventHandler(this.btnCerrarSubasta_Click);
            // 
            // _timer
            // 
            this._timer.Interval = 1000;
            this._timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // frmSubasta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(228)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(1380, 720);
            this.Controls.Add(this.grpNotificaciones);
            this.Controls.Add(this.grpOferta);
            this.Controls.Add(this.grpInteresados);
            this.Controls.Add(this.grpEstado);
            this.Controls.Add(this.grpIniciar);
            this.Controls.Add(this.btnCerrarSubasta);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSubasta";
            this.Text = "Gestión de Subasta";
            this.Load += new System.EventHandler(this.frmSubasta_Load);
            this.panelTop.ResumeLayout(false);
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.grpIniciar.ResumeLayout(false);
            this.grpIniciar.PerformLayout();
            this.grpEstado.ResumeLayout(false);
            this.grpEstado.PerformLayout();
            this.grpInteresados.ResumeLayout(false);
            this.grpInteresados.PerformLayout();
            this.grpOferta.ResumeLayout(false);
            this.grpOferta.PerformLayout();
            this.grpNotificaciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox grpIniciar;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.ComboBox cmbUnidad;
        private System.Windows.Forms.Button btnIniciarSubasta;
        private System.Windows.Forms.GroupBox grpEstado;
        private System.Windows.Forms.Label lblNombreLabel;
        private System.Windows.Forms.Label lblNombreSubasta;
        private System.Windows.Forms.Label lblBaseLabel;
        private System.Windows.Forms.Label lblPrecioBase;
        private System.Windows.Forms.Label lblActualLabel;
        private System.Windows.Forms.Label lblPrecioActual;
        private System.Windows.Forms.Label lblPujadorLabel;
        private System.Windows.Forms.Label lblUltimoPujador;
        private System.Windows.Forms.GroupBox grpInteresados;
        private System.Windows.Forms.Label lblPatronObs;
        private System.Windows.Forms.ListBox lstInteresados;
        private System.Windows.Forms.Label lblUsuarioSusc;
        private System.Windows.Forms.ComboBox cmbUsuarioSuscribir;
        private System.Windows.Forms.Label lblCanal;
        private System.Windows.Forms.ComboBox cmbCanal;
        private System.Windows.Forms.Button btnSuscribir;
        private System.Windows.Forms.Button btnDesuscribir;
        private System.Windows.Forms.GroupBox grpOferta;
        private System.Windows.Forms.Label lblPatronSing;
        private System.Windows.Forms.Label lblOfertante;
        private System.Windows.Forms.ComboBox cmbOfertante;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Button btnOfertar;
        private System.Windows.Forms.GroupBox grpNotificaciones;
        private System.Windows.Forms.RichTextBox rtbNotificaciones;
        private System.Windows.Forms.Button btnCerrarSubasta;
        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.Label lblTimer;
    }
}
