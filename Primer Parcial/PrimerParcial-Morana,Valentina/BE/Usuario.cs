namespace BE
{
    public class Usuario : Entidad
    {
        public string Nombre { get; set; }
        public string Email { get; set; }

        public override string ToString() => $"{Nombre} ({Email})";
    }
}
