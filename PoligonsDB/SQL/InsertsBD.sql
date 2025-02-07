-- Insertar 5 registros en la tabla Poligons (con diferentes tipos)
INSERT INTO Poligons (tipus, area, perimetre, color)
VALUES
-- 5 Quadrats
('Quadrat', 25.0, 20.0, 0), 
('Quadrat', 36.0, 24.0, 1),
('Quadrat', 49.0, 28.0, 1),
('Quadrat', 64.0, 32.0, 1),  
('Quadrat', 81.0, 36.0, 0), 

-- 5 Rectangles
('Rectangle', 50.0, 30.0, 1),
('Rectangle', 60.0, 40.0, 0),
('Rectangle', 70.0, 45.0, 0), 
('Rectangle', 80.0, 50.0, 1), 
('Rectangle', 90.0, 55.0, 0), 

-- 5 Cercles
('Cercle', 78.5, 31.4, 1),  
('Cercle', 113.1, 37.7, 1), 
('Cercle', 150.8, 42.8, 1), 
('Cercle', 201.1, 47.1, 1),  
('Cercle', 254.5, 51.2, 0), 

-- 5 Elipses
('Elipse', 100.0, 60.0, 0),   
('Elipse', 150.0, 70.0, 1), 
('Elipse', 200.0, 80.0, 0),   
('Elipse', 250.0, 90.0, 0), 
('Elipse', 300.0, 100.0, 1),  

-- 5 Triangles Rectangles (esquerra o dreta)
('Triangle Rectangle', 30.0, 20.0, 1), 
('Triangle Rectangle', 40.0, 25.0, 0), 
('Triangle Rectangle', 50.0, 30.0, 1),
('Triangle Rectangle', 60.0, 35.0, 0), 
('Triangle Rectangle', 70.0, 40.0, 1), 

-- 5 Triangles Isosceles
('Triangle Isosceles', 35.0, 20.0, 1),
('Triangle Isosceles', 45.0, 25.0, 0), 
('Triangle Isosceles', 55.0, 30.0, 1), 
('Triangle Isosceles', 65.0, 35.0, 1), 
('Triangle Isosceles', 75.0, 40.0, 0), 

-- 5 Rombes
('Rombe', 40.0, 30.0, 0),
('Rombe', 50.0, 35.0, 1), 
('Rombe', 60.0, 40.0, 1), 
('Rombe', 70.0, 45.0, 0),
('Rombe', 80.0, 50.0, 1), 

-- 5 Pentagons
('Pentagon', 80.0, 35.0, 1),
('Pentagon', 100.0, 40.0, 1), 
('Pentagon', 120.0, 45.0, 1),
('Pentagon', 140.0, 50.0, 0), 
('Pentagon', 160.0, 55.0, 0),

-- 5 Hexagons
('Hexagon', 90.0, 35.0, 1), 
('Hexagon', 110.0, 40.0, 0), 
('Hexagon', 130.0, 45.0, 1),
('Hexagon', 150.0, 50.0, 0), 
('Hexagon', 170.0, 55.0, 1),

-- 5 Octagons
('Octagon', 100.0, 35.0, 0), 
('Octagon', 120.0, 40.0, 0), 
('Octagon', 140.0, 45.0, 1), 
('Octagon', 160.0, 50.0, 1), 
('Octagon', 180.0, 55.0, 1); 

-- INSERT para Quadrats
-- Insertar en la tabla Quadrats
INSERT INTO Quadrats (id_Poligon, nom, lado)
VALUES
(1, 'Quadrat A', 5.0),  
(2, 'Quadrat B', 6.0), 
(3, 'Quadrat C', 7.0),  
(4, 'Quadrat D', 8.0), 
(5, 'Quadrat E', 9.0); 

-- Insertar en la tabla Rectangles
INSERT INTO Rectangles (id_Poligon, nom, ancho, alto)
VALUES
(6, 'Rectangle A', 10.0, 5.0), 
(7, 'Rectangle B', 12.0, 6.0),  
(8, 'Rectangle C', 15.0, 7.0),
(9, 'Rectangle D', 18.0, 8.0),
(10, 'Rectangle E', 20.0, 10.0);

-- Insertar en la tabla Cercles
INSERT INTO Cercles (id_Poligon, nom, radio)
VALUES
(11, 'Cercle A', 5.0), 
(12, 'Cercle B', 6.0),  
(13, 'Cercle C', 7.0), 
(14, 'Cercle D', 8.0), 
(15, 'Cercle E', 9.0); 

-- Insertar en la tabla Elipses
INSERT INTO Elipses (id_Poligon, nom, radio_mayor, radio_menor)
VALUES
(16, 'Elipse A', 10.0, 5.0), 
(17, 'Elipse B', 12.0, 6.0),  
(18, 'Elipse C', 15.0, 7.0),  
(19, 'Elipse D', 18.0, 8.0), 
(20, 'Elipse E', 20.0, 10.0);

-- Insertar en la tabla Triangles_Rectangles
INSERT INTO Triangles_Rectangles (id_Poligon, nom, ladoRect, base, altura)
VALUES
(21, 'Triangle Rectangle A', 0, 12.0, 8.0), 
(22, 'Triangle Rectangle B', 1, 14.0, 10.0),
(23, 'Triangle Rectangle C', 0, 16.0, 12.0), 
(24, 'Triangle Rectangle D', 1, 18.0, 14.0),
(25, 'Triangle Rectangle E', 0, 20.0, 16.0); 

-- Insertar en la tabla Triangles_Isosceles
INSERT INTO Triangles_Isosceles (id_Poligon, nom, base, altura)
VALUES
(26, 'Triangle Isosceles A', 8.0, 12.0),  
(27, 'Triangle Isosceles B', 9.0, 14.0),
(28, 'Triangle Isosceles C', 10.0, 16.0),
(29, 'Triangle Isosceles D', 11.0, 18.0), 
(30, 'Triangle Isosceles E', 12.0, 20.0);  

-- Insertar en la tabla Rombes
INSERT INTO Rombes (id_Poligon, nom, diagonal_mayor, diagonal_menor)
VALUES
(31, 'Rombe A', 10.0, 5.0),  
(32, 'Rombe B', 12.0, 6.0),
(33, 'Rombe C', 14.0, 7.0),  
(34, 'Rombe D', 16.0, 8.0),
(35, 'Rombe E', 18.0, 9.0);

-- Insertar en la tabla Pentagons
INSERT INTO Pentagons (id_Poligon, nom, lado, apotema)
VALUES
(36, 'Pentagon A', 6.0, 7.0), 
(37, 'Pentagon B', 7.0, 8.0), 
(38, 'Pentagon C', 8.0, 9.0),
(39, 'Pentagon D', 9.0, 10.0), 
(40, 'Pentagon E', 10.0, 11.0);

-- Insertar en la tabla Hexagons
INSERT INTO Hexagons (id_Poligon, nom, lado, apotema)
VALUES
(41, 'Hexagon A', 8.0, 9.0),  
(42, 'Hexagon B', 9.0, 10.0), 
(43, 'Hexagon C', 10.0, 11.0), 
(44, 'Hexagon D', 11.0, 12.0),
(45, 'Hexagon E', 12.0, 13.0); 

-- Insertar en la tabla Octagons
INSERT INTO Octagons (id_Poligon, nom, lado, apotema)
VALUES
(46, 'Octagon A', 6.0, 7.0), 
(47, 'Octagon B', 7.0, 8.0), 
(48, 'Octagon C', 8.0, 9.0), 
(49, 'Octagon D', 9.0, 10.0),
(50, 'Octagon E', 10.0, 11.0);

