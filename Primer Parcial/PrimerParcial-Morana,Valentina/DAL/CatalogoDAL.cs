using System.Data;

namespace DAL
{
    // Retorna DataTables crudas — la construcción del árbol Composite
    // la hace CatalogoBLL (que tiene referencia a Servicios).
    public class CatalogoDAL
    {
        private readonly Acceso _acceso = Acceso.Instancia;

        public DataTable ObtenerUnidades() =>
            _acceso.Leer(
                "SELECT Id, Nombre, Descripcion, PrecioBase, TipoUnidad, FechaIngreso FROM UnidadesDeVenta");

        public DataTable ObtenerRelaciones() =>
            _acceso.Leer("SELECT LoteId, ContenidoId FROM LoteContenido");
    }
}
