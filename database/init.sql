IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'PruebaSD')
BEGIN
    CREATE DATABASE PruebaSD
END
GO

USE PruebaSD
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Usuario' AND xtype='U')
BEGIN
    CREATE TABLE Usuario (
        usuID NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1),
        nombre VARCHAR(100) NOT NULL,
        apellido VARCHAR(100) NOT NULL
    )
END
GO

IF NOT EXISTS (SELECT * FROM Usuario)
BEGIN
    INSERT INTO Usuario (nombre, apellido) VALUES
    ('Andres', 'Rodriguez Vera'),
    ('Jose', 'Giraldo Perez'),
    ('Luis Enrique', 'Guerrero'),
    ('Elena', 'Martinez'),
    ('Carlos', 'Sanchez')
END
GO