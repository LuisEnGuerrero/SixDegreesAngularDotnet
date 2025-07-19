USE PruebaSD
GO
CREATE USER [sa] FOR LOGIN [sa]
GO
EXEC sp_addrolemember 'db_owner', 'sa'
GO