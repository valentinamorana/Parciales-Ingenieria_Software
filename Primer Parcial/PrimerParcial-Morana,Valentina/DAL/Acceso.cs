using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    // ═══════════════════════════════════════════════════════════
    //  PATRÓN SINGLETON — Acceso (capa de base de datos)
    // ═══════════════════════════════════════════════════════════
    // Punto de acceso único a SQL Server. Al ser Singleton:
    //   - La cadena de conexión se lee de App.config una sola vez.
    //   - Todos los DAL concretos obtienen la misma instancia vía GetInstance()
    //     (ver AbstractDAL<T>._acceso) sin crear conexiones propias.
    //
    // No mantiene una conexión abierta de forma permanente: cada método
    // abre y cierra su SqlConnection dentro de un using, lo que sigue el
    // patrón "open late / close early" y evita conexiones colgadas.
    //
    // Métodos disponibles:
    //   Leer                       → SELECT, devuelve DataTable
    //   Escribir                   → INSERT / UPDATE / DELETE, devuelve filas afectadas
    //   EjecutarEscalar            → INSERT + SCOPE_IDENTITY(), devuelve nuevo Id
    //   EjecutarEscalarEnTransaccion → INSERT dentro de una tx existente
    //   EjecutarTransaccion        → bloque atómico con commit/rollback automático
    //
    // Thread-safe con double-checked locking (mismo mecanismo que SessionManager).
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

        public static Acceso GetInstance()
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
                var resultado = cmd.ExecuteScalar();
                if (resultado == null || resultado == DBNull.Value)
                    throw new InvalidOperationException("EjecutarEscalar no devolvió un Id. Verificar la query.");
                return Convert.ToInt32(resultado);
            }
        }

        // INSERT dentro de una transacción existente — no abre conexión propia
        public int EjecutarEscalarEnTransaccion(string sql, SqlParameter[] parametros,
                                                SqlConnection conn, SqlTransaction tx)
        {
            using (var cmd = new SqlCommand(sql, conn, tx))
            {
                if (parametros != null) cmd.Parameters.AddRange(parametros);
                var resultado = cmd.ExecuteScalar();
                if (resultado == null || resultado == DBNull.Value)
                    throw new InvalidOperationException("EjecutarEscalarEnTransaccion no devolvió un Id.");
                return Convert.ToInt32(resultado);
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
