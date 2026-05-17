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
            DateTime? desde = diasAtras > 0 ? DateTime.Now.AddDays(-diasAtras) : (DateTime?)null;
            return _dal.ObtenerFiltrado(desde, criticidad, operacion);
        }
    }
}
