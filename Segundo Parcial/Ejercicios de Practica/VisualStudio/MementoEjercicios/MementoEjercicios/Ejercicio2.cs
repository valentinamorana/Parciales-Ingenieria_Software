using System;
using System.Collections.Generic;

// ============================================================
//  MEMENTO - Ejercicio 2: Checkpoints de un videojuego
//  El personaje tiene vida y nivel. Antes de una pelea difícil
//  se guarda el progreso. Si el jugador pierde, se carga el
//  último checkpoint.
//    Originator = Personaje  Memento = MementoJuego  Caretaker = GestorPartidas
// ============================================================
namespace MementoEjercicios.Juego
{
    // ---------- Memento ----------
    public class MementoJuego
    {
        public int Vida { get; }
        public int Nivel { get; }
        public MementoJuego(int vida, int nivel)
        {
            Vida = vida;
            Nivel = nivel;
        }
    }

    // ---------- Originator ----------
    public class Personaje
    {
        private int _vida = 100;
        private int _nivel = 1;

        public void Jugar(int dañoVida, int subeNivel)
        {
            _vida -= dañoVida;
            _nivel += subeNivel;
            Console.WriteLine($"Jugando... Vida={_vida}, Nivel={_nivel}");
        }

        public MementoJuego Guardar()
        {
            Console.WriteLine("Checkpoint guardado.");
            return new MementoJuego(_vida, _nivel);
        }

        public void Cargar(MementoJuego m)
        {
            _vida = m.Vida;
            _nivel = m.Nivel;
            Console.WriteLine($"Partida cargada -> Vida={_vida}, Nivel={_nivel}");
        }
    }

    // ---------- Caretaker ----------
    public class GestorPartidas
    {
        private List<MementoJuego> _guardados = new List<MementoJuego>();
        public void Guardar(MementoJuego m) => _guardados.Add(m);
        public MementoJuego UltimoGuardado() => _guardados[_guardados.Count - 1];
    }

    // ---------- Demo ----------
    public static class Demo
    {
        public static void Ejecutar()
        {
            Console.WriteLine("=== Memento - Ejercicio 2: Checkpoints de juego ===");

            Personaje heroe = new Personaje();
            GestorPartidas gestor = new GestorPartidas();

            heroe.Jugar(20, 1);                     // Vida=80, Nivel=2
            gestor.Guardar(heroe.Guardar());        // checkpoint

            heroe.Jugar(90, 0);                     // Vida=-10 (murió)
            heroe.Cargar(gestor.UltimoGuardado());  // vuelve a Vida=80, Nivel=2

            Console.WriteLine();
        }
    }
}
