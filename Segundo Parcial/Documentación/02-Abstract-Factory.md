# Patrón Abstract Factory (Fábrica Abstracta)

## ¿Qué resuelve?
Permite crear **familias de objetos relacionados** sin acoplar el código a sus clases concretas.
Cada fábrica concreta produce un conjunto de productos que **combinan bien entre sí**.

> **Idea clave:** "Varias familias, cada una con VARIOS productos que deben ser coherentes."
> Lo reconocés cuando una fábrica tiene **dos o más métodos `CrearX()`** y cada fábrica concreta los implementa juntos.

## Estructura del patrón

| Rol | Ejemplo de la cátedra (Pizzería) |
|-----|----------------------------------|
| **AbstractFactory** | `Pizzeria` con `CrearPizza()` + `CrearEmpanada()` |
| **ConcreteFactory** | `PizzeriaArgentina`, `PizzeriaItaliana`, `PizzeriaChina` |
| **AbstractProductA / B** | `Pizza`, `Empanada` |
| **ConcreteProduct** | `PizzaCancha`+`EmpanadaDeCarne`, etc. |

## Diagrama de clases (genérico)

```mermaid
classDiagram
    class FabricaAbstracta {
        <<abstract>>
        +CrearProductoA()* ProductoA
        +CrearProductoB()* ProductoB
    }
    class Fabrica1 {
        +CrearProductoA() ProductoA
        +CrearProductoB() ProductoB
    }
    class Fabrica2 {
        +CrearProductoA() ProductoA
        +CrearProductoB() ProductoB
    }
    class ProductoA { <<abstract>> }
    class ProductoB { <<abstract>> }
    class A1
    class A2
    class B1
    class B2

    FabricaAbstracta <|-- Fabrica1
    FabricaAbstracta <|-- Fabrica2
    ProductoA <|-- A1
    ProductoA <|-- A2
    ProductoB <|-- B1
    ProductoB <|-- B2
    Fabrica1 ..> A1
    Fabrica1 ..> B1
    Fabrica2 ..> A2
    Fabrica2 ..> B2
```

---

## Ejercicio 1 — Facciones de un videojuego

> Un juego de estrategia tiene distintas facciones (Humanos u Orcos). Cada facción produce su propio `Soldado` y su propio `Vehiculo`. No se pueden mezclar (un soldado humano con un vehículo orco sería incoherente).

### Diagrama

```mermaid
classDiagram
    class FabricaFaccion {
        <<abstract>>
        +CrearSoldado()* Soldado
        +CrearVehiculo()* Vehiculo
    }
    class FabricaHumanos
    class FabricaOrcos
    class Soldado { <<abstract>> }
    class Vehiculo { <<abstract>> }
    class SoldadoHumano
    class SoldadoOrco
    class VehiculoHumano
    class VehiculoOrco

    FabricaFaccion <|-- FabricaHumanos
    FabricaFaccion <|-- FabricaOrcos
    Soldado <|-- SoldadoHumano
    Soldado <|-- SoldadoOrco
    Vehiculo <|-- VehiculoHumano
    Vehiculo <|-- VehiculoOrco
```

### Código

```csharp
// ---------- Productos abstractos ----------
public abstract class Soldado
{
    public abstract string Atacar();
}
public abstract class Vehiculo
{
    public abstract string Mover();
}

// ---------- Productos concretos: familia Humanos ----------
public class SoldadoHumano : Soldado
{
    public override string Atacar() => "Soldado humano dispara su rifle.";
}
public class VehiculoHumano : Vehiculo
{
    public override string Mover() => "Tanque humano avanza sobre sus orugas.";
}

// ---------- Productos concretos: familia Orcos ----------
public class SoldadoOrco : Soldado
{
    public override string Atacar() => "Soldado orco ataca con su hacha.";
}
public class VehiculoOrco : Vehiculo
{
    public override string Mover() => "Catapulta orca rueda hacia el enemigo.";
}

// ---------- Fábrica abstracta ----------
public abstract class FabricaFaccion
{
    public abstract Soldado CrearSoldado();
    public abstract Vehiculo CrearVehiculo();
}

// ---------- Fábricas concretas ----------
public class FabricaHumanos : FabricaFaccion
{
    public override Soldado CrearSoldado() => new SoldadoHumano();
    public override Vehiculo CrearVehiculo() => new VehiculoHumano();
}
public class FabricaOrcos : FabricaFaccion
{
    public override Soldado CrearSoldado() => new SoldadoOrco();
    public override Vehiculo CrearVehiculo() => new VehiculoOrco();
}

// ---------- Cliente ----------
class Program
{
    static void Main()
    {
        FabricaFaccion fabrica = new FabricaHumanos();
        Console.WriteLine(fabrica.CrearSoldado().Atacar());
        Console.WriteLine(fabrica.CrearVehiculo().Mover());

        fabrica = new FabricaOrcos();
        Console.WriteLine(fabrica.CrearSoldado().Atacar());
        Console.WriteLine(fabrica.CrearVehiculo().Mover());
    }
}
```

---

## Ejercicio 2 — Mobiliario por estilo

> Una tienda arma juegos de muebles. Según el estilo (Moderno o Clásico) entrega una `Silla` y una `Mesa` que combinan entre sí.

### Diagrama

```mermaid
classDiagram
    class FabricaMuebles {
        <<abstract>>
        +CrearSilla()* Silla
        +CrearMesa()* Mesa
    }
    class FabricaModerna
    class FabricaClasica
    class Silla { <<abstract>> }
    class Mesa { <<abstract>> }
    class SillaModerna
    class SillaClasica
    class MesaModerna
    class MesaClasica

    FabricaMuebles <|-- FabricaModerna
    FabricaMuebles <|-- FabricaClasica
    Silla <|-- SillaModerna
    Silla <|-- SillaClasica
    Mesa <|-- MesaModerna
    Mesa <|-- MesaClasica
```

### Código

```csharp
public abstract class Silla { public abstract string Describir(); }
public abstract class Mesa  { public abstract string Describir(); }

public class SillaModerna : Silla { public override string Describir() => "Silla minimalista de metal"; }
public class MesaModerna  : Mesa  { public override string Describir() => "Mesa de vidrio templado"; }

public class SillaClasica : Silla { public override string Describir() => "Silla de madera tallada"; }
public class MesaClasica  : Mesa  { public override string Describir() => "Mesa de roble macizo"; }

public abstract class FabricaMuebles
{
    public abstract Silla CrearSilla();
    public abstract Mesa CrearMesa();
}

public class FabricaModerna : FabricaMuebles
{
    public override Silla CrearSilla() => new SillaModerna();
    public override Mesa CrearMesa() => new MesaModerna();
}

public class FabricaClasica : FabricaMuebles
{
    public override Silla CrearSilla() => new SillaClasica();
    public override Mesa CrearMesa() => new MesaClasica();
}

class Program
{
    static void Main()
    {
        FabricaMuebles fabrica = new FabricaModerna();
        Console.WriteLine(fabrica.CrearSilla().Describir());
        Console.WriteLine(fabrica.CrearMesa().Describir());

        fabrica = new FabricaClasica();
        Console.WriteLine(fabrica.CrearSilla().Describir());
        Console.WriteLine(fabrica.CrearMesa().Describir());
    }
}
```

---

## Cómo lo reconocés en un parcial
- Piden crear **un conjunto de productos que deben combinar** (familia coherente).
- La fábrica tiene **2+ métodos `CrearX()`**.
- Frase clave: *"familias de objetos relacionados", "que sean compatibles entre sí"*.
- ⚠️ **Factory Method = 1 producto. Abstract Factory = familia de productos (varios `CrearX`).**
```
