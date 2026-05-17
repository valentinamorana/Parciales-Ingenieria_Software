using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AlmonedaNacional.BE;
using AlmonedaNacional.BLL;
using AlmonedaNacional.Servicios;
using AlmonedaNacional.Servicios.Composite;

namespace AlmonedaNacional.GUI
{
    // Demuestra en un solo form los 3 patrones restantes:
    //   OBSERVER  : suscribir/desuscribir interesados, notificación automática al pujar
    //   STRATEGY  : cada interesado elige su canal (Web / Móvil / Pantalla Sala / GUI)
    //   SINGLETON : GestorDePujasSingleton procesa una puja a la vez (lock exclusivo)
    public partial class frmSubasta : Form
    {
        private SubastaBLL _bll;
        private SubastaActiva _subastaActiva;
        private List<Interesado> _interesados;
        private List<IUnidadDeVenta> _catalogo;
        private List<Usuario> _usuarios;

        public frmSubasta()
        {
            InitializeComponent();
            _bll        = new SubastaBLL();
            _interesados = new List<Interesado>();
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
            var taladro   = new ArticuloSimple { Id = 1, Nombre = "Taladro Industrial",  Descripcion = "Bosch 1500W",             PrecioBase = 15000m };
            var amoladora = new ArticuloSimple { Id = 2, Nombre = "Amoladora",           Descripcion = "Makita 9\"",               PrecioBase =  8000m };
            var loteHerr  = new LoteArticulos  { Id = 10, Nombre = "Lote Herramientas" };
            loteHerr.Agregar(taladro);
            loteHerr.Agregar(amoladora);
            var maquinaCNC = new ArticuloSimple { Id = 4, Nombre = "Máquina CNC", Descripcion = "3 ejes", PrecioBase = 250000m };

            _catalogo = new List<IUnidadDeVenta> { taladro, amoladora, loteHerr, maquinaCNC };
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

                rtbNotificaciones.AppendText($"[{DateTime.Now:HH:mm:ss}] Subasta iniciada: {unidad.Nombre}  |  Precio base: ${_subastaActiva.PrecioActual:N2}\r\n");
                ActualizarPanelSubasta();
                ActualizarEstadoControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────
        //  2. SUSCRIBIR INTERESADO (OBSERVER + STRATEGY)
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
                if (lstInteresados.SelectedIndex < 0)
                    throw new InvalidOperationException("Seleccione un interesado para desuscribir.");

                int idx = lstInteresados.SelectedIndex;
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
        //  4. REALIZAR OFERTA (SINGLETON + OBSERVER)
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
                // OBSERVER: al actualizarse el precio, Notificar() avisa a todos los suscriptores (RF-06)
                _bll.RealizarOferta(_subastaActiva, usuario, monto);

                txtMonto.Clear();
                ActualizarPanelSubasta();
            }
            catch (Exception ex)
            {
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
                var confirm = MessageBox.Show(
                    $"¿Cerrar la subasta de '{_subastaActiva.Unidad.Nombre}'?\n" +
                    $"Ganador: {_subastaActiva.UltimoPujador?.Nombre ?? "(sin ofertas)"}\n" +
                    $"Precio final: ${_subastaActiva.PrecioActual:N2}",
                    "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;

                // Cierra subasta → notifica a todos (RF-07) → persiste en BD
                var resultado = _bll.CerrarSubasta(_subastaActiva);

                lblPrecioActual.Text  = $"CERRADA — ${resultado.PrecioFinal:N2}";
                lblPrecioActual.ForeColor = Color.Red;

                rtbNotificaciones.AppendText($"\r\n[{DateTime.Now:HH:mm:ss}] ══ SUBASTA CERRADA ══\r\n");
                rtbNotificaciones.AppendText($"  Ganador: {resultado.NombreGanador}\r\n");
                rtbNotificaciones.AppendText($"  Precio final: ${resultado.PrecioFinal:N2}\r\n");
                rtbNotificaciones.AppendText($"  Persistido en BD: {resultado.FechaHora:dd/MM/yyyy HH:mm:ss}\r\n");

                ActualizarEstadoControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            grpInteresados.Enabled   = haySubasta;
            grpOferta.Enabled        = haySubasta;
            btnCerrarSubasta.Enabled = haySubasta;
            btnIniciarSubasta.Enabled = !haySubasta;
            cmbUnidad.Enabled        = !haySubasta;
        }
    }
}
