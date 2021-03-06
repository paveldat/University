/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2017 (14.0.1000)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Express Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [master]
GO
/****** Object:  Database [UpComany]    Script Date: 08.03.2021 02:27:56 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'UpComany')
BEGIN
CREATE DATABASE [UpComany]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UpComany', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\UpComany.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UpComany_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\UpComany_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 COLLATE Cyrillic_General_CI_AS
END
GO
ALTER DATABASE [UpComany] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UpComany].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UpComany] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UpComany] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UpComany] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UpComany] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UpComany] SET ARITHABORT OFF 
GO
ALTER DATABASE [UpComany] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UpComany] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UpComany] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UpComany] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UpComany] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UpComany] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UpComany] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UpComany] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UpComany] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UpComany] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UpComany] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UpComany] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UpComany] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UpComany] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UpComany] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UpComany] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UpComany] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UpComany] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UpComany] SET  MULTI_USER 
GO
ALTER DATABASE [UpComany] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UpComany] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UpComany] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UpComany] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UpComany] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [UpComany] SET QUERY_STORE = OFF
GO
ALTER AUTHORIZATION ON DATABASE::[UpComany] TO [KIRILL\kiril]
GO
USE [UpComany]
GO
GRANT VIEW ANY COLUMN ENCRYPTION KEY DEFINITION TO [public] AS [dbo]
GO
GRANT VIEW ANY COLUMN MASTER KEY DEFINITION TO [public] AS [dbo]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 08.03.2021 02:27:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[User_id] [int] IDENTITY(1,1) NOT NULL,
	[Role_id] [int] NOT NULL,
	[FIO] [nvarchar](60) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[Passport] [varchar](10) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[Phone] [nchar](11) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[Login] [varchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[Password] [varchar](64) COLLATE Cyrillic_General_CI_AS NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[User_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
ALTER AUTHORIZATION ON [dbo].[Users] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Executor]    Script Date: 08.03.2021 02:27:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Executor]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Executor](
	[Executor_id] [int] IDENTITY(1,1) NOT NULL,
	[FIO] [nvarchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[Phone] [nchar](11) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[Passport] [varchar](10) COLLATE Cyrillic_General_CI_AS NOT NULL,
 CONSTRAINT [PK_Executor] PRIMARY KEY CLUSTERED 
(
	[Executor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
ALTER AUTHORIZATION ON [dbo].[Executor] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Bid]    Script Date: 08.03.2021 02:27:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bid]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Bid](
	[Bid_id] [int] IDENTITY(1,1) NOT NULL,
	[BidTime] [datetime] NOT NULL,
	[ExecutorSchedule_id] [int] NOT NULL,
	[BidStatus] [char](1) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[TypeWork] [nvarchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[Client_id] [int] NOT NULL,
	[BidPrice_id] [int] NULL,
	[User_id] [int] NOT NULL,
 CONSTRAINT [PK_Bid] PRIMARY KEY CLUSTERED 
(
	[Bid_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
ALTER AUTHORIZATION ON [dbo].[Bid] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[ExecutorSchedule]    Script Date: 08.03.2021 02:27:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExecutorSchedule]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ExecutorSchedule](
	[ExecutorSchedule_id] [int] IDENTITY(1,1) NOT NULL,
	[Executor_id] [int] NOT NULL,
	[LeadTime_id] [int] NULL,
 CONSTRAINT [PK_ExecutorSchedule] PRIMARY KEY CLUSTERED 
(
	[ExecutorSchedule_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
ALTER AUTHORIZATION ON [dbo].[ExecutorSchedule] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 08.03.2021 02:27:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clients]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Clients](
	[Client_id] [int] IDENTITY(1,1) NOT NULL,
	[FIO] [nvarchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[Phone] [nchar](11) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[Adress] [nvarchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[Client_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
ALTER AUTHORIZATION ON [dbo].[Clients] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[BidDispatcher]    Script Date: 08.03.2021 02:27:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[BidDispatcher]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[BidDispatcher]
AS
SELECT        b.BidTime, b.BidStatus, b.TypeWork, es.ExecutorSchedule_id AS NumExec, e.FIO AS FIOExec, e.Phone AS PhoneExec, c.FIO AS FIOClient, c.Phone AS PhoneClient
FROM            dbo.Bid AS b INNER JOIN
                         dbo.ExecutorSchedule AS es ON es.ExecutorSchedule_id = b.ExecutorSchedule_id INNER JOIN
                         dbo.Executor AS e ON e.Executor_id = es.Executor_id INNER JOIN
                         dbo.Clients AS c ON c.Client_id = b.Client_id INNER JOIN
                         dbo.Users AS u ON u.User_id = b.User_id
' 
GO
ALTER AUTHORIZATION ON [dbo].[BidDispatcher] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[BidPrice]    Script Date: 08.03.2021 02:27:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BidPrice]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BidPrice](
	[BidPrice_id] [int] IDENTITY(1,1) NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_BidPrice] PRIMARY KEY CLUSTERED 
(
	[BidPrice_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
ALTER AUTHORIZATION ON [dbo].[BidPrice] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Houses]    Script Date: 08.03.2021 02:27:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Houses]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Houses](
	[House_id] [int] IDENTITY(1,1) NOT NULL,
	[HouseView_id] [int] NOT NULL,
	[HouseOver_id] [int] NOT NULL,
	[Price_id] [int] NULL,
	[Adress] [nvarchar](20) COLLATE Cyrillic_General_CI_AS NOT NULL,
 CONSTRAINT [PK_Houses] PRIMARY KEY CLUSTERED 
(
	[House_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
ALTER AUTHORIZATION ON [dbo].[Houses] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[HousesOverhaul]    Script Date: 08.03.2021 02:27:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HousesOverhaul]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[HousesOverhaul](
	[HouseOver_id] [int] IDENTITY(1,1) NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
	[ListOfWork] [nvarchar](100) COLLATE Cyrillic_General_CI_AS NULL,
 CONSTRAINT [PK_HousesOverhaul] PRIMARY KEY CLUSTERED 
(
	[HouseOver_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
ALTER AUTHORIZATION ON [dbo].[HousesOverhaul] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[HousesView]    Script Date: 08.03.2021 02:27:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HousesView]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[HousesView](
	[HouseView_id] [int] IDENTITY(1,1) NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
	[Defects] [nvarchar](100) COLLATE Cyrillic_General_CI_AS NULL,
 CONSTRAINT [PK_HousesView] PRIMARY KEY CLUSTERED 
(
	[HouseView_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
ALTER AUTHORIZATION ON [dbo].[HousesView] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[LeadTime]    Script Date: 08.03.2021 02:27:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LeadTime]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LeadTime](
	[LeadTime_id] [int] IDENTITY(1,1) NOT NULL,
	[Time] [nvarchar](16) COLLATE Cyrillic_General_CI_AS NOT NULL,
 CONSTRAINT [PK_LeadTime] PRIMARY KEY CLUSTERED 
(
	[LeadTime_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
ALTER AUTHORIZATION ON [dbo].[LeadTime] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Overhaul]    Script Date: 08.03.2021 02:27:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Overhaul]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Overhaul](
	[Overhaul_id] [int] IDENTITY(1,1) NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_Overhaul] PRIMARY KEY CLUSTERED 
(
	[Overhaul_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
ALTER AUTHORIZATION ON [dbo].[Overhaul] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Price]    Script Date: 08.03.2021 02:27:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Price]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Price](
	[Price_id] [int] IDENTITY(1,1) NOT NULL,
	[BidPrice_id] [int] NULL,
	[User_id] [int] NOT NULL,
	[Overhaul_id] [int] NOT NULL,
 CONSTRAINT [PK_Price] PRIMARY KEY CLUSTERED 
(
	[Price_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
ALTER AUTHORIZATION ON [dbo].[Price] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[References]    Script Date: 08.03.2021 02:27:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[References]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[References](
	[Reference_id] [int] IDENTITY(1,1) NOT NULL,
	[Client_id] [int] NOT NULL,
	[Status] [char](1) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[User_id] [int] NOT NULL,
 CONSTRAINT [PK_References] PRIMARY KEY CLUSTERED 
(
	[Reference_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
ALTER AUTHORIZATION ON [dbo].[References] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Role]    Script Date: 08.03.2021 02:27:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Role]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Role](
	[Role_id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) COLLATE Cyrillic_General_CI_AS NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
ALTER AUTHORIZATION ON [dbo].[Role] TO  SCHEMA OWNER 
GO
SET IDENTITY_INSERT [dbo].[Bid] ON 

INSERT [dbo].[Bid] ([Bid_id], [BidTime], [ExecutorSchedule_id], [BidStatus], [TypeWork], [Client_id], [BidPrice_id], [User_id]) VALUES (10, CAST(N'2021-03-07T22:13:41.813' AS DateTime), 2, N'0', N'Сантехника', 1, 5, 15)
INSERT [dbo].[Bid] ([Bid_id], [BidTime], [ExecutorSchedule_id], [BidStatus], [TypeWork], [Client_id], [BidPrice_id], [User_id]) VALUES (11, CAST(N'2021-03-07T22:13:41.813' AS DateTime), 3, N'1', N'Слесарство', 2, 2, 16)
INSERT [dbo].[Bid] ([Bid_id], [BidTime], [ExecutorSchedule_id], [BidStatus], [TypeWork], [Client_id], [BidPrice_id], [User_id]) VALUES (12, CAST(N'2021-03-07T23:29:38.917' AS DateTime), 13, N'1', N'Сварить суп', 2, 6, 15)
SET IDENTITY_INSERT [dbo].[Bid] OFF
GO
SET IDENTITY_INSERT [dbo].[BidPrice] ON 

INSERT [dbo].[BidPrice] ([BidPrice_id], [Price]) VALUES (1, 654.0000)
INSERT [dbo].[BidPrice] ([BidPrice_id], [Price]) VALUES (2, 585.0000)
INSERT [dbo].[BidPrice] ([BidPrice_id], [Price]) VALUES (3, 1234.0000)
INSERT [dbo].[BidPrice] ([BidPrice_id], [Price]) VALUES (4, 465465.0000)
INSERT [dbo].[BidPrice] ([BidPrice_id], [Price]) VALUES (5, 4654.0000)
INSERT [dbo].[BidPrice] ([BidPrice_id], [Price]) VALUES (6, 6666.0000)
SET IDENTITY_INSERT [dbo].[BidPrice] OFF
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([Client_id], [FIO], [Phone], [Adress]) VALUES (1, N'Петров Петр Васильевич', N'89653216549', N'Пушкина 31')
INSERT [dbo].[Clients] ([Client_id], [FIO], [Phone], [Adress]) VALUES (2, N'Васильчук Николай Первый', N'89456789543', N'Купатинская 2')
INSERT [dbo].[Clients] ([Client_id], [FIO], [Phone], [Adress]) VALUES (3, N'Камилов Рустам Бенедиктович', N'86326543219', N'Чебуречная 3')
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
SET IDENTITY_INSERT [dbo].[Executor] ON 

INSERT [dbo].[Executor] ([Executor_id], [FIO], [Phone], [Passport]) VALUES (1, N'Морнинг Утро Веселое', N'89654123698', N'4050312654')
INSERT [dbo].[Executor] ([Executor_id], [FIO], [Phone], [Passport]) VALUES (2, N'Уткин Василий Вениаминович', N'89654123697', N'6549873215')
SET IDENTITY_INSERT [dbo].[Executor] OFF
GO
SET IDENTITY_INSERT [dbo].[ExecutorSchedule] ON 

INSERT [dbo].[ExecutorSchedule] ([ExecutorSchedule_id], [Executor_id], [LeadTime_id]) VALUES (2, 2, 2)
INSERT [dbo].[ExecutorSchedule] ([ExecutorSchedule_id], [Executor_id], [LeadTime_id]) VALUES (3, 1, 3)
INSERT [dbo].[ExecutorSchedule] ([ExecutorSchedule_id], [Executor_id], [LeadTime_id]) VALUES (13, 2, NULL)
SET IDENTITY_INSERT [dbo].[ExecutorSchedule] OFF
GO
SET IDENTITY_INSERT [dbo].[Houses] ON 

INSERT [dbo].[Houses] ([House_id], [HouseView_id], [HouseOver_id], [Price_id], [Adress]) VALUES (4, 1, 1, 5, N'Привет 1')
INSERT [dbo].[Houses] ([House_id], [HouseView_id], [HouseOver_id], [Price_id], [Adress]) VALUES (5, 2, 2, 7, N'Пока 2')
INSERT [dbo].[Houses] ([House_id], [HouseView_id], [HouseOver_id], [Price_id], [Adress]) VALUES (6, 3, 3, NULL, N'Приветская 35')
SET IDENTITY_INSERT [dbo].[Houses] OFF
GO
SET IDENTITY_INSERT [dbo].[HousesOverhaul] ON 

INSERT [dbo].[HousesOverhaul] ([HouseOver_id], [TimeStamp], [ListOfWork]) VALUES (1, CAST(N'2021-03-07T00:00:00.000' AS DateTime), N'Поменяны перила, покрашены стены')
INSERT [dbo].[HousesOverhaul] ([HouseOver_id], [TimeStamp], [ListOfWork]) VALUES (2, CAST(N'2021-03-07T21:07:09.100' AS DateTime), N'Заделана дыра в стене')
INSERT [dbo].[HousesOverhaul] ([HouseOver_id], [TimeStamp], [ListOfWork]) VALUES (3, CAST(N'2021-03-07T21:00:04.757' AS DateTime), N'Ничего не найдено')
SET IDENTITY_INSERT [dbo].[HousesOverhaul] OFF
GO
SET IDENTITY_INSERT [dbo].[HousesView] ON 

INSERT [dbo].[HousesView] ([HouseView_id], [TimeStamp], [Defects]) VALUES (1, CAST(N'2021-03-07T21:06:55.897' AS DateTime), N'Дыоа в стене')
INSERT [dbo].[HousesView] ([HouseView_id], [TimeStamp], [Defects]) VALUES (2, CAST(N'2020-03-08T00:00:00.000' AS DateTime), N'Сломаны перила')
INSERT [dbo].[HousesView] ([HouseView_id], [TimeStamp], [Defects]) VALUES (3, CAST(N'2021-03-07T21:00:04.760' AS DateTime), N'Ничего не сделано')
SET IDENTITY_INSERT [dbo].[HousesView] OFF
GO
SET IDENTITY_INSERT [dbo].[LeadTime] ON 

INSERT [dbo].[LeadTime] ([LeadTime_id], [Time]) VALUES (2, N'07.03.2021 10:53')
INSERT [dbo].[LeadTime] ([LeadTime_id], [Time]) VALUES (3, N'07.03.2021 11:40')
SET IDENTITY_INSERT [dbo].[LeadTime] OFF
GO
SET IDENTITY_INSERT [dbo].[Overhaul] ON 

INSERT [dbo].[Overhaul] ([Overhaul_id], [Price]) VALUES (1, 2000.0000)
INSERT [dbo].[Overhaul] ([Overhaul_id], [Price]) VALUES (2, 456.0000)
INSERT [dbo].[Overhaul] ([Overhaul_id], [Price]) VALUES (3, 321.0000)
INSERT [dbo].[Overhaul] ([Overhaul_id], [Price]) VALUES (8, 2000000.0000)
INSERT [dbo].[Overhaul] ([Overhaul_id], [Price]) VALUES (9, 2000000.0000)
INSERT [dbo].[Overhaul] ([Overhaul_id], [Price]) VALUES (10, 2000000.0000)
INSERT [dbo].[Overhaul] ([Overhaul_id], [Price]) VALUES (11, 2000000.0000)
INSERT [dbo].[Overhaul] ([Overhaul_id], [Price]) VALUES (12, 0.0000)
INSERT [dbo].[Overhaul] ([Overhaul_id], [Price]) VALUES (13, 6500000.0000)
SET IDENTITY_INSERT [dbo].[Overhaul] OFF
GO
SET IDENTITY_INSERT [dbo].[Price] ON 

INSERT [dbo].[Price] ([Price_id], [BidPrice_id], [User_id], [Overhaul_id]) VALUES (1, 1, 3, 1)
INSERT [dbo].[Price] ([Price_id], [BidPrice_id], [User_id], [Overhaul_id]) VALUES (2, 2, 3, 2)
INSERT [dbo].[Price] ([Price_id], [BidPrice_id], [User_id], [Overhaul_id]) VALUES (3, 3, 3, 3)
INSERT [dbo].[Price] ([Price_id], [BidPrice_id], [User_id], [Overhaul_id]) VALUES (5, NULL, 3, 11)
INSERT [dbo].[Price] ([Price_id], [BidPrice_id], [User_id], [Overhaul_id]) VALUES (6, NULL, 3, 12)
INSERT [dbo].[Price] ([Price_id], [BidPrice_id], [User_id], [Overhaul_id]) VALUES (7, NULL, 3, 13)
SET IDENTITY_INSERT [dbo].[Price] OFF
GO
SET IDENTITY_INSERT [dbo].[References] ON 

INSERT [dbo].[References] ([Reference_id], [Client_id], [Status], [User_id]) VALUES (1, 1, N'0', 3)
INSERT [dbo].[References] ([Reference_id], [Client_id], [Status], [User_id]) VALUES (2, 2, N'2', 3)
INSERT [dbo].[References] ([Reference_id], [Client_id], [Status], [User_id]) VALUES (3, 3, N'1', 3)
INSERT [dbo].[References] ([Reference_id], [Client_id], [Status], [User_id]) VALUES (4, 2, N'1', 3)
SET IDENTITY_INSERT [dbo].[References] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Role_id], [Name]) VALUES (1, N'Диспетчер')
INSERT [dbo].[Role] ([Role_id], [Name]) VALUES (2, N'Администратор')
INSERT [dbo].[Role] ([Role_id], [Name]) VALUES (3, N'Бухгалтер')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([User_id], [Role_id], [FIO], [Passport], [Phone], [Login], [Password]) VALUES (3, 3, N'Обама Александр Баракович', N'6958741369', N'89732584563', N'3', N'4e07408562bedb8b60ce05c1decfe3ad16b72230967de01f640b7e4729b49fce')
INSERT [dbo].[Users] ([User_id], [Role_id], [FIO], [Passport], [Phone], [Login], [Password]) VALUES (15, 1, N'Лукашенко Федр Емельянович', N'6549876548', N'89653216549', N'1', N'6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b')
INSERT [dbo].[Users] ([User_id], [Role_id], [FIO], [Passport], [Phone], [Login], [Password]) VALUES (16, 2, N'Дробыш Людмила Витальевна', N'6543214568', N'89331478569', N'2', N'd4735e3a265e16eee03f59718b9b5d03019c07d8b6c51f90da3a666eec13ab35')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Bid_BidPrice]') AND parent_object_id = OBJECT_ID(N'[dbo].[Bid]'))
ALTER TABLE [dbo].[Bid]  WITH CHECK ADD  CONSTRAINT [FK_Bid_BidPrice] FOREIGN KEY([BidPrice_id])
REFERENCES [dbo].[BidPrice] ([BidPrice_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Bid_BidPrice]') AND parent_object_id = OBJECT_ID(N'[dbo].[Bid]'))
ALTER TABLE [dbo].[Bid] CHECK CONSTRAINT [FK_Bid_BidPrice]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Bid_Clients]') AND parent_object_id = OBJECT_ID(N'[dbo].[Bid]'))
ALTER TABLE [dbo].[Bid]  WITH CHECK ADD  CONSTRAINT [FK_Bid_Clients] FOREIGN KEY([Client_id])
REFERENCES [dbo].[Clients] ([Client_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Bid_Clients]') AND parent_object_id = OBJECT_ID(N'[dbo].[Bid]'))
ALTER TABLE [dbo].[Bid] CHECK CONSTRAINT [FK_Bid_Clients]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Bid_ExecutorSchedule]') AND parent_object_id = OBJECT_ID(N'[dbo].[Bid]'))
ALTER TABLE [dbo].[Bid]  WITH CHECK ADD  CONSTRAINT [FK_Bid_ExecutorSchedule] FOREIGN KEY([ExecutorSchedule_id])
REFERENCES [dbo].[ExecutorSchedule] ([ExecutorSchedule_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Bid_ExecutorSchedule]') AND parent_object_id = OBJECT_ID(N'[dbo].[Bid]'))
ALTER TABLE [dbo].[Bid] CHECK CONSTRAINT [FK_Bid_ExecutorSchedule]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Bid_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[Bid]'))
ALTER TABLE [dbo].[Bid]  WITH CHECK ADD  CONSTRAINT [FK_Bid_Users] FOREIGN KEY([User_id])
REFERENCES [dbo].[Users] ([User_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Bid_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[Bid]'))
ALTER TABLE [dbo].[Bid] CHECK CONSTRAINT [FK_Bid_Users]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExecutorSchedule_Executor]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExecutorSchedule]'))
ALTER TABLE [dbo].[ExecutorSchedule]  WITH CHECK ADD  CONSTRAINT [FK_ExecutorSchedule_Executor] FOREIGN KEY([Executor_id])
REFERENCES [dbo].[Executor] ([Executor_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExecutorSchedule_Executor]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExecutorSchedule]'))
ALTER TABLE [dbo].[ExecutorSchedule] CHECK CONSTRAINT [FK_ExecutorSchedule_Executor]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExecutorSchedule_LeadTime]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExecutorSchedule]'))
ALTER TABLE [dbo].[ExecutorSchedule]  WITH CHECK ADD  CONSTRAINT [FK_ExecutorSchedule_LeadTime] FOREIGN KEY([LeadTime_id])
REFERENCES [dbo].[LeadTime] ([LeadTime_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExecutorSchedule_LeadTime]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExecutorSchedule]'))
ALTER TABLE [dbo].[ExecutorSchedule] CHECK CONSTRAINT [FK_ExecutorSchedule_LeadTime]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Houses_HousesOverhaul]') AND parent_object_id = OBJECT_ID(N'[dbo].[Houses]'))
ALTER TABLE [dbo].[Houses]  WITH CHECK ADD  CONSTRAINT [FK_Houses_HousesOverhaul] FOREIGN KEY([HouseOver_id])
REFERENCES [dbo].[HousesOverhaul] ([HouseOver_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Houses_HousesOverhaul]') AND parent_object_id = OBJECT_ID(N'[dbo].[Houses]'))
ALTER TABLE [dbo].[Houses] CHECK CONSTRAINT [FK_Houses_HousesOverhaul]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Houses_HousesView]') AND parent_object_id = OBJECT_ID(N'[dbo].[Houses]'))
ALTER TABLE [dbo].[Houses]  WITH CHECK ADD  CONSTRAINT [FK_Houses_HousesView] FOREIGN KEY([HouseView_id])
REFERENCES [dbo].[HousesView] ([HouseView_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Houses_HousesView]') AND parent_object_id = OBJECT_ID(N'[dbo].[Houses]'))
ALTER TABLE [dbo].[Houses] CHECK CONSTRAINT [FK_Houses_HousesView]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Houses_Price]') AND parent_object_id = OBJECT_ID(N'[dbo].[Houses]'))
ALTER TABLE [dbo].[Houses]  WITH CHECK ADD  CONSTRAINT [FK_Houses_Price] FOREIGN KEY([Price_id])
REFERENCES [dbo].[Price] ([Price_id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Houses_Price]') AND parent_object_id = OBJECT_ID(N'[dbo].[Houses]'))
ALTER TABLE [dbo].[Houses] CHECK CONSTRAINT [FK_Houses_Price]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Price_Overhaul]') AND parent_object_id = OBJECT_ID(N'[dbo].[Price]'))
ALTER TABLE [dbo].[Price]  WITH CHECK ADD  CONSTRAINT [FK_Price_Overhaul] FOREIGN KEY([Overhaul_id])
REFERENCES [dbo].[Overhaul] ([Overhaul_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Price_Overhaul]') AND parent_object_id = OBJECT_ID(N'[dbo].[Price]'))
ALTER TABLE [dbo].[Price] CHECK CONSTRAINT [FK_Price_Overhaul]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Price_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[Price]'))
ALTER TABLE [dbo].[Price]  WITH CHECK ADD  CONSTRAINT [FK_Price_Users] FOREIGN KEY([User_id])
REFERENCES [dbo].[Users] ([User_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Price_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[Price]'))
ALTER TABLE [dbo].[Price] CHECK CONSTRAINT [FK_Price_Users]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_References_Clients]') AND parent_object_id = OBJECT_ID(N'[dbo].[References]'))
ALTER TABLE [dbo].[References]  WITH CHECK ADD  CONSTRAINT [FK_References_Clients] FOREIGN KEY([Client_id])
REFERENCES [dbo].[Clients] ([Client_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_References_Clients]') AND parent_object_id = OBJECT_ID(N'[dbo].[References]'))
ALTER TABLE [dbo].[References] CHECK CONSTRAINT [FK_References_Clients]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_References_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[References]'))
ALTER TABLE [dbo].[References]  WITH CHECK ADD  CONSTRAINT [FK_References_Users] FOREIGN KEY([User_id])
REFERENCES [dbo].[Users] ([User_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_References_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[References]'))
ALTER TABLE [dbo].[References] CHECK CONSTRAINT [FK_References_Users]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_Role]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Role] FOREIGN KEY([Role_id])
REFERENCES [dbo].[Role] ([Role_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_Role]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Role]
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_Bid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Bid]'))
ALTER TABLE [dbo].[Bid]  WITH CHECK ADD  CONSTRAINT [CK_Bid] CHECK  (([BidStatus]>=(0) AND [BidStatus]<=(1)))
GO
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_Bid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Bid]'))
ALTER TABLE [dbo].[Bid] CHECK CONSTRAINT [CK_Bid]
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_References]') AND parent_object_id = OBJECT_ID(N'[dbo].[References]'))
ALTER TABLE [dbo].[References]  WITH CHECK ADD  CONSTRAINT [CK_References] CHECK  (([Status]>=(0) AND [Status]<=(2)))
GO
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_References]') AND parent_object_id = OBJECT_ID(N'[dbo].[References]'))
ALTER TABLE [dbo].[References] CHECK CONSTRAINT [CK_References]
GO
/****** Object:  StoredProcedure [dbo].[DeleteHouses]    Script Date: 08.03.2021 02:27:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteHouses]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[DeleteHouses] AS' 
END
GO
ALTER PROCEDURE [dbo].[DeleteHouses]
	@HouseView_id [int],
	@HouseOver_id [int]
WITH EXECUTE AS CALLER
AS
delete from HousesView where HouseView_id = @HouseView_id;
delete from HousesOverhaul where HouseOver_id = @HouseOver_id;
GO
ALTER AUTHORIZATION ON [dbo].[DeleteHouses] TO  SCHEMA OWNER 
GO
ALTER AUTHORIZATION ON [dbo].[DeleteHouses] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[insertBid]    Script Date: 08.03.2021 02:27:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[insertBid]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[insertBid] AS' 
END
GO
ALTER PROCEDURE [dbo].[insertBid]
	@execFIO [nvarchar](50),
	@clientFIO [nvarchar](50),
	@typeWork [nvarchar](50),
	@login [nvarchar](50)
WITH EXECUTE AS CALLER
AS
BEGIN TRANSACTION;
INSERT INTO ExecutorSchedule values ((select e.Executor_id from Executor e where e.FIO = @execFIO), null);
INSERT INTO Bid VALUES (CURRENT_TIMESTAMP
, (select top 1 es.ExecutorSchedule_id from ExecutorSchedule es order by es.ExecutorSchedule_id desc)
, 0
, @typeWork
, (select c.Client_id from Clients c where c.FIO = @clientFIO)
, null
, (select User_id from Users where Login = @login));
COMMIT;
GO
ALTER AUTHORIZATION ON [dbo].[insertBid] TO  SCHEMA OWNER 
GO
ALTER AUTHORIZATION ON [dbo].[insertBid] TO  SCHEMA OWNER 
GO
/****** Object:  StoredProcedure [dbo].[TimeUpdateExec]    Script Date: 08.03.2021 02:27:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TimeUpdateExec]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TimeUpdateExec] AS' 
END
GO
ALTER PROCEDURE [dbo].[TimeUpdateExec]
	@execID [int],
	@leadTime [nvarchar](20)
WITH EXECUTE AS CALLER
AS
BEGIN TRANSACTION;
insert into LeadTime values (@leadTime);
update ExecutorSchedule set LeadTime_id = (select top 1 LeadTime_id from LeadTime order by LeadTime_id desc) where ExecutorSchedule_id = @execID;
commit;
GO
ALTER AUTHORIZATION ON [dbo].[TimeUpdateExec] TO  SCHEMA OWNER 
GO
ALTER AUTHORIZATION ON [dbo].[TimeUpdateExec] TO  SCHEMA OWNER 
GO
/****** Object:  Trigger [dbo].[priceNotNull]    Script Date: 08.03.2021 02:27:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[priceNotNull]'))
EXEC dbo.sp_executesql @statement = N'create trigger [dbo].[priceNotNull]
on [dbo].[Overhaul]
after insert, update
as
begin
	set nocount on;

	declare @price int
	set @price = (select Price from inserted)

	if @price < 0
		begin
			
			Rollback Tran
			raiserror(''Цена не может быть меньше 0'', 16, 10)
		
		end

end' 
GO
ALTER TABLE [dbo].[Overhaul] ENABLE TRIGGER [priceNotNull]
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'BidDispatcher', NULL,NULL))
	EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "b"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 132
               Right = 233
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "es"
            Begin Extent = 
               Top = 6
               Left = 271
               Bottom = 115
               Right = 466
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "e"
            Begin Extent = 
               Top = 120
               Left = 271
               Bottom = 246
               Right = 438
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "c"
            Begin Extent = 
               Top = 132
               Left = 38
               Bottom = 258
               Right = 205
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "u"
            Begin Extent = 
               Top = 246
               Left = 243
               Bottom = 372
               Right = 410
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'BidDispatcher'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'BidDispatcher', NULL,NULL))
	EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'BidDispatcher'
GO
USE [master]
GO
ALTER DATABASE [UpComany] SET  READ_WRITE 
GO
