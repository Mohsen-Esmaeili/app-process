USE [master]
GO
/****** Object:  Database [ApplicationProcess]    Script Date: 10/26/2021 3:55:27 PM ******/
CREATE DATABASE [ApplicationProcess]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ApplicationProcess', FILENAME = N'D:\Work\Projects\Application Process\Database\ApplicationProcess.mdf' , SIZE = 524288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 524288KB ), 
 FILEGROUP [ApplicationProcessDB_Data]  DEFAULT
( NAME = N'ApplicationProcessDB_Data', FILENAME = N'D:\Work\Projects\Application Process\Database\ApplicationProcessDB_Data.ndf' , SIZE = 524288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 524288KB ), 
 FILEGROUP [ApplicationProcessDB_Index] 
( NAME = N'ApplicationProcessDB_Index', FILENAME = N'D:\Work\Projects\Application Process\Database\ApplicationProcessDB_Index.ndf' , SIZE = 524288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 524288KB ), 
 FILEGROUP [ApplicationProcessDB_LOB] 
( NAME = N'ApplicationProcessDB_LOB', FILENAME = N'D:\Work\Projects\Application Process\Database\ApplicationProcessDB_LOB.ndf' , SIZE = 524288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 524288KB )
 LOG ON 
( NAME = N'ApplicationProcess_log', FILENAME = N'D:\Work\Projects\Application Process\Database\ApplicationProcess_log.ldf' , SIZE = 524288KB , MAXSIZE = 2048GB , FILEGROWTH = 524288KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ApplicationProcess] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ApplicationProcess].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ApplicationProcess] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ApplicationProcess] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ApplicationProcess] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ApplicationProcess] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ApplicationProcess] SET ARITHABORT OFF 
GO
ALTER DATABASE [ApplicationProcess] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ApplicationProcess] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ApplicationProcess] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ApplicationProcess] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ApplicationProcess] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ApplicationProcess] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ApplicationProcess] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ApplicationProcess] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ApplicationProcess] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ApplicationProcess] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ApplicationProcess] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ApplicationProcess] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ApplicationProcess] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ApplicationProcess] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ApplicationProcess] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ApplicationProcess] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ApplicationProcess] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ApplicationProcess] SET RECOVERY FULL 
GO
ALTER DATABASE [ApplicationProcess] SET  MULTI_USER 
GO
ALTER DATABASE [ApplicationProcess] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ApplicationProcess] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ApplicationProcess] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ApplicationProcess] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ApplicationProcess] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ApplicationProcess] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ApplicationProcess', N'ON'
GO
ALTER DATABASE [ApplicationProcess] SET QUERY_STORE = OFF
GO
USE [ApplicationProcess]
GO
/****** Object:  Table [dbo].[Asset]    Script Date: 10/26/2021 3:55:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asset](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Symbol] [nvarchar](50) NULL,
 CONSTRAINT [PK_Asset] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [ApplicationProcessDB_Data]
) ON [ApplicationProcessDB_Data]
GO
/****** Object:  Table [dbo].[User]    Script Date: 10/26/2021 3:55:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[Email] [nvarchar](50) NULL,
	[PostalCode] [varchar](50) NOT NULL,
	[Street] [nvarchar](50) NOT NULL,
	[HouseNumber] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [ApplicationProcessDB_Data]
) ON [ApplicationProcessDB_Data]
GO
/****** Object:  Table [dbo].[UserAsset]    Script Date: 10/26/2021 3:55:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAsset](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[AssetId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_UserAsset_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [ApplicationProcessDB_Data]
) ON [ApplicationProcessDB_Data]
GO
/****** Object:  Index [IX_UserAsset]    Script Date: 10/26/2021 3:55:28 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserAsset] ON [dbo].[UserAsset]
(
	[UserId] ASC,
	[AssetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [ApplicationProcessDB_Data]
GO
ALTER TABLE [dbo].[Asset] ADD  CONSTRAINT [DF_Asset_Id]  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[UserAsset]  WITH CHECK ADD  CONSTRAINT [FK_UserAsset_Asset] FOREIGN KEY([AssetId])
REFERENCES [dbo].[Asset] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserAsset] CHECK CONSTRAINT [FK_UserAsset_Asset]
GO
ALTER TABLE [dbo].[UserAsset]  WITH CHECK ADD  CONSTRAINT [FK_UserAsset_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserAsset] CHECK CONSTRAINT [FK_UserAsset_User]
GO
USE [master]
GO
ALTER DATABASE [ApplicationProcess] SET  READ_WRITE 
GO
