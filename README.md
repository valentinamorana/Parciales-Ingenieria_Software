# La Almoneda Nacional
**1er Parcial — Ingeniería de Software | UAI 2026**
**Alumna:** Morana, Valentina

---

## Descripción

Sistema de gestión de subastas para la empresa *La Almoneda Nacional*. Permite al martillero autenticado iniciar subastas, registrar pujas en tiempo real, cerrar subastas y consultar el historial y la auditoría del sistema.

---

## Arquitectura

Solución en **6 capas** con dependencias unidireccionales:

```
Interfaces → BE → Servicios → DAL → BLL → GUI
```

| Proyecto | Responsabilidad |
|----------|----------------|
| `AlmonedaNacional.Interfaces` | Contratos (`ICrud<T>`, `IUnidadDeVenta`, `IObservadorSubasta`) |
| `AlmonedaNacional.BE` | Entidades del dominio (`Martillero`, `Usuario`, `Puja`, `EventoBitacora`, etc.) |
| `AlmonedaNacional.Servicios` | Patrones de diseño: Composite, Observer, Singleton, Encriptación, SessionManager |
| `AlmonedaNacional.DAL` | Acceso a datos con ADO.NET — un DAL por entidad |
| `AlmonedaNacional.BLL` | Lógica de negocio — validaciones, reglas, orquestación |
| `AlmonedaNacional.GUI` | Formularios WinForms — una pantalla por funcionalidad |

---

## Patrones de Diseño implementados

### Composite — Catálogo de unidades de venta (RF-01 a RF-04)
Permite armar lotes que contienen artículos simples u otros lotes, con profundidad ilimitada.

```
IUnidadDeVenta
├── ArticuloSimple   (hoja — precio fijo)
└── LoteArticulos    (compuesto — precio = suma recursiva de hijos)
```

### Observer — Notificaciones de subasta (RF-05 a RF-08)
`SubastaActiva` es el sujeto; `Interesado` es el observador. Cada interesado tiene un canal (WEB, MÓVIL, PANTALLA SALA) y recibe notificaciones automáticas al cambiar el precio.

```
SubastaActiva.Notificar()  →  Interesado.Actualizar(subasta)
                            →  NotificacionRecibida(destinatario, mensaje)
```

### Singleton — Gestor de pujas (RF-09)
`GestorDePujasSingleton` garantiza que solo una puja sea procesada a la vez mediante double-check locking.

### Singleton — Sesión del martillero
`SessionManager` mantiene la sesión activa del martillero autenticado durante toda la ejecución.

---

## Funcionalidades

| RF | Descripción |
|----|-------------|
| RF-01/02 | Crear artículos simples y lotes (Composite) |
| RF-03 | Calcular precio base recursivamente |
| RF-04 | Obtener descripción completa del árbol |
| RF-05 | Iniciar subasta sobre una unidad de venta |
| RF-06 | Suscribir interesados como observadores |
| RF-07 | Cerrar subasta — notifica a todos y persiste en BD |
| RF-08 | Desuscribir interesados |
| RF-09 | Realizar oferta (Singleton garantiza exclusión mutua) |
| RF-10/11 | Validar que la oferta supere el precio actual |
| RF-12 | Persistir resultado y pujas en BD (transacción) |
| RF-13 | Reporte de jornada — recorrido Composite + exportar PDF/TXT |
| Plus | Temporizador regresivo 2 min + Anti-Sniping automático (+2 min si oferta en últimos 30 s) |
| Plus | Login con SHA-256, bloqueo tras 3 intentos, SessionManager |
| Plus | Bitácora de auditoría con filtros y exportación PDF |

---

## Pantallas

| Form | Descripción |
|------|-------------|
| `frmLogin` | Autenticación del martillero (SHA-256, bloqueo automático) |
| `frmPrincipal` | MDI principal con menú de navegación |
| `frmCatalogo` | Alta de artículos y lotes, visualización del árbol Composite |
| `frmSubasta` | Gestión completa de subasta activa: suscripciones, pujas, temporizador |
| `frmHistorial` | Historial de subastas cerradas + detalle de pujas por subasta |
| `frmBitacora` | Auditoría del sistema con filtros (días, criticidad, operación) + exportar PDF |
| `frmReporte` | Reporte de jornada RF-13: catálogo + subastas del día + exportar PDF/TXT |

---

## Requisitos

- **Visual Studio 2022** (o posterior)
- **.NET Framework 4.7.2**
- **SQL Server Express** (`.\SQLEXPRESS`)
- **NuGet:** `iTextSharp 5.5.13.3` (exportación PDF, se restaura automáticamente)

---

## Configuración de la Base de Datos

1. Abrir SQL Server Management Studio (o Azure Data Studio)
2. Ejecutar el script completo:
   ```
   AlmonedaNacional.sql
   ```
   El script crea la BD, todas las tablas y los datos iniciales de forma **idempotente** (se puede correr más de una vez sin error).

3. Verificar la cadena de conexión en `AlmonedaNacional.DAL/Conexion.cs`:
   ```
   Server=.\SQLEXPRESS;Database=AlmonedaNacional;Trusted_Connection=True;
   ```

### Tablas creadas

| Tabla | Descripción |
|-------|-------------|
| `Usuarios` | Participantes que realizan pujas |
| `UnidadesDeVenta` | Artículos y lotes del catálogo |
| `LoteContenido` | Relaciones padre-hijo del árbol Composite |
| `Subastas` | Resultados de subastas cerradas |
| `Pujas` | Historial de todas las ofertas (aceptadas y rechazadas) |
| `Martilleros` | Credenciales de acceso con control de bloqueo |
| `Bitacora` | Registro de auditoría de todas las operaciones |

---

## Credenciales por defecto

| Usuario | Contraseña |
|---------|-----------|
| `martillero` | `Admin1234` |

El hash SHA-256 queda almacenado en la tabla `Martilleros`. La cuenta se bloquea **10 minutos** tras **3 intentos fallidos** consecutivos.

---

## Cómo ejecutar

1. Clonar el repositorio
2. Ejecutar `AlmonedaNacional.sql` en SQL Server
3. Abrir `PrimerParcial-Morana,Valentina.sln` en Visual Studio
4. Compilar (`Ctrl+Shift+B`) — los paquetes NuGet se restauran automáticamente
5. Presionar `F5` para ejecutar
6. Ingresar con `martillero` / `Admin1234`

---

## Estructura de carpetas

```
PrimerParcial-Morana,Valentina/
├── AlmonedaNacional.Interfaces/     # Contratos e interfaces
├── AlmonedaNacional.BE/             # Entidades del dominio
│   ├── Martillero.cs
│   ├── EventoBitacora.cs
│   ├── CriticidadEvento.cs
│   └── ...
├── AlmonedaNacional.Servicios/      # Patrones de diseño
│   ├── Composite/                   # ArticuloSimple, LoteArticulos
│   ├── Observer/                    # SubastaActiva, Interesado
│   ├── Singleton/                   # GestorDePujasSingleton
│   └── Seguridad/                   # SessionManager, Encriptador
├── AlmonedaNacional.DAL/            # Acceso a datos (ADO.NET)
│   ├── Acceso.cs                    # Singleton de conexión
│   ├── CatalogoDAL.cs
│   ├── SubastaDAL.cs
│   ├── MartilleroDAL.cs
│   ├── BitacoraDAL.cs
│   └── ...
├── AlmonedaNacional.BLL/            # Lógica de negocio
│   ├── CatalogoBLL.cs               # Construye árbol Composite desde BD
│   ├── SubastaBLL.cs
│   ├── MartilleroBLL.cs             # Login + bloqueo de cuenta
│   ├── BitacoraBLL.cs
│   └── ReporteJornada.cs            # RF-13: recorrido Composite + historial
├── AlmonedaNacional.GUI/            # Formularios WinForms
│   ├── frmLogin.cs / .Designer.cs
│   ├── frmPrincipal.cs / .Designer.cs
│   ├── frmSubasta.cs / .Designer.cs
│   ├── frmHistorial.cs / .Designer.cs
│   ├── frmBitacora.cs / .Designer.cs
│   ├── frmReporte.cs / .Designer.cs
│   └── PdfExporter.cs               # Helper iTextSharp para exportar PDF
└── AlmonedaNacional.sql             # Script completo de BD
```

---

## Decisiones de diseño destacadas

**¿Por qué `ReporteJornada` está en BLL y no en Servicios?**
BLL referencia Servicios, pero Servicios no puede referenciar BLL (dependencia circular). Como el reporte necesita tanto los tipos Composite (Servicios) como `SubastaBLL`, se ubicó en BLL.

**¿Por qué la Bitácora usa silent-fail?**
`BitacoraBLL.Registrar()` captura todas las excepciones sin relanzarlas para que un error de auditoría nunca interrumpa el flujo principal de la subasta.

**Anti-Sniping:** si una oferta llega cuando quedan ≤ 30 segundos, el temporizador se extiende automáticamente +2 minutos. Esto evita que usuarios esperen al último segundo para pujar y ganar injustamente.
