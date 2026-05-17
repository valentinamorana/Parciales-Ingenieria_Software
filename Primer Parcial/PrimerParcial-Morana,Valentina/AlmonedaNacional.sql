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
        Id          INT           PRIMARY KEY IDENTITY(1,1),
        Nombre      VARCHAR(200)  NOT NULL,
        Descripcion VARCHAR(500),
        PrecioBase  DECIMAL(18,2) NOT NULL,
        TipoUnidad  VARCHAR(20)   NOT NULL CHECK (TipoUnidad IN ('Articulo', 'Lote'))
    );
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
--  TABLA: Subastas  (resultado final — RF: producto, precio final, ganador, fecha/hora)
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
--  TABLA: Ofertas  (historial de cada puja)
-- ─────────────────────────────────────────────
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Ofertas')
BEGIN
    CREATE TABLE Ofertas (
        Id          INT           PRIMARY KEY IDENTITY(1,1),
        SubastaId   INT           NOT NULL,
        UsuarioId   INT           NOT NULL,
        Monto       DECIMAL(18,2) NOT NULL,
        FechaHora   DATETIME      NOT NULL DEFAULT GETDATE(),
        CONSTRAINT FK_Ofertas_Subasta  FOREIGN KEY (SubastaId) REFERENCES Subastas(Id),
        CONSTRAINT FK_Ofertas_Usuario  FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
    );
END
GO

-- ─────────────────────────────────────────────
--  DATOS DE PRUEBA
-- ─────────────────────────────────────────────
INSERT INTO Usuarios (Nombre, Email) VALUES
    ('Carlos Méndez',    'carlos@web.com'),
    ('Laura Rodríguez',  'laura@movil.com'),
    ('Tomás García',     'tomas@sala.com');
GO

INSERT INTO UnidadesDeVenta (Nombre, Descripcion, PrecioBase, TipoUnidad) VALUES
    ('Taladro Industrial',           'Bosch 1500W',                  15000.00, 'Articulo'),
    ('Amoladora',                    'Makita 9 pulgadas',             8000.00, 'Articulo'),
    ('Set de Repuestos',             '200 unidades',                  5000.00, 'Articulo'),
    ('Máquina CNC',                  'Control numérico 3 ejes',     250000.00, 'Articulo'),
    ('Lote Herramientas Manuales',   'Taladro + Amoladora',          23000.00, 'Lote'),
    ('Sección Producción',           'Herramientas + Repuestos + CNC', 278000.00, 'Lote');
GO

-- Relaciones Composite: lote → contenido
INSERT INTO LoteContenido (LoteId, ContenidoId) VALUES
    (5, 1),   -- Lote Herramientas → Taladro
    (5, 2),   -- Lote Herramientas → Amoladora
    (6, 5),   -- Sección Producción → Lote Herramientas (lote dentro de lote)
    (6, 3),   -- Sección Producción → Set Repuestos
    (6, 4);   -- Sección Producción → Máquina CNC
GO

-- ─────────────────────────────────────────────
--  CONSULTA RF-13: reporte consolidado
-- ─────────────────────────────────────────────
-- SELECT NombreUnidadVenta, PrecioBase, PrecioFinal, NombreGanador, EmailGanador, FechaHora
-- FROM   Subastas
-- ORDER  BY FechaHora DESC;
