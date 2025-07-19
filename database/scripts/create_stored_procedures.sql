USE PruebaSD
GO

IF OBJECT_ID('GetUsuarios', 'P') IS NOT NULL
    DROP PROCEDURE GetUsuarios
GO

CREATE PROCEDURE GetUsuarios
AS
BEGIN
    SELECT usuID, nombre, apellido FROM Usuario
END
GO

IF OBJECT_ID('GetUsuarioById', 'P') IS NOT NULL
    DROP PROCEDURE GetUsuarioById
GO

CREATE PROCEDURE GetUsuarioById
    @usuID NUMERIC(18,0)
AS
BEGIN
    SELECT usuID, nombre, apellido FROM Usuario WHERE usuID = @usuID
END
GO