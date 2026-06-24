# Guía de estudio — Patrones de Diseño (Segundo Parcial)

Material de práctica con ejemplos resueltos y diagramas de clase para cada patrón.
Los diagramas están en **Mermaid**: se ven renderizados en GitHub, en VS Code (extensión *Markdown Preview Mermaid Support*) o en https://mermaid.live

## Índice
1. [Factory Method](01-Factory-Method.md) — crear **1 producto**, las subclases deciden cuál.
2. [Abstract Factory](02-Abstract-Factory.md) — crear **familias** de productos relacionados.
3. [Adapter](03-Adapter.md) — hacer **compatibles dos interfaces** distintas.
4. [Decorator](04-Decorator.md) — **agregar funcionalidad** en capas, sin subclases.
5. [Memento](05-Memento.md) — **guardar y restaurar** estado (undo / checkpoint).

---

## Clasificación de los patrones

| Patrón | Tipo (GoF) | Propósito en una frase |
|--------|-----------|------------------------|
| Factory Method | **Creacional** | Delegar a subclases QUÉ objeto crear |
| Abstract Factory | **Creacional** | Crear familias de objetos coherentes |
| Adapter | **Estructural** | Traducir una interfaz a otra |
| Decorator | **Estructural** | Sumar responsabilidades dinámicamente |
| Memento | **De comportamiento** | Capturar/restaurar estado sin romper encapsulamiento |

---

## Tabla comparativa rápida

| Patrón | Pista en el enunciado | Pieza clave | Relación principal |
|--------|----------------------|-------------|--------------------|
| **Factory Method** | "según el tipo, crea..." (UN producto) | 1 método abstracto `CrearX()` | Herencia (subclases) |
| **Abstract Factory** | "familia de productos que combinan" | Fábrica con VARIOS `CrearX()` | Herencia + composición |
| **Adapter** | "integrar / hacer compatible una clase existente" | Adapter implementa Target y envuelve Adaptee | Composición (tiene-un) |
| **Decorator** | "agregar adicionales/capas combinables" | Decorador ES-un y TIENE-un componente | Herencia + composición |
| **Memento** | "deshacer / guardar / restaurar estado" | Originator, Memento, Caretaker | Composición |

---

## Errores típicos que se confunden en el parcial

- **Factory Method vs Abstract Factory:**
  ¿Cuántos productos crea la fábrica? **Uno → Factory Method. Varios relacionados → Abstract Factory.**

- **Adapter vs Decorator:**
  Ambos envuelven a otro objeto, pero:
  - Adapter **cambia la interfaz** (la hace compatible). No agrega comportamiento nuevo, traduce.
  - Decorator **mantiene la interfaz** y **agrega** comportamiento. Se pueden apilar varios.

- **Decorator vs herencia simple:**
  Si necesitás **combinaciones dinámicas** (queso+jamón, jamón+aceitunas, las 3...) usás Decorator para no crear una subclase por cada combinación.

- **Memento — el encapsulamiento:**
  El **Caretaker NO debe leer el contenido** del Memento; sólo lo guarda y lo devuelve. El único que entiende el estado es el Originator.

---

## Plantilla mental para resolver "¿qué patrón uso?"

```
¿El problema es CREAR objetos?
   ├─ Sí, y es UN tipo de producto con variantes ........... Factory Method
   └─ Sí, y son VARIOS productos que deben combinar ........ Abstract Factory

¿El problema es ADAPTAR/EXTENDER un objeto existente?
   ├─ Necesito que dos interfaces incompatibles funcionen .. Adapter
   └─ Necesito sumarle funciones en capas combinables ...... Decorator

¿El problema es GUARDAR/RESTAURAR el estado de un objeto? .. Memento
```
