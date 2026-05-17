using System;

namespace BE
{
    // Se lanza cuando una oferta no cumple las reglas de negocio:
    // monto insuficiente, ofertante ya es el ganador actual, etc.
    public class OfertaInvalidaException : Exception
    {
        public OfertaInvalidaException(string mensaje) : base(mensaje) { }
    }
}
