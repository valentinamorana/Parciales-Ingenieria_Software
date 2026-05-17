using System;
using System.Collections.Generic;
using AlmonedaNacional.BE;
using AlmonedaNacional.DAL;
using AlmonedaNacional.Servicios.Seguridad;

namespace AlmonedaNacional.BLL
{
    public class BitacoraBLL
    {
        private readonly BitacoraDAL _dal = new BitacoraDAL();

        // Registra un evento — nunca interrumpe el flujo principal si falla la BD
        public void Registrar(string operacion, string detalle, CriticidadEvento criticidad)
        {
            try
            {
                _dal.Guardar(new EventoBitacora
                {
                    Fecha            = DateTime.Now,
                    Operacion        = operacion,
                    Detalle          = detalle,
                    Criticidad       = criticidad,
                    NombreMartillero = SessionManager.IsLoggedIn
                                       ? SessionManager.Instancia.Martillero.Username
                                       : "Sistema"
                });
            }
            catch { /* silencioso — bitácora no puede romper el flujo */ }
        }

        public IList<EventoBitacora> ObtenerFiltrado(int diasAtras, string criticidad, string operacion)
        {
            try
            {
                DateTime? desde = diasAtras > 0 ? DateTime.Now.AddDays(-diasAtras) : (DateTime?)null;
                return _dal.ObtenerFiltrado(desde, criticidad, operacion);
            }
            catch
            {
                return ObtenerDemo();
            }
        }

        public IList<EventoBitacora> ObtenerDemo() => new List<EventoBitacora>
        {
            new EventoBitacora { Id=1, Fecha=DateTime.Now.AddMinutes(-40), Operacion="LOGIN",           Detalle="Ingreso al sistema",                               Criticidad=CriticidadEvento.Baja,  NombreMartillero="martillero" },
            new EventoBitacora { Id=2, Fecha=DateTime.Now.AddMinutes(-35), Operacion="INICIAR_SUBASTA", Detalle="Subasta iniciada: Taladro Industrial ($15.000)",   Criticidad=CriticidadEvento.Media, NombreMartillero="martillero" },
            new EventoBitacora { Id=3, Fecha=DateTime.Now.AddMinutes(-28), Operacion="OFERTA_ACEPTADA", Detalle="Oferta $16.000 de Carlos Méndez aceptada",         Criticidad=CriticidadEvento.Baja,  NombreMartillero="martillero" },
            new EventoBitacora { Id=4, Fecha=DateTime.Now.AddMinutes(-22), Operacion="OFERTA_RECHAZADA",Detalle="Oferta $15.500 de Laura Rodríguez rechazada",      Criticidad=CriticidadEvento.Baja,  NombreMartillero="martillero" },
            new EventoBitacora { Id=5, Fecha=DateTime.Now.AddMinutes(-15), Operacion="OFERTA_ACEPTADA", Detalle="Oferta $21.500 de Carlos Méndez aceptada",         Criticidad=CriticidadEvento.Baja,  NombreMartillero="martillero" },
            new EventoBitacora { Id=6, Fecha=DateTime.Now.AddMinutes(-10), Operacion="CERRAR_SUBASTA",  Detalle="Subasta cerrada. Ganador: Carlos Méndez ($21.500)",Criticidad=CriticidadEvento.Alta,  NombreMartillero="martillero" },
            new EventoBitacora { Id=7, Fecha=DateTime.Now.AddMinutes(-5),  Operacion="LOGIN_FALLIDO",   Detalle="Intento de login fallido — usuario: desconocido",  Criticidad=CriticidadEvento.Alta,  NombreMartillero="Sistema" },
        };
    }
}
