CREATE DATABASE PoligonsBD;
GO

USE PoligonsBD;
GO

-- Crear la tabla principal de Polígonos
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

-- Crear la tabla para Rectángulos
CREATE TABLE Rectangles (
    id_Rectangle INT IDENTITY(1,1) PRIMARY KEY,
    id_Poligon INT NOT NULL,
    ancho FLOAT NOT NULL,
    alto FLOAT NOT NULL,
    FOREIGN KEY (id_Poligon) REFERENCES Poligons(id_Poligon)
);

-- Crear la tabla para Círculos
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

-- Crear la tabla para Triángulos
CREATE TABLE Triangles (
    id_Triangle INT IDENTITY(1,1) PRIMARY KEY,
    id_Poligon INT NOT NULL,
    tipo NVARCHAR(20) NOT NULL, -- 'Rectángulo' o 'Isósceles'
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

-- Crear la tabla para Pentágonos
CREATE TABLE Pentagons (
    id_Pentagon INT IDENTITY(1,1) PRIMARY KEY,
    id_Poligon INT NOT NULL,
    lado FLOAT NOT NULL,
    apotema FLOAT NOT NULL,
    FOREIGN KEY (id_Poligon) REFERENCES Poligons(id_Poligon)
);

-- Crear la tabla para Hexágonos
CREATE TABLE Hexagons (
    id_Hexagon INT IDENTITY(1,1) PRIMARY KEY,
    id_Poligon INT NOT NULL,
    lado FLOAT NOT NULL,
    apotema FLOAT NOT NULL,
    FOREIGN KEY (id_Poligon) REFERENCES Poligons(id_Poligon)
);

-- Crear la tabla para Octágonos
CREATE TABLE Octagons (
    id_Octagon INT IDENTITY(1,1) PRIMARY KEY,
    id_Poligon INT NOT NULL,
    lado FLOAT NOT NULL,
    apotema FLOAT NOT NULL,
    FOREIGN KEY (id_Poligon) REFERENCES Poligons(id_Poligon)
);

