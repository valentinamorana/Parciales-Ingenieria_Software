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

-- ─────────────────────────────────────────────
--  HISTORIAL DE SUBASTAS
-- ─────────────────────────────────────────────

-- ── 10 ABR 2026 — Temporada Otoño ──────────────────────────────────────

IF NOT EXISTS (SELECT 1 FROM Subastas WHERE CAST(FechaHora AS DATE) = '2026-04-10')
BEGIN
    INSERT INTO Subastas
        (NombreUnidadVenta, PrecioBase, PrecioFinal, NombreGanador, EmailGanador, FechaHora)
    VALUES
        ('Pañuelo Hermès "Jardin de Paris" Seda',
            12000.00,  19500.00, 'Sofía Ibáñez',     'sofia@moda.com',      '2026-04-10 14:15:00'),
        ('Set Joyería Plata y Lapislázuli',
            22000.00,  35200.00, 'Martina Ruiz',      'martina@vintage.com', '2026-04-10 15:00:00'),
        ('Agenda Louis Vuitton Edición Limitada',
            18500.00,  27000.00, 'Isabella Moreno',   'isa@couture.com',     '2026-04-10 15:45:00');
END
GO

-- ── 17 ABR 2026 — Subasta Especial Moda ────────────────────────────────

IF NOT EXISTS (SELECT 1 FROM Subastas WHERE CAST(FechaHora AS DATE) = '2026-04-17')
BEGIN
    INSERT INTO Subastas
        (NombreUnidadVenta, PrecioBase, PrecioFinal, NombreGanador, EmailGanador, FechaHora)
    VALUES
        ('Clutch Judith Leiber Swarovski',
            32000.00,  51000.00, 'Bianca Castillo',   'bianca@bijou.com',    '2026-04-17 13:30:00'),
        ('Abrigo Chanel Tweed Rosa Vintage',
            78000.00, 128500.00, 'Renata Solís',       'renata@lux.com',      '2026-04-17 14:20:00'),
        ('Vestido Givenchy Couture c.1965',
            95000.00, 162000.00, 'Isabella Moreno',   'isa@couture.com',     '2026-04-17 15:10:00'),
        ('Perfume Chanel Nº5 Vintage (1975)',
            38000.00,  59500.00, 'Florencia Paz',      'flor@arte.com',       '2026-04-17 16:00:00');
END
GO

-- ── 24 ABR 2026 — Arte Decorativo ──────────────────────────────────────

IF NOT EXISTS (SELECT 1 FROM Subastas WHERE CAST(FechaHora AS DATE) = '2026-04-24')
BEGIN
    INSERT INTO Subastas
        (NombreUnidadVenta, PrecioBase, PrecioFinal, NombreGanador, EmailGanador, FechaHora)
    VALUES
        ('Espejo Veneciano Talla Dorada',
            28000.00,  44000.00, 'Lucía Fernández',   'lucia@estilo.com',    '2026-04-24 14:00:00'),
        ('Escultura Porcelana Limoges s.XIX',
            55000.00,  89000.00, 'Agustina Ferreyra', 'agus@tendencia.com',  '2026-04-24 15:00:00'),
        ('Cuadro "Flores en Azul" óleo firmado',
           115000.00, 195000.00, 'Florencia Paz',      'flor@arte.com',       '2026-04-24 16:15:00');
END
GO

-- ── 05 MAY 2026 — Gran Colección ───────────────────────────────────────

IF NOT EXISTS (SELECT 1 FROM Subastas WHERE CAST(FechaHora AS DATE) = '2026-05-05')
BEGIN
    INSERT INTO Subastas
        (NombreUnidadVenta, PrecioBase, PrecioFinal, NombreGanador, EmailGanador, FechaHora)
    VALUES
        ('Collar de Perlas Akoya',
            62000.00,  98000.00, 'Camila Vega',        'camila@glamour.com',  '2026-05-05 13:00:00'),
        ('Pulsera Oro 18k con Rubíes',
            45000.00,  72500.00, 'Valentina Torres',   'valen@chic.com',      '2026-05-05 13:50:00'),
        ('Anillo de Zafiro Art Déco',
            85000.00, 148000.00, 'Renata Solís',        'renata@lux.com',      '2026-05-05 14:40:00'),
        ('Lámpara Tiffany Original c.1910',
           185000.00, 312000.00, 'Agustina Ferreyra',  'agus@tendencia.com',  '2026-05-05 15:30:00'),
        ('Lote Moda Vintage Couture',
           205000.00, 340000.00, 'Isabella Moreno',    'isa@couture.com',     '2026-05-05 16:30:00');
END
GO

-- ── 12 MAY 2026 — Subasta Semanal ──────────────────────────────────────

IF NOT EXISTS (SELECT 1 FROM Subastas WHERE CAST(FechaHora AS DATE) = '2026-05-12')
BEGIN
    INSERT INTO Subastas
        (NombreUnidadVenta, PrecioBase, PrecioFinal, NombreGanador, EmailGanador, FechaHora)
    VALUES
        ('Bolso Hermès Birkin 35 Negro',
           420000.00, 685000.00, 'Renata Solís',        'renata@lux.com',      '2026-05-12 14:00:00'),
        ('Colección Joyería Alta',
           192000.00, 310000.00, 'Camila Vega',         'camila@glamour.com',  '2026-05-12 15:00:00'),
        ('Tesoro Decorativo',
           268000.00, 425000.00, 'Florencia Paz',       'flor@arte.com',       '2026-05-12 16:00:00'),
        ('Pañuelo Hermès "Jardin de Paris" Seda',
            12000.00,  22000.00, 'Sofía Ibáñez',        'sofia@moda.com',      '2026-05-12 16:45:00');
END
GO

-- ── 15 MAY 2026 — Subasta Extraordinaria ───────────────────────────────

IF NOT EXISTS (SELECT 1 FROM Subastas WHERE CAST(FechaHora AS DATE) = '2026-05-15')
BEGIN
    INSERT INTO Subastas
        (NombreUnidadVenta, PrecioBase, PrecioFinal, NombreGanador, EmailGanador, FechaHora)
    VALUES
        ('Set Joyería Plata y Lapislázuli',
            22000.00,  38500.00, 'Valentina Torres',   'valen@chic.com',      '2026-05-15 13:15:00'),
        ('Clutch Judith Leiber Swarovski',
            32000.00,  55000.00, 'Bianca Castillo',    'bianca@bijou.com',    '2026-05-15 14:00:00'),
        ('Colección Arte y Deco Completa',
           383000.00, 620000.00, 'Agustina Ferreyra',  'agus@tendencia.com',  '2026-05-15 15:00:00'),
        ('Gran Lote Lujo',
           650000.00, 980000.00, 'Renata Solís',        'renata@lux.com',      '2026-05-15 16:30:00');
END
GO

-- ─────────────────────────────────────────────
--  PUJAS (historial de ofertas por subasta)
-- ─────────────────────────────────────────────

-- Función auxiliar: cargamos los SubastaIds en variables y poblamos las pujas
-- de las subastas más representativas para poblar el historial.

DECLARE @s1  INT = (SELECT Id FROM Subastas WHERE NombreUnidadVenta = 'Anillo de Zafiro Art Déco'          AND CAST(FechaHora AS DATE) = '2026-05-05');
DECLARE @s2  INT = (SELECT Id FROM Subastas WHERE NombreUnidadVenta = 'Bolso Hermès Birkin 35 Negro'        AND CAST(FechaHora AS DATE) = '2026-05-12');
DECLARE @s3  INT = (SELECT Id FROM Subastas WHERE NombreUnidadVenta = 'Colección Joyería Alta'              AND CAST(FechaHora AS DATE) = '2026-05-12');
DECLARE @s4  INT = (SELECT Id FROM Subastas WHERE NombreUnidadVenta = 'Gran Lote Lujo'                     AND CAST(FechaHora AS DATE) = '2026-05-15');
DECLARE @s5  INT = (SELECT Id FROM Subastas WHERE NombreUnidadVenta = 'Cuadro "Flores en Azul" óleo firmado' AND CAST(FechaHora AS DATE) = '2026-04-24');
DECLARE @s6  INT = (SELECT Id FROM Subastas WHERE NombreUnidadVenta = 'Vestido Givenchy Couture c.1965'    AND CAST(FechaHora AS DATE) = '2026-04-17');
DECLARE @s7  INT = (SELECT Id FROM Subastas WHERE NombreUnidadVenta = 'Lote Moda Vintage Couture'          AND CAST(FechaHora AS DATE) = '2026-05-05');
DECLARE @s8  INT = (SELECT Id FROM Subastas WHERE NombreUnidadVenta = 'Tesoro Decorativo'                  AND CAST(FechaHora AS DATE) = '2026-05-12');

IF @s1 IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Pujas WHERE SubastaId = @s1)
    INSERT INTO Pujas (SubastaId, NombreUsuario, Monto, FechaHora, Estado, MotivoRechazo) VALUES
        (@s1, 'Valentina Torres', 86000.00, '2026-05-05 14:02:00', 'Aceptada',  NULL),
        (@s1, 'Camila Vega',      95000.00, '2026-05-05 14:08:00', 'Aceptada',  NULL),
        (@s1, 'Valentina Torres', 93000.00, '2026-05-05 14:12:00', 'Rechazada', 'Oferta inferior a la puja vigente'),
        (@s1, 'Bianca Castillo', 110000.00, '2026-05-05 14:18:00', 'Aceptada',  NULL),
        (@s1, 'Camila Vega',     120000.00, '2026-05-05 14:25:00', 'Aceptada',  NULL),
        (@s1, 'Renata Solís',    148000.00, '2026-05-05 14:40:00', 'Aceptada',  NULL);
GO

DECLARE @s2  INT = (SELECT Id FROM Subastas WHERE NombreUnidadVenta = 'Bolso Hermès Birkin 35 Negro' AND CAST(FechaHora AS DATE) = '2026-05-12');
IF @s2 IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Pujas WHERE SubastaId = @s2)
    INSERT INTO Pujas (SubastaId, NombreUsuario, Monto, FechaHora, Estado, MotivoRechazo) VALUES
        (@s2, 'Camila Vega',      425000.00, '2026-05-12 13:05:00', 'Aceptada',  NULL),
        (@s2, 'Isabella Moreno',  450000.00, '2026-05-12 13:15:00', 'Aceptada',  NULL),
        (@s2, 'Bianca Castillo',  440000.00, '2026-05-12 13:18:00', 'Rechazada', 'Oferta inferior a la puja vigente'),
        (@s2, 'Agustina Ferreyra',500000.00, '2026-05-12 13:30:00', 'Aceptada',  NULL),
        (@s2, 'Isabella Moreno',  520000.00, '2026-05-12 13:42:00', 'Aceptada',  NULL),
        (@s2, 'Renata Solís',     600000.00, '2026-05-12 13:51:00', 'Aceptada',  NULL),
        (@s2, 'Isabella Moreno',  590000.00, '2026-05-12 13:53:00', 'Rechazada', 'Oferta inferior a la puja vigente'),
        (@s2, 'Renata Solís',     685000.00, '2026-05-12 14:00:00', 'Aceptada',  NULL);
GO

DECLARE @s3  INT = (SELECT Id FROM Subastas WHERE NombreUnidadVenta = 'Colección Joyería Alta' AND CAST(FechaHora AS DATE) = '2026-05-12');
IF @s3 IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Pujas WHERE SubastaId = @s3)
    INSERT INTO Pujas (SubastaId, NombreUsuario, Monto, FechaHora, Estado, MotivoRechazo) VALUES
        (@s3, 'Valentina Torres', 195000.00, '2026-05-12 14:10:00', 'Aceptada',  NULL),
        (@s3, 'Sofía Ibáñez',    210000.00, '2026-05-12 14:20:00', 'Aceptada',  NULL),
        (@s3, 'Valentina Torres', 200000.00, '2026-05-12 14:22:00', 'Rechazada', 'Oferta inferior a la puja vigente'),
        (@s3, 'Bianca Castillo', 250000.00, '2026-05-12 14:35:00', 'Aceptada',  NULL),
        (@s3, 'Camila Vega',     310000.00, '2026-05-12 15:00:00', 'Aceptada',  NULL);
GO

DECLARE @s4  INT = (SELECT Id FROM Subastas WHERE NombreUnidadVenta = 'Gran Lote Lujo' AND CAST(FechaHora AS DATE) = '2026-05-15');
IF @s4 IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Pujas WHERE SubastaId = @s4)
    INSERT INTO Pujas (SubastaId, NombreUsuario, Monto, FechaHora, Estado, MotivoRechazo) VALUES
        (@s4, 'Isabella Moreno',  660000.00, '2026-05-15 15:00:00', 'Aceptada',  NULL),
        (@s4, 'Agustina Ferreyra',700000.00, '2026-05-15 15:12:00', 'Aceptada',  NULL),
        (@s4, 'Isabella Moreno',  750000.00, '2026-05-15 15:20:00', 'Aceptada',  NULL),
        (@s4, 'Camila Vega',      800000.00, '2026-05-15 15:32:00', 'Aceptada',  NULL),
        (@s4, 'Agustina Ferreyra',780000.00, '2026-05-15 15:33:00', 'Rechazada', 'Oferta inferior a la puja vigente'),
        (@s4, 'Renata Solís',     900000.00, '2026-05-15 16:00:00', 'Aceptada',  NULL),
        (@s4, 'Camila Vega',      850000.00, '2026-05-15 16:01:00', 'Rechazada', 'Oferta inferior a la puja vigente'),
        (@s4, 'Renata Solís',     980000.00, '2026-05-15 16:30:00', 'Aceptada',  NULL);
GO

DECLARE @s5  INT = (SELECT Id FROM Subastas WHERE NombreUnidadVenta = 'Cuadro "Flores en Azul" óleo firmado' AND CAST(FechaHora AS DATE) = '2026-04-24');
IF @s5 IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Pujas WHERE SubastaId = @s5)
    INSERT INTO Pujas (SubastaId, NombreUsuario, Monto, FechaHora, Estado, MotivoRechazo) VALUES
        (@s5, 'Sofía Ibáñez',     120000.00, '2026-04-24 15:05:00', 'Aceptada',  NULL),
        (@s5, 'Lucía Fernández',  140000.00, '2026-04-24 15:18:00', 'Aceptada',  NULL),
        (@s5, 'Martina Ruiz',     135000.00, '2026-04-24 15:20:00', 'Rechazada', 'Oferta inferior a la puja vigente'),
        (@s5, 'Florencia Paz',    175000.00, '2026-04-24 15:40:00', 'Aceptada',  NULL),
        (@s5, 'Lucía Fernández',  195000.00, '2026-04-24 16:15:00', 'Aceptada',  NULL),
        (@s5, 'Florencia Paz',    195000.00, '2026-04-24 16:15:00', 'Aceptada',  NULL);
GO

DECLARE @s6  INT = (SELECT Id FROM Subastas WHERE NombreUnidadVenta = 'Vestido Givenchy Couture c.1965' AND CAST(FechaHora AS DATE) = '2026-04-17');
IF @s6 IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Pujas WHERE SubastaId = @s6)
    INSERT INTO Pujas (SubastaId, NombreUsuario, Monto, FechaHora, Estado, MotivoRechazo) VALUES
        (@s6, 'Valentina Torres',  98000.00, '2026-04-17 14:15:00', 'Aceptada',  NULL),
        (@s6, 'Bianca Castillo',  115000.00, '2026-04-17 14:25:00', 'Aceptada',  NULL),
        (@s6, 'Renata Solís',     140000.00, '2026-04-17 14:38:00', 'Aceptada',  NULL),
        (@s6, 'Isabella Moreno',  162000.00, '2026-04-17 15:10:00', 'Aceptada',  NULL);
GO

DECLARE @s7  INT = (SELECT Id FROM Subastas WHERE NombreUnidadVenta = 'Lote Moda Vintage Couture' AND CAST(FechaHora AS DATE) = '2026-05-05');
IF @s7 IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Pujas WHERE SubastaId = @s7)
    INSERT INTO Pujas (SubastaId, NombreUsuario, Monto, FechaHora, Estado, MotivoRechazo) VALUES
        (@s7, 'Sofía Ibáñez',     210000.00, '2026-05-05 15:40:00', 'Aceptada',  NULL),
        (@s7, 'Renata Solís',     250000.00, '2026-05-05 15:50:00', 'Aceptada',  NULL),
        (@s7, 'Bianca Castillo',  240000.00, '2026-05-05 15:52:00', 'Rechazada', 'Oferta inferior a la puja vigente'),
        (@s7, 'Camila Vega',      295000.00, '2026-05-05 16:05:00', 'Aceptada',  NULL),
        (@s7, 'Isabella Moreno',  340000.00, '2026-05-05 16:30:00', 'Aceptada',  NULL);
GO

DECLARE @s8  INT = (SELECT Id FROM Subastas WHERE NombreUnidadVenta = 'Tesoro Decorativo' AND CAST(FechaHora AS DATE) = '2026-05-12');
IF @s8 IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Pujas WHERE SubastaId = @s8)
    INSERT INTO Pujas (SubastaId, NombreUsuario, Monto, FechaHora, Estado, MotivoRechazo) VALUES
        (@s8, 'Lucía Fernández',  275000.00, '2026-05-12 15:10:00', 'Aceptada',  NULL),
        (@s8, 'Martina Ruiz',     300000.00, '2026-05-12 15:22:00', 'Aceptada',  NULL),
        (@s8, 'Agustina Ferreyra',350000.00, '2026-05-12 15:40:00', 'Aceptada',  NULL),
        (@s8, 'Lucía Fernández',  400000.00, '2026-05-12 15:52:00', 'Aceptada',  NULL),
        (@s8, 'Florencia Paz',    425000.00, '2026-05-12 16:00:00', 'Aceptada',  NULL);
GO

-- ─────────────────────────────────────────────
--  RESUMEN DE JORNADAS DISPONIBLES PARA REPORTES
-- ─────────────────────────────────────────────
--
--  10/04/2026  Temporada Otoño         3 items   $  81.700
--  17/04/2026  Especial Moda           4 items   $ 401.000
--  24/04/2026  Arte Decorativo         3 items   $ 328.000
--  05/05/2026  Gran Colección          5 items   $ 970.500
--  12/05/2026  Subasta Semanal         4 items   $1.442.000
--  15/05/2026  Extraordinaria          4 items   $1.713.500
