namespace DAL
{
    public static class Conexion
    {
        // Ajustar según instancia SQL Server local
        public static string ConnectionString =>
            @"Server=.\SQLEXPRESS;Database=AlmonedaNacional;Integrated Security=True;";
    }
}
