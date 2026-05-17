using System;
using System.Collections.Generic;
using AlmonedaNacional.BE;
using AlmonedaNacional.DAL;
using AlmonedaNacional.Servicios;
using AlmonedaNacional.Servicios.Composite;
using AlmonedaNacional.Servicios.Observer;

namespace AlmonedaNacional.BLL
{
    public class SubastaBLL : AbstractBLL<ResultadoSubasta>
    {
        private readonly PujaDAL _pujaDAL;

        public SubastaBLL()
        {
            _crud    = new SubastaDAL();
            _pujaDAL = new PujaDAL();
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

            // Usamos la transacción de Acceso Singleton: primero el resultado, luego las pujas.
            Acceso.Instancia.EjecutarTransaccion((conn, tx) =>
            {
                // 1. Persistir resultado final → obtener su Id
                var subastaDAL = (SubastaDAL)_crud;
                subastaDAL.Guardar(resultado);          // asigna resultado.Id

                // 2. Persistir cada puja con el Id de subasta recién creado
                foreach (var puja in subasta.Pujas)
                {
                    puja.IdSubasta = resultado.Id;
                    _pujaDAL.Guardar(puja);
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
