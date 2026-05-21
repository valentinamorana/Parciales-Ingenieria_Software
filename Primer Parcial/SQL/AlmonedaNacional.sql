-- =============================================
-- LA ALMONEDA NACIONAL - Script de Base de Datos
-- SQL Server | Ingeniería de Software UAI 2026
-- =============================================

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'AlmonedaNacional')
    CREATE DATABASE AlmonedaNacional;
GO

USE AlmonedaNacional;
GO

-- ─────────────────────────────────────────────
--  TABLA: Usuarios
-- ─────────────────────────────────────────────
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Usuarios')
BEGIN
    CREATE TABLE Usuarios (
        Id          INT           PRIMARY KEY IDENTITY(1,1),
        Nombre      VARCHAR(100)  NOT NULL,
        Email       VARCHAR(200)  NOT NULL UNIQUE,
        FechaAlta   DATETIME      NOT NULL DEFAULT GETDATE()
    );
END
GO

-- ─────────────────────────────────────────────
--  TABLA: UnidadesDeVenta  (Composite — nodos del árbol)
-- ─────────────────────────────────────────────
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'UnidadesDeVenta')
BEGIN
    CREATE TABLE UnidadesDeVenta (
        Id           INT           PRIMARY KEY IDENTITY(1,1),
        Nombre       VARCHAR(200)  NOT NULL,
        Descripcion  VARCHAR(500),
        PrecioBase   DECIMAL(18,2) NOT NULL,
        TipoUnidad   VARCHAR(20)   NOT NULL CHECK (TipoUnidad IN ('Articulo', 'Lote')),
        FechaIngreso DATETIME      NOT NULL DEFAULT GETDATE()
    );
END
GO

-- Migración: agregar FechaIngreso si la tabla ya existía sin ella
IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME = 'UnidadesDeVenta' AND COLUMN_NAME = 'FechaIngreso'
)
BEGIN
    ALTER TABLE UnidadesDeVenta ADD FechaIngreso DATETIME NOT NULL DEFAULT GETDATE();
END
GO

-- Migración: agregar Estado a UnidadesDeVenta
-- sp_executesql difiere el parsing al momento de ejecución, evitando el Msg 207
IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME = 'UnidadesDeVenta' AND COLUMN_NAME = 'Estado'
)
BEGIN
    EXEC sp_executesql N'ALTER TABLE UnidadesDeVenta ADD Estado VARCHAR(20) NOT NULL DEFAULT ''Disponible''';
    EXEC sp_executesql N'ALTER TABLE UnidadesDeVenta ADD CONSTRAINT CK_UnidadesDeVenta_Estado
        CHECK (Estado IN (''Disponible'', ''EnSubasta'', ''Adjudicado'', ''Desierta''))';
END
GO

-- ─────────────────────────────────────────────
--  TABLA: LoteContenido  (jerarquía del Composite sin límite de profundidad)
-- ─────────────────────────────────────────────
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'LoteContenido')
BEGIN
    CREATE TABLE LoteContenido (
        LoteId      INT NOT NULL,
        ContenidoId INT NOT NULL,
        CONSTRAINT PK_LoteContenido         PRIMARY KEY (LoteId, ContenidoId),
        CONSTRAINT FK_LoteContenido_Lote    FOREIGN KEY (LoteId)      REFERENCES UnidadesDeVenta(Id),
        CONSTRAINT FK_LoteContenido_Item    FOREIGN KEY (ContenidoId) REFERENCES UnidadesDeVenta(Id)
    );
END
GO

-- ─────────────────────────────────────────────
--  TABLA: Subastas  (resultado final — se inserta al cerrar)
-- ─────────────────────────────────────────────
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Subastas')
BEGIN
    CREATE TABLE Subastas (
        Id                  INT           PRIMARY KEY IDENTITY(1,1),
        NombreUnidadVenta   VARCHAR(200)  NOT NULL,
        PrecioBase          DECIMAL(18,2) NOT NULL,
        PrecioFinal         DECIMAL(18,2) NOT NULL,
        NombreGanador       VARCHAR(100)  NOT NULL,
        EmailGanador        VARCHAR(200)  NOT NULL,
        FechaHora           DATETIME      NOT NULL
    );
END
GO

-- ─────────────────────────────────────────────
--  TABLA: Pujas  (historial completo de ofertas: aceptadas y rechazadas)
-- ─────────────────────────────────────────────
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Pujas')
BEGIN
    CREATE TABLE Pujas (
        Id              INT             PRIMARY KEY IDENTITY(1,1),
        SubastaId       INT             NOT NULL,
        NombreUsuario   VARCHAR(100)    NOT NULL,
        Monto           DECIMAL(18,2)   NOT NULL,
        FechaHora       DATETIME        NOT NULL,
        Estado          VARCHAR(20)     NOT NULL CHECK (Estado IN ('Aceptada', 'Rechazada')),
        MotivoRechazo   VARCHAR(500)    NULL,
        CONSTRAINT FK_Pujas_Subasta FOREIGN KEY (SubastaId) REFERENCES Subastas(Id)
    );
END
GO

-- ─────────────────────────────────────────────
--  TABLA: Martilleros  (autenticación con bloqueo por intentos fallidos)
-- ─────────────────────────────────────────────
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Martilleros')
BEGIN
    CREATE TABLE Martilleros (
        Id               INT           PRIMARY KEY IDENTITY(1,1),
        Nombre           VARCHAR(100)  NOT NULL DEFAULT '',
        Username         VARCHAR(100)  NOT NULL UNIQUE,
        PasswordHash     VARCHAR(64)   NOT NULL,
        IntentosFallidos INT           NOT NULL DEFAULT 0,
        BloqueadoHasta   DATETIME      NULL
    );
END
GO

-- Agregar columna Nombre si no existe (migracion)
IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME = 'Martilleros' AND COLUMN_NAME = 'Nombre'
)
BEGIN
    ALTER TABLE Martilleros ADD Nombre VARCHAR(100) NOT NULL DEFAULT '';
END
GO

-- ─────────────────────────────────────────────
--  TABLA: Bitacora  (auditoría de operaciones del sistema)
-- ─────────────────────────────────────────────
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Bitacora')
BEGIN
    CREATE TABLE Bitacora (
        Id               INT           PRIMARY KEY IDENTITY(1,1),
        Fecha            DATETIME      NOT NULL DEFAULT GETDATE(),
        Operacion        VARCHAR(50)   NOT NULL,
        Detalle          VARCHAR(500)  NOT NULL,
        Criticidad       VARCHAR(20)   NOT NULL CHECK (Criticidad IN ('Baja', 'Media', 'Alta', 'IntentosLogin', 'BloqueosCuenta')),
        NombreMartillero VARCHAR(100)  NOT NULL
    );
END
GO

-- Ampliar columna Criticidad y actualizar CHECK (migracion)
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Bitacora')
BEGIN
    -- Eliminar el CHECK constraint existente sobre Criticidad (nombre autogenerado)
    DECLARE @constraintName NVARCHAR(200);
    SELECT @constraintName = cc.CONSTRAINT_NAME
    FROM   INFORMATION_SCHEMA.CHECK_CONSTRAINTS cc
    JOIN   INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE ccu
           ON cc.CONSTRAINT_NAME = ccu.CONSTRAINT_NAME
    WHERE  ccu.TABLE_NAME = 'Bitacora' AND ccu.COLUMN_NAME = 'Criticidad';

    IF @constraintName IS NOT NULL
        EXEC ('ALTER TABLE Bitacora DROP CONSTRAINT ' + @constraintName);

    -- Ampliar la columna a VARCHAR(20)
    ALTER TABLE Bitacora ALTER COLUMN Criticidad VARCHAR(20) NOT NULL;

    -- Agregar el nuevo CHECK con todos los valores validos
    IF NOT EXISTS (
        SELECT 1 FROM INFORMATION_SCHEMA.CHECK_CONSTRAINTS cc
        JOIN   INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE ccu
               ON cc.CONSTRAINT_NAME = ccu.CONSTRAINT_NAME
        WHERE  ccu.TABLE_NAME = 'Bitacora' AND ccu.COLUMN_NAME = 'Criticidad'
    )
    BEGIN
        ALTER TABLE Bitacora
            ADD CONSTRAINT CK_Bitacora_Criticidad
            CHECK (Criticidad IN ('Baja', 'Media', 'Alta', 'IntentosLogin', 'BloqueosCuenta'));
    END
END
GO

-- ─────────────────────────────────────────────
--  DATOS INICIALES
-- ─────────────────────────────────────────────

-- Martillero por defecto (password: Admin1234)
-- Hash SHA-256 de "Admin1234" en minúsculas
IF NOT EXISTS (SELECT 1 FROM Martilleros WHERE Username = 'martillero')
    INSERT INTO Martilleros (Nombre, Username, PasswordHash, IntentosFallidos)
    VALUES ('Morana, Valentina', 'martillero', '60fe74406e7f353ed979f350f2fbb6a2e8690a5fa7d1b0c32983d1d8b3f95f67', 0);
ELSE
    UPDATE Martilleros SET Nombre = 'Morana, Valentina' WHERE Username = 'martillero' AND Nombre = '';
GO

-- Usuarios que realizan pujas
IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE Email = 'carlos@web.com')
    INSERT INTO Usuarios (Nombre, Email) VALUES
        ('Carlos Méndez',   'carlos@web.com'),
        ('Laura Rodríguez', 'laura@movil.com'),
        ('Tomás García',    'tomas@sala.com');
GO

-- Catálogo inicial de unidades de venta
IF NOT EXISTS (SELECT 1 FROM UnidadesDeVenta WHERE Nombre = 'Taladro Industrial')
BEGIN
    INSERT INTO UnidadesDeVenta (Nombre, Descripcion, PrecioBase, TipoUnidad) VALUES
        ('Taladro Industrial', 'Bosch 1500W',              15000.00, 'Articulo'),
        ('Amoladora',          'Makita 9 pulgadas',          8000.00, 'Articulo'),
        ('Set de Repuestos',   '200 unidades',               5000.00, 'Articulo'),
        ('Máquina CNC',        'Control numérico 3 ejes',  250000.00, 'Articulo'),
        ('Lote Herramientas',  'Taladro + Amoladora',       23000.00, 'Lote');

    DECLARE @idTaladro INT = (SELECT Id FROM UnidadesDeVenta WHERE Nombre = 'Taladro Industrial');
    DECLARE @idAmolad  INT = (SELECT Id FROM UnidadesDeVenta WHERE Nombre = 'Amoladora');
    DECLARE @idLoteH   INT = (SELECT Id FROM UnidadesDeVenta WHERE Nombre = 'Lote Herramientas');

    INSERT INTO LoteContenido (LoteId, ContenidoId) VALUES
        (@idLoteH, @idTaladro),
        (@idLoteH, @idAmolad);
END
GO

-- ─────────────────────────────────────────────
--  CONSULTAS DE REFERENCIA
-- ─────────────────────────────────────────────

-- RF-13: reporte consolidado de subastas
-- SELECT NombreUnidadVenta, PrecioBase, PrecioFinal, NombreGanador, EmailGanador, FechaHora
-- FROM   Subastas ORDER BY FechaHora DESC;

-- Historial completo de pujas de una subasta
-- SELECT p.Id, p.NombreUsuario, p.Monto, p.FechaHora, p.Estado, p.MotivoRechazo
-- FROM   Pujas p WHERE p.SubastaId = <id> ORDER BY p.FechaHora;

-- Auditoría por criticidad
-- SELECT * FROM Bitacora WHERE Criticidad = 'Alta' ORDER BY Fecha DESC;
