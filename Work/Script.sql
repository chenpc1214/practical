USE [master]
GO
/****** Object:  Database [WorkDb]    Script Date: 2021/6/9 下午 10:10:15 ******/
CREATE DATABASE [WorkDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WorkDb', FILENAME = N'C:\Users\user\WorkDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WorkDb_log', FILENAME = N'C:\Users\user\WorkDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [WorkDb] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WorkDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WorkDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WorkDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WorkDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WorkDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WorkDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [WorkDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [WorkDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WorkDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WorkDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WorkDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WorkDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WorkDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WorkDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WorkDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WorkDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [WorkDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WorkDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WorkDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WorkDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WorkDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WorkDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [WorkDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WorkDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WorkDb] SET  MULTI_USER 
GO
ALTER DATABASE [WorkDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WorkDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WorkDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WorkDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WorkDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WorkDb] SET QUERY_STORE = OFF
GO
USE [WorkDb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [WorkDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2021/6/9 下午 10:10:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 2021/6/9 下午 10:10:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Mobile] [nvarchar](max) NULL,
	[sth] [nvarchar](max) NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210607150152_init', N'5.0.6')
GO
SET IDENTITY_INSERT [dbo].[Item] ON 

INSERT [dbo].[Item] ([Id], [Name], [Mobile], [sth]) VALUES (2, N'Abigail', N'0987456321', N'文件夾')
INSERT [dbo].[Item] ([Id], [Name], [Mobile], [sth]) VALUES (3, N'Eric', N'0923574158', N'鉛筆盒')
INSERT [dbo].[Item] ([Id], [Name], [Mobile], [sth]) VALUES (4, N'Adelaide', N'468465116', N'便條紙')
INSERT [dbo].[Item] ([Id], [Name], [Mobile], [sth]) VALUES (5, N'Afra', N'53646611', N'書籍')
INSERT [dbo].[Item] ([Id], [Name], [Mobile], [sth]) VALUES (6, N'Agatha', N'364611323', N'咖啡')
INSERT [dbo].[Item] ([Id], [Name], [Mobile], [sth]) VALUES (7, N'Agle', N'123456789101112', N'錢包')
INSERT [dbo].[Item] ([Id], [Name], [Mobile], [sth]) VALUES (8, N'Alberta', N'654694', N'墨水')
INSERT [dbo].[Item] ([Id], [Name], [Mobile], [sth]) VALUES (9, N'Alexia', N'2346146123', N'手套')
INSERT [dbo].[Item] ([Id], [Name], [Mobile], [sth]) VALUES (10, N'Alice', N'36461621612', N'溜冰鞋')
INSERT [dbo].[Item] ([Id], [Name], [Mobile], [sth]) VALUES (11, N'Alma', N'6463163', N'衣服')
INSERT [dbo].[Item] ([Id], [Name], [Mobile], [sth]) VALUES (12, N'Jacky', N'53653463', N'麵包')
INSERT [dbo].[Item] ([Id], [Name], [Mobile], [sth]) VALUES (13, N'Jack', N'6469414', N'眼鏡')
INSERT [dbo].[Item] ([Id], [Name], [Mobile], [sth]) VALUES (14, N'Buckley', N'0955005202', N'腳架')
INSERT [dbo].[Item] ([Id], [Name], [Mobile], [sth]) VALUES (15, N'Calder', N'0911818391', N'杯子')
INSERT [dbo].[Item] ([Id], [Name], [Mobile], [sth]) VALUES (17, N'Mullally', N'0912242821', N'相機')
INSERT [dbo].[Item] ([Id], [Name], [Mobile], [sth]) VALUES (18, N'Gary', N'0955878103', N'鋼琴')
INSERT [dbo].[Item] ([Id], [Name], [Mobile], [sth]) VALUES (20, N'Harper', N'0955732965', N'車子')
INSERT [dbo].[Item] ([Id], [Name], [Mobile], [sth]) VALUES (22, N'BOB', N'4534648345', N'蛋糕')
INSERT [dbo].[Item] ([Id], [Name], [Mobile], [sth]) VALUES (23, N'George', N'0916398306', N'枕頭')
INSERT [dbo].[Item] ([Id], [Name], [Mobile], [sth]) VALUES (24, N'Mullally', N'0968412189', N'冰淇淋')
INSERT [dbo].[Item] ([Id], [Name], [Mobile], [sth]) VALUES (25, N'Vivian', N'095452265', N'墨水')
SET IDENTITY_INSERT [dbo].[Item] OFF
GO
USE [master]
GO
ALTER DATABASE [WorkDb] SET  READ_WRITE 
GO
