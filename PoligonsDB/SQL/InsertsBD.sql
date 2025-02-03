-- INSERT para Poligons
INSERT INTO Poligons (tipus) VALUES ('Quadrat');
INSERT INTO Poligons (tipus) VALUES ('Rectangle');
INSERT INTO Poligons (tipus) VALUES ('Cercle');
INSERT INTO Poligons (tipus) VALUES ('Elipse');
INSERT INTO Poligons (tipus) VALUES ('Triangle_Rectangle');
INSERT INTO Poligons (tipus) VALUES ('Triangle_Isosceles');
INSERT INTO Poligons (tipus) VALUES ('Rombe');
INSERT INTO Poligons (tipus) VALUES ('Pentagon');
INSERT INTO Poligons (tipus) VALUES ('Hexagon');
INSERT INTO Poligons (tipus) VALUES ('Octagon');

-- INSERT para Quadrats
INSERT INTO Quadrats (id_Poligon, nom, lado, area, perimetre, color) 
VALUES (1, 'Quadrat1', 5.0, 25.0, 20.0, 0);
INSERT INTO Quadrats (id_Poligon, nom, lado, area, perimetre, color) 
VALUES (1, 'Quadrat2', 4.0, 16.0, 16.0, 1);
INSERT INTO Quadrats (id_Poligon, nom, lado, area, perimetre, color) 
VALUES (1, 'Quadrat3', 3.0, 9.0, 12.0, 0);
INSERT INTO Quadrats (id_Poligon, nom, lado, area, perimetre, color) 
VALUES (1, 'Quadrat4', 6.0, 36.0, 24.0, 1);
INSERT INTO Quadrats (id_Poligon, nom, lado, area, perimetre, color) 
VALUES (1, 'Quadrat5', 7.0, 49.0, 28.0, 1);

-- INSERT para Rectangles
INSERT INTO Rectangles (id_Poligon, nom, ancho, alto, area, perimetre, color) 
VALUES (2, 'Rectangle1', 4.0, 5.0, 20.0, 18.0, 0);
INSERT INTO Rectangles (id_Poligon, nom, ancho, alto, area, perimetre, color) 
VALUES (2, 'Rectangle2', 6.0, 3.0, 18.0, 18.0, 1);
INSERT INTO Rectangles (id_Poligon, nom, ancho, alto, area, perimetre, color) 
VALUES (2, 'Rectangle3', 7.0, 4.0, 28.0, 22.0, 0);
INSERT INTO Rectangles (id_Poligon, nom, ancho, alto, area, perimetre, color) 
VALUES (2, 'Rectangle4', 5.0, 6.0, 30.0, 22.0, 1);
INSERT INTO Rectangles (id_Poligon, nom, ancho, alto, area, perimetre, color) 
VALUES (2, 'Rectangle5', 8.0, 2.0, 16.0, 20.0, 1);

-- INSERT para Cercles
INSERT INTO Cercles (id_Poligon, nom, radio, area, perimetre, color) 
VALUES (3, 'Cercle1', 3.0, 28.27, 18.85, 0);
INSERT INTO Cercles (id_Poligon, nom, radio, area, perimetre, color) 
VALUES (3, 'Cercle2', 4.0, 50.24, 25.13, 0);
INSERT INTO Cercles (id_Poligon, nom, radio, area, perimetre, color) 
VALUES (3, 'Cercle3', 5.0, 78.54, 31.42, 0);
INSERT INTO Cercles (id_Poligon, nom, radio, area, perimetre, color) 
VALUES (3, 'Cercle4', 6.0, 113.10, 37.70, 1);
INSERT INTO Cercles (id_Poligon, nom, radio, area, perimetre, color) 
VALUES (3, 'Cercle5', 7.0, 153.94, 43.98, 0);

-- INSERT para Elipses
INSERT INTO Elipses (id_Poligon, nom, radio_mayor, radio_menor, area, perimetre, color) 
VALUES (4, 'Elipse1', 5.0, 3.0, 47.12, 25.13, 0);
INSERT INTO Elipses (id_Poligon, nom, radio_mayor, radio_menor, area, perimetre, color) 
VALUES (4, 'Elipse2', 6.0, 4.0, 75.40, 31.42, 1);
INSERT INTO Elipses (id_Poligon, nom, radio_mayor, radio_menor, area, perimetre, color) 
VALUES (4, 'Elipse3', 7.0, 5.0, 108.64, 37.70, 1);
INSERT INTO Elipses (id_Poligon, nom, radio_mayor, radio_menor, area, perimetre, color) 
VALUES (4, 'Elipse4', 8.0, 6.0, 150.80, 43.98, 1);
INSERT INTO Elipses (id_Poligon, nom, radio_mayor, radio_menor, area, perimetre, color) 
VALUES (4, 'Elipse5', 9.0, 7.0, 196.73, 50.27, 1);

-- INSERT para Triangles_Rectangles
INSERT INTO Triangles_Rectangles (id_Poligon, nom, base, altura, area, perimetre, color) 
VALUES (5, 'TriangleRectangle1', 4.0, 3.0, 6.0, 14.0, 0);
INSERT INTO Triangles_Rectangles (id_Poligon, nom, base, altura, area, perimetre, color) 
VALUES (5, 'TriangleRectangle2', 6.0, 5.0, 15.0, 22.0, 1);
INSERT INTO Triangles_Rectangles (id_Poligon, nom, base, altura, area, perimetre, color) 
VALUES (5, 'TriangleRectangle3', 8.0, 6.0, 24.0, 28.0, 1);
INSERT INTO Triangles_Rectangles (id_Poligon, nom, base, altura, area, perimetre, color) 
VALUES (5, 'TriangleRectangle4', 10.0, 7.0, 35.0, 34.0, 0);
INSERT INTO Triangles_Rectangles (id_Poligon, nom, base, altura, area, perimetre, color) 
VALUES (5, 'TriangleRectangle5', 12.0, 8.0, 48.0, 40.0, 0);

-- INSERT para Triangles_Isosceles
INSERT INTO Triangles_Isosceles (id_Poligon, nom, base, altura, area, perimetre, color) 
VALUES (6, 'TriangleIso1', 4.0, 3.0, 6.0, 14.0, 0);
INSERT INTO Triangles_Isosceles (id_Poligon, nom, base, altura, area, perimetre, color) 
VALUES (6, 'TriangleIso2', 6.0, 5.0, 15.0, 22.0, 1);
INSERT INTO Triangles_Isosceles (id_Poligon, nom, base, altura, area, perimetre, color) 
VALUES (6, 'TriangleIso3', 8.0, 6.0, 24.0, 28.0, 0);
INSERT INTO Triangles_Isosceles (id_Poligon, nom, base, altura, area, perimetre, color) 
VALUES (6, 'TriangleIso4', 10.0, 7.0, 35.0, 34.0, 1);
INSERT INTO Triangles_Isosceles (id_Poligon, nom, base, altura, area, perimetre, color) 
VALUES (6, 'TriangleIso5', 12.0, 8.0, 48.0, 40.0, 0);

-- INSERT para Rombes
INSERT INTO Rombes (id_Poligon, nom, diagonal_mayor, diagonal_menor, area, perimetre, color) 
VALUES (7, 'Rombe1', 5.0, 4.0, 10.0, 14.0, 0);
INSERT INTO Rombes (id_Poligon, nom, diagonal_mayor, diagonal_menor, area, perimetre, color) 
VALUES (7, 'Rombe2', 6.0, 5.0, 15.0, 20.0, 1);
INSERT INTO Rombes (id_Poligon, nom, diagonal_mayor, diagonal_menor, area, perimetre, color) 
VALUES (7, 'Rombe3', 7.0, 6.0, 21.0, 24.0, 1);
INSERT INTO Rombes (id_Poligon, nom, diagonal_mayor, diagonal_menor, area, perimetre, color) 
VALUES (7, 'Rombe4', 8.0, 7.0, 28.0, 28.0, 1);
INSERT INTO Rombes (id_Poligon, nom, diagonal_mayor, diagonal_menor, area, perimetre, color) 
VALUES (7, 'Rombe5', 9.0, 8.0, 36.0, 32.0, 1);

-- INSERT para Pentagons
INSERT INTO Pentagons (id_Poligon, nom, lado, apotema, area, perimetre, color) 
VALUES (8, 'Pentagon1', 5.0, 4.0, 25.0, 25.0, 1);
INSERT INTO Pentagons (id_Poligon, nom, lado, apotema, area, perimetre, color) 
VALUES (8, 'Pentagon2', 6.0, 5.0, 30.0, 30.0, 1);
INSERT INTO Pentagons (id_Poligon, nom, lado, apotema, area, perimetre, color) 
VALUES (8, 'Pentagon3', 7.0, 6.0, 35.0, 35.0, 0);
INSERT INTO Pentagons (id_Poligon, nom, lado, apotema, area, perimetre, color) 
VALUES (8, 'Pentagon4', 8.0, 7.0, 40.0, 40.0, 1);
INSERT INTO Pentagons (id_Poligon, nom, lado, apotema, area, perimetre, color) 
VALUES (8, 'Pentagon5', 9.0, 8.0, 45.0, 45.0, 0);

-- INSERT para Hexagons
INSERT INTO Hexagons (id_Poligon, nom, lado, apotema, area, perimetre, color) 
VALUES (9, 'Hexagon1', 5.0, 4.0, 43.3, 30.0, 1);
INSERT INTO Hexagons (id_Poligon, nom, lado, apotema, area, perimetre, color) 
VALUES (9, 'Hexagon2', 6.0, 5.0, 62.4, 36.0, 1);
INSERT INTO Hexagons (id_Poligon, nom, lado, apotema, area, perimetre, color) 
VALUES (9, 'Hexagon3', 7.0, 6.0, 84.0, 42.0, 0);
INSERT INTO Hexagons (id_Poligon, nom, lado, apotema, area, perimetre, color) 
VALUES (9, 'Hexagon4', 8.0, 7.0, 112.0, 48.0, 0);
INSERT INTO Hexagons (id_Poligon, nom, lado, apotema, area, perimetre, color) 
VALUES (9, 'Hexagon5', 9.0, 8.0, 141.4, 54.0, 1);

-- INSERT para Octagons
INSERT INTO Octagons (id_Poligon, nom, lado, apotema, area, perimetre, color) 
VALUES (10, 'Octagon1', 5.0, 4.0, 80.0, 40.0, 0);
INSERT INTO Octagons (id_Poligon, nom, lado, apotema, area, perimetre, color) 
VALUES (10, 'Octagon2', 6.0, 5.0, 90.0, 48.0, 1);
INSERT INTO Octagons (id_Poligon, nom, lado, apotema, area, perimetre, color) 
VALUES (10, 'Octagon3', 7.0, 6.0, 120.0, 56.0, 0);
INSERT INTO Octagons (id_Poligon, nom, lado, apotema, area, perimetre, color) 
VALUES (10, 'Octagon4', 8.0, 7.0, 140.0, 64.0, 1);
INSERT INTO Octagons (id_Poligon, nom, lado, apotema, area, perimetre, color) 
VALUES (10, 'Octagon5', 9.0, 8.0, 160.0, 72.0, 0);
