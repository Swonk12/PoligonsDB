-- Insertar registros en la tabla principal de Pol�gonos
INSERT INTO Poligons (tipus) VALUES ('Quadrat');
INSERT INTO Poligons (tipus) VALUES ('Rectangle');
INSERT INTO Poligons (tipus) VALUES ('Cercle');
INSERT INTO Poligons (tipus) VALUES ('Elipse');
INSERT INTO Poligons (tipus) VALUES ('Triangle Rect�ngulo');
INSERT INTO Poligons (tipus) VALUES ('Triangle Is�sceles');
INSERT INTO Poligons (tipus) VALUES ('Rombe');
INSERT INTO Poligons (tipus) VALUES ('Pent�gono');
INSERT INTO Poligons (tipus) VALUES ('Hex�gono');
INSERT INTO Poligons (tipus) VALUES ('Oct�gono');

-- Insertar registros en la tabla de Cuadrados
INSERT INTO Quadrats (id_Poligon, lado) VALUES (1, 5.0);
INSERT INTO Quadrats (id_Poligon, lado) VALUES (1, 7.5);

-- Insertar registros en la tabla de Rect�ngulos
INSERT INTO Rectangles (id_Poligon, ancho, alto) VALUES (2, 4.0, 8.0);
INSERT INTO Rectangles (id_Poligon, ancho, alto) VALUES (2, 6.5, 3.0);

-- Insertar registros en la tabla de C�rculos
INSERT INTO Cercles (id_Poligon, radio) VALUES (3, 10.0);
INSERT INTO Cercles (id_Poligon, radio) VALUES (3, 15.0);

-- Insertar registros en la tabla de Elipses
INSERT INTO Elipses (id_Poligon, radio_mayor, radio_menor) VALUES (4, 12.0, 8.0);
INSERT INTO Elipses (id_Poligon, radio_mayor, radio_menor) VALUES (4, 7.5, 5.0);

-- Insertar registros en la tabla de Tri�ngulos
INSERT INTO Triangles (id_Poligon, tipo, base, altura) VALUES (5, 'Rect�ngulo', 6.0, 8.0);
INSERT INTO Triangles (id_Poligon, tipo, base, altura) VALUES (6, 'Is�sceles', 5.0, 10.0);

-- Insertar registros en la tabla de Rombos
INSERT INTO Rombes (id_Poligon, diagonal_mayor, diagonal_menor) VALUES (7, 10.0, 6.0);
INSERT INTO Rombes (id_Poligon, diagonal_mayor, diagonal_menor) VALUES (7, 8.0, 4.0);

-- Insertar registros en la tabla de Pent�gonos
INSERT INTO Pentagons (id_Poligon, lado, apotema) VALUES (8, 5.0, 6.8);
INSERT INTO Pentagons (id_Poligon, lado, apotema) VALUES (8, 7.0, 8.5);

-- Insertar registros en la tabla de Hex�gonos
INSERT INTO Hexagons (id_Poligon, lado, apotema) VALUES (9, 4.0, 5.2);
INSERT INTO Hexagons (id_Poligon, lado, apotema) VALUES (9, 6.0, 7.8);

-- Insertar registros en la tabla de Oct�gonos
INSERT INTO Octagons (id_Poligon, lado, apotema) VALUES (10, 3.5, 4.5);
INSERT INTO Octagons (id_Poligon, lado, apotema) VALUES (10, 5.0, 6.5);
