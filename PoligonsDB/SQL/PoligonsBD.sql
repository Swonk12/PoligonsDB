CREATE DATABASE PoligonsBD;
GO

USE PoligonsBD;
GO

CREATE TABLE Poligons (
    id_Poligon INT IDENTITY(1,1) PRIMARY KEY,
    tipus NVARCHAR(50) NOT NULL,
    area FLOAT NOT NULL,
    perimetre FLOAT NOT NULL,
    color INT NOT NULL
);

CREATE TABLE Quadrats (
    id_Quadrat INT IDENTITY(1,1) PRIMARY KEY,
    id_Poligon INT NOT NULL,
    nom NVARCHAR(50) NOT NULL,
    lado FLOAT NOT NULL,
    FOREIGN KEY (id_Poligon) REFERENCES Poligons(id_Poligon)
);

CREATE TABLE Rectangles (
    id_Rectangle INT IDENTITY(1,1) PRIMARY KEY,
    id_Poligon INT NOT NULL,
    nom NVARCHAR(50) NOT NULL,
    ancho FLOAT NOT NULL,
    alto FLOAT NOT NULL,
    FOREIGN KEY (id_Poligon) REFERENCES Poligons(id_Poligon)
);

CREATE TABLE Cercles (
    id_Cercle INT IDENTITY(1,1) PRIMARY KEY,
    id_Poligon INT NOT NULL,
    nom NVARCHAR(50) NOT NULL,
    radio FLOAT NOT NULL,
    FOREIGN KEY (id_Poligon) REFERENCES Poligons(id_Poligon)
);

CREATE TABLE Elipses (
    id_Elipse INT IDENTITY(1,1) PRIMARY KEY,
    id_Poligon INT NOT NULL,
    nom NVARCHAR(50) NOT NULL,
    radio_mayor FLOAT NOT NULL,
    radio_menor FLOAT NOT NULL,
    FOREIGN KEY (id_Poligon) REFERENCES Poligons(id_Poligon)
);

CREATE TABLE Triangles_Rectangles (
    id_TriangleRect INT IDENTITY(1,1) PRIMARY KEY,
    id_Poligon INT NOT NULL,
    ladoRect INT NOT NULL,
    nom NVARCHAR(50) NOT NULL,
    base FLOAT NOT NULL,
    altura FLOAT NOT NULL,
    FOREIGN KEY (id_Poligon) REFERENCES Poligons(id_Poligon)
);

CREATE TABLE Triangles_Isosceles (
    id_TriangleIso INT IDENTITY(1,1) PRIMARY KEY,
    id_Poligon INT NOT NULL,
    nom NVARCHAR(50) NOT NULL,
    base FLOAT NOT NULL,
    altura FLOAT NOT NULL,
    FOREIGN KEY (id_Poligon) REFERENCES Poligons(id_Poligon)
);

CREATE TABLE Rombes (
    id_Rombe INT IDENTITY(1,1) PRIMARY KEY,
    id_Poligon INT NOT NULL,
    nom NVARCHAR(50) NOT NULL,
    diagonal_mayor FLOAT NOT NULL,
    diagonal_menor FLOAT NOT NULL,
    FOREIGN KEY (id_Poligon) REFERENCES Poligons(id_Poligon)
);

CREATE TABLE Pentagons (
    id_Pentagon INT IDENTITY(1,1) PRIMARY KEY,
    id_Poligon INT NOT NULL,
    nom NVARCHAR(50) NOT NULL,
    lado FLOAT NOT NULL,
    apotema FLOAT NOT NULL,
    FOREIGN KEY (id_Poligon) REFERENCES Poligons(id_Poligon)
);

CREATE TABLE Hexagons (
    id_Hexagon INT IDENTITY(1,1) PRIMARY KEY,
    id_Poligon INT NOT NULL,
    nom NVARCHAR(50) NOT NULL,
    lado FLOAT NOT NULL,
    apotema FLOAT NOT NULL,
    FOREIGN KEY (id_Poligon) REFERENCES Poligons(id_Poligon)
);

CREATE TABLE Octagons (
    id_Octagon INT IDENTITY(1,1) PRIMARY KEY,
    id_Poligon INT NOT NULL,
    nom NVARCHAR(50) NOT NULL,
    lado FLOAT NOT NULL,
    apotema FLOAT NOT NULL,
    FOREIGN KEY (id_Poligon) REFERENCES Poligons(id_Poligon)
);
