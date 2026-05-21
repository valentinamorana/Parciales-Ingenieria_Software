namespace Servicios
{
    // ═══════════════════════════════════════════════════════════
    //  PATRÓN OBSERVER — Rol: Subject (Sujeto) — interfaz
    // ═══════════════════════════════════════════════════════════
    // Define el contrato que debe cumplir cualquier sujeto observable.
    // En el sistema el único sujeto concreto es SubastaActiva.
    //
    // Separar la interfaz de la implementación permite que la GUI
    // y el BLL dependan de ISujetoSubasta (abstracción) y no de
    // SubastaActiva directamente — principio DIP.
    //
    // Ciclo de vida Observer:
    //   1. GUI llama Suscribir(interesado) para registrar un observador (RF-05).
    //   2. SubastaActiva llama Notificar() cada vez que hay una puja aceptada (RF-06)
    //      y al cerrar la subasta (RF-07).
    //   3. GUI o BLL llama Desuscribir(interesado) para quitar el observador (RF-08).
    public interface ISujetoSubasta
    {
        void Suscribir(IObservadorSubasta observador);    // RF-05: registrar un interesado
        void Desuscribir(IObservadorSubasta observador);  // RF-08: dar de baja un interesado
        void Notificar();                                  // RF-06/RF-07: avisar a todos los observadores
    }
}
