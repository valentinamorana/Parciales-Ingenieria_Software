using System;
using System.Collections.Generic;

// ============================================================
//  MEMENTO - Ejercicio 1: Editor de texto con "Deshacer"
//  Un editor escribe texto. Antes de cada cambio guarda un
//  checkpoint. Si el usuario se arrepiente, vuelve a una versión
//  anterior, sin exponer los campos internos del editor.
//    Originator = Editor   Memento = MementoTexto   Caretaker = HistorialEdicion
// ============================================================
namespace MementoEjercicios.Editor
{
    // ---------- Memento ----------
    public class MementoTexto
    {
        private readonly string _contenido;
        public MementoTexto(string contenido)
        {
            _contenido = contenido;
        }
        public string Contenido => _contenido; // sólo lectura
    }

    // ---------- Originator ----------
    public class Editor
    {
        private string _contenido = "";

        public void Escribir(string texto)
        {
            _contenido += texto;
        }

        public MementoTexto GuardarCheckpoint()
        {
            Console.WriteLine($"Guardando checkpoint: \"{_contenido}\"");
            return new MementoTexto(_contenido);
        }

        public void Restaurar(MementoTexto m)
        {
            _contenido = m.Contenido;
            Console.WriteLine($"Restaurado a: \"{_contenido}\"");
        }

        public void MostrarContenido()
        {
            Console.WriteLine($"Contenido actual: \"{_contenido}\"");
        }
    }

    // ---------- Caretaker ----------
    public class HistorialEdicion
    {
        private List<MementoTexto> _checkpoints = new List<MementoTexto>();

        public void Guardar(MementoTexto m) => _checkpoints.Add(m);
        public MementoTexto Recuperar(int i) => _checkpoints[i];
    }

    // ---------- Demo ----------
    public static class Demo
    {
        public static void Ejecutar()
        {
            Console.WriteLine("=== Memento - Ejercicio 1: Editor con Undo ===");

            Editor editor = new Editor();
            HistorialEdicion historial = new HistorialEdicion();

            editor.Escribir("Hola ");
            historial.Guardar(editor.GuardarCheckpoint());

            editor.Escribir("mundo");
            historial.Guardar(editor.GuardarCheckpoint());

            editor.Escribir(" BORRADOR");
            editor.MostrarContenido();                  // "Hola mundo BORRADOR"

            editor.Restaurar(historial.Recuperar(1));   // vuelve a "Hola mundo"
            editor.MostrarContenido();

            Console.WriteLine();
        }
    }
}
