USE [photog_recovery]
GO
/****** Object:  StoredProcedure [dbo].[RESTORE_AZURE_BLOB]    Script Date: 27/1/2021 11:01:15 AM ******/
DROP PROCEDURE [dbo].[RESTORE_AZURE_BLOB]
GO
/****** Object:  StoredProcedure [dbo].[BACKUP_AZURE_BLOB]    Script Date: 27/1/2021 11:01:15 AM ******/
DROP PROCEDURE [dbo].[BACKUP_AZURE_BLOB]
GO
USE [master]
GO
/****** Object:  Database [photog_recovery]    Script Date: 27/1/2021 11:01:15 AM ******/
DROP DATABASE [photog_recovery]
GO
/****** Object:  Database [photog_recovery]    Script Date: 27/1/2021 11:01:15 AM ******/
CREATE DATABASE [photog_recovery]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'photog_recovery', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\photog_recovery.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'photog_recovery_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\photog_recovery_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [photog_recovery] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [photog_recovery].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [photog_recovery] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [photog_recovery] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [photog_recovery] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [photog_recovery] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [photog_recovery] SET ARITHABORT OFF 
GO
ALTER DATABASE [photog_recovery] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [photog_recovery] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [photog_recovery] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [photog_recovery] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [photog_recovery] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [photog_recovery] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [photog_recovery] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [photog_recovery] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [photog_recovery] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [photog_recovery] SET  DISABLE_BROKER 
GO
ALTER DATABASE [photog_recovery] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [photog_recovery] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [photog_recovery] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [photog_recovery] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [photog_recovery] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [photog_recovery] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [photog_recovery] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [photog_recovery] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [photog_recovery] SET  MULTI_USER 
GO
ALTER DATABASE [photog_recovery] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [photog_recovery] SET DB_CHAINING OFF 
GO
ALTER DATABASE [photog_recovery] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [photog_recovery] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [photog_recovery] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [photog_recovery] SET QUERY_STORE = OFF
GO
USE [photog_recovery]
GO
/****** Object:  StoredProcedure [dbo].[BACKUP_AZURE_BLOB]    Script Date: 27/1/2021 11:01:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[BACKUP_AZURE_BLOB]
AS
DECLARE @url nvarchar(max)
BEGIN
	IF NOT EXISTS (SELECT * FROM sys.credentials WHERE name = 'AzurePhotogCred')
	CREATE CREDENTIAL AzurePhotogCred
	WITH IDENTITY='storagephotog2', SECRET='sNjEcjfWSLVSLiNeaZ3NMdB+rvehO4Obhcw5Y5yJR7OvLMnbIuVf5nWzDsyNie+4wSbYHZVKfdEruYIi13tvAw==';

	SET @url = N'https://storagephotog2.blob.core.windows.net/db-backup/' + CONVERT(NVARCHAR(MAX),SYSDATETIME())  + '.bak'

	--IF NOT EXISTS (SELECT * FROM sys.credentials WHERE name = 'https://photogstorage2.blob.core.windows.net/db-backup')
	--BEGIN
	--	CREATE CREDENTIAL [https://photogstorage2.blob.core.windows.net/db-backup]
	--	WITH IDENTITY = 'SHARED ACCESS SIGNATURE',
	--	SECRET = 'sv=2019-12-12&ss=bfqt&srt=sco&sp=rwdlacupx&se=2021-12-11T01:56:09Z&st=2021-01-14T17:56:09Z&spr=https,http&sig=AJHbLPu2y2nrLR%2F%2FYPG5QAa5RtbFj68r66dej5UXyKQ%3D'
	--END

	BACKUP DATABASE photog  
	TO URL = @url
     WITH CREDENTIAL = 'AzurePhotogCred';
END
GO
/****** Object:  StoredProcedure [dbo].[RESTORE_AZURE_BLOB]    Script Date: 27/1/2021 11:01:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[RESTORE_AZURE_BLOB]
(@url nvarchar(max))
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM sys.credentials WHERE name = 'AzurePhotogCred')
	CREATE CREDENTIAL AzurePhotogCred
	WITH IDENTITY='storagephotog2', SECRET='sNjEcjfWSLVSLiNeaZ3NMdB+rvehO4Obhcw5Y5yJR7OvLMnbIuVf5nWzDsyNie+4wSbYHZVKfdEruYIi13tvAw==';

	--IF NOT EXISTS (SELECT * FROM sys.credentials WHERE name = 'https://photogstorage2.blob.core.windows.net/db-backup')
	--BEGIN
	--	CREATE CREDENTIAL [https://photogstorage2.blob.core.windows.net/db-backup]
	--	WITH IDENTITY = 'SHARED ACCESS SIGNATURE',
	--	SECRET = 'sv=2019-12-12&ss=bfqt&srt=sco&sp=rwdlacupx&se=2021-12-11T01:56:09Z&st=2021-01-14T17:56:09Z&spr=https,http&sig=AJHbLPu2y2nrLR%2F%2FYPG5QAa5RtbFj68r66dej5UXyKQ%3D'
	--END

	--ALTER DATABASE photog
	--SET SINGLE_USER
	--	--This rolls back all uncommitted transactions in the db.
	--WITH ROLLBACK IMMEDIATE

alter database photog
set offline with rollback immediate

	DROP DATABASE photog
	RESTORE DATABASE photog  
	FROM URL = @url
	WITH CREDENTIAL = 'AzurePhotogCred'	,
	REPLACE;


	  alter database photog
  set online
END
GO
USE [master]
GO
ALTER DATABASE [photog_recovery] SET  READ_WRITE 
GO
