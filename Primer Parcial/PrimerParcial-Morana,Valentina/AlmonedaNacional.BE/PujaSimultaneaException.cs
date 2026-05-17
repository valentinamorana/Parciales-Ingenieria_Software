using System;

namespace AlmonedaNacional.BE
{
    // Se lanza cuando el GestorDePujasSingleton no puede adquirir el lock
    // porque otra puja está siendo procesada en ese momento.
    public class PujaSimultaneaException : Exception
    {
        public PujaSimultaneaException()
            : base("El sistema está procesando otra oferta. Reintentá en unos instantes.") { }
    }
}
