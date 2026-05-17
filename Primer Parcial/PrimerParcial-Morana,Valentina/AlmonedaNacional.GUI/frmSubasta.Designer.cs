namespace AlmonedaNacional.GUI
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
            this.grpIniciar.SuspendLayout();
            this.grpEstado.SuspendLayout();
            this.grpInteresados.SuspendLayout();
            this.grpOferta.SuspendLayout();
            this.grpNotificaciones.SuspendLayout();
            this.SuspendLayout();
            // ── grpIniciar ─────────────────────────────────────────────────────
            this.grpIniciar.Location = new System.Drawing.Point(10, 10);
            this.grpIniciar.Name = "grpIniciar";
            this.grpIniciar.Size = new System.Drawing.Size(1150, 60);
            this.grpIniciar.Text = "1. Seleccionar Unidad de Venta  [COMPOSITE]";
            this.grpIniciar.Controls.Add(this.lblUnidad);
            this.grpIniciar.Controls.Add(this.cmbUnidad);
            this.grpIniciar.Controls.Add(this.btnIniciarSubasta);
            // lblUnidad
            this.lblUnidad.AutoSize = true;
            this.lblUnidad.Location = new System.Drawing.Point(10, 25);
            this.lblUnidad.Text = "Unidad:";
            // cmbUnidad
            this.cmbUnidad.Location = new System.Drawing.Point(70, 22);
            this.cmbUnidad.Name = "cmbUnidad";
            this.cmbUnidad.Size = new System.Drawing.Size(700, 21);
            this.cmbUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // btnIniciarSubasta
            this.btnIniciarSubasta.Location = new System.Drawing.Point(790, 19);
            this.btnIniciarSubasta.Name = "btnIniciarSubasta";
            this.btnIniciarSubasta.Size = new System.Drawing.Size(340, 28);
            this.btnIniciarSubasta.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnIniciarSubasta.ForeColor = System.Drawing.Color.White;
            this.btnIniciarSubasta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnIniciarSubasta.Text = "▶ INICIAR SUBASTA";
            this.btnIniciarSubasta.UseVisualStyleBackColor = false;
            this.btnIniciarSubasta.Click += new System.EventHandler(this.btnIniciarSubasta_Click);
            // ── grpEstado ──────────────────────────────────────────────────────
            this.grpEstado.Location = new System.Drawing.Point(10, 80);
            this.grpEstado.Name = "grpEstado";
            this.grpEstado.Size = new System.Drawing.Size(1150, 75);
            this.grpEstado.Text = "Estado de la Subasta Activa";
            this.grpEstado.Controls.Add(this.lblNombreLabel);
            this.grpEstado.Controls.Add(this.lblNombreSubasta);
            this.grpEstado.Controls.Add(this.lblBaseLabel);
            this.grpEstado.Controls.Add(this.lblPrecioBase);
            this.grpEstado.Controls.Add(this.lblActualLabel);
            this.grpEstado.Controls.Add(this.lblPrecioActual);
            this.grpEstado.Controls.Add(this.lblPujadorLabel);
            this.grpEstado.Controls.Add(this.lblUltimoPujador);
            // lblNombreLabel
            this.lblNombreLabel.AutoSize = true; this.lblNombreLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNombreLabel.Location = new System.Drawing.Point(10, 25); this.lblNombreLabel.Text = "Artículo:";
            // lblNombreSubasta
            this.lblNombreSubasta.AutoSize = true; this.lblNombreSubasta.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblNombreSubasta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombreSubasta.Location = new System.Drawing.Point(80, 25); this.lblNombreSubasta.Text = "—";
            // lblBaseLabel
            this.lblBaseLabel.AutoSize = true; this.lblBaseLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblBaseLabel.Location = new System.Drawing.Point(400, 25); this.lblBaseLabel.Text = "Precio Base:";
            // lblPrecioBase
            this.lblPrecioBase.AutoSize = true; this.lblPrecioBase.Location = new System.Drawing.Point(490, 25); this.lblPrecioBase.Text = "—";
            // lblActualLabel
            this.lblActualLabel.AutoSize = true; this.lblActualLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblActualLabel.Location = new System.Drawing.Point(10, 50); this.lblActualLabel.Text = "Precio Actual:";
            // lblPrecioActual
            this.lblPrecioActual.AutoSize = true; this.lblPrecioActual.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblPrecioActual.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPrecioActual.Location = new System.Drawing.Point(110, 47); this.lblPrecioActual.Text = "—";
            // lblPujadorLabel
            this.lblPujadorLabel.AutoSize = true; this.lblPujadorLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPujadorLabel.Location = new System.Drawing.Point(400, 50); this.lblPujadorLabel.Text = "Último Pujador:";
            // lblUltimoPujador
            this.lblUltimoPujador.AutoSize = true; this.lblUltimoPujador.Location = new System.Drawing.Point(510, 50); this.lblUltimoPujador.Text = "—";
            // ── grpInteresados ─────────────────────────────────────────────────
            this.grpInteresados.Location = new System.Drawing.Point(10, 165);
            this.grpInteresados.Name = "grpInteresados";
            this.grpInteresados.Size = new System.Drawing.Size(560, 200);
            this.grpInteresados.Text = "2. Interesados  [OBSERVER + STRATEGY]";
            this.grpInteresados.Controls.Add(this.lblPatronObs);
            this.grpInteresados.Controls.Add(this.lstInteresados);
            this.grpInteresados.Controls.Add(this.lblUsuarioSusc);
            this.grpInteresados.Controls.Add(this.cmbUsuarioSuscribir);
            this.grpInteresados.Controls.Add(this.lblCanal);
            this.grpInteresados.Controls.Add(this.cmbCanal);
            this.grpInteresados.Controls.Add(this.btnSuscribir);
            this.grpInteresados.Controls.Add(this.btnDesuscribir);
            // lblPatronObs
            this.lblPatronObs.AutoSize = false; this.lblPatronObs.BackColor = System.Drawing.Color.MidnightBlue; this.lblPatronObs.ForeColor = System.Drawing.Color.White;
            this.lblPatronObs.Location = new System.Drawing.Point(5, 18); this.lblPatronObs.Size = new System.Drawing.Size(548, 18);
            this.lblPatronObs.Font = new System.Drawing.Font("Segoe UI", 8F); this.lblPatronObs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPatronObs.Text = "Observer: el Sujeto (SubastaActiva) notifica a cada Observador (Interesado) vía Strategy";
            // lstInteresados
            this.lstInteresados.Location = new System.Drawing.Point(5, 40); this.lstInteresados.Name = "lstInteresados";
            this.lstInteresados.Size = new System.Drawing.Size(240, 150);
            // lblUsuarioSusc
            this.lblUsuarioSusc.AutoSize = true; this.lblUsuarioSusc.Location = new System.Drawing.Point(255, 40); this.lblUsuarioSusc.Text = "Usuario:";
            // cmbUsuarioSuscribir
            this.cmbUsuarioSuscribir.Location = new System.Drawing.Point(255, 58); this.cmbUsuarioSuscribir.Name = "cmbUsuarioSuscribir";
            this.cmbUsuarioSuscribir.Size = new System.Drawing.Size(295, 21); this.cmbUsuarioSuscribir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // lblCanal
            this.lblCanal.AutoSize = true; this.lblCanal.Location = new System.Drawing.Point(255, 88); this.lblCanal.Text = "Canal [STRATEGY]:";
            // cmbCanal
            this.cmbCanal.Location = new System.Drawing.Point(255, 106); this.cmbCanal.Name = "cmbCanal";
            this.cmbCanal.Size = new System.Drawing.Size(295, 21); this.cmbCanal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // btnSuscribir
            this.btnSuscribir.Location = new System.Drawing.Point(255, 136); this.btnSuscribir.Name = "btnSuscribir";
            this.btnSuscribir.Size = new System.Drawing.Size(140, 30); this.btnSuscribir.Text = "Suscribir (RF-05)";
            this.btnSuscribir.BackColor = System.Drawing.Color.SteelBlue; this.btnSuscribir.ForeColor = System.Drawing.Color.White;
            this.btnSuscribir.UseVisualStyleBackColor = false;
            this.btnSuscribir.Click += new System.EventHandler(this.btnSuscribir_Click);
            // btnDesuscribir
            this.btnDesuscribir.Location = new System.Drawing.Point(405, 136); this.btnDesuscribir.Name = "btnDesuscribir";
            this.btnDesuscribir.Size = new System.Drawing.Size(145, 30); this.btnDesuscribir.Text = "Desuscribir (RF-08)";
            this.btnDesuscribir.BackColor = System.Drawing.Color.IndianRed; this.btnDesuscribir.ForeColor = System.Drawing.Color.White;
            this.btnDesuscribir.UseVisualStyleBackColor = false;
            this.btnDesuscribir.Click += new System.EventHandler(this.btnDesuscribir_Click);
            // ── grpOferta ──────────────────────────────────────────────────────
            this.grpOferta.Location = new System.Drawing.Point(580, 165);
            this.grpOferta.Name = "grpOferta";
            this.grpOferta.Size = new System.Drawing.Size(580, 200);
            this.grpOferta.Text = "3. Realizar Oferta  [SINGLETON — lock exclusivo RF-09]";
            this.grpOferta.Controls.Add(this.lblPatronSing);
            this.grpOferta.Controls.Add(this.lblOfertante);
            this.grpOferta.Controls.Add(this.cmbOfertante);
            this.grpOferta.Controls.Add(this.lblMonto);
            this.grpOferta.Controls.Add(this.txtMonto);
            this.grpOferta.Controls.Add(this.btnOfertar);
            // lblPatronSing
            this.lblPatronSing.AutoSize = false; this.lblPatronSing.BackColor = System.Drawing.Color.DarkOliveGreen; this.lblPatronSing.ForeColor = System.Drawing.Color.White;
            this.lblPatronSing.Location = new System.Drawing.Point(5, 18); this.lblPatronSing.Size = new System.Drawing.Size(568, 18);
            this.lblPatronSing.Font = new System.Drawing.Font("Segoe UI", 8F); this.lblPatronSing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPatronSing.Text = "Singleton: GestorDePujasSingleton.EjecutarBajoLock() garantiza 1 puja a la vez";
            // lblOfertante
            this.lblOfertante.AutoSize = true; this.lblOfertante.Location = new System.Drawing.Point(10, 45); this.lblOfertante.Text = "Ofertante:";
            // cmbOfertante
            this.cmbOfertante.Location = new System.Drawing.Point(10, 63); this.cmbOfertante.Name = "cmbOfertante";
            this.cmbOfertante.Size = new System.Drawing.Size(550, 21); this.cmbOfertante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // lblMonto
            this.lblMonto.AutoSize = true; this.lblMonto.Location = new System.Drawing.Point(10, 95);
            this.lblMonto.Text = "Monto de la oferta:  $";
            this.lblMonto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            // txtMonto
            this.txtMonto.Location = new System.Drawing.Point(10, 115); this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(550, 21);
            this.txtMonto.Font = new System.Drawing.Font("Consolas", 11F);
            // btnOfertar
            this.btnOfertar.Location = new System.Drawing.Point(10, 150); this.btnOfertar.Name = "btnOfertar";
            this.btnOfertar.Size = new System.Drawing.Size(550, 36);
            this.btnOfertar.BackColor = System.Drawing.Color.DarkGreen; this.btnOfertar.ForeColor = System.Drawing.Color.White;
            this.btnOfertar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOfertar.Text = "💰 REALIZAR OFERTA  (RF-10)";
            this.btnOfertar.UseVisualStyleBackColor = false;
            this.btnOfertar.Click += new System.EventHandler(this.btnOfertar_Click);
            // ── grpNotificaciones ──────────────────────────────────────────────
            this.grpNotificaciones.Location = new System.Drawing.Point(10, 375);
            this.grpNotificaciones.Name = "grpNotificaciones";
            this.grpNotificaciones.Size = new System.Drawing.Size(1150, 260);
            this.grpNotificaciones.Text = "Notificaciones recibidas  [OBSERVER RF-06/RF-07 + STRATEGY — canal elegido por cada interesado]";
            this.grpNotificaciones.Controls.Add(this.rtbNotificaciones);
            // rtbNotificaciones
            this.rtbNotificaciones.Location = new System.Drawing.Point(5, 18); this.rtbNotificaciones.Name = "rtbNotificaciones";
            this.rtbNotificaciones.Size = new System.Drawing.Size(1138, 235);
            this.rtbNotificaciones.Font = new System.Drawing.Font("Consolas", 9F);
            this.rtbNotificaciones.ReadOnly = true; this.rtbNotificaciones.BackColor = System.Drawing.Color.Black;
            this.rtbNotificaciones.ForeColor = System.Drawing.Color.Lime;
            // ── btnCerrarSubasta ───────────────────────────────────────────────
            this.btnCerrarSubasta.Location = new System.Drawing.Point(10, 645);
            this.btnCerrarSubasta.Name = "btnCerrarSubasta";
            this.btnCerrarSubasta.Size = new System.Drawing.Size(1150, 40);
            this.btnCerrarSubasta.BackColor = System.Drawing.Color.Maroon;
            this.btnCerrarSubasta.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSubasta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrarSubasta.Text = "🔨 CERRAR SUBASTA — notifica a todos (RF-07) y persiste en BD";
            this.btnCerrarSubasta.UseVisualStyleBackColor = false;
            this.btnCerrarSubasta.Click += new System.EventHandler(this.btnCerrarSubasta_Click);
            // ── frmSubasta ─────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 700);
            this.Controls.Add(this.grpIniciar);
            this.Controls.Add(this.grpEstado);
            this.Controls.Add(this.grpInteresados);
            this.Controls.Add(this.grpOferta);
            this.Controls.Add(this.grpNotificaciones);
            this.Controls.Add(this.btnCerrarSubasta);
            this.Name = "frmSubasta";
            this.Text = "Gestión de Subasta — OBSERVER + SINGLETON + STRATEGY";
            this.Load += new System.EventHandler(this.frmSubasta_Load);
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
    }
}
