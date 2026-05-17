# La Almoneda Nacional
**1er Parcial — Ingeniería de Software — UAI 2026**  
**Morana, Valentina**

Sistema de escritorio para gestión de subastas de bienes, desarrollado en C# WinForms con arquitectura en 7 capas y tres patrones de diseño GoF.

---

## Patrones de diseño implementados

| Patrón | Clases principales | RF |
|---|---|---|
| **Composite** | `IUnidadDeVenta`, `UnidadDeVentaBase`, `ArticuloSimple`, `LoteArticulos` | RF-01 a RF-04 |
| **Observer** | `ISujetoSubasta`, `IObservadorSubasta`, `SubastaActiva`, `Interesado` | RF-05 a RF-08 |
| **Singleton** | `GestorDePujasSingleton` (pujas), `SessionManager` (sesión), `Acceso` (BD) | RF-09 |

---

## Arquitectura

```
GUI → BLL → DAL
          → Servicios (patrones)
          → Seguridad (auth)
          → BE (entidades)
          → Interfaces (ICrud, IEntidad)
```

7 proyectos con dependencias unidireccionales. La GUI nunca toca la BD directamente.

---

## Requisitos

- .NET Framework 4.7.2
- SQL Server Express (`.\SQLEXPRESS`)
- Visual Studio 2022 o `dotnet build`

## Configuración

1. Ejecutar `AlmonedaNacional.sql` contra `.\SQLEXPRESS` (idempotente, se puede re-ejecutar).
2. Verificar `App.config` en el proyecto GUI: cadena `AlmonedaNacionalDB`.
3. Compilar y ejecutar `GUI.exe`.

**Credenciales por defecto:** `martillero` / `Admin1234`

---

## Funcionalidades

- **Login** con bloqueo automático (3 intentos → 10 minutos bloqueado)
- **Catálogo** Composite: artículos simples y lotes anidados sin límite de profundidad
- **Subasta** con temporizador, suscripción de interesados (Observer) y exclusión mutua (Singleton)
- **Anti-Sniping**: extensión automática del tiempo si se puja en los últimos 30 segundos
- **Historial** de subastas cerradas con detalle de cada puja (aceptadas y rechazadas)
- **Bitácora** de auditoría con filtros por criticidad, operación y rango de fechas
- **Reporte de jornada** con recorrido recursivo del Composite, exportable a TXT y PDF

---

## Estructura del proyecto

```
PrimerParcial-Morana,Valentina/
├── Interfaces/          ICrud<T>, IEntidad
├── BE/                  Entidades, excepciones tipadas, enums
├── Seguridad/           Encriptador (SHA-256), SessionManager (Singleton)
├── Servicios/
│   ├── Composite/       IUnidadDeVenta, ArticuloSimple, LoteArticulos
│   ├── Observer/        ISujetoSubasta, IObservadorSubasta
│   ├── Singleton/       GestorDePujasSingleton
│   ├── SubastaActiva.cs (Sujeto Observer + usa Singleton)
│   └── Interesado.cs    (Observador concreto)
├── DAL/                 Acceso (Singleton BD), AbstractDAL<T>, DALs concretos
├── BLL/                 AbstractBLL<T>, BLLs concretos, ReporteJornada
├── GUI/                 WinForms: Login, Principal (MDI), Catálogo, Subasta,
│                        Historial, Bitácora, Reporte
└── AlmonedaNacional.sql Script de BD (con migraciones guardadas)
```

---

## Base de datos

Tablas: `Usuarios`, `UnidadesDeVenta`, `LoteContenido`, `Subastas`, `Pujas`, `Martilleros`, `Bitacora`.

El script SQL es idempotente: usa `IF NOT EXISTS` y `ALTER TABLE` guardados para migraciones.
