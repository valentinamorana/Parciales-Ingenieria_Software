using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using BE;

namespace DAL
{
    public class BitacoraDAL : AbstractDAL<EventoBitacora>
    {
        public override void Guardar(EventoBitacora e)
        {
            _acceso.Escribir(
                @"INSERT INTO Bitacora (Fecha, Operacion, Detalle, Criticidad, NombreMartillero)
                  VALUES (@f, @op, @det, @crit, @nm)",
                new SqlParameter[]
                {
                    new SqlParameter("@f",    e.Fecha),
                    new SqlParameter("@op",   e.Operacion),
                    new SqlParameter("@det",  e.Detalle),
                    new SqlParameter("@crit", e.Criticidad.ToString()),
                    new SqlParameter("@nm",   e.NombreMartillero)
                });
        }

        public IList<EventoBitacora> ObtenerFiltrado(DateTime? desde, string criticidad, string operacion)
        {
            var sb = new StringBuilder(
                "SELECT Id, Fecha, Operacion, Detalle, Criticidad, NombreMartillero FROM Bitacora WHERE 1=1");
            var p = new List<SqlParameter>();

            if (desde.HasValue)
            {
                sb.Append(" AND Fecha >= @desde");
                p.Add(new SqlParameter("@desde", desde.Value));
            }
            if (!string.IsNullOrWhiteSpace(criticidad) && criticidad != "Todas")
            {
                sb.Append(" AND Criticidad = @crit");
                p.Add(new SqlParameter("@crit", criticidad));
            }
            if (!string.IsNullOrWhiteSpace(operacion) && operacion != "Todas")
            {
                sb.Append(" AND Operacion LIKE @op");
                p.Add(new SqlParameter("@op", $"%{operacion}%"));
            }
            sb.Append(" ORDER BY Fecha DESC");

            var tabla = _acceso.Leer(sb.ToString(), p.Count > 0 ? p.ToArray() : null);
            var lista = new List<EventoBitacora>();
            foreach (System.Data.DataRow fila in tabla.Rows)
                lista.Add(MapearFila(fila));
            return lista;
        }

        public override IList<EventoBitacora> ObtenerTodos()
        {
            var tabla = _acceso.Leer(
                "SELECT Id, Fecha, Operacion, Detalle, Criticidad, NombreMartillero FROM Bitacora ORDER BY Fecha DESC");
            var lista = new List<EventoBitacora>();
            foreach (System.Data.DataRow f in tabla.Rows)
                lista.Add(MapearFila(f));
            return lista;
        }

        public override EventoBitacora ObtenerPorId(int id)
        {
            var tabla = _acceso.Leer(
                "SELECT Id, Fecha, Operacion, Detalle, Criticidad, NombreMartillero FROM Bitacora WHERE Id=@id",
                new[] { new SqlParameter("@id", id) });
            return tabla.Rows.Count == 0 ? null : MapearFila(tabla.Rows[0]);
        }

        public override void Eliminar(EventoBitacora e)
            => _acceso.Escribir("DELETE FROM Bitacora WHERE Id=@id",
                new[] { new SqlParameter("@id", e.Id) });

        private static EventoBitacora MapearFila(System.Data.DataRow f) => new EventoBitacora
        {
            Id               = (int)f["Id"],
            Fecha            = (DateTime)f["Fecha"],
            Operacion        = (string)f["Operacion"],
            Detalle          = (string)f["Detalle"],
            Criticidad       = (CriticidadEvento)Enum.Parse(typeof(CriticidadEvento), (string)f["Criticidad"]),
            NombreMartillero = (string)f["NombreMartillero"]
        };
    }
}
