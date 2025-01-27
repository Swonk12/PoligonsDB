CREATE DATABASE PoligonsBD;
GO

USE PoligonsBD;
GO

-- Crear la tabla principal de Pol�gonos
CREATE TABLE Poligons (
    id_Poligon INT IDENTITY(1,1) PRIMARY KEY,
    tipus NVARCHAR(50) NOT NULL
);

-- Crear la tabla para Cuadrados
CREATE TABLE Quadrats (
    id_Quadrat INT IDENTITY(1,1) PRIMARY KEY,
    id_Poligon INT NOT NULL,
    lado FLOAT NOT NULL,
    FOREIGN KEY (id_Poligon) REFERENCES Poligons(id_Poligon)
);

-- Crear la tabla para Rect�ngulos
CREATE TABLE Rectangles (
    id_Rectangle INT IDENTITY(1,1) PRIMARY KEY,
    id_Poligon INT NOT NULL,
    ancho FLOAT NOT NULL,
    alto FLOAT NOT NULL,
    FOREIGN KEY (id_Poligon) REFERENCES Poligons(id_Poligon)
);

-- Crear la tabla para C�rculos
CREATE TABLE Cercles (
    id_Cercle INT IDENTITY(1,1) PRIMARY KEY,
    id_Poligon INT NOT NULL,
    radio FLOAT NOT NULL,
    FOREIGN KEY (id_Poligon) REFERENCES Poligons(id_Poligon)
);

-- Crear la tabla para Elipses
CREATE TABLE Elipses (
    id_Elipse INT IDENTITY(1,1) PRIMARY KEY,
    id_Poligon INT NOT NULL,
    radio_mayor FLOAT NOT NULL,
    radio_menor FLOAT NOT NULL,
    FOREIGN KEY (id_Poligon) REFERENCES Poligons(id_Poligon)
);

-- Crear la tabla para Tri�ngulos
CREATE TABLE Triangles (
    id_Triangle INT IDENTITY(1,1) PRIMARY KEY,
    id_Poligon INT NOT NULL,
    tipo NVARCHAR(20) NOT NULL, -- 'Rect�ngulo' o 'Is�sceles'
    base FLOAT NOT NULL,
    altura FLOAT NOT NULL,
    FOREIGN KEY (id_Poligon) REFERENCES Poligons(id_Poligon)
);

-- Crear la tabla para Rombos
CREATE TABLE Rombes (
    id_Rombe INT IDENTITY(1,1) PRIMARY KEY,
    id_Poligon INT NOT NULL,
    diagonal_mayor FLOAT NOT NULL,
    diagonal_menor FLOAT NOT NULL,
    FOREIGN KEY (id_Poligon) REFERENCES Poligons(id_Poligon)
);

-- Crear la tabla para Pent�gonos
CREATE TABLE Pentagons (
    id_Pentagon INT IDENTITY(1,1) PRIMARY KEY,
    id_Poligon INT NOT NULL,
    lado FLOAT NOT NULL,
    apotema FLOAT NOT NULL,
    FOREIGN KEY (id_Poligon) REFERENCES Poligons(id_Poligon)
);

-- Crear la tabla para Hex�gonos
CREATE TABLE Hexagons (
    id_Hexagon INT IDENTITY(1,1) PRIMARY KEY,
    id_Poligon INT NOT NULL,
    lado FLOAT NOT NULL,
    apotema FLOAT NOT NULL,
    FOREIGN KEY (id_Poligon) REFERENCES Poligons(id_Poligon)
);

-- Crear la tabla para Oct�gonos
CREATE TABLE Octagons (
    id_Octagon INT IDENTITY(1,1) PRIMARY KEY,
    id_Poligon INT NOT NULL,
    lado FLOAT NOT NULL,
    apotema FLOAT NOT NULL,
    FOREIGN KEY (id_Poligon) REFERENCES Poligons(id_Poligon)
);

