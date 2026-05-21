using System;
using System.Collections.Generic;
using BE;
using DAL;
using Servicios;
using Servicios.Composite;

namespace BLL
{
    public class SubastaBLL : AbstractBLL<ResultadoSubasta>
    {
        // Referencia tipada para poder llamar GuardarEnTransaccion sin cast.
        // _crud = _subastaDAL para que AbstractBLL delegue CRUD normalmente.
        private readonly SubastaDAL _subastaDAL;
        private readonly PujaDAL    _pujaDAL;

        public SubastaBLL()
        {
            _subastaDAL = new SubastaDAL();
            _crud       = _subastaDAL;
            _pujaDAL    = new PujaDAL();
        }

        public SubastaActiva CrearSubasta(IUnidadDeVenta unidad)
        {
            if (unidad == null) throw new ArgumentNullException(nameof(unidad));
            return new SubastaActiva(unidad);
        }

        public void Suscribir(SubastaActiva subasta, IObservadorSubasta observador)
        {
            if (subasta == null) throw new ArgumentNullException(nameof(subasta));
            subasta.Suscribir(observador);
        }

        public void Desuscribir(SubastaActiva subasta, IObservadorSubasta observador)
        {
            if (subasta == null) throw new ArgumentNullException(nameof(subasta));
            subasta.Desuscribir(observador);
        }

        public void RealizarOferta(SubastaActiva subasta, Usuario usuario, decimal monto)
        {
            if (subasta == null) throw new ArgumentNullException(nameof(subasta));
            // SubastaActiva.RealizarOferta registra internamente la puja (Aceptada o Rechazada)
            // y lanza excepción si es rechazada para que el formulario informe al usuario.
            subasta.RealizarOferta(usuario, monto);
        }

        // RF-07: cierra subasta, persiste ResultadoSubasta y todas las Pujas en una transacción atómica.
        public ResultadoSubasta CerrarSubasta(SubastaActiva subasta)
        {
            if (subasta == null) throw new ArgumentNullException(nameof(subasta));

            var resultado = subasta.Cerrar();

            // Transacción atómica: subasta + todas sus pujas en la misma conexión/tx.
            Acceso.GetInstance().EjecutarTransaccion((conn, tx) =>
            {
                // 1. Persistir resultado final → obtener su Id
                _subastaDAL.GuardarEnTransaccion(resultado, conn, tx);

                // 2. Persistir cada puja con el Id de subasta recién creado
                foreach (var puja in subasta.Pujas)
                {
                    puja.IdSubasta = resultado.Id;
                    _pujaDAL.GuardarEnTransaccion(puja, conn, tx);
                }
            });

            return resultado;
        }

        public IList<ResultadoSubasta> ObtenerHistorial()
            => _crud.ObtenerTodos();

        // Pujas de una subasta ya cerrada (para un eventual reporte de detalle)
        public IList<Puja> ObtenerPujas(int idSubasta)
            => _pujaDAL.ObtenerPorSubasta(idSubasta);
    }
}
