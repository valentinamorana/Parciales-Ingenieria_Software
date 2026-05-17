using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    // PATRON SINGLETON — Punto de acceso único a la base de datos.
    // Thread-safe con double-checked locking.
    // Centraliza Leer / Escribir / EjecutarEscalar / EjecutarTransaccion
    // para que ningún DAL gestione conexiones directamente.
    public sealed class Acceso
    {
        private static volatile Acceso _instancia;
        private static readonly object _lockCreacion = new object();

        private readonly string _cadenaConexion;

        private Acceso()
        {
            _cadenaConexion = ConfigurationManager
                .ConnectionStrings["AlmonedaNacionalDB"]
                .ConnectionString;
        }

        public static Acceso Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    lock (_lockCreacion)
                    {
                        if (_instancia == null)
                            _instancia = new Acceso();
                    }
                }
                return _instancia;
            }
        }

        // SELECT — devuelve DataTable
        public DataTable Leer(string sql, SqlParameter[] parametros = null)
        {
            using (var conn = new SqlConnection(_cadenaConexion))
            using (var cmd  = new SqlCommand(sql, conn))
            {
                if (parametros != null) cmd.Parameters.AddRange(parametros);
                conn.Open();
                var tabla = new DataTable();
                using (var adapter = new SqlDataAdapter(cmd))
                    adapter.Fill(tabla);
                return tabla;
            }
        }

        // INSERT / UPDATE / DELETE — devuelve filas afectadas
        public int Escribir(string sql, SqlParameter[] parametros = null)
        {
            using (var conn = new SqlConnection(_cadenaConexion))
            using (var cmd  = new SqlCommand(sql, conn))
            {
                if (parametros != null) cmd.Parameters.AddRange(parametros);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // INSERT con SELECT SCOPE_IDENTITY() — devuelve el nuevo Id
        public int EjecutarEscalar(string sql, SqlParameter[] parametros = null)
        {
            using (var conn = new SqlConnection(_cadenaConexion))
            using (var cmd  = new SqlCommand(sql, conn))
            {
                if (parametros != null) cmd.Parameters.AddRange(parametros);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Bloque transaccional atómico — útil para cerrar subasta + insertar pujas
        public void EjecutarTransaccion(Action<SqlConnection, SqlTransaction> accion)
        {
            using (var conn = new SqlConnection(_cadenaConexion))
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try   { accion(conn, tx); tx.Commit(); }
                    catch { tx.Rollback(); throw; }
                }
            }
        }
    }
}
