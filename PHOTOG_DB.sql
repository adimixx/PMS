USE [photog]
GO
/****** Object:  StoredProcedure [dbo].[SELECT_REMOTE_TBL]    Script Date: 27/1/2021 10:59:54 AM ******/
DROP PROCEDURE [dbo].[SELECT_REMOTE_TBL]
GO
/****** Object:  StoredProcedure [dbo].[SELECT_LOCAL_TBL]    Script Date: 27/1/2021 10:59:54 AM ******/
DROP PROCEDURE [dbo].[SELECT_LOCAL_TBL]
GO
/****** Object:  StoredProcedure [dbo].[RESTORE_LOCAL]    Script Date: 27/1/2021 10:59:54 AM ******/
DROP PROCEDURE [dbo].[RESTORE_LOCAL]
GO
/****** Object:  StoredProcedure [dbo].[ON_CONSTR_LOCAL]    Script Date: 27/1/2021 10:59:54 AM ******/
DROP PROCEDURE [dbo].[ON_CONSTR_LOCAL]
GO
/****** Object:  StoredProcedure [dbo].[OFF_CONSTR_REMOTE]    Script Date: 27/1/2021 10:59:54 AM ******/
DROP PROCEDURE [dbo].[OFF_CONSTR_REMOTE]
GO
/****** Object:  StoredProcedure [dbo].[OFF_CONSTR_LOCAL]    Script Date: 27/1/2021 10:59:54 AM ******/
DROP PROCEDURE [dbo].[OFF_CONSTR_LOCAL]
GO
/****** Object:  StoredProcedure [dbo].[GENERATE_OBJ_ID]    Script Date: 27/1/2021 10:59:54 AM ******/
DROP PROCEDURE [dbo].[GENERATE_OBJ_ID]
GO
/****** Object:  StoredProcedure [dbo].[GENERATE_CONSTRAINT]    Script Date: 27/1/2021 10:59:54 AM ******/
DROP PROCEDURE [dbo].[GENERATE_CONSTRAINT]
GO
/****** Object:  StoredProcedure [dbo].[FROMLOCAL_GENERATE_FK]    Script Date: 27/1/2021 10:59:54 AM ******/
DROP PROCEDURE [dbo].[FROMLOCAL_GENERATE_FK]
GO
/****** Object:  StoredProcedure [dbo].[FROMLOCAL_GENERATE_CONSTRAINT]    Script Date: 27/1/2021 10:59:54 AM ******/
DROP PROCEDURE [dbo].[FROMLOCAL_GENERATE_CONSTRAINT]
GO
/****** Object:  StoredProcedure [dbo].[FROMCLOUD_GENERATE_FK]    Script Date: 27/1/2021 10:59:54 AM ******/
DROP PROCEDURE [dbo].[FROMCLOUD_GENERATE_FK]
GO
/****** Object:  StoredProcedure [dbo].[FROMCLOUD_GENERATE_CONSTRAINT]    Script Date: 27/1/2021 10:59:54 AM ******/
DROP PROCEDURE [dbo].[FROMCLOUD_GENERATE_CONSTRAINT]
GO
/****** Object:  StoredProcedure [dbo].[DROP_REMOTE_TBL]    Script Date: 27/1/2021 10:59:54 AM ******/
DROP PROCEDURE [dbo].[DROP_REMOTE_TBL]
GO
/****** Object:  StoredProcedure [dbo].[DROP_LOCAL_TBL]    Script Date: 27/1/2021 10:59:54 AM ******/
DROP PROCEDURE [dbo].[DROP_LOCAL_TBL]
GO
/****** Object:  StoredProcedure [dbo].[CREATE_TBL_FROM_LOCAL]    Script Date: 27/1/2021 10:59:54 AM ******/
DROP PROCEDURE [dbo].[CREATE_TBL_FROM_LOCAL]
GO
/****** Object:  StoredProcedure [dbo].[CREATE_TBL_FROM_CLOUD]    Script Date: 27/1/2021 10:59:54 AM ******/
DROP PROCEDURE [dbo].[CREATE_TBL_FROM_CLOUD]
GO
/****** Object:  StoredProcedure [dbo].[BACKUP_AZURE_BLOB]    Script Date: 27/1/2021 10:59:54 AM ******/
DROP PROCEDURE [dbo].[BACKUP_AZURE_BLOB]
GO
/****** Object:  StoredProcedure [dbo].[BACKUP_AZURE]    Script Date: 27/1/2021 10:59:54 AM ******/
DROP PROCEDURE [dbo].[BACKUP_AZURE]
GO
ALTER TABLE [dbo].[UserSystemRole] DROP CONSTRAINT [FK__UserSyste__useri__40F9A68C]
GO
ALTER TABLE [dbo].[UserSystemRole] DROP CONSTRAINT [FK__UserSyste__syste__1AD3FDA4]
GO
ALTER TABLE [dbo].[UserStudio] DROP CONSTRAINT [FK__UserStudi__useri__3F115E1A]
GO
ALTER TABLE [dbo].[UserStudio] DROP CONSTRAINT [FK__UserStudi__studi__3D2915A8]
GO
ALTER TABLE [dbo].[UserStudio] DROP CONSTRAINT [FK__UserStudi__studi__18EBB532]
GO
ALTER TABLE [dbo].[Transaction] DROP CONSTRAINT [FK__Transacti__payme__17036CC0]
GO
ALTER TABLE [dbo].[Transaction] DROP CONSTRAINT [FK__Transacti__invoi__160F4887]
GO
ALTER TABLE [dbo].[StudioLink] DROP CONSTRAINT [FK__StudioLin__studi__395884C4]
GO
ALTER TABLE [dbo].[PackageImage] DROP CONSTRAINT [FK__PackageIm__Packa__14270015]
GO
ALTER TABLE [dbo].[Package] DROP CONSTRAINT [FK__Package__studioi__3864608B]
GO
ALTER TABLE [dbo].[JobDateUser] DROP CONSTRAINT [FK__JobDateUs__users__11E05B9E]
GO
ALTER TABLE [dbo].[JobDateUser] DROP CONSTRAINT [FK__JobDateUs__jobda__114A936A]
GO
ALTER TABLE [dbo].[JobDate] DROP CONSTRAINT [FK__JobDate__jobstat__10566F31]
GO
ALTER TABLE [dbo].[JobDate] DROP CONSTRAINT [FK__JobDate__jobid__3493CFA7]
GO
ALTER TABLE [dbo].[JobCharges] DROP CONSTRAINT [FK__JobCharge__jobid__339FAB6E]
GO
ALTER TABLE [dbo].[Job] DROP CONSTRAINT [FK__Job__userid__31B762FC]
GO
ALTER TABLE [dbo].[Job] DROP CONSTRAINT [FK__Job__packageid__30C33EC3]
GO
ALTER TABLE [dbo].[Job] DROP CONSTRAINT [FK__Job__jobstatusid__2FCF1A8A]
GO
ALTER TABLE [dbo].[Invoice] DROP CONSTRAINT [FK__Invoice__jobid__2EDAF651]
GO
ALTER TABLE [dbo].[ChatKey] DROP CONSTRAINT [FK_ChatKey_User]
GO
ALTER TABLE [dbo].[ChatKey] DROP CONSTRAINT [FK_ChatKey_Studio]
GO
ALTER TABLE [dbo].[Charges] DROP CONSTRAINT [FK_Charges_Studio]
GO
ALTER TABLE [dbo].[Package] DROP CONSTRAINT [DF__Package__status__1DB06A4F]
GO
/****** Object:  Index [uc_usersystemrole]    Script Date: 27/1/2021 10:59:54 AM ******/
ALTER TABLE [dbo].[UserSystemRole] DROP CONSTRAINT [uc_usersystemrole]
GO
/****** Object:  Index [uc_userstudio]    Script Date: 27/1/2021 10:59:54 AM ******/
ALTER TABLE [dbo].[UserStudio] DROP CONSTRAINT [uc_userstudio]
GO
/****** Object:  Index [UQ__User__AB6E61640D7A5532]    Script Date: 27/1/2021 10:59:54 AM ******/
ALTER TABLE [dbo].[User] DROP CONSTRAINT [UQ__User__AB6E61640D7A5532]
GO
/****** Object:  Index [UQ__SystemRo__72E12F1BA7DD3064]    Script Date: 27/1/2021 10:59:54 AM ******/
ALTER TABLE [dbo].[SystemRole] DROP CONSTRAINT [UQ__SystemRo__72E12F1BA7DD3064]
GO
/****** Object:  Index [UQ__StudioRo__72E12F1B59457F0F]    Script Date: 27/1/2021 10:59:54 AM ******/
ALTER TABLE [dbo].[StudioRole] DROP CONSTRAINT [UQ__StudioRo__72E12F1B59457F0F]
GO
/****** Object:  Index [UQ__Studio__3E7228C41578A8D0]    Script Date: 27/1/2021 10:59:54 AM ******/
ALTER TABLE [dbo].[Studio] DROP CONSTRAINT [UQ__Studio__3E7228C41578A8D0]
GO
/****** Object:  Index [UQ__PaymentM__72E12F1B24245977]    Script Date: 27/1/2021 10:59:54 AM ******/
ALTER TABLE [dbo].[PaymentMethod] DROP CONSTRAINT [UQ__PaymentM__72E12F1B24245977]
GO
/****** Object:  Index [UQ__JobStatu__72E12F1B3C8BB635]    Script Date: 27/1/2021 10:59:54 AM ******/
ALTER TABLE [dbo].[JobStatus] DROP CONSTRAINT [UQ__JobStatu__72E12F1B3C8BB635]
GO
/****** Object:  Index [uc_JobDateUser]    Script Date: 27/1/2021 10:59:54 AM ******/
ALTER TABLE [dbo].[JobDateUser] DROP CONSTRAINT [uc_JobDateUser]
GO
/****** Object:  Table [dbo].[UserSystemRole]    Script Date: 27/1/2021 10:59:54 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserSystemRole]') AND type in (N'U'))
DROP TABLE [dbo].[UserSystemRole]
GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 27/1/2021 10:59:54 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Transaction]') AND type in (N'U'))
DROP TABLE [dbo].[Transaction]
GO
/****** Object:  Table [dbo].[SystemRole]    Script Date: 27/1/2021 10:59:54 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SystemRole]') AND type in (N'U'))
DROP TABLE [dbo].[SystemRole]
GO
/****** Object:  Table [dbo].[StudioRole]    Script Date: 27/1/2021 10:59:54 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudioRole]') AND type in (N'U'))
DROP TABLE [dbo].[StudioRole]
GO
/****** Object:  Table [dbo].[StudioLink]    Script Date: 27/1/2021 10:59:54 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StudioLink]') AND type in (N'U'))
DROP TABLE [dbo].[StudioLink]
GO
/****** Object:  Table [dbo].[Studio]    Script Date: 27/1/2021 10:59:54 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Studio]') AND type in (N'U'))
DROP TABLE [dbo].[Studio]
GO
/****** Object:  Table [dbo].[PaymentMethod]    Script Date: 27/1/2021 10:59:54 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PaymentMethod]') AND type in (N'U'))
DROP TABLE [dbo].[PaymentMethod]
GO
/****** Object:  Table [dbo].[PackageImage]    Script Date: 27/1/2021 10:59:54 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PackageImage]') AND type in (N'U'))
DROP TABLE [dbo].[PackageImage]
GO
/****** Object:  Table [dbo].[JobStatus]    Script Date: 27/1/2021 10:59:54 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JobStatus]') AND type in (N'U'))
DROP TABLE [dbo].[JobStatus]
GO
/****** Object:  Table [dbo].[JobDate]    Script Date: 27/1/2021 10:59:54 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JobDate]') AND type in (N'U'))
DROP TABLE [dbo].[JobDate]
GO
/****** Object:  Table [dbo].[JobCharges]    Script Date: 27/1/2021 10:59:54 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JobCharges]') AND type in (N'U'))
DROP TABLE [dbo].[JobCharges]
GO
/****** Object:  Table [dbo].[ChatKey]    Script Date: 27/1/2021 10:59:54 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChatKey]') AND type in (N'U'))
DROP TABLE [dbo].[ChatKey]
GO
/****** Object:  Table [dbo].[Charges]    Script Date: 27/1/2021 10:59:54 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Charges]') AND type in (N'U'))
DROP TABLE [dbo].[Charges]
GO
/****** Object:  UserDefinedFunction [dbo].[beststaff]    Script Date: 27/1/2021 10:59:54 AM ******/
DROP FUNCTION [dbo].[beststaff]
GO
/****** Object:  Table [dbo].[UserStudio]    Script Date: 27/1/2021 10:59:54 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserStudio]') AND type in (N'U'))
DROP TABLE [dbo].[UserStudio]
GO
/****** Object:  Table [dbo].[JobDateUser]    Script Date: 27/1/2021 10:59:54 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JobDateUser]') AND type in (N'U'))
DROP TABLE [dbo].[JobDateUser]
GO
/****** Object:  Table [dbo].[User]    Script Date: 27/1/2021 10:59:54 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
DROP TABLE [dbo].[User]
GO
/****** Object:  UserDefinedFunction [dbo].[bestpackage]    Script Date: 27/1/2021 10:59:54 AM ******/
DROP FUNCTION [dbo].[bestpackage]
GO
/****** Object:  Table [dbo].[Package]    Script Date: 27/1/2021 10:59:54 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Package]') AND type in (N'U'))
DROP TABLE [dbo].[Package]
GO
/****** Object:  Table [dbo].[Job]    Script Date: 27/1/2021 10:59:54 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Job]') AND type in (N'U'))
DROP TABLE [dbo].[Job]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 27/1/2021 10:59:54 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Invoice]') AND type in (N'U'))
DROP TABLE [dbo].[Invoice]
GO
/****** Object:  Schema [HangFire]    Script Date: 27/1/2021 10:59:54 AM ******/
DROP SCHEMA [HangFire]
GO
USE [master]
GO
/****** Object:  Database [photog]    Script Date: 27/1/2021 10:59:54 AM ******/
DROP DATABASE [photog]
GO
/****** Object:  Database [photog]    Script Date: 27/1/2021 10:59:54 AM ******/
CREATE DATABASE [photog]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'photog', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\photog.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'photog_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\photog_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [photog] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [photog].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [photog] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [photog] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [photog] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [photog] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [photog] SET ARITHABORT OFF 
GO
ALTER DATABASE [photog] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [photog] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [photog] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [photog] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [photog] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [photog] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [photog] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [photog] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [photog] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [photog] SET  DISABLE_BROKER 
GO
ALTER DATABASE [photog] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [photog] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [photog] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [photog] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [photog] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [photog] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [photog] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [photog] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [photog] SET  MULTI_USER 
GO
ALTER DATABASE [photog] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [photog] SET DB_CHAINING OFF 
GO
ALTER DATABASE [photog] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [photog] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [photog] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [photog] SET QUERY_STORE = OFF
GO
USE [photog]
GO
/****** Object:  Schema [HangFire]    Script Date: 27/1/2021 10:59:54 AM ******/
CREATE SCHEMA [HangFire]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 27/1/2021 10:59:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[jobid] [int] NULL,
	[invdate] [datetime] NOT NULL,
	[expirydate] [datetime] NOT NULL,
	[total] [decimal](6, 2) NOT NULL,
	[totalunpaid] [decimal](6, 2) NOT NULL,
	[detail] [nvarchar](50) NULL,
	[status] [nvarchar](50) NULL,
 CONSTRAINT [PK__Invoice__3213E83F4032058D] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Job]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Job](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[packageid] [int] NOT NULL,
	[userid] [int] NOT NULL,
	[jobstatusid] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[paymentstatus] [nvarchar](50) NULL,
	[PackagePrice] [decimal](6, 2) NOT NULL,
	[TotalPrice] [decimal](6, 2) NOT NULL,
 CONSTRAINT [PK__Job__3213E83FEAEA9ED4] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Package]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Package](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[studioid] [int] NULL,
	[name] [nvarchar](50) NOT NULL,
	[price] [decimal](6, 2) NOT NULL,
	[depositprice] [decimal](6, 2) NOT NULL,
	[details] [nvarchar](100) NULL,
	[status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__Package__3213E83FE25ABCA0] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[bestpackage]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    FUNCTION [dbo].[bestpackage] (@studioid int)

RETURNS TABLE 
AS
RETURN 
(

SELECT        TOP (100) PERCENT dbo.Package.name AS package, SUM(invoice.total) AS 'quantity'
FROM            dbo.Package INNER JOIN
                         dbo.Job ON dbo.Package.id = dbo.Job.packageid INNER JOIN
                         dbo.Invoice ON dbo.Job.id = dbo.Invoice.jobid
WHERE        (dbo.Package.studioid = @studioid)
GROUP BY dbo.Package.name
ORDER BY 'quantity' DESC
)
GO
/****** Object:  Table [dbo].[User]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
	[name] [nvarchar](100) NULL,
	[dateofbirth] [datetime] NULL,
	[phonenumber] [nvarchar](50) NULL,
	[imgprofile] [nvarchar](255) NULL,
	[isVerified] [bit] NOT NULL,
	[verifiedKey] [nvarchar](max) NULL,
	[emailTemp] [nvarchar](50) NULL,
	[isForgotPassword] [bit] NOT NULL,
 CONSTRAINT [PK__User__3213E83F14BFA05E] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobDateUser]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobDateUser](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[jobdateid] [int] NULL,
	[userstudioid] [int] NULL,
	[charge] [decimal](6, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserStudio]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserStudio](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[studioid] [int] NULL,
	[userid] [int] NULL,
	[studioroleid] [int] NULL,
	[isActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[beststaff]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create     FUNCTION [dbo].[beststaff] (@studioid int)

RETURNS TABLE 
AS
RETURN 
(
SELECT        dbo.[User].name, dbo.[User].id, COUNT(dbo.JobDateUser.id) AS times
FROM            dbo.JobDateUser INNER JOIN
                         dbo.UserStudio ON dbo.JobDateUser.userstudioid = dbo.UserStudio.id INNER JOIN
                         dbo.[User] ON dbo.UserStudio.userid = dbo.[User].id
WHERE        (dbo.UserStudio.studioid = @studioid)
GROUP BY dbo.[User].name, dbo.[User].id
)
GO
/****** Object:  Table [dbo].[Charges]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Charges](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[StudioID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[Price] [decimal](6, 2) NULL,
	[Unit] [nvarchar](50) NULL,
 CONSTRAINT [PK__Charges__3213E83FED6BB8A1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChatKey]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatKey](
	[ChatKeyID] [int] IDENTITY(1,1) NOT NULL,
	[ChatKey_Key] [nvarchar](50) NULL,
	[UserID] [int] NULL,
	[StudioID] [int] NULL,
 CONSTRAINT [PK_ChatKey] PRIMARY KEY CLUSTERED 
(
	[ChatKeyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobCharges]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobCharges](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[jobid] [int] NULL,
	[amount] [decimal](6, 2) NOT NULL,
	[remarks] [nvarchar](255) NULL,
 CONSTRAINT [PK__JobCharg__3213E83F033F51FE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobDate]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobDate](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[jobid] [int] NULL,
	[jobdate] [datetime] NOT NULL,
	[location] [nvarchar](100) NOT NULL,
	[description] [nvarchar](100) NULL,
	[jobstatusid] [int] NULL,
 CONSTRAINT [PK__JobDate__3213E83F91C63BC3] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobStatus]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobStatus](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__JobStatu__3213E83FC3D97965] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PackageImage]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackageImage](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ImageName] [nvarchar](max) NOT NULL,
	[PackageID] [int] NOT NULL,
	[IsCoverPhoto] [bit] NULL,
 CONSTRAINT [PK__PackageI__3214EC27F4692120] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentMethod]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentMethod](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__PaymentM__3213E83FA8CB40E8] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Studio]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Studio](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[uniquename] [nvarchar](20) NOT NULL,
	[State] [nvarchar](100) NULL,
	[City] [nvarchar](100) NULL,
	[ImgLogo] [nvarchar](max) NULL,
	[ImgCover] [nvarchar](max) NULL,
	[shortDesc] [nvarchar](50) NULL,
	[longDesc] [nvarchar](500) NULL,
	[phoneNum] [nvarchar](12) NULL,
	[email] [nvarchar](50) NULL,
 CONSTRAINT [PK__Studio__3213E83F33A26060] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudioLink]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudioLink](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[address] [nvarchar](250) NOT NULL,
	[studioid] [int] NULL,
 CONSTRAINT [PK__StudioLi__3213E83F93A400B8] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudioRole]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudioRole](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__StudioRo__3213E83F13A4A576] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemRole]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemRole](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__SystemRo__3213E83FDBC6E71C] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[transdate] [datetime] NOT NULL,
	[total] [decimal](6, 2) NOT NULL,
	[invoiceid] [int] NULL,
	[paymentmethodid] [int] NULL,
	[reference] [nvarchar](100) NULL,
 CONSTRAINT [PK__Transact__3213E83F84932ACA] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserSystemRole]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSystemRole](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[systemroleid] [int] NULL,
	[userid] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Charges] ON 
GO
INSERT [dbo].[Charges] ([id], [StudioID], [Name], [Description], [Price], [Unit]) VALUES (2, 2, N'Travel Fees', N'Required Based on Kilometer Count', CAST(2.20 AS Decimal(6, 2)), N'KM        ')
GO
INSERT [dbo].[Charges] ([id], [StudioID], [Name], [Description], [Price], [Unit]) VALUES (3, 2, N'Extra Hours', N'Add hours to shooting sessions', CAST(51.00 AS Decimal(6, 2)), N'Hour      ')
GO
INSERT [dbo].[Charges] ([id], [StudioID], [Name], [Description], [Price], [Unit]) VALUES (5, 2, N'Extra Photographer Charge', NULL, CAST(300.60 AS Decimal(6, 2)), N'Photog    ')
GO
INSERT [dbo].[Charges] ([id], [StudioID], [Name], [Description], [Price], [Unit]) VALUES (9, 8, N'Extra Photographer', N'Tambah Photographer', CAST(900.00 AS Decimal(6, 2)), N'Person    ')
GO
INSERT [dbo].[Charges] ([id], [StudioID], [Name], [Description], [Price], [Unit]) VALUES (11, 8, N'Fuel Charges', N'Kira Minyak', CAST(3.00 AS Decimal(6, 2)), N'KM        ')
GO
INSERT [dbo].[Charges] ([id], [StudioID], [Name], [Description], [Price], [Unit]) VALUES (12, 9, N'charge name', N' ', CAST(1000.00 AS Decimal(6, 2)), N'1         ')
GO
INSERT [dbo].[Charges] ([id], [StudioID], [Name], [Description], [Price], [Unit]) VALUES (13, 9, N'charge name 2', N'                              ', CAST(200.00 AS Decimal(6, 2)), NULL)
GO
INSERT [dbo].[Charges] ([id], [StudioID], [Name], [Description], [Price], [Unit]) VALUES (14, 8, N'Accomodation', N'For long trips shoot', NULL, N'2         ')
GO
INSERT [dbo].[Charges] ([id], [StudioID], [Name], [Description], [Price], [Unit]) VALUES (16, 25, N'Kilometer', N'harga per kilometer', CAST(10.00 AS Decimal(6, 2)), N'1')
GO
INSERT [dbo].[Charges] ([id], [StudioID], [Name], [Description], [Price], [Unit]) VALUES (17, 3, N'Photobook', NULL, CAST(250.00 AS Decimal(6, 2)), N'Book')
GO
INSERT [dbo].[Charges] ([id], [StudioID], [Name], [Description], [Price], [Unit]) VALUES (18, 3, N'Softcopy Photobook (20 Pages)', NULL, CAST(100.00 AS Decimal(6, 2)), N'20 Pages')
GO
INSERT [dbo].[Charges] ([id], [StudioID], [Name], [Description], [Price], [Unit]) VALUES (19, 3, N'Softcopy Photobook (40 Pages)', NULL, CAST(200.00 AS Decimal(6, 2)), N'40 Pages')
GO
INSERT [dbo].[Charges] ([id], [StudioID], [Name], [Description], [Price], [Unit]) VALUES (20, 3, N'Extra Photographer', NULL, CAST(350.00 AS Decimal(6, 2)), N'photog')
GO
INSERT [dbo].[Charges] ([id], [StudioID], [Name], [Description], [Price], [Unit]) VALUES (21, 3, N'Extra Videographer', NULL, CAST(600.00 AS Decimal(6, 2)), N'Videog')
GO
SET IDENTITY_INSERT [dbo].[Charges] OFF
GO
SET IDENTITY_INSERT [dbo].[ChatKey] ON 
GO
INSERT [dbo].[ChatKey] ([ChatKeyID], [ChatKey_Key], [UserID], [StudioID]) VALUES (64, N'studiokey2userkey5', 5, 2)
GO
INSERT [dbo].[ChatKey] ([ChatKeyID], [ChatKey_Key], [UserID], [StudioID]) VALUES (65, N'studiokey8userkey2', 2, 8)
GO
INSERT [dbo].[ChatKey] ([ChatKeyID], [ChatKey_Key], [UserID], [StudioID]) VALUES (67, N'studiokey6userkey2', 2, 6)
GO
INSERT [dbo].[ChatKey] ([ChatKeyID], [ChatKey_Key], [UserID], [StudioID]) VALUES (68, N'studiokey2userkey17', 17, 2)
GO
INSERT [dbo].[ChatKey] ([ChatKeyID], [ChatKey_Key], [UserID], [StudioID]) VALUES (69, N'studiokey3userkey3', 3, 3)
GO
INSERT [dbo].[ChatKey] ([ChatKeyID], [ChatKey_Key], [UserID], [StudioID]) VALUES (70, N'studiokey4userkey2', 2, 4)
GO
INSERT [dbo].[ChatKey] ([ChatKeyID], [ChatKey_Key], [UserID], [StudioID]) VALUES (71, N'studiokey3userkey20', 20, 3)
GO
SET IDENTITY_INSERT [dbo].[ChatKey] OFF
GO
SET IDENTITY_INSERT [dbo].[Invoice] ON 
GO
INSERT [dbo].[Invoice] ([id], [jobid], [invdate], [expirydate], [total], [totalunpaid], [detail], [status]) VALUES (29, 22, CAST(N'2021-01-19T14:41:00.977' AS DateTime), CAST(N'2021-04-19T14:41:00.977' AS DateTime), CAST(500.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(6, 2)), N'Deposit', N'Paid')
GO
INSERT [dbo].[Invoice] ([id], [jobid], [invdate], [expirydate], [total], [totalunpaid], [detail], [status]) VALUES (31, 24, CAST(N'2021-01-19T14:52:38.533' AS DateTime), CAST(N'2021-04-19T14:52:38.533' AS DateTime), CAST(1900.00 AS Decimal(6, 2)), CAST(1900.00 AS Decimal(6, 2)), N'Full Payment', N'Not Paid')
GO
INSERT [dbo].[Invoice] ([id], [jobid], [invdate], [expirydate], [total], [totalunpaid], [detail], [status]) VALUES (32, 24, CAST(N'2021-01-19T14:52:54.920' AS DateTime), CAST(N'2021-04-19T14:52:54.920' AS DateTime), CAST(200.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(6, 2)), N'Deposit', N'Paid')
GO
INSERT [dbo].[Invoice] ([id], [jobid], [invdate], [expirydate], [total], [totalunpaid], [detail], [status]) VALUES (33, 25, CAST(N'2021-01-19T16:10:09.717' AS DateTime), CAST(N'2021-04-19T16:10:09.717' AS DateTime), CAST(80.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(6, 2)), N'Deposit', N'Paid')
GO
INSERT [dbo].[Invoice] ([id], [jobid], [invdate], [expirydate], [total], [totalunpaid], [detail], [status]) VALUES (34, 25, CAST(N'2021-01-19T16:13:39.810' AS DateTime), CAST(N'2021-04-19T16:13:39.810' AS DateTime), CAST(128.80 AS Decimal(6, 2)), CAST(0.80 AS Decimal(6, 2)), N'Full Payment', N'Paid')
GO
INSERT [dbo].[Invoice] ([id], [jobid], [invdate], [expirydate], [total], [totalunpaid], [detail], [status]) VALUES (36, 27, CAST(N'2021-01-20T04:47:12.153' AS DateTime), CAST(N'2021-04-20T12:46:00.000' AS DateTime), CAST(213.20 AS Decimal(6, 2)), CAST(0.00 AS Decimal(6, 2)), N'Full Payment', N'Paid')
GO
INSERT [dbo].[Invoice] ([id], [jobid], [invdate], [expirydate], [total], [totalunpaid], [detail], [status]) VALUES (37, 29, CAST(N'2021-01-21T15:04:05.363' AS DateTime), CAST(N'2021-04-21T15:04:05.363' AS DateTime), CAST(150.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(6, 2)), N'Deposit', N'Paid')
GO
INSERT [dbo].[Invoice] ([id], [jobid], [invdate], [expirydate], [total], [totalunpaid], [detail], [status]) VALUES (39, 29, CAST(N'2021-01-21T16:22:54.300' AS DateTime), CAST(N'2021-04-21T16:22:54.300' AS DateTime), CAST(372.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(6, 2)), N'Full Payment', N'Paid')
GO
INSERT [dbo].[Invoice] ([id], [jobid], [invdate], [expirydate], [total], [totalunpaid], [detail], [status]) VALUES (40, 31, CAST(N'2021-01-22T12:58:47.533' AS DateTime), CAST(N'2021-04-22T12:58:47.533' AS DateTime), CAST(99.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(6, 2)), N'Deposit', N'Paid')
GO
INSERT [dbo].[Invoice] ([id], [jobid], [invdate], [expirydate], [total], [totalunpaid], [detail], [status]) VALUES (41, 32, CAST(N'2021-01-26T11:13:50.813' AS DateTime), CAST(N'2021-04-26T11:13:50.813' AS DateTime), CAST(99.00 AS Decimal(6, 2)), CAST(99.00 AS Decimal(6, 2)), N'Deposit', N'Not Paid')
GO
INSERT [dbo].[Invoice] ([id], [jobid], [invdate], [expirydate], [total], [totalunpaid], [detail], [status]) VALUES (42, 41, CAST(N'2021-01-26T17:23:53.217' AS DateTime), CAST(N'2021-04-26T17:23:53.217' AS DateTime), CAST(100.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(6, 2)), N'Deposit', N'Paid')
GO
SET IDENTITY_INSERT [dbo].[Invoice] OFF
GO
SET IDENTITY_INSERT [dbo].[Job] ON 
GO
INSERT [dbo].[Job] ([id], [packageid], [userid], [jobstatusid], [DateCreated], [paymentstatus], [PackagePrice], [TotalPrice]) VALUES (22, 8, 2, 1, CAST(N'2021-01-19T14:33:52.330' AS DateTime), NULL, CAST(3000.00 AS Decimal(6, 2)), CAST(3900.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[Job] ([id], [packageid], [userid], [jobstatusid], [DateCreated], [paymentstatus], [PackagePrice], [TotalPrice]) VALUES (24, 7, 2, 1, CAST(N'2021-01-19T14:52:30.613' AS DateTime), NULL, CAST(1000.00 AS Decimal(6, 2)), CAST(1900.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[Job] ([id], [packageid], [userid], [jobstatusid], [DateCreated], [paymentstatus], [PackagePrice], [TotalPrice]) VALUES (25, 1, 5, 3, CAST(N'2021-01-19T16:09:13.763' AS DateTime), NULL, CAST(200.00 AS Decimal(6, 2)), CAST(208.80 AS Decimal(6, 2)))
GO
INSERT [dbo].[Job] ([id], [packageid], [userid], [jobstatusid], [DateCreated], [paymentstatus], [PackagePrice], [TotalPrice]) VALUES (26, 8, 2, 6, CAST(N'2021-01-20T11:13:33.870' AS DateTime), NULL, CAST(3000.00 AS Decimal(6, 2)), CAST(3024.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[Job] ([id], [packageid], [userid], [jobstatusid], [DateCreated], [paymentstatus], [PackagePrice], [TotalPrice]) VALUES (27, 1, 3, 1, CAST(N'2021-01-20T12:19:32.683' AS DateTime), NULL, CAST(200.00 AS Decimal(6, 2)), CAST(213.20 AS Decimal(6, 2)))
GO
INSERT [dbo].[Job] ([id], [packageid], [userid], [jobstatusid], [DateCreated], [paymentstatus], [PackagePrice], [TotalPrice]) VALUES (28, 1, 8, 6, CAST(N'2021-01-20T15:52:42.450' AS DateTime), NULL, CAST(340.00 AS Decimal(6, 2)), CAST(340.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[Job] ([id], [packageid], [userid], [jobstatusid], [DateCreated], [paymentstatus], [PackagePrice], [TotalPrice]) VALUES (29, 2, 5, 1, CAST(N'2021-01-21T15:03:35.617' AS DateTime), NULL, CAST(500.00 AS Decimal(6, 2)), CAST(522.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[Job] ([id], [packageid], [userid], [jobstatusid], [DateCreated], [paymentstatus], [PackagePrice], [TotalPrice]) VALUES (30, 9, 2, 6, CAST(N'2021-01-22T12:49:23.473' AS DateTime), NULL, CAST(5000.00 AS Decimal(6, 2)), CAST(5000.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[Job] ([id], [packageid], [userid], [jobstatusid], [DateCreated], [paymentstatus], [PackagePrice], [TotalPrice]) VALUES (31, 1, 5, 1, CAST(N'2021-01-22T12:51:29.793' AS DateTime), NULL, CAST(340.00 AS Decimal(6, 2)), CAST(391.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[Job] ([id], [packageid], [userid], [jobstatusid], [DateCreated], [paymentstatus], [PackagePrice], [TotalPrice]) VALUES (32, 1, 5, 6, CAST(N'2021-01-26T11:13:40.760' AS DateTime), NULL, CAST(340.00 AS Decimal(6, 2)), CAST(340.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[Job] ([id], [packageid], [userid], [jobstatusid], [DateCreated], [paymentstatus], [PackagePrice], [TotalPrice]) VALUES (33, 18, 3, 6, CAST(N'2021-01-26T16:47:07.857' AS DateTime), NULL, CAST(450.00 AS Decimal(6, 2)), CAST(450.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[Job] ([id], [packageid], [userid], [jobstatusid], [DateCreated], [paymentstatus], [PackagePrice], [TotalPrice]) VALUES (34, 18, 3, 6, CAST(N'2021-01-26T16:47:18.093' AS DateTime), NULL, CAST(450.00 AS Decimal(6, 2)), CAST(450.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[Job] ([id], [packageid], [userid], [jobstatusid], [DateCreated], [paymentstatus], [PackagePrice], [TotalPrice]) VALUES (35, 18, 3, 6, CAST(N'2021-01-26T16:47:28.427' AS DateTime), NULL, CAST(450.00 AS Decimal(6, 2)), CAST(450.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[Job] ([id], [packageid], [userid], [jobstatusid], [DateCreated], [paymentstatus], [PackagePrice], [TotalPrice]) VALUES (36, 18, 3, 6, CAST(N'2021-01-26T16:53:55.057' AS DateTime), NULL, CAST(450.00 AS Decimal(6, 2)), CAST(450.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[Job] ([id], [packageid], [userid], [jobstatusid], [DateCreated], [paymentstatus], [PackagePrice], [TotalPrice]) VALUES (37, 18, 3, 6, CAST(N'2021-01-26T16:57:28.230' AS DateTime), NULL, CAST(450.00 AS Decimal(6, 2)), CAST(450.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[Job] ([id], [packageid], [userid], [jobstatusid], [DateCreated], [paymentstatus], [PackagePrice], [TotalPrice]) VALUES (38, 14, 3, 6, CAST(N'2021-01-26T17:00:25.703' AS DateTime), NULL, CAST(450.00 AS Decimal(6, 2)), CAST(450.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[Job] ([id], [packageid], [userid], [jobstatusid], [DateCreated], [paymentstatus], [PackagePrice], [TotalPrice]) VALUES (39, 14, 3, 6, CAST(N'2021-01-26T17:12:36.937' AS DateTime), NULL, CAST(450.00 AS Decimal(6, 2)), CAST(450.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[Job] ([id], [packageid], [userid], [jobstatusid], [DateCreated], [paymentstatus], [PackagePrice], [TotalPrice]) VALUES (40, 17, 3, 6, CAST(N'2021-01-26T17:20:47.570' AS DateTime), NULL, CAST(350.00 AS Decimal(6, 2)), CAST(350.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[Job] ([id], [packageid], [userid], [jobstatusid], [DateCreated], [paymentstatus], [PackagePrice], [TotalPrice]) VALUES (41, 14, 3, 1, CAST(N'2021-01-26T17:21:22.697' AS DateTime), NULL, CAST(450.00 AS Decimal(6, 2)), CAST(450.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[Job] ([id], [packageid], [userid], [jobstatusid], [DateCreated], [paymentstatus], [PackagePrice], [TotalPrice]) VALUES (42, 17, 3, 6, CAST(N'2021-01-26T17:21:21.787' AS DateTime), NULL, CAST(350.00 AS Decimal(6, 2)), CAST(350.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[Job] ([id], [packageid], [userid], [jobstatusid], [DateCreated], [paymentstatus], [PackagePrice], [TotalPrice]) VALUES (43, 17, 3, 6, CAST(N'2021-01-26T17:21:21.780' AS DateTime), NULL, CAST(350.00 AS Decimal(6, 2)), CAST(350.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[Job] ([id], [packageid], [userid], [jobstatusid], [DateCreated], [paymentstatus], [PackagePrice], [TotalPrice]) VALUES (44, 17, 3, 6, CAST(N'2021-01-26T17:24:45.630' AS DateTime), NULL, CAST(350.00 AS Decimal(6, 2)), CAST(350.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[Job] ([id], [packageid], [userid], [jobstatusid], [DateCreated], [paymentstatus], [PackagePrice], [TotalPrice]) VALUES (45, 13, 20, 6, CAST(N'2021-01-27T10:20:43.607' AS DateTime), NULL, CAST(600.00 AS Decimal(6, 2)), CAST(800.00 AS Decimal(6, 2)))
GO
SET IDENTITY_INSERT [dbo].[Job] OFF
GO
SET IDENTITY_INSERT [dbo].[JobCharges] ON 
GO
INSERT [dbo].[JobCharges] ([id], [jobid], [amount], [remarks]) VALUES (17, 22, CAST(900.00 AS Decimal(6, 2)), N'Extra Photographer')
GO
INSERT [dbo].[JobCharges] ([id], [jobid], [amount], [remarks]) VALUES (18, 24, CAST(900.00 AS Decimal(6, 2)), N'Extra Photographer')
GO
INSERT [dbo].[JobCharges] ([id], [jobid], [amount], [remarks]) VALUES (19, 25, CAST(8.80 AS Decimal(6, 2)), N'Travel Fees')
GO
INSERT [dbo].[JobCharges] ([id], [jobid], [amount], [remarks]) VALUES (20, 26, CAST(24.00 AS Decimal(6, 2)), N'Fuel Charges')
GO
INSERT [dbo].[JobCharges] ([id], [jobid], [amount], [remarks]) VALUES (21, 27, CAST(13.20 AS Decimal(6, 2)), N'Travel Fees')
GO
INSERT [dbo].[JobCharges] ([id], [jobid], [amount], [remarks]) VALUES (22, 29, CAST(22.00 AS Decimal(6, 2)), N'Travel Fees')
GO
INSERT [dbo].[JobCharges] ([id], [jobid], [amount], [remarks]) VALUES (23, 31, CAST(51.00 AS Decimal(6, 2)), N'Extra Hours')
GO
INSERT [dbo].[JobCharges] ([id], [jobid], [amount], [remarks]) VALUES (24, 45, CAST(200.00 AS Decimal(6, 2)), N'Softcopy Photobook (20 Pages)')
GO
SET IDENTITY_INSERT [dbo].[JobCharges] OFF
GO
SET IDENTITY_INSERT [dbo].[JobDate] ON 
GO
INSERT [dbo].[JobDate] ([id], [jobid], [jobdate], [location], [description], [jobstatusid]) VALUES (32, 22, CAST(N'2021-01-21T06:33:00.000' AS DateTime), N'Masjid Ampang', NULL, 6)
GO
INSERT [dbo].[JobDate] ([id], [jobid], [jobdate], [location], [description], [jobstatusid]) VALUES (34, 24, CAST(N'2021-01-27T06:52:00.000' AS DateTime), N'Pavilion', NULL, 6)
GO
INSERT [dbo].[JobDate] ([id], [jobid], [jobdate], [location], [description], [jobstatusid]) VALUES (35, 25, CAST(N'2021-01-22T08:09:00.000' AS DateTime), N'Shah Alam', N'Masjid Shah Alam', 6)
GO
INSERT [dbo].[JobDate] ([id], [jobid], [jobdate], [location], [description], [jobstatusid]) VALUES (36, 26, CAST(N'2021-01-22T03:13:00.000' AS DateTime), N'Masjid Andalusia', NULL, 6)
GO
INSERT [dbo].[JobDate] ([id], [jobid], [jobdate], [location], [description], [jobstatusid]) VALUES (37, 27, CAST(N'2021-01-31T01:00:00.000' AS DateTime), N'Shah Alam', NULL, 6)
GO
INSERT [dbo].[JobDate] ([id], [jobid], [jobdate], [location], [description], [jobstatusid]) VALUES (38, 28, CAST(N'2021-01-30T07:52:00.000' AS DateTime), N'Masjid Andalusia', NULL, 6)
GO
INSERT [dbo].[JobDate] ([id], [jobid], [jobdate], [location], [description], [jobstatusid]) VALUES (39, 29, CAST(N'2021-10-11T09:00:00.000' AS DateTime), N'Masjid Shah Alam', NULL, 6)
GO
INSERT [dbo].[JobDate] ([id], [jobid], [jobdate], [location], [description], [jobstatusid]) VALUES (40, 31, CAST(N'2021-01-29T12:51:00.000' AS DateTime), N'Shah Alam', NULL, 6)
GO
INSERT [dbo].[JobDate] ([id], [jobid], [jobdate], [location], [description], [jobstatusid]) VALUES (41, 32, CAST(N'2021-01-28T03:30:00.000' AS DateTime), N'Stadium Shah Alam', NULL, 6)
GO
INSERT [dbo].[JobDate] ([id], [jobid], [jobdate], [location], [description], [jobstatusid]) VALUES (42, 33, CAST(N'2021-01-31T01:00:00.000' AS DateTime), N'masjid putrajaya', NULL, 6)
GO
INSERT [dbo].[JobDate] ([id], [jobid], [jobdate], [location], [description], [jobstatusid]) VALUES (43, 34, CAST(N'2021-01-31T01:00:00.000' AS DateTime), N'masjid putrajaya', NULL, 6)
GO
INSERT [dbo].[JobDate] ([id], [jobid], [jobdate], [location], [description], [jobstatusid]) VALUES (44, 35, CAST(N'2021-01-31T01:00:00.000' AS DateTime), N'masjid putrajaya', NULL, 6)
GO
INSERT [dbo].[JobDate] ([id], [jobid], [jobdate], [location], [description], [jobstatusid]) VALUES (45, 36, CAST(N'2021-01-31T01:00:00.000' AS DateTime), N'masjid putrajaya', NULL, 6)
GO
INSERT [dbo].[JobDate] ([id], [jobid], [jobdate], [location], [description], [jobstatusid]) VALUES (46, 37, CAST(N'2021-01-31T01:00:00.000' AS DateTime), N'masjid putrajaya', NULL, 6)
GO
INSERT [dbo].[JobDate] ([id], [jobid], [jobdate], [location], [description], [jobstatusid]) VALUES (47, 38, CAST(N'2021-01-30T14:00:00.000' AS DateTime), N'Kepala Batas', NULL, 6)
GO
INSERT [dbo].[JobDate] ([id], [jobid], [jobdate], [location], [description], [jobstatusid]) VALUES (48, 39, CAST(N'2021-01-27T09:12:00.000' AS DateTime), N'Shah Alam', NULL, 6)
GO
INSERT [dbo].[JobDate] ([id], [jobid], [jobdate], [location], [description], [jobstatusid]) VALUES (49, 40, CAST(N'2021-01-29T09:20:00.000' AS DateTime), N'Shah Alam ', NULL, 6)
GO
INSERT [dbo].[JobDate] ([id], [jobid], [jobdate], [location], [description], [jobstatusid]) VALUES (50, 41, CAST(N'2021-01-27T09:12:00.000' AS DateTime), N'Shah Alam', NULL, 6)
GO
INSERT [dbo].[JobDate] ([id], [jobid], [jobdate], [location], [description], [jobstatusid]) VALUES (51, 42, CAST(N'2021-01-29T09:20:00.000' AS DateTime), N'Shah Alam ', NULL, 6)
GO
INSERT [dbo].[JobDate] ([id], [jobid], [jobdate], [location], [description], [jobstatusid]) VALUES (52, 43, CAST(N'2021-01-29T09:20:00.000' AS DateTime), N'Shah Alam ', NULL, 6)
GO
INSERT [dbo].[JobDate] ([id], [jobid], [jobdate], [location], [description], [jobstatusid]) VALUES (53, 44, CAST(N'2021-01-29T09:20:00.000' AS DateTime), N'Shah Alam ', NULL, 6)
GO
INSERT [dbo].[JobDate] ([id], [jobid], [jobdate], [location], [description], [jobstatusid]) VALUES (54, 45, CAST(N'2021-01-30T02:20:00.000' AS DateTime), N'Masjid', NULL, 6)
GO
SET IDENTITY_INSERT [dbo].[JobDate] OFF
GO
SET IDENTITY_INSERT [dbo].[JobDateUser] ON 
GO
INSERT [dbo].[JobDateUser] ([id], [jobdateid], [userstudioid], [charge]) VALUES (15, 35, 15, CAST(2.00 AS Decimal(6, 2)))
GO
INSERT [dbo].[JobDateUser] ([id], [jobdateid], [userstudioid], [charge]) VALUES (19, 39, 15, CAST(200.00 AS Decimal(6, 2)))
GO
SET IDENTITY_INSERT [dbo].[JobDateUser] OFF
GO
SET IDENTITY_INSERT [dbo].[JobStatus] ON 
GO
INSERT [dbo].[JobStatus] ([id], [name]) VALUES (3, N'Completed')
GO
INSERT [dbo].[JobStatus] ([id], [name]) VALUES (2, N'Ongoing')
GO
INSERT [dbo].[JobStatus] ([id], [name]) VALUES (1, N'Pending')
GO
INSERT [dbo].[JobStatus] ([id], [name]) VALUES (6, N'Pending Deposit')
GO
SET IDENTITY_INSERT [dbo].[JobStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Package] ON 
GO
INSERT [dbo].[Package] ([id], [studioid], [name], [price], [depositprice], [details], [status]) VALUES (1, 2, N'Wedding Basic', CAST(340.00 AS Decimal(6, 2)), CAST(99.00 AS Decimal(6, 2)), N'Wedding photoshoot at desired place and 30 pages of album.', N'Enabled')
GO
INSERT [dbo].[Package] ([id], [studioid], [name], [price], [depositprice], [details], [status]) VALUES (2, 2, N'Wedding Premium', CAST(500.00 AS Decimal(6, 2)), CAST(150.00 AS Decimal(6, 2)), N'Wedding photoshoot at 2 different desired place and 70 pages of album.', N'Enabled')
GO
INSERT [dbo].[Package] ([id], [studioid], [name], [price], [depositprice], [details], [status]) VALUES (3, 5, N'Convocation', CAST(100.00 AS Decimal(6, 2)), CAST(50.00 AS Decimal(6, 2)), N'Maximum of 100 photo per shooting. Lorem Ipsum is simply dummy text of the printing and typesetting.', N'Enabled')
GO
INSERT [dbo].[Package] ([id], [studioid], [name], [price], [depositprice], [details], [status]) VALUES (4, 6, N'Convocation Picture Basic', CAST(200.00 AS Decimal(6, 2)), CAST(50.00 AS Decimal(6, 2)), N'Choose desired place to do photoshoot.', N'Enabled')
GO
INSERT [dbo].[Package] ([id], [studioid], [name], [price], [depositprice], [details], [status]) VALUES (5, 2, N'Test Package', CAST(1000.00 AS Decimal(6, 2)), CAST(450.00 AS Decimal(6, 2)), NULL, N'Disabled')
GO
INSERT [dbo].[Package] ([id], [studioid], [name], [price], [depositprice], [details], [status]) VALUES (6, 8, N'Package Budget', CAST(300.00 AS Decimal(6, 2)), CAST(100.00 AS Decimal(6, 2)), N'Package for budget use', N'Enabled')
GO
INSERT [dbo].[Package] ([id], [studioid], [name], [price], [depositprice], [details], [status]) VALUES (7, 8, N'Package Potrait', CAST(1000.00 AS Decimal(6, 2)), CAST(200.00 AS Decimal(6, 2)), N'Suits for potrait', N'Enabled')
GO
INSERT [dbo].[Package] ([id], [studioid], [name], [price], [depositprice], [details], [status]) VALUES (8, 8, N'Catalogue Photography', CAST(3000.00 AS Decimal(6, 2)), CAST(500.00 AS Decimal(6, 2)), N'This package suitable for hijab, garment or for seasonal collection release', N'Enabled')
GO
INSERT [dbo].[Package] ([id], [studioid], [name], [price], [depositprice], [details], [status]) VALUES (9, 8, N'Experimental Package', CAST(5000.00 AS Decimal(6, 2)), CAST(1000.00 AS Decimal(6, 2)), N'When we were approached to brainstorm for an idea or a concept', N'Enabled')
GO
INSERT [dbo].[Package] ([id], [studioid], [name], [price], [depositprice], [details], [status]) VALUES (10, 8, N'Test Package', CAST(10.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(6, 2)), NULL, N'Disabled')
GO
INSERT [dbo].[Package] ([id], [studioid], [name], [price], [depositprice], [details], [status]) VALUES (11, 9, N'Shot From Mobile Package', CAST(200.00 AS Decimal(6, 2)), CAST(50.00 AS Decimal(6, 2)), N'Shot from mobile!', N'Enabled')
GO
INSERT [dbo].[Package] ([id], [studioid], [name], [price], [depositprice], [details], [status]) VALUES (12, 25, N'Wedding', CAST(1000.00 AS Decimal(6, 2)), CAST(500.00 AS Decimal(6, 2)), N'Maximum of 100 photo per shooting. Lorem Ipsum is simply dummy text of the printing and typesetting.', N'Enabled')
GO
INSERT [dbo].[Package] ([id], [studioid], [name], [price], [depositprice], [details], [status]) VALUES (13, 3, N'Nikah RM600', CAST(600.00 AS Decimal(6, 2)), CAST(200.00 AS Decimal(6, 2)), N'unlimited shot, FREE edit, nikah, outdoor, frame, pendrive', N'Enabled')
GO
INSERT [dbo].[Package] ([id], [studioid], [name], [price], [depositprice], [details], [status]) VALUES (14, 3, N'Nikah RM450', CAST(450.00 AS Decimal(6, 2)), CAST(100.00 AS Decimal(6, 2)), N'unlimited shot, pendrive, FREE edit', N'Enabled')
GO
INSERT [dbo].[Package] ([id], [studioid], [name], [price], [depositprice], [details], [status]) VALUES (15, 3, N'Nikah + Sanding RM1300 (1 Day Event)', CAST(1280.00 AS Decimal(6, 2)), CAST(500.00 AS Decimal(6, 2)), N'unlimited shot : nikah, sanding, outdoor, FREE edit , FREE pendrive', N'Enabled')
GO
INSERT [dbo].[Package] ([id], [studioid], [name], [price], [depositprice], [details], [status]) VALUES (16, 3, N'Nikah + Sanding RM1350 (1 Day Event)', CAST(1350.00 AS Decimal(6, 2)), CAST(500.00 AS Decimal(6, 2)), N'unlimited shot : nikah & sanding , outdoor, photobook (40 pages) , frame (16x24), FREE edit', N'Enabled')
GO
INSERT [dbo].[Package] ([id], [studioid], [name], [price], [depositprice], [details], [status]) VALUES (17, 3, N'Bertunang/Malam Berinai RM350', CAST(350.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(6, 2)), N'unlimited shot,free edit,free pendrive', N'Disabled')
GO
INSERT [dbo].[Package] ([id], [studioid], [name], [price], [depositprice], [details], [status]) VALUES (18, 3, N'Bertunang/Malam Berinai RM450', CAST(450.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(6, 2)), N'unlimited shot, outdoor / pre-wedding, free edit, free pendrive', N'Enabled')
GO
INSERT [dbo].[Package] ([id], [studioid], [name], [price], [depositprice], [details], [status]) VALUES (19, 4, N'Convocation Photoshoot', CAST(230.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(6, 2)), N'1 person + Family', N'Enabled')
GO
INSERT [dbo].[Package] ([id], [studioid], [name], [price], [depositprice], [details], [status]) VALUES (20, 4, N'Convocation Photoshoot Party', CAST(240.00 AS Decimal(6, 2)), CAST(0.00 AS Decimal(6, 2)), N'2 - 3 person.', N'Enabled')
GO
SET IDENTITY_INSERT [dbo].[Package] OFF
GO
SET IDENTITY_INSERT [dbo].[PackageImage] ON 
GO
INSERT [dbo].[PackageImage] ([ID], [ImageName], [PackageID], [IsCoverPhoto]) VALUES (40, N'yXCGEYg.jpg', 1, NULL)
GO
INSERT [dbo].[PackageImage] ([ID], [ImageName], [PackageID], [IsCoverPhoto]) VALUES (41, N'zbwl7l1.png', 1, NULL)
GO
INSERT [dbo].[PackageImage] ([ID], [ImageName], [PackageID], [IsCoverPhoto]) VALUES (42, N'pvFtcrP.png', 2, NULL)
GO
INSERT [dbo].[PackageImage] ([ID], [ImageName], [PackageID], [IsCoverPhoto]) VALUES (43, N'bkOds09.jpg', 4, NULL)
GO
INSERT [dbo].[PackageImage] ([ID], [ImageName], [PackageID], [IsCoverPhoto]) VALUES (45, N'jQKWjwp.png', 6, NULL)
GO
INSERT [dbo].[PackageImage] ([ID], [ImageName], [PackageID], [IsCoverPhoto]) VALUES (46, N'zuoGsUS.png', 7, NULL)
GO
INSERT [dbo].[PackageImage] ([ID], [ImageName], [PackageID], [IsCoverPhoto]) VALUES (47, N'xexKGFY.png', 8, NULL)
GO
INSERT [dbo].[PackageImage] ([ID], [ImageName], [PackageID], [IsCoverPhoto]) VALUES (48, N'o2jCJ4B.png', 9, NULL)
GO
INSERT [dbo].[PackageImage] ([ID], [ImageName], [PackageID], [IsCoverPhoto]) VALUES (50, N'gBakRtL.jpg', 3, NULL)
GO
INSERT [dbo].[PackageImage] ([ID], [ImageName], [PackageID], [IsCoverPhoto]) VALUES (52, N'6h9pc2o.jpg', 11, NULL)
GO
INSERT [dbo].[PackageImage] ([ID], [ImageName], [PackageID], [IsCoverPhoto]) VALUES (54, N'o8eyLar.jpg', 12, NULL)
GO
INSERT [dbo].[PackageImage] ([ID], [ImageName], [PackageID], [IsCoverPhoto]) VALUES (55, N'dRPcEFO.jpg', 13, NULL)
GO
INSERT [dbo].[PackageImage] ([ID], [ImageName], [PackageID], [IsCoverPhoto]) VALUES (57, N'TDl6Trg.jpg', 15, NULL)
GO
INSERT [dbo].[PackageImage] ([ID], [ImageName], [PackageID], [IsCoverPhoto]) VALUES (58, N'7HRwxAs.jpg', 16, NULL)
GO
INSERT [dbo].[PackageImage] ([ID], [ImageName], [PackageID], [IsCoverPhoto]) VALUES (60, N'qg5fbRd.jpg', 14, NULL)
GO
INSERT [dbo].[PackageImage] ([ID], [ImageName], [PackageID], [IsCoverPhoto]) VALUES (61, N'LKzuREf.jpg', 18, NULL)
GO
INSERT [dbo].[PackageImage] ([ID], [ImageName], [PackageID], [IsCoverPhoto]) VALUES (66, N'FGZcjXf.jpg', 19, NULL)
GO
INSERT [dbo].[PackageImage] ([ID], [ImageName], [PackageID], [IsCoverPhoto]) VALUES (67, N'7ArP7BZ.jpg', 20, NULL)
GO
INSERT [dbo].[PackageImage] ([ID], [ImageName], [PackageID], [IsCoverPhoto]) VALUES (68, N'hhpabl3.jpg', 17, NULL)
GO
SET IDENTITY_INSERT [dbo].[PackageImage] OFF
GO
SET IDENTITY_INSERT [dbo].[PaymentMethod] ON 
GO
INSERT [dbo].[PaymentMethod] ([id], [name]) VALUES (2, N'Credit/Debit Card')
GO
INSERT [dbo].[PaymentMethod] ([id], [name]) VALUES (1, N'FPX')
GO
SET IDENTITY_INSERT [dbo].[PaymentMethod] OFF
GO
SET IDENTITY_INSERT [dbo].[Studio] ON 
GO
INSERT [dbo].[Studio] ([id], [name], [uniquename], [State], [City], [ImgLogo], [ImgCover], [shortDesc], [longDesc], [phoneNum], [email]) VALUES (2, N'Pelatography', N'pelatography', N'Kuala Lumpur', NULL, N'wsTYYTS.jpg', N'nwJH1Ar.jpg', N'Wedding Photographers', N'Malaysian Wedding Photographers.
Speaking through visual. #pelatography
SSM (002998064-P)', N'01263744432', N'hello@pelat.com')
GO
INSERT [dbo].[Studio] ([id], [name], [uniquename], [State], [City], [ImgLogo], [ImgCover], [shortDesc], [longDesc], [phoneNum], [email]) VALUES (3, N'Moshi Graphy', N'moshigraphy', N'Perak', N'Ipoh', N'9aopV4j.jpg', N'9aopV4j.png', N'Moshi Photography', N'DM for collaboration/assist/enq
Wedding photography/convo/event/portrait
#perakweddingphotographer #weddingphotographer', N'0196282869', N'alifmoshi@yahoo.com')
GO
INSERT [dbo].[Studio] ([id], [name], [uniquename], [State], [City], [ImgLogo], [ImgCover], [shortDesc], [longDesc], [phoneNum], [email]) VALUES (4, N'Lensa Cinta', N'lensacintakonvo', N'Pulau Pinang', N'Georgetown', N'vBurMJa.jpg', N'bDifqHX.jpg', N'Convo By Lensa Cinta', N'1 and half hour photoshoot. All high definition picture will be given via google drive, dropbox or telegram.', N'0164586919', N'lensacinta@gmail.com')
GO
INSERT [dbo].[Studio] ([id], [name], [uniquename], [State], [City], [ImgLogo], [ImgCover], [shortDesc], [longDesc], [phoneNum], [email]) VALUES (5, N'Polyphia', N'CQUrE', N'Pulau Pinang', N'Perai', N'mihphgS.jpg', N'6jJdHc8.jpg', N'Makes your dream come true', N'Hi, please follow me on social media.', N'0125001524', N'mdafiqiskandar@gmail.com')
GO
INSERT [dbo].[Studio] ([id], [name], [uniquename], [State], [City], [ImgLogo], [ImgCover], [shortDesc], [longDesc], [phoneNum], [email]) VALUES (6, N'Raz Imagination', N'razpic', N'Selangor', N'Petaling Jaya', N'XEJKlhA.jpg', NULL, N'Imagination is power', N'Welcome to Raz Picture', N'0389472076', N'raziq@ahahak.com')
GO
INSERT [dbo].[Studio] ([id], [name], [uniquename], [State], [City], [ImgLogo], [ImgCover], [shortDesc], [longDesc], [phoneNum], [email]) VALUES (8, N'Flawa Studio', N'flawastudio', N'Selangor', N'Shah Alam', N'GcuJ3kS.jpg', N'GcuJ3kS.png', N'MALAYSIA STUDIO PHOTOGRAPHER', N'Website : theflawa.com', N'0193504142', N'flawa.studio@gmail.com')
GO
INSERT [dbo].[Studio] ([id], [name], [uniquename], [State], [City], [ImgLogo], [ImgCover], [shortDesc], [longDesc], [phoneNum], [email]) VALUES (9, N'SabPhy', N'SABPHY99', N'Kedah', N'Pokok Sena', N'G1tv1v0.png', N'y9DalHX.png', N'YOUR ONE STOP SABPHY CENTER', N'TEST', N'0122428459', N'TEST@SABPHY.COM')
GO
INSERT [dbo].[Studio] ([id], [name], [uniquename], [State], [City], [ImgLogo], [ImgCover], [shortDesc], [longDesc], [phoneNum], [email]) VALUES (25, N'Studio Violet', N'rosestudio', N'Pulau Pinang', N'Butterworth', N'2mvUQyI.jpg', N'bYMniOX.jpg', N'Makes your dream come true', N'Hi, welcome to my page.', N'0123310551', N'mdafiqiskandar@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[Studio] OFF
GO
SET IDENTITY_INSERT [dbo].[StudioLink] ON 
GO
INSERT [dbo].[StudioLink] ([id], [name], [address], [studioid]) VALUES (1, N'Facebook', N'pelatography', NULL)
GO
INSERT [dbo].[StudioLink] ([id], [name], [address], [studioid]) VALUES (2, N'Twitter', N'zahiruliman', 2)
GO
INSERT [dbo].[StudioLink] ([id], [name], [address], [studioid]) VALUES (3, N'Instagram', N'pelatography', NULL)
GO
INSERT [dbo].[StudioLink] ([id], [name], [address], [studioid]) VALUES (4, N'Web', N'google.com', NULL)
GO
INSERT [dbo].[StudioLink] ([id], [name], [address], [studioid]) VALUES (5, N'Facebook', N'polifia.12', 5)
GO
INSERT [dbo].[StudioLink] ([id], [name], [address], [studioid]) VALUES (6, N'Twitter', N'pol12', 5)
GO
INSERT [dbo].[StudioLink] ([id], [name], [address], [studioid]) VALUES (7, N'Instagram', N'poli.12', 5)
GO
INSERT [dbo].[StudioLink] ([id], [name], [address], [studioid]) VALUES (8, N'Instagram', N'flawa.studio', NULL)
GO
INSERT [dbo].[StudioLink] ([id], [name], [address], [studioid]) VALUES (9, N'Facebook', N'haramFB', 9)
GO
INSERT [dbo].[StudioLink] ([id], [name], [address], [studioid]) VALUES (10, N'Twitter', N'haramIG', 9)
GO
INSERT [dbo].[StudioLink] ([id], [name], [address], [studioid]) VALUES (11, N'Instagram', N'haramTwitter', 9)
GO
INSERT [dbo].[StudioLink] ([id], [name], [address], [studioid]) VALUES (12, N'Twitter', N'flawa.studio', NULL)
GO
INSERT [dbo].[StudioLink] ([id], [name], [address], [studioid]) VALUES (13, N'Instagram', N'flawa.studio', NULL)
GO
INSERT [dbo].[StudioLink] ([id], [name], [address], [studioid]) VALUES (14, N'Twitter', N'flawa.studios', NULL)
GO
INSERT [dbo].[StudioLink] ([id], [name], [address], [studioid]) VALUES (15, N'Instagram', N'flawa.studios', NULL)
GO
INSERT [dbo].[StudioLink] ([id], [name], [address], [studioid]) VALUES (16, N'Twitter', N'flawa.studios', NULL)
GO
INSERT [dbo].[StudioLink] ([id], [name], [address], [studioid]) VALUES (17, N'Instagram', N'flawa.studios', NULL)
GO
INSERT [dbo].[StudioLink] ([id], [name], [address], [studioid]) VALUES (18, N'Twitter', N'flawa.studios', NULL)
GO
INSERT [dbo].[StudioLink] ([id], [name], [address], [studioid]) VALUES (19, N'Instagram', N'flawa.studios', 8)
GO
INSERT [dbo].[StudioLink] ([id], [name], [address], [studioid]) VALUES (20, N'Facebook', N'violet.fb', 25)
GO
INSERT [dbo].[StudioLink] ([id], [name], [address], [studioid]) VALUES (21, N'Instagram', N'moshi_graphy', 3)
GO
INSERT [dbo].[StudioLink] ([id], [name], [address], [studioid]) VALUES (22, N'Facebook', N'pelatography', 2)
GO
INSERT [dbo].[StudioLink] ([id], [name], [address], [studioid]) VALUES (23, N'Instagram', N'pelatography', 2)
GO
INSERT [dbo].[StudioLink] ([id], [name], [address], [studioid]) VALUES (24, N'Instagram', N'hafizhempire', NULL)
GO
INSERT [dbo].[StudioLink] ([id], [name], [address], [studioid]) VALUES (25, N'Instagram', N'lensacintakonvo', 4)
GO
SET IDENTITY_INSERT [dbo].[StudioLink] OFF
GO
SET IDENTITY_INSERT [dbo].[StudioRole] ON 
GO
INSERT [dbo].[StudioRole] ([id], [name]) VALUES (1, N'Admin')
GO
INSERT [dbo].[StudioRole] ([id], [name]) VALUES (2, N'Staff')
GO
SET IDENTITY_INSERT [dbo].[StudioRole] OFF
GO
SET IDENTITY_INSERT [dbo].[SystemRole] ON 
GO
INSERT [dbo].[SystemRole] ([id], [name]) VALUES (1, N'Admin')
GO
INSERT [dbo].[SystemRole] ([id], [name]) VALUES (2, N'User')
GO
SET IDENTITY_INSERT [dbo].[SystemRole] OFF
GO
SET IDENTITY_INSERT [dbo].[Transaction] ON 
GO
INSERT [dbo].[Transaction] ([id], [transdate], [total], [invoiceid], [paymentmethodid], [reference]) VALUES (19, CAST(N'2021-01-19T14:41:25.090' AS DateTime), CAST(500.00 AS Decimal(6, 2)), 29, 1, N'pi_1IBDtiBQ6wryxylDgbECdZA5')
GO
INSERT [dbo].[Transaction] ([id], [transdate], [total], [invoiceid], [paymentmethodid], [reference]) VALUES (20, CAST(N'2021-01-19T14:53:14.747' AS DateTime), CAST(200.00 AS Decimal(6, 2)), 32, 1, N'pi_1IBE5EBQ6wryxylD4hqlJBQV')
GO
INSERT [dbo].[Transaction] ([id], [transdate], [total], [invoiceid], [paymentmethodid], [reference]) VALUES (21, CAST(N'2021-01-19T16:10:34.440' AS DateTime), CAST(80.00 AS Decimal(6, 2)), 33, 1, N'pi_1IBFHzBQ6wryxylDyIAA2Wlh')
GO
INSERT [dbo].[Transaction] ([id], [transdate], [total], [invoiceid], [paymentmethodid], [reference]) VALUES (22, CAST(N'2021-01-19T16:14:17.240' AS DateTime), CAST(128.00 AS Decimal(6, 2)), 34, 1, N'pi_1IBFLiBQ6wryxylDOnQ2YTBS')
GO
INSERT [dbo].[Transaction] ([id], [transdate], [total], [invoiceid], [paymentmethodid], [reference]) VALUES (23, CAST(N'2021-01-20T12:47:54.360' AS DateTime), CAST(213.20 AS Decimal(6, 2)), 36, 1, N'pi_1IBYbUBQ6wryxylDjeVQPUgd')
GO
INSERT [dbo].[Transaction] ([id], [transdate], [total], [invoiceid], [paymentmethodid], [reference]) VALUES (25, CAST(N'2021-01-21T15:04:46.237' AS DateTime), CAST(150.00 AS Decimal(6, 2)), 37, 1, N'pi_1IBxD7BQ6wryxylDvrwTkPoP')
GO
INSERT [dbo].[Transaction] ([id], [transdate], [total], [invoiceid], [paymentmethodid], [reference]) VALUES (27, CAST(N'2021-01-21T16:24:51.487' AS DateTime), CAST(372.00 AS Decimal(6, 2)), 39, 1, N'pi_1IByRlBQ6wryxylDDNL43vRJ')
GO
INSERT [dbo].[Transaction] ([id], [transdate], [total], [invoiceid], [paymentmethodid], [reference]) VALUES (29, CAST(N'2021-01-22T13:00:08.507' AS DateTime), CAST(99.00 AS Decimal(6, 2)), 40, 1, N'pi_1ICPDwBQ6wryxylDQMQbGsgP')
GO
INSERT [dbo].[Transaction] ([id], [transdate], [total], [invoiceid], [paymentmethodid], [reference]) VALUES (30, CAST(N'2021-01-26T17:24:08.013' AS DateTime), CAST(100.00 AS Decimal(6, 2)), 42, 1, N'pi_1IDnmBBQ6wryxylDmWlg7Ice')
GO
SET IDENTITY_INSERT [dbo].[Transaction] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([id], [email], [password], [name], [dateofbirth], [phonenumber], [imgprofile], [isVerified], [verifiedKey], [emailTemp], [isForgotPassword]) VALUES (1, N'admin', N'839629FD7B6BD4ECC4912BBA40D9ECBAFFDF7361039BE02538605319188514EE', N'Admin System 1', CAST(N'1999-08-07T00:00:00.000' AS DateTime), N'0185759971', N'UVvapxn.jpg', 1, NULL, NULL, 0)
GO
INSERT [dbo].[User] ([id], [email], [password], [name], [dateofbirth], [phonenumber], [imgprofile], [isVerified], [verifiedKey], [emailTemp], [isForgotPassword]) VALUES (2, N'user01@gmail.com', N'A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3', N'Moon Byul', NULL, N'0185759971', N'UGiBnhb.jpg', 1, N'IwMcAD39', NULL, 1)
GO
INSERT [dbo].[User] ([id], [email], [password], [name], [dateofbirth], [phonenumber], [imgprofile], [isVerified], [verifiedKey], [emailTemp], [isForgotPassword]) VALUES (3, N'raziq@ahahak.com', N'ECD71870D1963316A97E3AC3408C9835AD8CF0F3C1BC703527C30265534F75AE', N'raziq@ahahak.com', NULL, NULL, N'gRskXC4.png', 1, NULL, NULL, 0)
GO
INSERT [dbo].[User] ([id], [email], [password], [name], [dateofbirth], [phonenumber], [imgprofile], [isVerified], [verifiedKey], [emailTemp], [isForgotPassword]) VALUES (4, N'user02@gmail.com', N'A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3', N'user02@gmail.com', NULL, NULL, NULL, 1, NULL, NULL, 0)
GO
INSERT [dbo].[User] ([id], [email], [password], [name], [dateofbirth], [phonenumber], [imgprofile], [isVerified], [verifiedKey], [emailTemp], [isForgotPassword]) VALUES (5, N'user03@gmail.com', N'5FD924625F6AB16A19CC9807C7C506AE1813490E4BA675F843D5A10E0BAACDB8', N'user03@gmail.com', NULL, NULL, N'ggVrF8G.jpg', 1, N'jzLM4TXu', NULL, 1)
GO
INSERT [dbo].[User] ([id], [email], [password], [name], [dateofbirth], [phonenumber], [imgprofile], [isVerified], [verifiedKey], [emailTemp], [isForgotPassword]) VALUES (7, N'danish@ahahak.com', N'ECD71870D1963316A97E3AC3408C9835AD8CF0F3C1BC703527C30265534F75AE', N'danish@ahahak.com', NULL, NULL, NULL, 1, N'YOpHqKTP', NULL, 0)
GO
INSERT [dbo].[User] ([id], [email], [password], [name], [dateofbirth], [phonenumber], [imgprofile], [isVerified], [verifiedKey], [emailTemp], [isForgotPassword]) VALUES (8, N'user04@hotmail.com', N'A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3', N'Adi Iman', NULL, N'0185759971', N'BUh863v.jpg', 1, NULL, NULL, 0)
GO
INSERT [dbo].[User] ([id], [email], [password], [name], [dateofbirth], [phonenumber], [imgprofile], [isVerified], [verifiedKey], [emailTemp], [isForgotPassword]) VALUES (9, N'test@test.com', N'A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3', N'test@test.com', NULL, NULL, NULL, 0, N'Y26ae9Rp', NULL, 0)
GO
INSERT [dbo].[User] ([id], [email], [password], [name], [dateofbirth], [phonenumber], [imgprofile], [isVerified], [verifiedKey], [emailTemp], [isForgotPassword]) VALUES (10, N'user05@gmail.com', N'A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3', N'user07@photog.com', NULL, NULL, NULL, 1, NULL, NULL, 0)
GO
INSERT [dbo].[User] ([id], [email], [password], [name], [dateofbirth], [phonenumber], [imgprofile], [isVerified], [verifiedKey], [emailTemp], [isForgotPassword]) VALUES (11, N'user07@photog.com', N'5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8', N'user07@photog.com', NULL, NULL, NULL, 0, N'ivupAFn4', NULL, 0)
GO
INSERT [dbo].[User] ([id], [email], [password], [name], [dateofbirth], [phonenumber], [imgprofile], [isVerified], [verifiedKey], [emailTemp], [isForgotPassword]) VALUES (12, N'user08@outlook.com', N'5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8', N'user08@outlook.com', NULL, NULL, N'VPHTbHn.png', 1, NULL, NULL, 0)
GO
INSERT [dbo].[User] ([id], [email], [password], [name], [dateofbirth], [phonenumber], [imgprofile], [isVerified], [verifiedKey], [emailTemp], [isForgotPassword]) VALUES (13, N'user09@gmail.com', N'A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3', N'user09@gmail.com', NULL, NULL, N'Ukt987N.jpg', 1, NULL, NULL, 0)
GO
INSERT [dbo].[User] ([id], [email], [password], [name], [dateofbirth], [phonenumber], [imgprofile], [isVerified], [verifiedKey], [emailTemp], [isForgotPassword]) VALUES (14, N'user10@hshsh.com', N'ECD71870D1963316A97E3AC3408C9835AD8CF0F3C1BC703527C30265534F75AE', N'user10@hshsh.com', NULL, NULL, NULL, 1, NULL, NULL, 0)
GO
INSERT [dbo].[User] ([id], [email], [password], [name], [dateofbirth], [phonenumber], [imgprofile], [isVerified], [verifiedKey], [emailTemp], [isForgotPassword]) VALUES (15, N'sivabo8767@dashseat.com', N'5FD924625F6AB16A19CC9807C7C506AE1813490E4BA675F843D5A10E0BAACDB8', N'sivabo8767@dashseat.com', NULL, NULL, NULL, 1, NULL, NULL, 0)
GO
INSERT [dbo].[User] ([id], [email], [password], [name], [dateofbirth], [phonenumber], [imgprofile], [isVerified], [verifiedKey], [emailTemp], [isForgotPassword]) VALUES (17, N'user11@hshsh.com', N'A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3', N'hengkai', NULL, N'0110940018', N'vtQq7B4.jpg', 1, NULL, NULL, 0)
GO
INSERT [dbo].[User] ([id], [email], [password], [name], [dateofbirth], [phonenumber], [imgprofile], [isVerified], [verifiedKey], [emailTemp], [isForgotPassword]) VALUES (20, N'user12@hshsh.com', N'A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3', N'user12@hshsh.com', NULL, NULL, NULL, 1, N'yRwFw4If', NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserStudio] ON 
GO
INSERT [dbo].[UserStudio] ([id], [studioid], [userid], [studioroleid], [isActive]) VALUES (2, 2, 2, 1, 1)
GO
INSERT [dbo].[UserStudio] ([id], [studioid], [userid], [studioroleid], [isActive]) VALUES (7, 3, 2, 1, 1)
GO
INSERT [dbo].[UserStudio] ([id], [studioid], [userid], [studioroleid], [isActive]) VALUES (8, 4, 2, 1, 1)
GO
INSERT [dbo].[UserStudio] ([id], [studioid], [userid], [studioroleid], [isActive]) VALUES (9, 5, 5, 1, 1)
GO
INSERT [dbo].[UserStudio] ([id], [studioid], [userid], [studioroleid], [isActive]) VALUES (10, 6, 3, 1, 1)
GO
INSERT [dbo].[UserStudio] ([id], [studioid], [userid], [studioroleid], [isActive]) VALUES (12, 2, 4, 2, NULL)
GO
INSERT [dbo].[UserStudio] ([id], [studioid], [userid], [studioroleid], [isActive]) VALUES (13, 5, 2, 1, 0)
GO
INSERT [dbo].[UserStudio] ([id], [studioid], [userid], [studioroleid], [isActive]) VALUES (15, 2, 3, 2, NULL)
GO
INSERT [dbo].[UserStudio] ([id], [studioid], [userid], [studioroleid], [isActive]) VALUES (17, 6, 2, 2, NULL)
GO
INSERT [dbo].[UserStudio] ([id], [studioid], [userid], [studioroleid], [isActive]) VALUES (18, 6, 4, 2, NULL)
GO
INSERT [dbo].[UserStudio] ([id], [studioid], [userid], [studioroleid], [isActive]) VALUES (20, 8, 8, 1, NULL)
GO
INSERT [dbo].[UserStudio] ([id], [studioid], [userid], [studioroleid], [isActive]) VALUES (22, 9, 12, 1, NULL)
GO
INSERT [dbo].[UserStudio] ([id], [studioid], [userid], [studioroleid], [isActive]) VALUES (23, 9, 11, 1, NULL)
GO
INSERT [dbo].[UserStudio] ([id], [studioid], [userid], [studioroleid], [isActive]) VALUES (39, 25, 15, 1, NULL)
GO
INSERT [dbo].[UserStudio] ([id], [studioid], [userid], [studioroleid], [isActive]) VALUES (40, 25, 5, 2, NULL)
GO
SET IDENTITY_INSERT [dbo].[UserStudio] OFF
GO
SET IDENTITY_INSERT [dbo].[UserSystemRole] ON 
GO
INSERT [dbo].[UserSystemRole] ([id], [systemroleid], [userid]) VALUES (1, 1, 1)
GO
INSERT [dbo].[UserSystemRole] ([id], [systemroleid], [userid]) VALUES (2, 2, 1)
GO
INSERT [dbo].[UserSystemRole] ([id], [systemroleid], [userid]) VALUES (3, 2, 2)
GO
INSERT [dbo].[UserSystemRole] ([id], [systemroleid], [userid]) VALUES (4, 2, 3)
GO
INSERT [dbo].[UserSystemRole] ([id], [systemroleid], [userid]) VALUES (5, 2, 4)
GO
INSERT [dbo].[UserSystemRole] ([id], [systemroleid], [userid]) VALUES (6, 2, 5)
GO
INSERT [dbo].[UserSystemRole] ([id], [systemroleid], [userid]) VALUES (8, 2, 7)
GO
INSERT [dbo].[UserSystemRole] ([id], [systemroleid], [userid]) VALUES (9, 2, 8)
GO
INSERT [dbo].[UserSystemRole] ([id], [systemroleid], [userid]) VALUES (10, 2, 9)
GO
INSERT [dbo].[UserSystemRole] ([id], [systemroleid], [userid]) VALUES (11, 2, 10)
GO
INSERT [dbo].[UserSystemRole] ([id], [systemroleid], [userid]) VALUES (12, 2, 11)
GO
INSERT [dbo].[UserSystemRole] ([id], [systemroleid], [userid]) VALUES (13, 2, 12)
GO
INSERT [dbo].[UserSystemRole] ([id], [systemroleid], [userid]) VALUES (14, 2, 13)
GO
INSERT [dbo].[UserSystemRole] ([id], [systemroleid], [userid]) VALUES (15, 2, 14)
GO
INSERT [dbo].[UserSystemRole] ([id], [systemroleid], [userid]) VALUES (16, 2, 15)
GO
INSERT [dbo].[UserSystemRole] ([id], [systemroleid], [userid]) VALUES (19, 2, 20)
GO
SET IDENTITY_INSERT [dbo].[UserSystemRole] OFF
GO
/****** Object:  Index [uc_JobDateUser]    Script Date: 27/1/2021 10:59:55 AM ******/
ALTER TABLE [dbo].[JobDateUser] ADD  CONSTRAINT [uc_JobDateUser] UNIQUE NONCLUSTERED 
(
	[jobdateid] ASC,
	[userstudioid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__JobStatu__72E12F1B3C8BB635]    Script Date: 27/1/2021 10:59:55 AM ******/
ALTER TABLE [dbo].[JobStatus] ADD  CONSTRAINT [UQ__JobStatu__72E12F1B3C8BB635] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__PaymentM__72E12F1B24245977]    Script Date: 27/1/2021 10:59:55 AM ******/
ALTER TABLE [dbo].[PaymentMethod] ADD  CONSTRAINT [UQ__PaymentM__72E12F1B24245977] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Studio__3E7228C41578A8D0]    Script Date: 27/1/2021 10:59:55 AM ******/
ALTER TABLE [dbo].[Studio] ADD  CONSTRAINT [UQ__Studio__3E7228C41578A8D0] UNIQUE NONCLUSTERED 
(
	[uniquename] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__StudioRo__72E12F1B59457F0F]    Script Date: 27/1/2021 10:59:55 AM ******/
ALTER TABLE [dbo].[StudioRole] ADD  CONSTRAINT [UQ__StudioRo__72E12F1B59457F0F] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__SystemRo__72E12F1BA7DD3064]    Script Date: 27/1/2021 10:59:55 AM ******/
ALTER TABLE [dbo].[SystemRole] ADD  CONSTRAINT [UQ__SystemRo__72E12F1BA7DD3064] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__User__AB6E61640D7A5532]    Script Date: 27/1/2021 10:59:55 AM ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [UQ__User__AB6E61640D7A5532] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [uc_userstudio]    Script Date: 27/1/2021 10:59:55 AM ******/
ALTER TABLE [dbo].[UserStudio] ADD  CONSTRAINT [uc_userstudio] UNIQUE NONCLUSTERED 
(
	[studioid] ASC,
	[userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [uc_usersystemrole]    Script Date: 27/1/2021 10:59:55 AM ******/
ALTER TABLE [dbo].[UserSystemRole] ADD  CONSTRAINT [uc_usersystemrole] UNIQUE NONCLUSTERED 
(
	[systemroleid] ASC,
	[userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Package] ADD  CONSTRAINT [DF__Package__status__1DB06A4F]  DEFAULT ('Enabled') FOR [status]
GO
ALTER TABLE [dbo].[Charges]  WITH CHECK ADD  CONSTRAINT [FK_Charges_Studio] FOREIGN KEY([StudioID])
REFERENCES [dbo].[Studio] ([id])
GO
ALTER TABLE [dbo].[Charges] CHECK CONSTRAINT [FK_Charges_Studio]
GO
ALTER TABLE [dbo].[ChatKey]  WITH CHECK ADD  CONSTRAINT [FK_ChatKey_Studio] FOREIGN KEY([StudioID])
REFERENCES [dbo].[Studio] ([id])
GO
ALTER TABLE [dbo].[ChatKey] CHECK CONSTRAINT [FK_ChatKey_Studio]
GO
ALTER TABLE [dbo].[ChatKey]  WITH CHECK ADD  CONSTRAINT [FK_ChatKey_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[ChatKey] CHECK CONSTRAINT [FK_ChatKey_User]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK__Invoice__jobid__2EDAF651] FOREIGN KEY([jobid])
REFERENCES [dbo].[Job] ([id])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK__Invoice__jobid__2EDAF651]
GO
ALTER TABLE [dbo].[Job]  WITH CHECK ADD  CONSTRAINT [FK__Job__jobstatusid__2FCF1A8A] FOREIGN KEY([jobstatusid])
REFERENCES [dbo].[JobStatus] ([id])
GO
ALTER TABLE [dbo].[Job] CHECK CONSTRAINT [FK__Job__jobstatusid__2FCF1A8A]
GO
ALTER TABLE [dbo].[Job]  WITH CHECK ADD  CONSTRAINT [FK__Job__packageid__30C33EC3] FOREIGN KEY([packageid])
REFERENCES [dbo].[Package] ([id])
GO
ALTER TABLE [dbo].[Job] CHECK CONSTRAINT [FK__Job__packageid__30C33EC3]
GO
ALTER TABLE [dbo].[Job]  WITH CHECK ADD  CONSTRAINT [FK__Job__userid__31B762FC] FOREIGN KEY([userid])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Job] CHECK CONSTRAINT [FK__Job__userid__31B762FC]
GO
ALTER TABLE [dbo].[JobCharges]  WITH CHECK ADD  CONSTRAINT [FK__JobCharge__jobid__339FAB6E] FOREIGN KEY([jobid])
REFERENCES [dbo].[Job] ([id])
GO
ALTER TABLE [dbo].[JobCharges] CHECK CONSTRAINT [FK__JobCharge__jobid__339FAB6E]
GO
ALTER TABLE [dbo].[JobDate]  WITH CHECK ADD  CONSTRAINT [FK__JobDate__jobid__3493CFA7] FOREIGN KEY([jobid])
REFERENCES [dbo].[Job] ([id])
GO
ALTER TABLE [dbo].[JobDate] CHECK CONSTRAINT [FK__JobDate__jobid__3493CFA7]
GO
ALTER TABLE [dbo].[JobDate]  WITH CHECK ADD  CONSTRAINT [FK__JobDate__jobstat__10566F31] FOREIGN KEY([jobstatusid])
REFERENCES [dbo].[JobStatus] ([id])
GO
ALTER TABLE [dbo].[JobDate] CHECK CONSTRAINT [FK__JobDate__jobstat__10566F31]
GO
ALTER TABLE [dbo].[JobDateUser]  WITH CHECK ADD  CONSTRAINT [FK__JobDateUs__jobda__114A936A] FOREIGN KEY([jobdateid])
REFERENCES [dbo].[JobDate] ([id])
GO
ALTER TABLE [dbo].[JobDateUser] CHECK CONSTRAINT [FK__JobDateUs__jobda__114A936A]
GO
ALTER TABLE [dbo].[JobDateUser]  WITH CHECK ADD FOREIGN KEY([userstudioid])
REFERENCES [dbo].[UserStudio] ([id])
GO
ALTER TABLE [dbo].[Package]  WITH CHECK ADD  CONSTRAINT [FK__Package__studioi__3864608B] FOREIGN KEY([studioid])
REFERENCES [dbo].[Studio] ([id])
GO
ALTER TABLE [dbo].[Package] CHECK CONSTRAINT [FK__Package__studioi__3864608B]
GO
ALTER TABLE [dbo].[PackageImage]  WITH CHECK ADD  CONSTRAINT [FK__PackageIm__Packa__14270015] FOREIGN KEY([PackageID])
REFERENCES [dbo].[Package] ([id])
GO
ALTER TABLE [dbo].[PackageImage] CHECK CONSTRAINT [FK__PackageIm__Packa__14270015]
GO
ALTER TABLE [dbo].[StudioLink]  WITH CHECK ADD  CONSTRAINT [FK__StudioLin__studi__395884C4] FOREIGN KEY([studioid])
REFERENCES [dbo].[Studio] ([id])
GO
ALTER TABLE [dbo].[StudioLink] CHECK CONSTRAINT [FK__StudioLin__studi__395884C4]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK__Transacti__invoi__160F4887] FOREIGN KEY([invoiceid])
REFERENCES [dbo].[Invoice] ([id])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK__Transacti__invoi__160F4887]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK__Transacti__payme__17036CC0] FOREIGN KEY([paymentmethodid])
REFERENCES [dbo].[PaymentMethod] ([id])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK__Transacti__payme__17036CC0]
GO
ALTER TABLE [dbo].[UserStudio]  WITH CHECK ADD  CONSTRAINT [FK__UserStudi__studi__18EBB532] FOREIGN KEY([studioroleid])
REFERENCES [dbo].[StudioRole] ([id])
GO
ALTER TABLE [dbo].[UserStudio] CHECK CONSTRAINT [FK__UserStudi__studi__18EBB532]
GO
ALTER TABLE [dbo].[UserStudio]  WITH CHECK ADD  CONSTRAINT [FK__UserStudi__studi__3D2915A8] FOREIGN KEY([studioid])
REFERENCES [dbo].[Studio] ([id])
GO
ALTER TABLE [dbo].[UserStudio] CHECK CONSTRAINT [FK__UserStudi__studi__3D2915A8]
GO
ALTER TABLE [dbo].[UserStudio]  WITH CHECK ADD  CONSTRAINT [FK__UserStudi__useri__3F115E1A] FOREIGN KEY([userid])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[UserStudio] CHECK CONSTRAINT [FK__UserStudi__useri__3F115E1A]
GO
ALTER TABLE [dbo].[UserSystemRole]  WITH CHECK ADD  CONSTRAINT [FK__UserSyste__syste__1AD3FDA4] FOREIGN KEY([systemroleid])
REFERENCES [dbo].[SystemRole] ([id])
GO
ALTER TABLE [dbo].[UserSystemRole] CHECK CONSTRAINT [FK__UserSyste__syste__1AD3FDA4]
GO
ALTER TABLE [dbo].[UserSystemRole]  WITH CHECK ADD  CONSTRAINT [FK__UserSyste__useri__40F9A68C] FOREIGN KEY([userid])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[UserSystemRole] CHECK CONSTRAINT [FK__UserSyste__useri__40F9A68C]
GO
/****** Object:  StoredProcedure [dbo].[BACKUP_AZURE]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE           PROC [dbo].[BACKUP_AZURE]
AS
BEGIN
	EXEC OFF_CONSTR_REMOTE
	EXEC DROP_REMOTE_TBL
	EXEC CREATE_TBL_FROM_LOCAL
	EXEC SELECT_LOCAL_TBL
	EXEC FROMLOCAL_GENERATE_CONSTRAINT
	EXEC FROMLOCAL_GENERATE_FK
END
GO
/****** Object:  StoredProcedure [dbo].[BACKUP_AZURE_BLOB]    Script Date: 27/1/2021 10:59:55 AM ******/
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
/****** Object:  StoredProcedure [dbo].[CREATE_TBL_FROM_CLOUD]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[CREATE_TBL_FROM_CLOUD]
	@SELECTION_CLOUD NVARCHAR(MAX) = ''
AS
BEGIN
DECLARE  
      @object_name SYSNAME  
    , @object_id INT  
    , @SQL NVARCHAR(MAX) 

SET @SQL = 
'DECLARE Cursor_TableName CURSOR FOR
select ''[dbo].['' + [name] + '']''
    ,[object_id]  
from [PhotogAzure].[photog_backup].sys.tables where type = ''U''';

IF @SELECTION_CLOUD != ''
BEGIN
	SET @SQL = CONCAT(@SQL,' AND object_id IN ' + @SELECTION_CLOUD);
END

EXECUTE sp_executesql @SQL;

OPEN Cursor_TableName
FETCH NEXT FROM Cursor_TableName INTO @object_name,  @object_id 

While @@FETCH_STATUS = 0
BEGIN

SELECT @SQL = 'CREATE TABLE ' + @object_name + CHAR(13) + '(' + CHAR(13) + STUFF((  
    SELECT CHAR(13) + '    , [' + c.name + '] ' +   
        CASE WHEN c.is_computed = 1  
            THEN 'AS ' + OBJECT_DEFINITION(c.[object_id], c.column_id)  
            ELSE   
                CASE WHEN c.system_type_id != c.user_type_id   
                    THEN '[' + SCHEMA_NAME(tp.[schema_id]) + '].[' + tp.name + ']'   
                    ELSE '[' + UPPER(tp.name) + ']'   
                END  +   
                CASE   
                    WHEN tp.name IN ('varchar', 'char', 'varbinary', 'binary')  
                        THEN '(' + CASE WHEN c.max_length = -1   
                                        THEN 'MAX'   
                                        ELSE CAST(c.max_length AS VARCHAR(5))   
                                    END + ')'  
                    WHEN tp.name IN ('nvarchar', 'nchar')  
                        THEN '(' + CASE WHEN c.max_length = -1   
                                        THEN 'MAX'   
                                        ELSE CAST(c.max_length / 2 AS VARCHAR(5))   
                                    END + ')'  
                    WHEN tp.name IN ('datetime2', 'time2', 'datetimeoffset')   
                        THEN '(' + CAST(c.scale AS VARCHAR(5)) + ')'  
                    WHEN tp.name = 'decimal'  
                        THEN '(' + CAST(c.[precision] AS VARCHAR(5)) + ',' + CAST(c.scale AS VARCHAR(5)) + ')'  
                    ELSE ''  
                END +  
                CASE WHEN c.collation_name IS NOT NULL AND c.system_type_id = c.user_type_id   
                    THEN ' COLLATE ' + c.collation_name  
                    ELSE ''  
                END +  
                CASE WHEN c.is_nullable = 1   
                    THEN ' NULL'  
                    ELSE ' NOT NULL'  
                END +  
                CASE WHEN c.is_identity = 1   
                    THEN ' IDENTITY(' + CAST(ic.SEED_VALUE AS VARCHAR(5)) + ',' +   
                                    CAST(ic.INCREMENT_VALUE AS VARCHAR(5)) + ')'  
                    ELSE ''   
                END   
        END  
    FROM [PhotogAzure].[photog_backup].sys.columns c WITH(NOLOCK)  
	JOIN [PhotogAzure].[photog_backup].sys.IDENTITY_COLUMNS ic ON ic.object_id = c.object_id
    JOIN [PhotogAzure].[photog_backup].sys.types tp WITH(NOLOCK) ON c.user_type_id = tp.user_type_id  
    LEFT JOIN [PhotogAzure].[photog_backup].sys.check_constraints cc WITH(NOLOCK)   
         ON c.[object_id] = cc.parent_object_id   
        AND cc.parent_column_id = c.column_id  
    WHERE c.[object_id] = @object_id  
    ORDER BY c.column_id  
    FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 7, '      ')  + CHAR(13) + ');'  
  
  --PRINT @SQL
	exec sp_executesql
		@statement = @SQL  
  
FETCH NEXT FROM Cursor_TableName INTO @object_name,  @object_id 
END

CLOSE Cursor_TableName
DEALLOCATE Cursor_TableName
END
GO
/****** Object:  StoredProcedure [dbo].[CREATE_TBL_FROM_LOCAL]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[CREATE_TBL_FROM_LOCAL]
AS
BEGIN
DECLARE  
      @object_name SYSNAME  
    , @object_id INT  
    , @SQL NVARCHAR(MAX) 

DECLARE Cursor_TableName CURSOR FOR
select '[dbo].[' + [name]+ ']'  
    ,[object_id]  
from sys.tables where type = 'U'
OPEN Cursor_TableName
FETCH NEXT FROM Cursor_TableName INTO @object_name,  @object_id 

While @@FETCH_STATUS = 0
BEGIN

SELECT @SQL = 'CREATE TABLE ' + @object_name + CHAR(13) + '(' + CHAR(13) + STUFF((  
    SELECT CHAR(13) + '    , [' + c.name + '] ' +   
        CASE WHEN c.is_computed = 1  
            THEN 'AS ' + OBJECT_DEFINITION(c.[object_id], c.column_id)  
            ELSE   
                CASE WHEN c.system_type_id != c.user_type_id   
                    THEN '[' + SCHEMA_NAME(tp.[schema_id]) + '].[' + tp.name + ']'   
                    ELSE '[' + UPPER(tp.name) + ']'   
                END  +   
                CASE   
                    WHEN tp.name IN ('varchar', 'char', 'varbinary', 'binary')  
                        THEN '(' + CASE WHEN c.max_length = -1   
                                        THEN 'MAX'   
                                        ELSE CAST(c.max_length AS VARCHAR(5))   
                                    END + ')'  
                    WHEN tp.name IN ('nvarchar', 'nchar')  
                        THEN '(' + CASE WHEN c.max_length = -1   
                                        THEN 'MAX'   
                                        ELSE CAST(c.max_length / 2 AS VARCHAR(5))   
                                    END + ')'  
                    WHEN tp.name IN ('datetime2', 'time2', 'datetimeoffset')   
                        THEN '(' + CAST(c.scale AS VARCHAR(5)) + ')'  
                    WHEN tp.name = 'decimal'  
                        THEN '(' + CAST(c.[precision] AS VARCHAR(5)) + ',' + CAST(c.scale AS VARCHAR(5)) + ')'  
                    ELSE ''  
                END +  
                CASE WHEN c.collation_name IS NOT NULL AND c.system_type_id = c.user_type_id   
                    THEN ' COLLATE ' + c.collation_name  
                    ELSE ''  
                END +  
                CASE WHEN c.is_nullable = 1   
                    THEN ' NULL'  
                    ELSE ' NOT NULL'  
                END +  
                CASE WHEN c.is_identity = 1   
                    THEN ' IDENTITY(' + CAST(ic.SEED_VALUE AS VARCHAR(5)) + ',' +   
                                    CAST(ic.INCREMENT_VALUE AS VARCHAR(5)) + ')'  
                    ELSE ''   
                END   
        END  
    FROM sys.columns c WITH(NOLOCK)  
	JOIN sys.IDENTITY_COLUMNS ic ON ic.object_id = c.object_id
    JOIN sys.types tp WITH(NOLOCK) ON c.user_type_id = tp.user_type_id  
    LEFT JOIN sys.check_constraints cc WITH(NOLOCK)   
         ON c.[object_id] = cc.parent_object_id   
        AND cc.parent_column_id = c.column_id  
    WHERE c.[object_id] = @object_id  
    ORDER BY c.column_id  
    FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 7, '      ')  + CHAR(13) + ');'  
  
  --PRINT @SQL
	EXEC (@SQL) AT [PhotogAzure]
  
FETCH NEXT FROM Cursor_TableName INTO @object_name,  @object_id 
END

CLOSE Cursor_TableName
DEALLOCATE Cursor_TableName
END
GO
/****** Object:  StoredProcedure [dbo].[DROP_LOCAL_TBL]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROC [dbo].[DROP_LOCAL_TBL]
	@SELECTION_LOCAL NVARCHAR(MAX) = NULL
AS
BEGIN
--- SCRIPT TO GENERATE THE DROP SCRIPT OF ALL FOREIGN KEY CONSTRAINTS
declare @ForeignKeyName varchar(4000)
declare @ParentTableName varchar(4000)
declare @ParentTableSchema varchar(4000)
declare @SQL NVARCHAR(MAX)
declare @TSQLDropFK nvarchar(max)

SET @SQL = N'declare CursorFK cursor for 
select fk.name ForeignKeyName, schema_name(t.schema_id) ParentTableSchema, t.name ParentTableName
from sys.foreign_keys fk  inner join sys.tables t on fk.parent_object_id=t.object_id';

IF (@SELECTION_LOCAL != '')
BEGIN
	SET @SQL = CONCAT(@SQL, ' WHERE fk.referenced_object_id in ', @SELECTION_LOCAL)
END

EXECUTE sp_executesql @SQL;

open CursorFK
fetch next from CursorFK into  @ForeignKeyName, @ParentTableSchema, @ParentTableName
while (@@FETCH_STATUS=0)
begin
 set @TSQLDropFK ='ALTER TABLE '+quotename(@ParentTableSchema)+'.'+quotename(@ParentTableName)+' DROP CONSTRAINT '+quotename(@ForeignKeyName)+ char(13)

 EXEC sp_executesql 
	@stmt = @TSQLDropFK
fetch next from CursorFK into  @ForeignKeyName, @ParentTableSchema, @ParentTableName
end
close CursorFK
deallocate CursorFK

SET @SQL = 
N'DECLARE Cursor_TableName CURSOR FOR
SELECT tt.Table_Name  FROM INFORMATION_SCHEMA.TABLES tt JOIN sys.tables st on tt.table_name = st.name
WHERE TABLE_TYPE   = ''BASE TABLE''';

IF (@SELECTION_LOCAL != '')
BEGIN
	SET @SQL = CONCAT(@SQL , ' AND st.object_id in ' , @SELECTION_LOCAL);
END

EXECUTE sp_executesql @SQL;

OPEN Cursor_TableName
FETCH NEXT FROM Cursor_TableName INTO @ParentTableName

While @@FETCH_STATUS = 0
BEGIN
	set @TSQLDropFK = 'DROP TABLE [dbo].[' + @ParentTableName + ']'

		exec sp_executesql
		@statement = @TSQLDropFK
	FETCH NEXT FROM Cursor_TableName INTO @ParentTableName
END

CLOSE Cursor_TableName
DEALLOCATE Cursor_TableName
END
GO
/****** Object:  StoredProcedure [dbo].[DROP_REMOTE_TBL]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[DROP_REMOTE_TBL]
AS
BEGIN
--- SCRIPT TO GENERATE THE DROP SCRIPT OF ALL FOREIGN KEY CONSTRAINTS
declare @ForeignKeyName varchar(4000)
declare @ParentTableName varchar(4000)
declare @ParentTableSchema varchar(4000)

declare @TSQLDropFK nvarchar(max)

declare CursorFK cursor for select fk.name ForeignKeyName, schema_name(t.schema_id) ParentTableSchema, t.name ParentTableName
from [PhotogAzure].[photog_backup].sys.foreign_keys fk  inner join [PhotogAzure].[photog_backup].sys.tables t on fk.parent_object_id=t.object_id
open CursorFK
fetch next from CursorFK into  @ForeignKeyName, @ParentTableSchema, @ParentTableName
while (@@FETCH_STATUS=0)
begin
 set @TSQLDropFK ='ALTER TABLE '+quotename(@ParentTableSchema)+'.'+quotename(@ParentTableName)+' DROP CONSTRAINT '+quotename(@ForeignKeyName)+ char(13)
 
 EXEC (@TSQLDropFK) AT [PhotogAzure]
fetch next from CursorFK into  @ForeignKeyName, @ParentTableSchema, @ParentTableName
end
close CursorFK
deallocate CursorFK

DECLARE Cursor_TableName CURSOR FOR
SELECT Table_Name  
FROM [PhotogAzure].[photog_backup].INFORMATION_SCHEMA.TABLES c  
WHERE c.TABLE_TYPE = 'BASE TABLE'
OPEN Cursor_TableName
FETCH NEXT FROM Cursor_TableName INTO @ParentTableName

While @@FETCH_STATUS = 0
BEGIN
	set @TSQLDropFK = 'DROP TABLE [dbo].[' + @ParentTableName + ']'
	EXEC (@TSQLDropFK) AT [PhotogAzure]
	FETCH NEXT FROM Cursor_TableName INTO @ParentTableName
END

CLOSE Cursor_TableName
DEALLOCATE Cursor_TableName
END
GO
/****** Object:  StoredProcedure [dbo].[FROMCLOUD_GENERATE_CONSTRAINT]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[FROMCLOUD_GENERATE_CONSTRAINT]
	@SELECTION_CLOUD NVARCHAR(MAX) = ''
AS
BEGIN
--- SCRIPT TO GENERATE THE CREATION SCRIPT OF ALL PK AND UNIQUE CONSTRAINTS.
declare @SchemaName varchar(100)
declare @TableName varchar(256)
declare @IndexName varchar(256)
declare @ColumnName varchar(100)
declare @is_unique_constraint varchar(100)
declare @IndexTypeDesc varchar(100)
declare @FileGroupName varchar(100)
declare @is_disabled varchar(100)
declare @IndexOptions varchar(max)
declare @IndexColumnId int
declare @IsDescendingKey int 
declare @IsIncludedColumn int
declare @TSQLScripCreationIndex nvarchar(max)
declare @TSQLScripDisableIndex nvarchar(max)
declare @is_primary_key varchar(100)
declare @TSQL nvarchar(max)

SET @TSQL = 'declare CursorIndex cursor for 
 select schema_name(t.schema_id) [schema_name], t.name, ix.name,
 case when ix.is_unique_constraint = 1 then '' UNIQUE '' else '''' END 
    ,case when ix.is_primary_key = 1 then '' PRIMARY KEY '' else '''' END 
 , ix.type_desc,
  case when ix.is_padded=1 then ''PAD_INDEX = ON, '' else ''PAD_INDEX = OFF, '' end
 + case when ix.allow_page_locks=1 then ''ALLOW_PAGE_LOCKS = ON, '' else ''ALLOW_PAGE_LOCKS = OFF, '' end
 + case when ix.allow_row_locks=1 then  ''ALLOW_ROW_LOCKS = ON, '' else ''ALLOW_ROW_LOCKS = OFF, '' end
 + case when INDEXPROPERTY(t.object_id, ix.name, ''IsStatistics'') = 1 then ''STATISTICS_NORECOMPUTE = ON, '' else ''STATISTICS_NORECOMPUTE = OFF, '' end
 + case when ix.ignore_dup_key=1 then ''IGNORE_DUP_KEY = ON, '' else ''IGNORE_DUP_KEY = OFF, '' end
 + ''SORT_IN_TEMPDB = OFF, FILLFACTOR ='' + CAST(ix.fill_factor AS VARCHAR(3)) AS IndexOptions
 , FILEGROUP_NAME(ix.data_space_id) FileGroupName
 from [PhotogAzure].[photog_backup].sys.tables t 
 inner join [PhotogAzure].[photog_backup].sys.indexes ix on t.object_id=ix.object_id
 where ix.type>0 and  (ix.is_primary_key=1 or ix.is_unique_constraint=1)
 and t.is_ms_shipped=0 and t.name<>''sysdiagrams''';

IF @SELECTION_CLOUD != ''
BEGIN
	SET @TSQL = CONCAT (@TSQL , ' AND t.object_id IN ' , @SELECTION_CLOUD)
END

SET @TSQL = CONCAT (@TSQL , ' order by schema_name(t.schema_id), t.name, ix.name')

EXECUTE sp_executesql @TSQL;

open CursorIndex
fetch next from CursorIndex into  @SchemaName, @TableName, @IndexName, @is_unique_constraint, @is_primary_key, @IndexTypeDesc, @IndexOptions, @FileGroupName
while (@@fetch_status=0)
begin
 declare @IndexColumns varchar(max)
 declare @IncludedColumns varchar(max)
 set @IndexColumns=''
 set @IncludedColumns=''
 declare CursorIndexColumn cursor for 
 select col.name, ixc.is_descending_key, ixc.is_included_column
 from [PhotogAzure].[photog_backup].sys.tables tb 
 inner join [PhotogAzure].[photog_backup].sys.indexes ix on tb.object_id=ix.object_id
 inner join [PhotogAzure].[photog_backup].sys.index_columns ixc on ix.object_id=ixc.object_id and ix.index_id= ixc.index_id
 inner join [PhotogAzure].[photog_backup].sys.columns col on ixc.object_id =col.object_id  and ixc.column_id=col.column_id
 where ix.type>0 and (ix.is_primary_key=1 or ix.is_unique_constraint=1)
 and schema_name(tb.schema_id)=@SchemaName and tb.name=@TableName and ix.name=@IndexName
 order by ixc.key_ordinal
 open CursorIndexColumn 
 fetch next from CursorIndexColumn into  @ColumnName, @IsDescendingKey, @IsIncludedColumn
 while (@@fetch_status=0)
 begin
  if @IsIncludedColumn=0 
    set @IndexColumns=@IndexColumns + @ColumnName  + case when @IsDescendingKey=1  then ' DESC, ' else  ' ASC, ' end
  else 
   set @IncludedColumns=@IncludedColumns  + @ColumnName  +', ' 
     
  fetch next from CursorIndexColumn into @ColumnName, @IsDescendingKey, @IsIncludedColumn
 end
 close CursorIndexColumn
 deallocate CursorIndexColumn
 set @IndexColumns = substring(@IndexColumns, 1, len(@IndexColumns)-1)
 set @IncludedColumns = case when len(@IncludedColumns) >0 then substring(@IncludedColumns, 1, len(@IncludedColumns)-1) else '' end
--  print @IndexColumns
--  print @IncludedColumns

set @TSQLScripCreationIndex =''
set @TSQLScripDisableIndex =''
set  @TSQLScripCreationIndex='ALTER TABLE '+  QUOTENAME(@SchemaName) +'.'+ QUOTENAME(@TableName)+ ' ADD CONSTRAINT ' +  QUOTENAME(@IndexName) + @is_unique_constraint + @is_primary_key + +@IndexTypeDesc +  '('+@IndexColumns+'); '

 EXEC sp_executesql 
	@stmt = @TSQLScripCreationIndex
--print @TSQLScripDisableIndex

fetch next from CursorIndex into  @SchemaName, @TableName, @IndexName, @is_unique_constraint, @is_primary_key, @IndexTypeDesc, @IndexOptions, @FileGroupName

end
close CursorIndex
deallocate CursorIndex

END

GO
/****** Object:  StoredProcedure [dbo].[FROMCLOUD_GENERATE_FK]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[FROMCLOUD_GENERATE_FK]
	@SELECTION_CLOUD NVARCHAR(MAX) = ''
AS
BEGIN
--- SCRIPT TO GENERATE THE CREATION SCRIPT OF ALL FOREIGN KEY CONSTRAINTS
declare @ForeignKeyID int
declare @ForeignKeyName varchar(4000)
declare @ParentTableName varchar(4000)
declare @ParentColumn varchar(4000)
declare @ReferencedTable varchar(4000)
declare @ReferencedColumn varchar(4000)
declare @StrParentColumn varchar(max)
declare @StrReferencedColumn varchar(max)
declare @ParentTableSchema varchar(4000)
declare @ReferencedTableSchema varchar(4000)
declare @TSQLCreationFK nvarchar(max)
declare @SQL NVARCHAR(MAX)

SET @SQL = 'declare CursorFK cursor for 
select fk.object_id from [PhotogAzure].[photog_backup].sys.foreign_keys fk  inner join [PhotogAzure].[photog_backup].sys.tables t on fk.parent_object_id=t.object_id';

IF (@SELECTION_CLOUD != '')
BEGIN
	SET @SQL = CONCAT(@SQL, ' WHERE fk.referenced_object_id in ', @SELECTION_CLOUD);
END

EXECUTE sp_executesql @SQL;

open CursorFK
fetch next from CursorFK into @ForeignKeyID
while (@@FETCH_STATUS=0)
begin
 set @StrParentColumn=''
 set @StrReferencedColumn=''
 declare CursorFKDetails cursor for
  select  fk.name ForeignKeyName, schema_name(t1.schema_id) ParentTableSchema,
  t1.name ParentTable, c1.name ParentColumn,schema_name(t2.schema_id) ReferencedTableSchema,
   t2.name ReferencedTable,c2.name ReferencedColumn
  from --sys.tables t inner join 
  [PhotogAzure].[photog_backup].sys.foreign_keys fk 
  inner join [PhotogAzure].[photog_backup].sys.foreign_key_columns fkc on fk.object_id=fkc.constraint_object_id
  inner join [PhotogAzure].[photog_backup].sys.columns c1 on c1.object_id=fkc.parent_object_id and c1.column_id=fkc.parent_column_id 
  inner join [PhotogAzure].[photog_backup].sys.columns c2 on c2.object_id=fkc.referenced_object_id and c2.column_id=fkc.referenced_column_id 
  inner join [PhotogAzure].[photog_backup].sys.tables t1 on t1.object_id=fkc.parent_object_id 
  inner join [PhotogAzure].[photog_backup].sys.tables t2 on t2.object_id=fkc.referenced_object_id 
  where fk.object_id=@ForeignKeyID
 open CursorFKDetails
 fetch next from CursorFKDetails into  @ForeignKeyName, @ParentTableSchema, @ParentTableName, @ParentColumn, @ReferencedTableSchema, @ReferencedTable, @ReferencedColumn
 while (@@FETCH_STATUS=0)
 begin    
  set @StrParentColumn=@StrParentColumn + ', ' + quotename(@ParentColumn)
  set @StrReferencedColumn=@StrReferencedColumn + ', ' + quotename(@ReferencedColumn)
  
     fetch next from CursorFKDetails into  @ForeignKeyName, @ParentTableSchema, @ParentTableName, @ParentColumn, @ReferencedTableSchema, @ReferencedTable, @ReferencedColumn
 end
 close CursorFKDetails
 deallocate CursorFKDetails

 set @StrParentColumn=substring(@StrParentColumn,2,len(@StrParentColumn)-1)
 set @StrReferencedColumn=substring(@StrReferencedColumn,2,len(@StrReferencedColumn)-1)
 set @TSQLCreationFK='ALTER TABLE '+quotename(@ParentTableSchema)+'.'+quotename(@ParentTableName)+' WITH CHECK ADD CONSTRAINT '+quotename(@ForeignKeyName)
 + ' FOREIGN KEY('+ltrim(@StrParentColumn)+') '+ char(13) +'REFERENCES '+quotename(@ReferencedTableSchema)+'.'+quotename(@ReferencedTable)+' ('+ltrim(@StrReferencedColumn)+') ' + char(13)
 
 EXEC sp_executesql 
	@stmt = @TSQLCreationFK

fetch next from CursorFK into @ForeignKeyID 
end
close CursorFK
deallocate CursorFK
END
GO
/****** Object:  StoredProcedure [dbo].[FROMLOCAL_GENERATE_CONSTRAINT]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[FROMLOCAL_GENERATE_CONSTRAINT]
AS
BEGIN
--- SCRIPT TO GENERATE THE CREATION SCRIPT OF ALL PK AND UNIQUE CONSTRAINTS.
declare @SchemaName varchar(100)
declare @TableName varchar(256)
declare @IndexName varchar(256)
declare @ColumnName varchar(100)
declare @is_unique_constraint varchar(100)
declare @IndexTypeDesc varchar(100)
declare @FileGroupName varchar(100)
declare @is_disabled varchar(100)
declare @IndexOptions varchar(max)
declare @IndexColumnId int
declare @IsDescendingKey int 
declare @IsIncludedColumn int
declare @TSQLScripCreationIndex nvarchar(max)
declare @TSQLScripDisableIndex nvarchar(max)
declare @is_primary_key varchar(100)

declare CursorIndex cursor for
 select schema_name(t.schema_id) [schema_name], t.name, ix.name,
 case when ix.is_unique_constraint = 1 then ' UNIQUE ' else '' END 
    ,case when ix.is_primary_key = 1 then ' PRIMARY KEY ' else '' END 
 , ix.type_desc,
  case when ix.is_padded=1 then 'PAD_INDEX = ON, ' else 'PAD_INDEX = OFF, ' end
 + case when ix.allow_page_locks=1 then 'ALLOW_PAGE_LOCKS = ON, ' else 'ALLOW_PAGE_LOCKS = OFF, ' end
 + case when ix.allow_row_locks=1 then  'ALLOW_ROW_LOCKS = ON, ' else 'ALLOW_ROW_LOCKS = OFF, ' end
 + case when INDEXPROPERTY(t.object_id, ix.name, 'IsStatistics') = 1 then 'STATISTICS_NORECOMPUTE = ON, ' else 'STATISTICS_NORECOMPUTE = OFF, ' end
 + case when ix.ignore_dup_key=1 then 'IGNORE_DUP_KEY = ON, ' else 'IGNORE_DUP_KEY = OFF, ' end
 + 'SORT_IN_TEMPDB = OFF, FILLFACTOR =' + CAST(ix.fill_factor AS VARCHAR(3)) AS IndexOptions
 , FILEGROUP_NAME(ix.data_space_id) FileGroupName
 from sys.tables t 
 inner join sys.indexes ix on t.object_id=ix.object_id
 where ix.type>0 and  (ix.is_primary_key=1 or ix.is_unique_constraint=1) --and schema_name(tb.schema_id)= @SchemaName and tb.name=@TableName
 and t.is_ms_shipped=0 and t.name<>'sysdiagrams'
 order by schema_name(t.schema_id), t.name, ix.name
open CursorIndex
fetch next from CursorIndex into  @SchemaName, @TableName, @IndexName, @is_unique_constraint, @is_primary_key, @IndexTypeDesc, @IndexOptions, @FileGroupName
while (@@fetch_status=0)
begin
 declare @IndexColumns varchar(max)
 declare @IncludedColumns varchar(max)
 set @IndexColumns=''
 set @IncludedColumns=''
 declare CursorIndexColumn cursor for 
 select col.name, ixc.is_descending_key, ixc.is_included_column
 from sys.tables tb 
 inner join sys.indexes ix on tb.object_id=ix.object_id
 inner join sys.index_columns ixc on ix.object_id=ixc.object_id and ix.index_id= ixc.index_id
 inner join sys.columns col on ixc.object_id =col.object_id  and ixc.column_id=col.column_id
 where ix.type>0 and (ix.is_primary_key=1 or ix.is_unique_constraint=1)
 and schema_name(tb.schema_id)=@SchemaName and tb.name=@TableName and ix.name=@IndexName
 order by ixc.key_ordinal
 open CursorIndexColumn 
 fetch next from CursorIndexColumn into  @ColumnName, @IsDescendingKey, @IsIncludedColumn
 while (@@fetch_status=0)
 begin
  if @IsIncludedColumn=0 
    set @IndexColumns=@IndexColumns + @ColumnName  + case when @IsDescendingKey=1  then ' DESC, ' else  ' ASC, ' end
  else 
   set @IncludedColumns=@IncludedColumns  + @ColumnName  +', ' 
     
  fetch next from CursorIndexColumn into @ColumnName, @IsDescendingKey, @IsIncludedColumn
 end
 close CursorIndexColumn
 deallocate CursorIndexColumn
 set @IndexColumns = substring(@IndexColumns, 1, len(@IndexColumns)-1)
 set @IncludedColumns = case when len(@IncludedColumns) >0 then substring(@IncludedColumns, 1, len(@IncludedColumns)-1) else '' end
--  print @IndexColumns
--  print @IncludedColumns

set @TSQLScripCreationIndex =''
set @TSQLScripDisableIndex =''
set  @TSQLScripCreationIndex='ALTER TABLE '+  QUOTENAME(@SchemaName) +'.'+ QUOTENAME(@TableName)+ ' ADD CONSTRAINT ' +  QUOTENAME(@IndexName) + @is_unique_constraint + @is_primary_key + +@IndexTypeDesc +  '('+@IndexColumns+'); '

 EXEC (@TSQLScripCreationIndex) AT [PhotogAzure]
--print @TSQLScripDisableIndex

fetch next from CursorIndex into  @SchemaName, @TableName, @IndexName, @is_unique_constraint, @is_primary_key, @IndexTypeDesc, @IndexOptions, @FileGroupName

end
close CursorIndex
deallocate CursorIndex
END

GO
/****** Object:  StoredProcedure [dbo].[FROMLOCAL_GENERATE_FK]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[FROMLOCAL_GENERATE_FK]
AS
BEGIN
--- SCRIPT TO GENERATE THE CREATION SCRIPT OF ALL FOREIGN KEY CONSTRAINTS
declare @ForeignKeyID int
declare @ForeignKeyName varchar(4000)
declare @ParentTableName varchar(4000)
declare @ParentColumn varchar(4000)
declare @ReferencedTable varchar(4000)
declare @ReferencedColumn varchar(4000)
declare @StrParentColumn varchar(max)
declare @StrReferencedColumn varchar(max)
declare @ParentTableSchema varchar(4000)
declare @ReferencedTableSchema varchar(4000)
declare @TSQLCreationFK nvarchar(max)
--Written by Percy Reyes www.percyreyes.com
declare CursorFK cursor for select object_id--, name, object_name( parent_object_id) 
from sys.foreign_keys
open CursorFK
fetch next from CursorFK into @ForeignKeyID
while (@@FETCH_STATUS=0)
begin
 set @StrParentColumn=''
 set @StrReferencedColumn=''
 declare CursorFKDetails cursor for
  select  fk.name ForeignKeyName, schema_name(t1.schema_id) ParentTableSchema,
  t1.name ParentTable, c1.name ParentColumn,schema_name(t2.schema_id) ReferencedTableSchema,
   t2.name ReferencedTable,c2.name ReferencedColumn
  from --sys.tables t inner join 
  sys.foreign_keys fk 
  inner join sys.foreign_key_columns fkc on fk.object_id=fkc.constraint_object_id
  inner join sys.columns c1 on c1.object_id=fkc.parent_object_id and c1.column_id=fkc.parent_column_id 
  inner join sys.columns c2 on c2.object_id=fkc.referenced_object_id and c2.column_id=fkc.referenced_column_id 
  inner join sys.tables t1 on t1.object_id=fkc.parent_object_id 
  inner join sys.tables t2 on t2.object_id=fkc.referenced_object_id 
  where fk.object_id=@ForeignKeyID
 open CursorFKDetails
 fetch next from CursorFKDetails into  @ForeignKeyName, @ParentTableSchema, @ParentTableName, @ParentColumn, @ReferencedTableSchema, @ReferencedTable, @ReferencedColumn
 while (@@FETCH_STATUS=0)
 begin    
  set @StrParentColumn=@StrParentColumn + ', ' + quotename(@ParentColumn)
  set @StrReferencedColumn=@StrReferencedColumn + ', ' + quotename(@ReferencedColumn)
  
     fetch next from CursorFKDetails into  @ForeignKeyName, @ParentTableSchema, @ParentTableName, @ParentColumn, @ReferencedTableSchema, @ReferencedTable, @ReferencedColumn
 end
 close CursorFKDetails
 deallocate CursorFKDetails

 set @StrParentColumn=substring(@StrParentColumn,2,len(@StrParentColumn)-1)
 set @StrReferencedColumn=substring(@StrReferencedColumn,2,len(@StrReferencedColumn)-1)
 set @TSQLCreationFK='ALTER TABLE '+quotename(@ParentTableSchema)+'.'+quotename(@ParentTableName)+' WITH CHECK ADD CONSTRAINT '+quotename(@ForeignKeyName)
 + ' FOREIGN KEY('+ltrim(@StrParentColumn)+') '+ char(13) +'REFERENCES '+quotename(@ReferencedTableSchema)+'.'+quotename(@ReferencedTable)+' ('+ltrim(@StrReferencedColumn)+') ' + char(13)
 
 EXEC (@TSQLCreationFK) AT [PhotogAzure]
 
fetch next from CursorFK into @ForeignKeyID 
end
close CursorFK
deallocate CursorFK
END

GO
/****** Object:  StoredProcedure [dbo].[GENERATE_CONSTRAINT]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[GENERATE_CONSTRAINT]
AS
BEGIN
--- SCRIPT TO GENERATE THE CREATION SCRIPT OF ALL PK AND UNIQUE CONSTRAINTS.
declare @SchemaName varchar(100)
declare @TableName varchar(256)
declare @IndexName varchar(256)
declare @ColumnName varchar(100)
declare @is_unique_constraint varchar(100)
declare @IndexTypeDesc varchar(100)
declare @FileGroupName varchar(100)
declare @is_disabled varchar(100)
declare @IndexOptions varchar(max)
declare @IndexColumnId int
declare @IsDescendingKey int 
declare @IsIncludedColumn int
declare @TSQLScripCreationIndex varchar(max)
declare @TSQLScripDisableIndex varchar(max)
declare @is_primary_key varchar(100)

declare CursorIndex cursor for
 select schema_name(t.schema_id) [schema_name], t.name, ix.name,
 case when ix.is_unique_constraint = 1 then ' UNIQUE ' else '' END 
    ,case when ix.is_primary_key = 1 then ' PRIMARY KEY ' else '' END 
 , ix.type_desc,
  case when ix.is_padded=1 then 'PAD_INDEX = ON, ' else 'PAD_INDEX = OFF, ' end
 + case when ix.allow_page_locks=1 then 'ALLOW_PAGE_LOCKS = ON, ' else 'ALLOW_PAGE_LOCKS = OFF, ' end
 + case when ix.allow_row_locks=1 then  'ALLOW_ROW_LOCKS = ON, ' else 'ALLOW_ROW_LOCKS = OFF, ' end
 + case when INDEXPROPERTY(t.object_id, ix.name, 'IsStatistics') = 1 then 'STATISTICS_NORECOMPUTE = ON, ' else 'STATISTICS_NORECOMPUTE = OFF, ' end
 + case when ix.ignore_dup_key=1 then 'IGNORE_DUP_KEY = ON, ' else 'IGNORE_DUP_KEY = OFF, ' end
 + 'SORT_IN_TEMPDB = OFF, FILLFACTOR =' + CAST(ix.fill_factor AS VARCHAR(3)) AS IndexOptions
 , FILEGROUP_NAME(ix.data_space_id) FileGroupName
 from [PhotogAzure].[photog].sys.tables t 
 inner join [PhotogAzure].[photog].sys.indexes ix on t.object_id=ix.object_id
 where ix.type>0 and  (ix.is_primary_key=1 or ix.is_unique_constraint=1) --and [PhotogAzure]schema_name(tb.schema_id)= @SchemaName and tb.name=@TableName
 and t.is_ms_shipped=0 and t.name<>'sysdiagrams'
 order by schema_name(t.schema_id), t.name, ix.name
open CursorIndex
fetch next from CursorIndex into  @SchemaName, @TableName, @IndexName, @is_unique_constraint, @is_primary_key, @IndexTypeDesc, @IndexOptions, @FileGroupName
while (@@fetch_status=0)
begin
 declare @IndexColumns varchar(max)
 declare @IncludedColumns varchar(max)
 set @IndexColumns=''
 set @IncludedColumns=''
 declare CursorIndexColumn cursor for 
 select col.name, ixc.is_descending_key, ixc.is_included_column
 from sys.tables tb 
 inner join sys.indexes ix on tb.object_id=ix.object_id
 inner join sys.index_columns ixc on ix.object_id=ixc.object_id and ix.index_id= ixc.index_id
 inner join sys.columns col on ixc.object_id =col.object_id  and ixc.column_id=col.column_id
 where ix.type>0 and (ix.is_primary_key=1 or ix.is_unique_constraint=1)
 and schema_name(tb.schema_id)=@SchemaName and tb.name=@TableName and ix.name=@IndexName
 order by ixc.key_ordinal
 open CursorIndexColumn 
 fetch next from CursorIndexColumn into  @ColumnName, @IsDescendingKey, @IsIncludedColumn
 while (@@fetch_status=0)
 begin
  if @IsIncludedColumn=0 
    set @IndexColumns=@IndexColumns + @ColumnName  + case when @IsDescendingKey=1  then ' DESC, ' else  ' ASC, ' end
  else 
   set @IncludedColumns=@IncludedColumns  + @ColumnName  +', ' 
     
  fetch next from CursorIndexColumn into @ColumnName, @IsDescendingKey, @IsIncludedColumn
 end
 close CursorIndexColumn
 deallocate CursorIndexColumn
 --set @IndexColumns = substring(@IndexColumns, 1, len(@IndexColumns)-1)
 --set @IncludedColumns = case when len(@IncludedColumns) >0 then substring(@IncludedColumns, 1, len(@IncludedColumns)-1) else '' end

--  print @IndexColumns
--  print @IncludedColumns

set @TSQLScripCreationIndex =''
set @TSQLScripDisableIndex =''
set  @TSQLScripCreationIndex='ALTER TABLE [photog].'+  QUOTENAME(@SchemaName) +'.'+ QUOTENAME(@TableName)+ ' ADD CONSTRAINT ' +  QUOTENAME(@IndexName) + @is_unique_constraint + @is_primary_key + +@IndexTypeDesc +  '('+@IndexColumns+') '+ 
 case when len(@IncludedColumns)>0 then CHAR(13) +'INCLUDE (' + @IncludedColumns+ ')' else '' end + CHAR(13)+'WITH (' + @IndexOptions+ ') ON ' + QUOTENAME(@FileGroupName) + ';'  

 print @TSQLScripCreationIndex
 print @TSQLScripDisableIndex

  --EXEC @TSQLScripCreationIndex

fetch next from CursorIndex into  @SchemaName, @TableName, @IndexName, @is_unique_constraint, @is_primary_key, @IndexTypeDesc, @IndexOptions, @FileGroupName

end
close CursorIndex
deallocate CursorIndex
END
GO
/****** Object:  StoredProcedure [dbo].[GENERATE_OBJ_ID]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    PROC [dbo].[GENERATE_OBJ_ID] 
	@SERVER_DETAIL NVARCHAR(MAX),
	@COLUMN_TO_SEARCH NVARCHAR(MAX),
	@table_condition NVARCHAR(MAX) OUTPUT
AS	
BEGIN	
	DECLARE @table_name NVARCHAR(MAX)
	DECLARE @sql_xml XML = Cast('<root><U>'+ Replace(@COLUMN_TO_SEARCH, ',', '</U><U>')+ '</U></root>' AS XML)
	DECLARE Cursor_WhereTableName CURSOR FOR
		SELECT trim(f.x.value('.', 'nvarchar(max)'))
		FROM @sql_xml.nodes('/root/U') f(x)
	OPEN Cursor_WhereTableName
	FETCH NEXT FROM Cursor_WhereTableName INTO @table_name

	While @@FETCH_STATUS = 0
	BEGIN
		IF (@table_condition != '')
		BEGIN
			SET @table_condition = CONCAT(@table_condition , ' OR ')
		END

		SET @table_condition = CONCAT(@table_condition , 'name = ''' , @table_name , '''')

		FETCH NEXT FROM Cursor_WhereTableName INTO @table_name
	END

	CLOSE Cursor_WhereTableName
	DEALLOCATE Cursor_WhereTableName

	IF @table_condition != ''
	BEGIN
		SET @table_condition = CONCAT('(SELECT object_id from ', @SERVER_DETAIL, 'sys.tables where ' , @table_condition, ')')
	END
END


GO
/****** Object:  StoredProcedure [dbo].[OFF_CONSTR_LOCAL]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[OFF_CONSTR_LOCAL]
AS
BEGIN
DECLARE @tableName varchar(max)
DECLARE @sql nvarchar(max)

DECLARE Cursor_TableName CURSOR FOR
SELECT Table_Name  
FROM INFORMATION_SCHEMA.TABLES c  
WHERE c.TABLE_TYPE = 'BASE TABLE'

OPEN Cursor_TableName
FETCH NEXT FROM Cursor_TableName INTO @tableName

While @@FETCH_STATUS = 0
BEGIN
	 set @sql = 'ALTER TABLE [dbo].[' + @tableName + '] NOCHECK CONSTRAINT all'
	exec sp_executesql
		@statement = @sql
	FETCH NEXT FROM Cursor_TableName INTO @tableName
END

CLOSE Cursor_TableName
DEALLOCATE Cursor_TableName
END
GO
/****** Object:  StoredProcedure [dbo].[OFF_CONSTR_REMOTE]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[OFF_CONSTR_REMOTE]
AS
BEGIN
DECLARE @tableName varchar(max)
DECLARE @sql nvarchar(max)

DECLARE Cursor_TableName CURSOR FOR
SELECT Table_Name  
FROM [PhotogAzure].[photog_backup].INFORMATION_SCHEMA.TABLES c  
WHERE c.TABLE_TYPE = 'BASE TABLE'

OPEN Cursor_TableName
FETCH NEXT FROM Cursor_TableName INTO @tableName

While @@FETCH_STATUS = 0
BEGIN
	 set @sql = 'ALTER TABLE [' + @tableName + '] NOCHECK CONSTRAINT all'
	EXEC (@sql) AT [PhotogAzure]

	FETCH NEXT FROM Cursor_TableName INTO @tableName
END

CLOSE Cursor_TableName
DEALLOCATE Cursor_TableName
END
GO
/****** Object:  StoredProcedure [dbo].[ON_CONSTR_LOCAL]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROC [dbo].[ON_CONSTR_LOCAL]
AS
BEGIN
DECLARE @tableName varchar(max)
DECLARE @sql nvarchar(max)

DECLARE Cursor_TableName CURSOR FOR
SELECT Table_Name  
FROM INFORMATION_SCHEMA.TABLES c  
WHERE c.TABLE_TYPE = 'BASE TABLE'

OPEN Cursor_TableName
FETCH NEXT FROM Cursor_TableName INTO @tableName

While @@FETCH_STATUS = 0
BEGIN
	 set @sql = 'ALTER TABLE [dbo].[' + @tableName + '] CHECK CONSTRAINT ALL'
	exec sp_executesql
		@statement = @sql
	FETCH NEXT FROM Cursor_TableName INTO @tableName
END

CLOSE Cursor_TableName
DEALLOCATE Cursor_TableName
END
GO
/****** Object:  StoredProcedure [dbo].[RESTORE_LOCAL]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[RESTORE_LOCAL]
	@WHERE_TABLES NVARCHAR(MAX) = ''
AS
	DECLARE @SELECTION_LOCAL NVARCHAR(MAX), @SELECTION_CLOUD NVARCHAR(MAX)
BEGIN

	IF (@WHERE_TABLES != '')
	BEGIN 
		EXEC GENERATE_OBJ_ID 
			@SERVER_DETAIL = N'[PhotogAzure].[photog_backup].', 
			@COLUMN_TO_SEARCH = @WHERE_TABLES ,
			@table_condition = @SELECTION_CLOUD  OUTPUT

		EXEC GENERATE_OBJ_ID 
			@SERVER_DETAIL = N'', 
			@COLUMN_TO_SEARCH = @WHERE_TABLES ,
			@table_condition = @SELECTION_LOCAL OUTPUT
	END

	EXEC OFF_CONSTR_LOCAL

	EXEC DROP_LOCAL_TBL
		@SELECTION_LOCAL

	EXEC CREATE_TBL_FROM_CLOUD
		@SELECTION_CLOUD

	EXEC SELECT_REMOTE_TBL
		@SELECTION_LOCAL

	EXEC FROMCLOUD_GENERATE_CONSTRAINT
		@SELECTION_CLOUD

	EXEC FROMCLOUD_GENERATE_FK
		@SELECTION_CLOUD

	EXEC ON_CONSTR_LOCAL
END
GO
/****** Object:  StoredProcedure [dbo].[SELECT_LOCAL_TBL]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[SELECT_LOCAL_TBL]
AS
BEGIN
declare @TSQL nvarchar(max)
declare @TableName nvarchar(max)
declare @columns nvarchar(max)

DECLARE Cursor_TableName CURSOR FOR
SELECT Table_Name  
FROM INFORMATION_SCHEMA.TABLES c  
WHERE c.TABLE_TYPE = 'BASE TABLE'
OPEN Cursor_TableName
FETCH NEXT FROM Cursor_TableName INTO @TableName
While @@FETCH_STATUS = 0
BEGIN
	SET @TSQL = 'SELECT @columns = SUBSTRING(
    (SELECT '', '' + QUOTENAME(COLUMN_NAME)
        FROM INFORMATION_SCHEMA.COLUMNS
        WHERE TABLE_NAME = ''' + @TableName + '''
        ORDER BY ORDINAL_POSITION
        FOR XML path('''')),
    3,
    200000);'

	exec sp_executesql
		@TSQL,
		N'@columns nvarchar(max) OUTPUT',
		@columns = @columns OUTPUT 

	SET @TSQL = 'SELECT * INTO [dbo].[' + @TableName + '2] FROM [dbo].[' + @TableName + '] UNION ALL SELECT * FROM [dbo].[' + @TableName + '] WHERE 1 = 0;'
	EXEC(@TSQL) AT [PhotogAzure]
	
	SET @TSQL = 'INSERT INTO [PhotogAzure].[photog_backup].[dbo].[' + @TableName + '2] ('+ @columns + ') SELECT '+ @columns + ' FROM [dbo].[' + @TableName + '];'
	exec sp_executesql
		@statement = @TSQL
	
	
	SET @TSQL = 'SET IDENTITY_INSERT [dbo].[' + @TableName + '] ON;
		ALTER TABLE [dbo].[' + @TableName + '2] SWITCH TO [dbo].[' + @TableName + '];
		SET IDENTITY_INSERT [dbo].[' + @TableName + '] OFF;
		DROP TABLE [dbo].[' + @TableName + '2];'
	EXEC(@TSQL) AT [PhotogAzure]

	FETCH NEXT FROM Cursor_TableName INTO @TableName
END

CLOSE Cursor_TableName
DEALLOCATE Cursor_TableName
END
GO
/****** Object:  StoredProcedure [dbo].[SELECT_REMOTE_TBL]    Script Date: 27/1/2021 10:59:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SELECT_REMOTE_TBL]
	@SELECTION_LOCAL NVARCHAR(MAX) = ''
AS
BEGIN
declare @TSQL nvarchar(max)
, @TableName nvarchar(max)
, @columns nvarchar(max)

SET @TSQL = 
'
DECLARE Cursor_TableName CURSOR FOR
select name from sys.tables where type = ''U''
';
	

IF @SELECTION_LOCAL != ''
BEGIN
	SET @TSQL = CONCAT(@TSQL ,' AND object_id IN ' + @SELECTION_LOCAL)
END

EXECUTE sp_executesql @TSQL;

OPEN Cursor_TableName
FETCH NEXT FROM Cursor_TableName INTO @TableName
While @@FETCH_STATUS = 0
BEGIN
	SET @TSQL = 'SELECT @columns = SUBSTRING(
    (SELECT '', '' + QUOTENAME(COLUMN_NAME)
        FROM INFORMATION_SCHEMA.COLUMNS
        WHERE TABLE_NAME = ''' + @TableName + '''
        ORDER BY ORDINAL_POSITION
        FOR XML path('''')),
    3,
    200000);'

	exec sp_executesql
		@TSQL,
		N'@columns nvarchar(max) OUTPUT',
		@columns = @columns OUTPUT 

	SET @TSQL = 'SET IDENTITY_INSERT [dbo].[' + @TableName + '] ON;'+
	'INSERT INTO [dbo].[' + @TableName + '] ('+ @columns + ') SELECT '+ @columns + ' FROM [PhotogAzure].[photog_backup].[dbo].[' + @TableName + '];
	SET IDENTITY_INSERT [dbo].[' + @TableName + '] OFF;'

		exec sp_executesql
		@statement = @TSQL
	FETCH NEXT FROM Cursor_TableName INTO @TableName
END

CLOSE Cursor_TableName
DEALLOCATE Cursor_TableName
END
GO
USE [master]
GO
ALTER DATABASE [photog] SET  READ_WRITE 
GO
