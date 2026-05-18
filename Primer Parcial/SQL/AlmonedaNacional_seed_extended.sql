-- =============================================
-- LA ALMONEDA NACIONAL - Seed de Datos Extendido
-- SQL Server | Ingeniería de Software UAI 2026
-- Ejecutar UNA sola vez sobre AlmonedaNacional
-- =============================================

USE AlmonedaNacional;
GO

-- ─────────────────────────────────────────────
--  MARTILLEROS
--  Password para todos: Admin1234
--  Hash SHA-256: 60fe74406e7f353ed979f350f2fbb6a2e8690a5fa7d1b0c32983d1d8b3f95f67
-- ─────────────────────────────────────────────

IF NOT EXISTS (SELECT 1 FROM Martilleros WHERE Username = 'vmorana')
    INSERT INTO Martilleros (Nombre, Username, PasswordHash, IntentosFallidos)
    VALUES ('Valentina Morana', 'vmorana',
            '60fe74406e7f353ed979f350f2fbb6a2e8690a5fa7d1b0c32983d1d8b3f95f67', 0);
GO

IF NOT EXISTS (SELECT 1 FROM Martilleros WHERE Username = 'ileon')
    INSERT INTO Martilleros (Nombre, Username, PasswordHash, IntentosFallidos)
    VALUES ('Ignacio León', 'ileon',
            '60fe74406e7f353ed979f350f2fbb6a2e8690a5fa7d1b0c32983d1d8b3f95f67', 0);
GO

-- ─────────────────────────────────────────────
--  USUARIOS PUJADORES
-- ─────────────────────────────────────────────

IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE Email = 'camila@glamour.com')
    INSERT INTO Usuarios (Nombre, Email) VALUES
        ('Camila Vega',        'camila@glamour.com'),
        ('Sofía Ibáñez',       'sofia@moda.com'),
        ('Lucía Fernández',    'lucia@estilo.com'),
        ('Valentina Torres',   'valen@chic.com'),
        ('Martina Ruiz',       'martina@vintage.com'),
        ('Isabella Moreno',    'isa@couture.com'),
        ('Florencia Paz',      'flor@arte.com'),
        ('Renata Solís',       'renata@lux.com'),
        ('Bianca Castillo',    'bianca@bijou.com'),
        ('Agustina Ferreyra',  'agus@tendencia.com');
GO

-- ─────────────────────────────────────────────
--  CATÁLOGO: ARTÍCULOS & LOTES
-- ─────────────────────────────────────────────

IF NOT EXISTS (SELECT 1 FROM UnidadesDeVenta WHERE Nombre = 'Anillo de Zafiro Art Déco')
BEGIN

    -- ── ARTÍCULOS INDIVIDUALES ──────────────────────────────────────────

    INSERT INTO UnidadesDeVenta (Nombre, Descripcion, PrecioBase, TipoUnidad) VALUES
        ('Anillo de Zafiro Art Déco',
            'Zafiro oval 4ct rodeado de diamantes, montura platino, c.1925. Certificado GIA.',
            85000.00,  'Articulo'),
        ('Collar de Perlas Akoya',
            'Hilo de 47 perlas Akoya 7.5mm, cierre en oro blanco 18k con diamante central.',
            62000.00,  'Articulo'),
        ('Pulsera Oro 18k con Rubíes',
            'Brazalete rígido con 9 rubíes birmanos engastados en oro 18k. Firmado Cartier.',
            45000.00,  'Articulo'),
        ('Perfume Chanel Nº5 Vintage (1975)',
            'Frasco original 50ml sin abrir, caja de época. Procedencia colección privada París.',
            38000.00,  'Articulo'),
        ('Bolso Hermès Birkin 35 Negro',
            'Cuero togo negro, herrajes dorados, candado y llaves originales. Año 2008.',
            420000.00, 'Articulo'),
        ('Vestido Givenchy Couture c.1965',
            'Organza marfil con bordado floral a mano, talle 38 FR. Estado impecable.',
            95000.00,  'Articulo'),
        ('Abrigo Chanel Tweed Rosa Vintage',
            'Tweed lana y seda, botonería CC dorada, forro seda cruda. Temporada 1992.',
            78000.00,  'Articulo'),
        ('Clutch Judith Leiber Swarovski',
            'Minaudière dorada con 3.200 cristales multicolor. Diseño floral. Con bolsa original.',
            32000.00,  'Articulo'),
        ('Cuadro "Flores en Azul" óleo firmado',
            'Óleo sobre tela 60×80cm, firmado B. Sarlo (1988). Con certificado de autenticidad.',
            115000.00, 'Articulo'),
        ('Escultura Porcelana Limoges s.XIX',
            'Figura femenina porcelana policromada 34cm, marca Haviland, c.1880. Base original.',
            55000.00,  'Articulo'),
        ('Espejo Veneciano Talla Dorada',
            'Marco madera tallada y dorada al pan de oro, cristal biselado, 90×60cm. s.XVIII.',
            28000.00,  'Articulo'),
        ('Lámpara Tiffany Original c.1910',
            'Base bronce patinado, pantalla vitral con peonías rosadas. Certificado Dreicer.',
            185000.00, 'Articulo'),
        ('Set Joyería Plata y Lapislázuli',
            'Collar, aretes y anillo en plata 925 con cabujones de lapislázuli afgano. Estuche.',
            22000.00,  'Articulo'),
        ('Agenda Louis Vuitton Edición Limitada',
            'Monograma Multicolore blanco, año 2003 colección Marc Jacobs. Estuche original.',
            18500.00,  'Articulo'),
        ('Pañuelo Hermès "Jardin de Paris" Seda',
            '90×90cm, seda twill 100%, colorway azul/coral. Sin uso, caja original.',
            12000.00,  'Articulo');

    -- ── LOTES ──────────────────────────────────────────────────────────

    INSERT INTO UnidadesDeVenta (Nombre, Descripcion, PrecioBase, TipoUnidad) VALUES
        ('Colección Joyería Alta',
            'Trío de alta joyería: anillo zafiro Art Déco + collar perlas Akoya + pulsera rubíes Cartier.',
            192000.00, 'Lote'),
        ('Lote Moda Vintage Couture',
            'Tres íconos del siglo XX: vestido Givenchy + abrigo Chanel tweed + clutch Judith Leiber.',
            205000.00, 'Lote'),
        ('Tesoro Decorativo',
            'Para el hogar más chic: escultura Limoges + espejo veneciano + lámpara Tiffany original.',
            268000.00, 'Lote'),
        ('Gran Lote Lujo',
            'El lote más codiciado de la temporada: Colección Joyería Alta + Birkin negro + Chanel Nº5.',
            650000.00, 'Lote'),
        ('Colección Arte y Deco Completa',
            'Para el coleccionista exigente: cuadro Flores en Azul + Tesoro Decorativo completo.',
            383000.00, 'Lote');

    -- ── RELACIONES COMPOSITE ──────────────────────────────────────────

    DECLARE @idAnillo    INT = (SELECT Id FROM UnidadesDeVenta WHERE Nombre = 'Anillo de Zafiro Art Déco');
    DECLARE @idCollar    INT = (SELECT Id FROM UnidadesDeVenta WHERE Nombre = 'Collar de Perlas Akoya');
    DECLARE @idPulsera   INT = (SELECT Id FROM UnidadesDeVenta WHERE Nombre = 'Pulsera Oro 18k con Rubíes');
    DECLARE @idPerfume   INT = (SELECT Id FROM UnidadesDeVenta WHERE Nombre = 'Perfume Chanel Nº5 Vintage (1975)');
    DECLARE @idBirkin    INT = (SELECT Id FROM UnidadesDeVenta WHERE Nombre = 'Bolso Hermès Birkin 35 Negro');
    DECLARE @idVestido   INT = (SELECT Id FROM UnidadesDeVenta WHERE Nombre = 'Vestido Givenchy Couture c.1965');
    DECLARE @idAbrigo    INT = (SELECT Id FROM UnidadesDeVenta WHERE Nombre = 'Abrigo Chanel Tweed Rosa Vintage');
    DECLARE @idClutch    INT = (SELECT Id FROM UnidadesDeVenta WHERE Nombre = 'Clutch Judith Leiber Swarovski');
    DECLARE @idCuadro    INT = (SELECT Id FROM UnidadesDeVenta WHERE Nombre = 'Cuadro "Flores en Azul" óleo firmado');
    DECLARE @idEscultura INT = (SELECT Id FROM UnidadesDeVenta WHERE Nombre = 'Escultura Porcelana Limoges s.XIX');
    DECLARE @idEspejo    INT = (SELECT Id FROM UnidadesDeVenta WHERE Nombre = 'Espejo Veneciano Talla Dorada');
    DECLARE @idLampara   INT = (SELECT Id FROM UnidadesDeVenta WHERE Nombre = 'Lámpara Tiffany Original c.1910');

    DECLARE @idLoteJoya  INT = (SELECT Id FROM UnidadesDeVenta WHERE Nombre = 'Colección Joyería Alta');
    DECLARE @idLoteModa  INT = (SELECT Id FROM UnidadesDeVenta WHERE Nombre = 'Lote Moda Vintage Couture');
    DECLARE @idLoteDeco  INT = (SELECT Id FROM UnidadesDeVenta WHERE Nombre = 'Tesoro Decorativo');
    DECLARE @idLoteLujo  INT = (SELECT Id FROM UnidadesDeVenta WHERE Nombre = 'Gran Lote Lujo');
    DECLARE @idLoteArte  INT = (SELECT Id FROM UnidadesDeVenta WHERE Nombre = 'Colección Arte y Deco Completa');

    INSERT INTO LoteContenido (LoteId, ContenidoId) VALUES
        -- Colección Joyería Alta ─ 3 artículos
        (@idLoteJoya, @idAnillo),
        (@idLoteJoya, @idCollar),
        (@idLoteJoya, @idPulsera),
        -- Lote Moda Vintage Couture ─ 3 artículos
        (@idLoteModa, @idVestido),
        (@idLoteModa, @idAbrigo),
        (@idLoteModa, @idClutch),
        -- Tesoro Decorativo ─ 3 artículos
        (@idLoteDeco, @idEscultura),
        (@idLoteDeco, @idEspejo),
        (@idLoteDeco, @idLampara),
        -- Gran Lote Lujo ─ anida Colección Joyería Alta + Birkin + Perfume
        (@idLoteLujo, @idLoteJoya),
        (@idLoteLujo, @idBirkin),
        (@idLoteLujo, @idPerfume),
        -- Colección Arte y Deco ─ anida Cuadro + Tesoro Decorativo
        (@idLoteArte, @idCuadro),
        (@idLoteArte, @idLoteDeco);

END
GO
