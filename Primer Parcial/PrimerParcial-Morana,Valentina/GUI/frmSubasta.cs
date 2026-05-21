using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BE;
using BLL;
using Servicios;
using Servicios.Composite;
using Seguridad;

namespace GUI
{
    // Demuestra en un solo form los 3 patrones:
    //   OBSERVER  : suscribir/desuscribir interesados, notificación automática al pujar
    //   SINGLETON : GestorDePujasSingleton procesa una puja a la vez (lock exclusivo)
    //   COMPOSITE : el catálogo usa ArticuloSimple / LoteArticulos
    // Plus: Temporizador regresivo + Anti-Sniping automático
    public partial class frmSubasta : Form
    {
        private SubastaBLL _bll;
        private CatalogoBLL _catalogoBLL;
        private SubastaActiva _subastaActiva;
        private List<Interesado> _interesados;
        private List<Usuario> _usuarios;
        private readonly BitacoraBLL _bitacora = new BitacoraBLL();

        public bool TieneSubastaActiva => _subastaActiva != null && _subastaActiva.EstaActiva;

        private const int UMBRAL_ANTISNIPING    = 30;   // últimos N segundos disparan extensión
        private const int EXTENSION_ANTISNIPING = 120; // se agregan N segundos al tiempo restante
        private int _segundosRestantes;

        public frmSubasta()
        {
            InitializeComponent();
            _bll         = new SubastaBLL();
            _catalogoBLL = new CatalogoBLL();
            _interesados = new List<Interesado>();
            _usuarios    = new List<Usuario>();
        }

        private void frmSubasta_Load(object sender, EventArgs e)
        {
            InicializarDatos();
            ActualizarEstadoControles();
        }

        // ─────────────────────────────────────────────
        //  DATOS DE DEMO
        // ─────────────────────────────────────────────
        private void InicializarDatos()
        {
            try
            {
                _usuarios = new List<Usuario>(new UsuarioBLL().ObtenerTodos());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[InicializarDatos] Error al cargar usuarios: {ex}");
                MessageBox.Show(
                    $"No se pudieron cargar los usuarios desde la base de datos.\nSe usarán usuarios de demo.\n\nDetalle: {ex.Message}",
                    "Aviso — sin conexión a BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _usuarios = new List<Usuario>
                {
                    new Usuario { Id = 1, Nombre = "Carlos Méndez",   Email = "carlos@web.com"  },
                    new Usuario { Id = 2, Nombre = "Laura Rodríguez", Email = "laura@movil.com" },
                    new Usuario { Id = 3, Nombre = "Tomás García",    Email = "tomas@sala.com"  }
                };
            }

            RecargarComboUnidad();

            cmbOfertante.DataSource    = null;
            cmbOfertante.DataSource    = new List<Usuario>(_usuarios);
            cmbOfertante.DisplayMember = "Nombre";

            cmbUsuarioSuscribir.DataSource    = null;
            cmbUsuarioSuscribir.DataSource    = new List<Usuario>(_usuarios);
            cmbUsuarioSuscribir.DisplayMember = "Nombre";
        }

        // Recarga el combo con unidades subastables (Disponible o Desierta) desde BD.
        private void RecargarComboUnidad()
        {
            try
            {
                var todas = _catalogoBLL.ObtenerCatalogo();
                var subastables = todas.FindAll(u =>
                    u.Estado == EstadoUnidad.Disponible || u.Estado == EstadoUnidad.Desierta);
                cmbUnidad.DataSource    = null;
                cmbUnidad.DataSource    = subastables;
                cmbUnidad.DisplayMember = "Nombre";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[RecargarComboUnidad] {ex.Message}");
            }
        }

        // ─────────────────────────────────────────────
        //  1. INICIAR SUBASTA
        // ─────────────────────────────────────────────
        private void btnIniciarSubasta_Click(object sender, EventArgs e)
        {
            try
            {
                if (_subastaActiva != null && _subastaActiva.EstaActiva)
                    throw new InvalidOperationException("Ya hay una subasta activa. Ciérrela primero.");

                var unidad = cmbUnidad.SelectedItem as IUnidadDeVenta;
                if (unidad == null)
                    throw new InvalidOperationException("Seleccione una unidad de venta.");

                int duracion = DialogoDuracion();
                if (duracion < 0) return;

                _subastaActiva = _bll.CrearSubasta(unidad);
                unidad.Estado  = EstadoUnidad.EnSubasta;
                _catalogoBLL.ActualizarEstado(unidad.Id, EstadoUnidad.EnSubasta);
                _interesados.Clear();
                lstInteresados.Items.Clear();
                rtbNotificaciones.Clear();

                _segundosRestantes = duracion;
                ActualizarLblTimer();
                _timer.Start();

                _bitacora.Registrar("INICIAR_SUBASTA",
                    $"Subasta iniciada: {unidad.Nombre} — Base: ${_subastaActiva.PrecioActual:N2}",
                    CriticidadEvento.Media);

                rtbNotificaciones.AppendText($"[{DateTime.Now:HH:mm:ss}] Subasta iniciada: {unidad.Nombre}  |  Precio base: ${_subastaActiva.PrecioActual:N2}  |  Duración: {FormatearDuracion(duracion)}\r\n");
                ActualizarPanelSubasta();
                ActualizarEstadoControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────
        //  2. SUSCRIBIR INTERESADO (OBSERVER)
        // ─────────────────────────────────────────────
        private void btnSuscribir_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarSubastaActiva();
                var usuario = cmbUsuarioSuscribir.SelectedItem as Usuario;

                if (_interesados.Exists(i => i.Usuario.Id == usuario.Id))
                    throw new InvalidOperationException($"{usuario.Nombre} ya está suscripto a esta subasta.");

                var interesado = new Interesado(usuario);
                interesado.NotificacionRecibida += (destinatario, mensaje) =>
                    rtbNotificaciones.AppendText($"[{DateTime.Now:HH:mm:ss}] Para {destinatario} — Notificación: {mensaje}\r\n");

                // OBSERVER: Sujeto registra al observador (RF-05)
                _bll.Suscribir(_subastaActiva, interesado);
                _interesados.Add(interesado);

                lstInteresados.Items.Add(usuario.Nombre);
                rtbNotificaciones.AppendText($"[{DateTime.Now:HH:mm:ss}] {usuario.Nombre} suscripto.\r\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────
        //  3. DESUSCRIBIR INTERESADO (OBSERVER — RF-08)
        // ─────────────────────────────────────────────
        private void btnDesuscribir_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarSubastaActiva();
                int idx = lstInteresados.SelectedIndex;
                if (idx < 0)
                    throw new InvalidOperationException("Seleccioná un interesado de la lista para desuscribir.");

                var interesado = _interesados[idx];

                // OBSERVER: Sujeto elimina al observador (RF-08)
                _bll.Desuscribir(_subastaActiva, interesado);
                _interesados.RemoveAt(idx);
                lstInteresados.Items.RemoveAt(idx);

                rtbNotificaciones.AppendText($"[{DateTime.Now:HH:mm:ss}] {interesado.Usuario.Nombre} desuscripto.\r\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────
        //  4. REALIZAR OFERTA (SINGLETON + OBSERVER + ANTI-SNIPING)
        // ─────────────────────────────────────────────
        private void txtMonto_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != ',' && e.KeyChar != '.')
                e.Handled = true;
        }

        private void btnOfertar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarSubastaActiva();
                var usuario = cmbOfertante.SelectedItem as Usuario;
                if (!decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0)
                    throw new ArgumentException("Ingrese un monto válido mayor a cero.");

                // SINGLETON: GestorDePujasSingleton garantiza exclusión mutua (RF-09)
                // OBSERVER: al actualizarse el precio, Notificar() avisa a todos (RF-06)
                _bll.RealizarOferta(_subastaActiva, usuario, monto);

                _bitacora.Registrar("OFERTA_ACEPTADA",
                    $"{usuario.Nombre} — ${monto:N2} — {_subastaActiva.Unidad.Nombre}",
                    CriticidadEvento.Baja);

                // ANTI-SNIPING: si la oferta llega en los últimos N segundos, extender
                if (_segundosRestantes <= UMBRAL_ANTISNIPING)
                {
                    _segundosRestantes += EXTENSION_ANTISNIPING;
                    rtbNotificaciones.AppendText(
                        $"[{DateTime.Now:HH:mm:ss}] ⚡ ANTI-SNIPING activado — tiempo extendido +{EXTENSION_ANTISNIPING / 60} min\r\n");
                }

                txtMonto.Clear();
                ActualizarPanelSubasta();
                ActualizarLblTimer();
            }
            catch (Exception ex)
            {
                _bitacora.Registrar("OFERTA_RECHAZADA",
                    $"{(cmbOfertante.SelectedItem as Usuario)?.Nombre} — ${txtMonto.Text} — {ex.Message}",
                    CriticidadEvento.Baja);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────
        //  5. CERRAR SUBASTA (OBSERVER RF-07 + DAL)
        // ─────────────────────────────────────────────
        private void btnCerrarSubasta_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarSubastaActiva();

                if (_subastaActiva.UltimoPujador == null)
                {
                    MessageBox.Show(
                        "Esta subasta no tiene ofertas y no puede cerrarse con adjudicación.\n" +
                        "Esperá una oferta o dejá que el tiempo expire.",
                        "Sin ofertas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show(
                    $"¿Cerrar la subasta de '{_subastaActiva.Unidad.Nombre}'?\n" +
                    $"Ganador: {_subastaActiva.UltimoPujador.Nombre}\n" +
                    $"Precio final: ${_subastaActiva.PrecioActual:N2}",
                    "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;

                _timer.Stop();

                // Cierra subasta → notifica a todos (RF-07) → persiste en BD
                var resultado = _bll.CerrarSubasta(_subastaActiva);
                _subastaActiva.Unidad.Estado = EstadoUnidad.Adjudicado;
                _catalogoBLL.ActualizarEstado(_subastaActiva.Unidad.Id, EstadoUnidad.Adjudicado);
                RecargarComboUnidad();

                _bitacora.Registrar("CERRAR_SUBASTA",
                    $"Cierre manual — {_subastaActiva.Unidad.Nombre} — Ganador: {resultado.NombreGanador} — ${resultado.PrecioFinal:N2}",
                    CriticidadEvento.Alta);

                lblPrecioActual.Text      = $"CERRADA — ${resultado.PrecioFinal:N2}";
                lblPrecioActual.ForeColor = Color.Red;
                lblTimer.Text             = "⏱  --:--";
                lblTimer.ForeColor        = Color.DimGray;

                rtbNotificaciones.AppendText($"\r\n[{DateTime.Now:HH:mm:ss}] ══ SUBASTA CERRADA ══\r\n");
                rtbNotificaciones.AppendText($"  Ganador: {resultado.NombreGanador}\r\n");
                rtbNotificaciones.AppendText($"  Precio final: ${resultado.PrecioFinal:N2}\r\n");
                rtbNotificaciones.AppendText($"  Persistido en BD: {resultado.FechaHora:dd/MM/yyyy HH:mm:ss}\r\n");

                ActualizarEstadoControles();
            }
            catch (Exception ex)
            {
                _timer.Start();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────
        //  TEMPORIZADOR
        // ─────────────────────────────────────────────
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_segundosRestantes <= 0)
            {
                _timer.Stop();
                AutoCerrarSubasta();
                return;
            }
            _segundosRestantes--;
            ActualizarLblTimer();
        }

        private void ActualizarLblTimer()
        {
            lblTimer.Text      = "⏱  " + FormatearSegundos(_segundosRestantes);
            lblTimer.ForeColor = _segundosRestantes <= UMBRAL_ANTISNIPING
                ? Color.FromArgb(200, 60, 60)
                : Color.FromArgb(30, 140, 80);
        }

        private static string FormatearSegundos(int seg)
        {
            int d = seg / 86400;
            int h = (seg % 86400) / 3600;
            int m = (seg % 3600) / 60;
            int s = seg % 60;
            return d > 0
                ? $"{d}d {h:00}:{m:00}:{s:00}"
                : h > 0
                    ? $"{h:00}:{m:00}:{s:00}"
                    : $"{m:00}:{s:00}";
        }

        private static string FormatearDuracion(int seg)
        {
            return DuracionEnPalabras(seg / 86400, (seg % 86400) / 3600, (seg % 3600) / 60);
        }

        private void AutoCerrarSubasta()
        {
            if (_subastaActiva == null || !_subastaActiva.EstaActiva) return;

            lblTimer.Text      = "⏱  00:00:00";
            lblTimer.ForeColor = Color.FromArgb(200, 60, 60);

            if (_subastaActiva.UltimoPujador == null)
            {
                // Sin ofertas: queda Desierta — puede volver a subastarse
                var unidadDesierta = _subastaActiva.Unidad;
                unidadDesierta.Estado = EstadoUnidad.Desierta;
                _catalogoBLL.ActualizarEstado(unidadDesierta.Id, EstadoUnidad.Desierta);
                _subastaActiva = null;
                RecargarComboUnidad();
                rtbNotificaciones.AppendText(
                    $"\r\n[{DateTime.Now:HH:mm:ss}] ══ TIEMPO AGOTADO — sin ofertas, subasta marcada como Desierta ══\r\n");
                ActualizarEstadoControles();
                return;
            }

            try
            {
                var resultado = _bll.CerrarSubasta(_subastaActiva);
                _subastaActiva.Unidad.Estado = EstadoUnidad.Adjudicado;
                _catalogoBLL.ActualizarEstado(_subastaActiva.Unidad.Id, EstadoUnidad.Adjudicado);
                RecargarComboUnidad();

                _bitacora.Registrar("CIERRE_AUTOMATICO",
                    $"Tiempo agotado — {_subastaActiva?.Unidad?.Nombre} — Ganador: {resultado.NombreGanador} — ${resultado.PrecioFinal:N2}",
                    CriticidadEvento.Alta);

                lblPrecioActual.Text      = $"CERRADA — ${resultado.PrecioFinal:N2}";
                lblPrecioActual.ForeColor = Color.Red;

                rtbNotificaciones.AppendText($"\r\n[{DateTime.Now:HH:mm:ss}] ══ TIEMPO AGOTADO — SUBASTA CERRADA AUTOMÁTICAMENTE ══\r\n");
                rtbNotificaciones.AppendText($"  Ganador: {resultado.NombreGanador}\r\n");
                rtbNotificaciones.AppendText($"  Precio final: ${resultado.PrecioFinal:N2}\r\n");

                ActualizarEstadoControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cerrar automáticamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────
        //  DIÁLOGO DE DURACIÓN
        // ─────────────────────────────────────────────
        // Devuelve los segundos elegidos, o -1 si el usuario canceló.
        private int DialogoDuracion()
        {
            using (var dlg = new Form())
            {
                dlg.Text            = "Duración de la subasta";
                dlg.ClientSize      = new Size(290, 252);
                dlg.StartPosition   = FormStartPosition.CenterParent;
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.MaximizeBox     = false;
                dlg.MinimizeBox     = false;
                dlg.BackColor       = Color.FromArgb(252, 228, 235);

                var header = new Panel { Dock = DockStyle.Top, Height = 38, BackColor = Color.FromArgb(210, 100, 135) };
                header.Controls.Add(new Label
                {
                    Text = "Configurar duración", Dock = DockStyle.Fill,
                    ForeColor = Color.White, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter
                });
                dlg.Controls.Add(header);

                Func<string, int, int, long, NumericUpDown> fila = (etiq, y, max, def) =>
                {
                    dlg.Controls.Add(new Label
                    {
                        Text = etiq, Location = new Point(20, y + 3), AutoSize = true,
                        Font = new Font("Segoe UI", 9F), ForeColor = Color.FromArgb(64, 64, 64)
                    });
                    var nud = new NumericUpDown
                    {
                        Location = new Point(150, y), Size = new Size(80, 24),
                        Minimum = 0, Maximum = max, Value = def,
                        BackColor = Color.FromArgb(245, 245, 248), Font = new Font("Segoe UI", 9F)
                    };
                    dlg.Controls.Add(nud);
                    return nud;
                };

                var nudDias    = fila("Días:",    52,  9999, 0);
                var nudHoras   = fila("Horas:",   90,  23,   0);
                var nudMinutos = fila("Minutos:", 128, 59,   5);

                var lblTotal = new Label
                {
                    Location = new Point(20, 166), Size = new Size(250, 36),
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Italic),
                    ForeColor = Color.FromArgb(100, 100, 135)
                };
                dlg.Controls.Add(lblTotal);

                Action actualizar = () =>
                {
                    lblTotal.Text = DuracionEnPalabras((int)nudDias.Value, (int)nudHoras.Value, (int)nudMinutos.Value);
                };
                nudDias.ValueChanged    += (s2, e2) => actualizar();
                nudHoras.ValueChanged   += (s2, e2) => actualizar();
                nudMinutos.ValueChanged += (s2, e2) => actualizar();
                actualizar();

                var btnOk = new Button
                {
                    Text = "Confirmar", DialogResult = DialogResult.OK,
                    Location = new Point(30, 212), Size = new Size(100, 28),
                    BackColor = Color.FromArgb(210, 100, 135), ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                };
                btnOk.FlatAppearance.BorderSize = 0;

                var btnCan = new Button
                {
                    Text = "Cancelar", DialogResult = DialogResult.Cancel,
                    Location = new Point(158, 212), Size = new Size(100, 28),
                    BackColor = Color.FromArgb(200, 200, 210), ForeColor = Color.FromArgb(64, 64, 64),
                    FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                };
                btnCan.FlatAppearance.BorderSize = 0;

                dlg.Controls.Add(btnOk);
                dlg.Controls.Add(btnCan);
                dlg.AcceptButton = btnOk;
                dlg.CancelButton = btnCan;

                if (dlg.ShowDialog(this) != DialogResult.OK) return -1;

                long total = (long)nudDias.Value * 86400 + (long)nudHoras.Value * 3600 + (long)nudMinutos.Value * 60;
                if (total <= 0)
                    throw new InvalidOperationException("La duración debe ser mayor a cero.");
                return (int)total;
            }
        }

        private static string DuracionEnPalabras(int dias, int horas, int minutos)
        {
            if (dias == 0 && horas == 0 && minutos == 0) return "Seleccioná al menos 1 minuto.";

            string parteDias    = dias    == 1 ? "1 día"    : dias    > 1 ? $"{dias} días"     : null;
            string parteHoras   = horas   == 1 ? "1 hora"   : horas   > 1 ? $"{horas} horas"   : null;
            string parteMinutos = minutos == 1 ? "1 minuto" : minutos > 1 ? $"{minutos} minutos" : null;

            var partes = new System.Collections.Generic.List<string>();
            if (parteDias    != null) partes.Add(parteDias);
            if (parteHoras   != null) partes.Add(parteHoras);
            if (parteMinutos != null) partes.Add(parteMinutos);

            return string.Join(" y ", partes);
        }

        // ─────────────────────────────────────────────
        //  HELPERS
        // ─────────────────────────────────────────────
        private void ValidarSubastaActiva()
        {
            if (_subastaActiva == null || !_subastaActiva.EstaActiva)
                throw new InvalidOperationException("No hay ninguna subasta activa en este momento.");
        }

        private void ActualizarPanelSubasta()
        {
            if (_subastaActiva == null) return;
            lblNombreSubasta.Text = _subastaActiva.Unidad.Nombre;
            lblPrecioBase.Text    = $"${_subastaActiva.Unidad.CalcularPrecioBase():N2}";
            lblPrecioActual.Text  = $"${_subastaActiva.PrecioActual:N2}";
            lblPrecioActual.ForeColor = Color.DarkGreen;
            lblUltimoPujador.Text = _subastaActiva.UltimoPujador?.Nombre ?? "—";
        }

        private void ActualizarEstadoControles()
        {
            bool haySubasta = _subastaActiva != null && _subastaActiva.EstaActiva;

            grpInteresados.Enabled    = haySubasta;
            grpOferta.Enabled         = haySubasta;
            btnCerrarSubasta.Enabled  = haySubasta;
            btnIniciarSubasta.Enabled = !haySubasta;
            cmbUnidad.Enabled         = !haySubasta;
        }
    }
}
