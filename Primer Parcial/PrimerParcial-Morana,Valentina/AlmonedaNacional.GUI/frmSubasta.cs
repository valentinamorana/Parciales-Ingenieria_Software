using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AlmonedaNacional.BE;
using AlmonedaNacional.BLL;
using AlmonedaNacional.Servicios;
using AlmonedaNacional.Servicios.Composite;
using AlmonedaNacional.Seguridad;

namespace AlmonedaNacional.GUI
{
    // Demuestra en un solo form los 3 patrones:
    //   OBSERVER  : suscribir/desuscribir interesados, notificación automática al pujar
    //   SINGLETON : GestorDePujasSingleton procesa una puja a la vez (lock exclusivo)
    //   COMPOSITE : el catálogo usa ArticuloSimple / LoteArticulos
    // Plus: Temporizador regresivo + Anti-Sniping automático
    public partial class frmSubasta : Form
    {
        private SubastaBLL _bll;
        private SubastaActiva _subastaActiva;
        private List<Interesado> _interesados;
        private List<IUnidadDeVenta> _catalogo;
        private List<Usuario> _usuarios;
        private readonly BitacoraBLL _bitacora = new BitacoraBLL();

        private const int DURACION_INICIAL     = 120;  // 2 minutos por subasta
        private const int UMBRAL_ANTISNIPING   = 30;   // últimos N segundos disparan extensión
        private const int EXTENSION_ANTISNIPING = 120; // se agregan N segundos al tiempo restante
        private int _segundosRestantes;

        public frmSubasta(List<IUnidadDeVenta> catalogo)
        {
            InitializeComponent();
            _bll         = new SubastaBLL();
            _interesados = new List<Interesado>();
            _catalogo    = catalogo;
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
            _usuarios = new List<Usuario>
            {
                new Usuario { Id = 1, Nombre = "Carlos Méndez",   Email = "carlos@web.com"   },
                new Usuario { Id = 2, Nombre = "Laura Rodríguez", Email = "laura@movil.com"  },
                new Usuario { Id = 3, Nombre = "Tomás García",    Email = "tomas@sala.com"   }
            };

            cmbUnidad.DataSource    = null;
            cmbUnidad.DataSource    = _catalogo;
            cmbUnidad.DisplayMember = "Nombre";

            cmbOfertante.DataSource    = null;
            cmbOfertante.DataSource    = new List<Usuario>(_usuarios);
            cmbOfertante.DisplayMember = "Nombre";

            cmbUsuarioSuscribir.DataSource    = null;
            cmbUsuarioSuscribir.DataSource    = new List<Usuario>(_usuarios);
            cmbUsuarioSuscribir.DisplayMember = "Nombre";

            string[] canales = { "WEB", "MÓVIL", "PANTALLA SALA", "INTERFAZ GRÁFICA" };
            cmbCanal.DataSource = canales;
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

                _subastaActiva = _bll.CrearSubasta(unidad);
                _interesados.Clear();
                lstInteresados.Items.Clear();
                rtbNotificaciones.Clear();

                _segundosRestantes = DURACION_INICIAL;
                ActualizarLblTimer();
                _timer.Start();

                _bitacora.Registrar("INICIAR_SUBASTA",
                    $"Subasta iniciada: {unidad.Nombre} — Base: ${_subastaActiva.PrecioActual:N2}",
                    CriticidadEvento.Media);

                rtbNotificaciones.AppendText($"[{DateTime.Now:HH:mm:ss}] Subasta iniciada: {unidad.Nombre}  |  Precio base: ${_subastaActiva.PrecioActual:N2}  |  Tiempo: {DURACION_INICIAL / 60} min\r\n");
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
                string canal = cmbCanal.SelectedItem?.ToString();

                var interesado = new Interesado(usuario, canal);
                interesado.NotificacionRecibida += (destinatario, mensaje) =>
                    rtbNotificaciones.AppendText($"[{DateTime.Now:HH:mm:ss}] [{canal}] {destinatario}: {mensaje}\r\n");

                // OBSERVER: Sujeto registra al observador (RF-05)
                _bll.Suscribir(_subastaActiva, interesado);
                _interesados.Add(interesado);

                lstInteresados.Items.Add($"{usuario.Nombre}  [{canal}]");
                rtbNotificaciones.AppendText($"[{DateTime.Now:HH:mm:ss}] {usuario.Nombre} suscripto vía {canal}\r\n");
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
                var usuario = cmbUsuarioSuscribir.SelectedItem as Usuario;
                var interesado = _interesados.Find(i => i.Usuario.Id == usuario.Id);
                if (interesado == null)
                    throw new InvalidOperationException($"{usuario.Nombre} no está suscripto a esta subasta.");

                // OBSERVER: Sujeto elimina al observador (RF-08)
                _bll.Desuscribir(_subastaActiva, interesado);
                _interesados.Remove(interesado);

                for (int i = lstInteresados.Items.Count - 1; i >= 0; i--)
                    if (lstInteresados.Items[i].ToString().Contains(usuario.Nombre))
                    { lstInteresados.Items.RemoveAt(i); break; }

                rtbNotificaciones.AppendText($"[{DateTime.Now:HH:mm:ss}] {usuario.Nombre} desuscripto.\r\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────
        //  4. REALIZAR OFERTA (SINGLETON + OBSERVER + ANTI-SNIPING)
        // ─────────────────────────────────────────────
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
            int m = _segundosRestantes / 60;
            int s = _segundosRestantes % 60;
            lblTimer.Text = $"⏱  {m:00}:{s:00}";
            lblTimer.ForeColor = _segundosRestantes <= UMBRAL_ANTISNIPING
                ? Color.FromArgb(200, 60, 60)   // rojo urgente
                : Color.FromArgb(30, 140, 80);  // verde normal
        }

        private void AutoCerrarSubasta()
        {
            if (_subastaActiva == null || !_subastaActiva.EstaActiva) return;

            lblTimer.Text      = "⏱  00:00";
            lblTimer.ForeColor = Color.FromArgb(200, 60, 60);

            if (_subastaActiva.UltimoPujador == null)
            {
                // Sin ofertas: no se puede adjudicar, se cancela sin persistir
                _subastaActiva = null;
                rtbNotificaciones.AppendText(
                    $"\r\n[{DateTime.Now:HH:mm:ss}] ══ TIEMPO AGOTADO — sin ofertas, subasta cancelada sin adjudicación ══\r\n");
                ActualizarEstadoControles();
                return;
            }

            try
            {
                var resultado = _bll.CerrarSubasta(_subastaActiva);

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
