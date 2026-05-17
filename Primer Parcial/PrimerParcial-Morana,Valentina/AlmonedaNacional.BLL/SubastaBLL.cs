using System;
using System.Collections.Generic;
using AlmonedaNacional.BE;
using AlmonedaNacional.DAL;
using AlmonedaNacional.Servicios;
using AlmonedaNacional.Servicios.Composite;
using AlmonedaNacional.Servicios.Observer;

namespace AlmonedaNacional.BLL
{
    // Extiende AbstractBLL<ResultadoSubasta> para la parte de persistencia,
    // igual al patrón del ejemplo. Agrega métodos de dominio específicos de la subasta.
    public class SubastaBLL : AbstractBLL<ResultadoSubasta>
    {
        public SubastaBLL()
        {
            _crud = new SubastaDAL();
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
            subasta.RealizarOferta(usuario, monto);
        }

        public ResultadoSubasta CerrarSubasta(SubastaActiva subasta)
        {
            if (subasta == null) throw new ArgumentNullException(nameof(subasta));
            var resultado = subasta.Cerrar();
            _crud.Guardar(resultado);
            return resultado;
        }

        public IList<ResultadoSubasta> ObtenerHistorial()
        {
            return _crud.ObtenerTodos();
        }
    }
}
