-- =============================================================
-- LA ALMONEDA NACIONAL -- DDL limpio para importar el DER
-- Enterprise Architect: Database Engineering > Import from SQL DDL
-- =============================================================

CREATE TABLE Martilleros (
    Id               INT           PRIMARY KEY IDENTITY(1,1),
    Nombre           VARCHAR(100)  NOT NULL DEFAULT '',
    Username         VARCHAR(100)  NOT NULL UNIQUE,
    PasswordHash     VARCHAR(64)   NOT NULL,
    IntentosFallidos INT           NOT NULL DEFAULT 0,
    BloqueadoHasta   DATETIME      NULL
);

CREATE TABLE Usuarios (
    Id        INT           PRIMARY KEY IDENTITY(1,1),
    Nombre    VARCHAR(100)  NOT NULL,
    Email     VARCHAR(200)  NOT NULL UNIQUE,
    FechaAlta DATETIME      NOT NULL DEFAULT GETDATE()
);

CREATE TABLE UnidadesDeVenta (
    Id           INT           PRIMARY KEY IDENTITY(1,1),
    Nombre       VARCHAR(200)  NOT NULL,
    Descripcion  VARCHAR(500)  NULL,
    PrecioBase   DECIMAL(18,2) NOT NULL,
    TipoUnidad   VARCHAR(20)   NOT NULL,
    FechaIngreso DATETIME      NOT NULL DEFAULT GETDATE()
);

-- Tabla puente para el patrón Composite (relación lote -> contenido)
-- LoteId y ContenidoId son ambos FK a UnidadesDeVenta (auto-referencia)
CREATE TABLE LoteContenido (
    LoteId      INT NOT NULL,
    ContenidoId INT NOT NULL,
    CONSTRAINT PK_LoteContenido      PRIMARY KEY (LoteId, ContenidoId),
    CONSTRAINT FK_LoteContenido_Lote FOREIGN KEY (LoteId)      REFERENCES UnidadesDeVenta(Id),
    CONSTRAINT FK_LoteContenido_Item FOREIGN KEY (ContenidoId) REFERENCES UnidadesDeVenta(Id)
);

-- Resultado final de cada subasta cerrada
CREATE TABLE Subastas (
    Id                INT           PRIMARY KEY IDENTITY(1,1),
    NombreUnidadVenta VARCHAR(200)  NOT NULL,
    PrecioBase        DECIMAL(18,2) NOT NULL,
    PrecioFinal       DECIMAL(18,2) NOT NULL,
    NombreGanador     VARCHAR(100)  NOT NULL,
    EmailGanador      VARCHAR(200)  NOT NULL,
    FechaHora         DATETIME      NOT NULL
);

-- Historial completo de ofertas (aceptadas y rechazadas)
CREATE TABLE Pujas (
    Id            INT           PRIMARY KEY IDENTITY(1,1),
    SubastaId     INT           NOT NULL,
    NombreUsuario VARCHAR(100)  NOT NULL,
    Monto         DECIMAL(18,2) NOT NULL,
    FechaHora     DATETIME      NOT NULL,
    Estado        VARCHAR(20)   NOT NULL,
    MotivoRechazo VARCHAR(500)  NULL,
    CONSTRAINT FK_Pujas_Subasta FOREIGN KEY (SubastaId) REFERENCES Subastas(Id)
);

-- Auditoría de operaciones del sistema
CREATE TABLE Bitacora (
    Id               INT          PRIMARY KEY IDENTITY(1,1),
    Fecha            DATETIME     NOT NULL DEFAULT GETDATE(),
    Operacion        VARCHAR(50)  NOT NULL,
    Detalle          VARCHAR(500) NOT NULL,
    Criticidad       VARCHAR(20)  NOT NULL,
    NombreMartillero VARCHAR(100) NOT NULL
);
