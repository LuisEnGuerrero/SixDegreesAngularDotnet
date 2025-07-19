USE PruebaSD
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Usuario' and xtype='U')
BEGIN
    CREATE TABLE Usuario (
        usuID NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1),
        nombre VARCHAR(100) NOT NULL,
        apellido VARCHAR(100) NOT NULL
    )
END
GO