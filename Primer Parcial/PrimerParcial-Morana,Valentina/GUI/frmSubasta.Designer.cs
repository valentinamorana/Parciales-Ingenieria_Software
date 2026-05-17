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
            this.panelTop           = new System.Windows.Forms.Panel();
            this.lblTitulo          = new System.Windows.Forms.Label();
            this.lblSubtitulo       = new System.Windows.Forms.Label();
            this.panelStatus        = new System.Windows.Forms.Panel();
            this.lblStatus          = new System.Windows.Forms.Label();
            this.grpIniciar         = new System.Windows.Forms.GroupBox();
            this.lblUnidad          = new System.Windows.Forms.Label();
            this.cmbUnidad          = new System.Windows.Forms.ComboBox();
            this.btnIniciarSubasta  = new System.Windows.Forms.Button();
            this.grpEstado          = new System.Windows.Forms.GroupBox();
            this.lblNombreLabel     = new System.Windows.Forms.Label();
            this.lblNombreSubasta   = new System.Windows.Forms.Label();
            this.lblBaseLabel       = new System.Windows.Forms.Label();
            this.lblPrecioBase      = new System.Windows.Forms.Label();
            this.lblActualLabel     = new System.Windows.Forms.Label();
            this.lblPrecioActual    = new System.Windows.Forms.Label();
            this.lblPujadorLabel    = new System.Windows.Forms.Label();
            this.lblUltimoPujador   = new System.Windows.Forms.Label();
            this.grpInteresados     = new System.Windows.Forms.GroupBox();
            this.lblPatronObs       = new System.Windows.Forms.Label();
            this.lstInteresados     = new System.Windows.Forms.ListBox();
            this.lblUsuarioSusc     = new System.Windows.Forms.Label();
            this.cmbUsuarioSuscribir= new System.Windows.Forms.ComboBox();
            this.lblCanal           = new System.Windows.Forms.Label();
            this.cmbCanal           = new System.Windows.Forms.ComboBox();
            this.btnSuscribir       = new System.Windows.Forms.Button();
            this.btnDesuscribir     = new System.Windows.Forms.Button();
            this.grpOferta          = new System.Windows.Forms.GroupBox();
            this.lblPatronSing      = new System.Windows.Forms.Label();
            this.lblOfertante       = new System.Windows.Forms.Label();
            this.cmbOfertante       = new System.Windows.Forms.ComboBox();
            this.lblMonto           = new System.Windows.Forms.Label();
            this.txtMonto           = new System.Windows.Forms.TextBox();
            this.btnOfertar         = new System.Windows.Forms.Button();
            this.grpNotificaciones  = new System.Windows.Forms.GroupBox();
            this.rtbNotificaciones  = new System.Windows.Forms.RichTextBox();
            this.btnCerrarSubasta   = new System.Windows.Forms.Button();
            this.components         = new System.ComponentModel.Container();
            this._timer             = new System.Windows.Forms.Timer(this.components);
            this.lblTimer           = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelStatus.SuspendLayout();
            this.grpIniciar.SuspendLayout();
            this.grpEstado.SuspendLayout();
            this.grpInteresados.SuspendLayout();
            this.grpOferta.SuspendLayout();
            this.grpNotificaciones.SuspendLayout();
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
            this.lblTitulo.Text = "Gestión de Subasta";
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
            this.lblSubtitulo.Text = "Patrones: Observer + Singleton — RF-05 a RF-12  |  Plus: Temporizador + Anti-Sniping";
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
            this.lblStatus.Text = "Iniciá una subasta, suscribí interesados y realizá ofertas.";
            //
            // grpIniciar
            //
            this.grpIniciar.BackColor = System.Drawing.Color.FromArgb(252, 228, 235);
            this.grpIniciar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpIniciar.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.grpIniciar.Location = new System.Drawing.Point(10, 66);
            this.grpIniciar.Name = "grpIniciar";
            this.grpIniciar.Size = new System.Drawing.Size(1150, 60);
            this.grpIniciar.Text = "1. Seleccionar Unidad de Venta  [COMPOSITE]";
            this.grpIniciar.Controls.Add(this.lblUnidad);
            this.grpIniciar.Controls.Add(this.cmbUnidad);
            this.grpIniciar.Controls.Add(this.btnIniciarSubasta);
            //
            // lblUnidad
            //
            this.lblUnidad.AutoSize = true;
            this.lblUnidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUnidad.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblUnidad.Location = new System.Drawing.Point(10, 26);
            this.lblUnidad.Text = "Unidad:";
            //
            // cmbUnidad
            //
            this.cmbUnidad.BackColor = System.Drawing.Color.FromArgb(245, 245, 248);
            this.cmbUnidad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbUnidad.Location = new System.Drawing.Point(75, 23);
            this.cmbUnidad.Name = "cmbUnidad";
            this.cmbUnidad.Size = new System.Drawing.Size(690, 24);
            this.cmbUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //
            // btnIniciarSubasta
            //
            this.btnIniciarSubasta.BackColor = System.Drawing.Color.FromArgb(210, 100, 135);
            this.btnIniciarSubasta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarSubasta.FlatAppearance.BorderSize = 0;
            this.btnIniciarSubasta.ForeColor = System.Drawing.Color.White;
            this.btnIniciarSubasta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnIniciarSubasta.Location = new System.Drawing.Point(780, 20);
            this.btnIniciarSubasta.Name = "btnIniciarSubasta";
            this.btnIniciarSubasta.Size = new System.Drawing.Size(356, 28);
            this.btnIniciarSubasta.Text = "▶  Iniciar Subasta";
            this.btnIniciarSubasta.UseVisualStyleBackColor = false;
            this.btnIniciarSubasta.Click += new System.EventHandler(this.btnIniciarSubasta_Click);
            //
            // grpEstado
            //
            this.grpEstado.BackColor = System.Drawing.Color.FromArgb(252, 228, 235);
            this.grpEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpEstado.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.grpEstado.Location = new System.Drawing.Point(10, 136);
            this.grpEstado.Name = "grpEstado";
            this.grpEstado.Size = new System.Drawing.Size(1150, 78);
            this.grpEstado.Text = "Estado de la Subasta Activa";
            this.grpEstado.Controls.Add(this.lblNombreLabel);
            this.grpEstado.Controls.Add(this.lblNombreSubasta);
            this.grpEstado.Controls.Add(this.lblBaseLabel);
            this.grpEstado.Controls.Add(this.lblPrecioBase);
            this.grpEstado.Controls.Add(this.lblActualLabel);
            this.grpEstado.Controls.Add(this.lblPrecioActual);
            this.grpEstado.Controls.Add(this.lblPujadorLabel);
            this.grpEstado.Controls.Add(this.lblUltimoPujador);
            this.grpEstado.Controls.Add(this.lblTimer);
            //
            // lblNombreLabel
            //
            this.lblNombreLabel.AutoSize = true;
            this.lblNombreLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNombreLabel.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblNombreLabel.Location = new System.Drawing.Point(10, 24);
            this.lblNombreLabel.Text = "Artículo:";
            //
            // lblNombreSubasta
            //
            this.lblNombreSubasta.AutoSize = true;
            this.lblNombreSubasta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombreSubasta.ForeColor = System.Drawing.Color.FromArgb(210, 100, 135);
            this.lblNombreSubasta.Location = new System.Drawing.Point(78, 24);
            this.lblNombreSubasta.Text = "—";
            //
            // lblBaseLabel
            //
            this.lblBaseLabel.AutoSize = true;
            this.lblBaseLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblBaseLabel.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblBaseLabel.Location = new System.Drawing.Point(400, 24);
            this.lblBaseLabel.Text = "Precio Base:";
            //
            // lblPrecioBase
            //
            this.lblPrecioBase.AutoSize = true;
            this.lblPrecioBase.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPrecioBase.ForeColor = System.Drawing.Color.DimGray;
            this.lblPrecioBase.Location = new System.Drawing.Point(490, 24);
            this.lblPrecioBase.Text = "—";
            //
            // lblActualLabel
            //
            this.lblActualLabel.AutoSize = true;
            this.lblActualLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblActualLabel.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblActualLabel.Location = new System.Drawing.Point(10, 50);
            this.lblActualLabel.Text = "Precio Actual:";
            //
            // lblPrecioActual — verde éxito (igual WardrobeFlow)
            //
            this.lblPrecioActual.AutoSize = true;
            this.lblPrecioActual.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPrecioActual.ForeColor = System.Drawing.Color.FromArgb(30, 140, 80);
            this.lblPrecioActual.Location = new System.Drawing.Point(106, 47);
            this.lblPrecioActual.Text = "—";
            //
            // lblPujadorLabel
            //
            this.lblPujadorLabel.AutoSize = true;
            this.lblPujadorLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPujadorLabel.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblPujadorLabel.Location = new System.Drawing.Point(400, 50);
            this.lblPujadorLabel.Text = "Último Pujador:";
            //
            // lblUltimoPujador
            //
            this.lblUltimoPujador.AutoSize = true;
            this.lblUltimoPujador.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblUltimoPujador.ForeColor = System.Drawing.Color.DimGray;
            this.lblUltimoPujador.Location = new System.Drawing.Point(506, 50);
            this.lblUltimoPujador.Text = "—";
            //
            // lblTimer — countdown en grpEstado (Plus: Temporizador + Anti-Sniping)
            //
            this.lblTimer.AutoSize = false;
            this.lblTimer.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTimer.ForeColor = System.Drawing.Color.DimGray;
            this.lblTimer.Location = new System.Drawing.Point(870, 14);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(268, 52);
            this.lblTimer.Text = "⏱  --:--";
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // _timer
            //
            this._timer.Interval = 1000;
            this._timer.Tick += new System.EventHandler(this.Timer_Tick);
            //
            // grpInteresados
            //
            this.grpInteresados.BackColor = System.Drawing.Color.FromArgb(252, 228, 235);
            this.grpInteresados.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpInteresados.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.grpInteresados.Location = new System.Drawing.Point(10, 224);
            this.grpInteresados.Name = "grpInteresados";
            this.grpInteresados.Size = new System.Drawing.Size(560, 208);
            this.grpInteresados.Text = "2. Interesados  [OBSERVER]";
            this.grpInteresados.Controls.Add(this.lblPatronObs);
            this.grpInteresados.Controls.Add(this.lstInteresados);
            this.grpInteresados.Controls.Add(this.lblUsuarioSusc);
            this.grpInteresados.Controls.Add(this.cmbUsuarioSuscribir);
            this.grpInteresados.Controls.Add(this.lblCanal);
            this.grpInteresados.Controls.Add(this.cmbCanal);
            this.grpInteresados.Controls.Add(this.btnSuscribir);
            this.grpInteresados.Controls.Add(this.btnDesuscribir);
            //
            // lblPatronObs — banner rosa brand
            //
            this.lblPatronObs.AutoSize = false;
            this.lblPatronObs.BackColor = System.Drawing.Color.FromArgb(210, 100, 135);
            this.lblPatronObs.ForeColor = System.Drawing.Color.White;
            this.lblPatronObs.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblPatronObs.Location = new System.Drawing.Point(6, 18);
            this.lblPatronObs.Size = new System.Drawing.Size(546, 18);
            this.lblPatronObs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPatronObs.Text = "Observer: SubastaActiva notifica a cada Interesado suscripto (RF-05/RF-06/RF-07/RF-08)";
            //
            // lstInteresados
            //
            this.lstInteresados.BackColor = System.Drawing.Color.White;
            this.lstInteresados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstInteresados.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstInteresados.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lstInteresados.Location = new System.Drawing.Point(6, 40);
            this.lstInteresados.Name = "lstInteresados";
            this.lstInteresados.Size = new System.Drawing.Size(238, 158);
            //
            // lblUsuarioSusc
            //
            this.lblUsuarioSusc.AutoSize = true;
            this.lblUsuarioSusc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsuarioSusc.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblUsuarioSusc.Location = new System.Drawing.Point(254, 40);
            this.lblUsuarioSusc.Text = "Usuario:";
            //
            // cmbUsuarioSuscribir
            //
            this.cmbUsuarioSuscribir.BackColor = System.Drawing.Color.FromArgb(245, 245, 248);
            this.cmbUsuarioSuscribir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbUsuarioSuscribir.Location = new System.Drawing.Point(254, 58);
            this.cmbUsuarioSuscribir.Name = "cmbUsuarioSuscribir";
            this.cmbUsuarioSuscribir.Size = new System.Drawing.Size(294, 24);
            this.cmbUsuarioSuscribir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //
            // lblCanal
            //
            this.lblCanal.AutoSize = true;
            this.lblCanal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCanal.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblCanal.Location = new System.Drawing.Point(254, 90);
            this.lblCanal.Text = "Canal de notificación:";
            //
            // cmbCanal
            //
            this.cmbCanal.BackColor = System.Drawing.Color.FromArgb(245, 245, 248);
            this.cmbCanal.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbCanal.Location = new System.Drawing.Point(254, 108);
            this.cmbCanal.Name = "cmbCanal";
            this.cmbCanal.Size = new System.Drawing.Size(294, 24);
            this.cmbCanal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //
            // btnSuscribir
            //
            this.btnSuscribir.BackColor = System.Drawing.Color.FromArgb(210, 100, 135);
            this.btnSuscribir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuscribir.FlatAppearance.BorderSize = 0;
            this.btnSuscribir.ForeColor = System.Drawing.Color.White;
            this.btnSuscribir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSuscribir.Location = new System.Drawing.Point(254, 140);
            this.btnSuscribir.Name = "btnSuscribir";
            this.btnSuscribir.Size = new System.Drawing.Size(140, 28);
            this.btnSuscribir.Text = "Suscribir  (RF-05)";
            this.btnSuscribir.UseVisualStyleBackColor = false;
            this.btnSuscribir.Click += new System.EventHandler(this.btnSuscribir_Click);
            //
            // btnDesuscribir
            //
            this.btnDesuscribir.BackColor = System.Drawing.Color.FromArgb(200, 60, 60);
            this.btnDesuscribir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesuscribir.FlatAppearance.BorderSize = 0;
            this.btnDesuscribir.ForeColor = System.Drawing.Color.White;
            this.btnDesuscribir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDesuscribir.Location = new System.Drawing.Point(404, 140);
            this.btnDesuscribir.Name = "btnDesuscribir";
            this.btnDesuscribir.Size = new System.Drawing.Size(144, 28);
            this.btnDesuscribir.Text = "Desuscribir  (RF-08)";
            this.btnDesuscribir.UseVisualStyleBackColor = false;
            this.btnDesuscribir.Click += new System.EventHandler(this.btnDesuscribir_Click);
            //
            // grpOferta
            //
            this.grpOferta.BackColor = System.Drawing.Color.FromArgb(252, 228, 235);
            this.grpOferta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpOferta.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.grpOferta.Location = new System.Drawing.Point(580, 224);
            this.grpOferta.Name = "grpOferta";
            this.grpOferta.Size = new System.Drawing.Size(580, 208);
            this.grpOferta.Text = "3. Realizar Oferta  [SINGLETON — lock exclusivo RF-09]";
            this.grpOferta.Controls.Add(this.lblPatronSing);
            this.grpOferta.Controls.Add(this.lblOfertante);
            this.grpOferta.Controls.Add(this.cmbOfertante);
            this.grpOferta.Controls.Add(this.lblMonto);
            this.grpOferta.Controls.Add(this.txtMonto);
            this.grpOferta.Controls.Add(this.btnOfertar);
            //
            // lblPatronSing — banner verde (acción positiva)
            //
            this.lblPatronSing.AutoSize = false;
            this.lblPatronSing.BackColor = System.Drawing.Color.FromArgb(30, 140, 80);
            this.lblPatronSing.ForeColor = System.Drawing.Color.White;
            this.lblPatronSing.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblPatronSing.Location = new System.Drawing.Point(6, 18);
            this.lblPatronSing.Size = new System.Drawing.Size(566, 18);
            this.lblPatronSing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPatronSing.Text = "Singleton: GestorDePujasSingleton.EjecutarBajoLock() — 1 puja a la vez";
            //
            // lblOfertante
            //
            this.lblOfertante.AutoSize = true;
            this.lblOfertante.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOfertante.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblOfertante.Location = new System.Drawing.Point(10, 44);
            this.lblOfertante.Text = "Ofertante:";
            //
            // cmbOfertante
            //
            this.cmbOfertante.BackColor = System.Drawing.Color.FromArgb(245, 245, 248);
            this.cmbOfertante.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbOfertante.Location = new System.Drawing.Point(10, 62);
            this.cmbOfertante.Name = "cmbOfertante";
            this.cmbOfertante.Size = new System.Drawing.Size(554, 24);
            this.cmbOfertante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //
            // lblMonto
            //
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMonto.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblMonto.Location = new System.Drawing.Point(10, 96);
            this.lblMonto.Text = "Monto de la oferta:  $";
            //
            // txtMonto
            //
            this.txtMonto.BackColor = System.Drawing.Color.FromArgb(245, 245, 248);
            this.txtMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMonto.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMonto.Location = new System.Drawing.Point(10, 116);
            this.txtMonto.MaxLength = 15;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(554, 26);
            //
            // btnOfertar
            //
            this.btnOfertar.BackColor = System.Drawing.Color.FromArgb(30, 140, 80);
            this.btnOfertar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOfertar.FlatAppearance.BorderSize = 0;
            this.btnOfertar.ForeColor = System.Drawing.Color.White;
            this.btnOfertar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOfertar.Location = new System.Drawing.Point(10, 152);
            this.btnOfertar.Name = "btnOfertar";
            this.btnOfertar.Size = new System.Drawing.Size(554, 36);
            this.btnOfertar.Text = "Realizar Oferta  (RF-10)";
            this.btnOfertar.UseVisualStyleBackColor = false;
            this.btnOfertar.Click += new System.EventHandler(this.btnOfertar_Click);
            //
            // grpNotificaciones
            //
            this.grpNotificaciones.BackColor = System.Drawing.Color.FromArgb(252, 228, 235);
            this.grpNotificaciones.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpNotificaciones.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.grpNotificaciones.Location = new System.Drawing.Point(10, 442);
            this.grpNotificaciones.Name = "grpNotificaciones";
            this.grpNotificaciones.Size = new System.Drawing.Size(1150, 220);
            this.grpNotificaciones.Text = "Notificaciones  [OBSERVER RF-06/RF-07]";
            this.grpNotificaciones.Controls.Add(this.rtbNotificaciones);
            //
            // rtbNotificaciones — consola oscura (contraste con el rosa)
            //
            this.rtbNotificaciones.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.rtbNotificaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbNotificaciones.Font = new System.Drawing.Font("Consolas", 9F);
            this.rtbNotificaciones.ForeColor = System.Drawing.Color.FromArgb(180, 255, 180);
            this.rtbNotificaciones.Location = new System.Drawing.Point(6, 18);
            this.rtbNotificaciones.Name = "rtbNotificaciones";
            this.rtbNotificaciones.ReadOnly = true;
            this.rtbNotificaciones.Size = new System.Drawing.Size(1136, 196);
            //
            // btnCerrarSubasta
            //
            this.btnCerrarSubasta.BackColor = System.Drawing.Color.FromArgb(200, 60, 60);
            this.btnCerrarSubasta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSubasta.FlatAppearance.BorderSize = 0;
            this.btnCerrarSubasta.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSubasta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrarSubasta.Location = new System.Drawing.Point(10, 670);
            this.btnCerrarSubasta.Name = "btnCerrarSubasta";
            this.btnCerrarSubasta.Size = new System.Drawing.Size(1150, 38);
            this.btnCerrarSubasta.Text = "Cerrar Subasta — notifica a todos (RF-07) y persiste en BD";
            this.btnCerrarSubasta.UseVisualStyleBackColor = false;
            this.btnCerrarSubasta.Click += new System.EventHandler(this.btnCerrarSubasta_Click);
            //
            // frmSubasta
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(252, 228, 235);
            this.ClientSize = new System.Drawing.Size(1180, 720);
            this.Controls.Add(this.grpNotificaciones);
            this.Controls.Add(this.grpOferta);
            this.Controls.Add(this.grpInteresados);
            this.Controls.Add(this.grpEstado);
            this.Controls.Add(this.grpIniciar);
            this.Controls.Add(this.btnCerrarSubasta);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.panelTop);
            this.Name = "frmSubasta";
            this.Text = "Gestión de Subasta — OBSERVER + SINGLETON";
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
