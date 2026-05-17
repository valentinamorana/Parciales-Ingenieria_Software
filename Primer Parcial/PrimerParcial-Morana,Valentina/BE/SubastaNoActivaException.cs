using System;

namespace BE
{
    // Se lanza al intentar operar sobre una subasta que ya fue cerrada.
    public class SubastaNoActivaException : Exception
    {
        public SubastaNoActivaException() : base("No hay ninguna subasta activa en este momento.") { }
        public SubastaNoActivaException(string mensaje) : base(mensaje) { }
    }
}
