USE master
GO

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'TestTemplate12Db')
BEGIN
  CREATE DATABASE TestTemplate12Db;
END;
GO

USE TestTemplate12Db;
GO

IF NOT EXISTS (SELECT 1
                 FROM sys.server_principals
                WHERE [name] = N'TestTemplate12Db_Login' 
                  AND [type] IN ('C','E', 'G', 'K', 'S', 'U'))
BEGIN
    CREATE LOGIN TestTemplate12Db_Login
        WITH PASSWORD = '<DB_PASSWORD>';
END;
GO  

IF NOT EXISTS (select * from sys.database_principals where name = 'TestTemplate12Db_User')
BEGIN
    CREATE USER TestTemplate12Db_User FOR LOGIN TestTemplate12Db_Login;
END;
GO  


EXEC sp_addrolemember N'db_datareader', N'TestTemplate12Db_User';
GO

EXEC sp_addrolemember N'db_datawriter', N'TestTemplate12Db_User';
GO

EXEC sp_addrolemember N'db_ddladmin', N'TestTemplate12Db_User';
GO
