USE [master]
GO
/****** Object:  Database [BiponeeDB]    Script Date: 10/26/2018 9:25:10 PM ******/
CREATE DATABASE [BiponeeDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BiponeeDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BiponeeDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BiponeeDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BiponeeDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BiponeeDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BiponeeDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BiponeeDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BiponeeDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BiponeeDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BiponeeDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BiponeeDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BiponeeDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BiponeeDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BiponeeDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BiponeeDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BiponeeDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BiponeeDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BiponeeDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BiponeeDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BiponeeDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BiponeeDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BiponeeDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BiponeeDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BiponeeDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BiponeeDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BiponeeDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BiponeeDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BiponeeDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BiponeeDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BiponeeDB] SET  MULTI_USER 
GO
ALTER DATABASE [BiponeeDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BiponeeDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BiponeeDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BiponeeDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BiponeeDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BiponeeDB] SET QUERY_STORE = OFF
GO
USE [BiponeeDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [BiponeeDB]
GO
/****** Object:  Table [dbo].[admins]    Script Date: 10/26/2018 9:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admins](
	[AdminID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[FirstName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
 CONSTRAINT [PK_admins] PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartItems]    Script Date: 10/26/2018 9:25:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartItems](
	[CartItemID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[ProductImage] [varchar](50) NOT NULL,
	[ProductName] [varchar](50) NOT NULL,
	[ProductSize] [varchar](50) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Subtotal] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_CartItems] PRIMARY KEY CLUSTERED 
(
	[CartItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orders]    Script Date: 10/26/2018 9:25:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orders](
	[orderId] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [varchar](50) NOT NULL,
	[lastName] [varchar](50) NOT NULL,
	[phone] [varchar](20) NOT NULL,
	[address] [varchar](50) NOT NULL,
	[state] [varchar](50) NOT NULL,
	[city] [varchar](50) NOT NULL,
	[userId] [int] NOT NULL,
	[paymentmethod] [varchar](50) NOT NULL,
	[total] [decimal](18, 2) NOT NULL,
	[date] [varchar](100) NOT NULL,
 CONSTRAINT [PK_orders] PRIMARY KEY CLUSTERED 
(
	[orderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products]    Script Date: 10/26/2018 9:25:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](500) NOT NULL,
	[ProductCode] [varchar](500) NOT NULL,
	[SectionId] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Category] [varchar](100) NULL,
	[Description] [text] NULL,
	[ImageLink] [varchar](2000) NOT NULL,
	[LCount] [int] NULL,
	[MCount] [int] NULL,
	[XLCount] [int] NULL,
	[XXLCount] [int] NULL,
	[Quantity] [int] NULL,
	[BrandName] [varchar](50) NULL,
 CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[promocodes]    Script Date: 10/26/2018 9:25:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[promocodes](
	[promoId] [int] IDENTITY(1,1) NOT NULL,
	[promocode] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[discount] [int] NOT NULL,
	[isapplied] [varchar](50) NOT NULL,
 CONSTRAINT [PK_promocodes] PRIMARY KEY CLUSTERED 
(
	[promoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sections]    Script Date: 10/26/2018 9:25:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sections](
	[SectionID] [int] IDENTITY(1,1) NOT NULL,
	[SectionName] [varchar](100) NULL,
 CONSTRAINT [PK_sections] PRIMARY KEY CLUSTERED 
(
	[SectionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 10/26/2018 9:25:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](100) NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[admins] ON 

INSERT [dbo].[admins] ([AdminID], [Email], [Password], [FirstName], [LastName]) VALUES (1, N'sady@gmail.com', N'123', N'Toufiq', N'Islam')
INSERT [dbo].[admins] ([AdminID], [Email], [Password], [FirstName], [LastName]) VALUES (3, N'admin@gmail.com', N'123', N'Toufiqul', N'Islam')
SET IDENTITY_INSERT [dbo].[admins] OFF
SET IDENTITY_INSERT [dbo].[CartItems] ON 

INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (49, 1, 1012, N'/Style/ProductImage/2/IPHN220img.jpeg', N'I Phone6', N'', CAST(85000.00 AS Decimal(18, 2)), 1, CAST(85000.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (50, 1, 1007, N'/Style/ProductImage/2/Mack220img.jpeg', N'Mackbook Pro', N'', CAST(150000.00 AS Decimal(18, 2)), 2, CAST(300000.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (51, 2, 1012, N'/Style/ProductImage/2/IPHN220img.jpeg', N'I Phone6', N'', CAST(85000.00 AS Decimal(18, 2)), 2, CAST(170000.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (52, 2, 1007, N'/Style/ProductImage/2/Mack220img.jpeg', N'Mackbook Pro', N'', CAST(150000.00 AS Decimal(18, 2)), 1, CAST(150000.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (1049, 1002, 1007, N'/Style/ProductImage/2/Mack220img.jpeg', N'Mackbook Pro', N'', CAST(150000.00 AS Decimal(18, 2)), 1, CAST(150000.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (1050, 1002, 1011, N'/Style/ProductImage/1/Kamiz01img.jpeg', N'Long Kamiz', N'', CAST(1590.00 AS Decimal(18, 2)), 1, CAST(1590.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (1051, 1002, 1008, N'/Style/ProductImage/3/DN01img.jpeg', N'Lifebuoy HandWash', N'', CAST(50.00 AS Decimal(18, 2)), 1, CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (1052, 1002, 1009, N'/Style/ProductImage/4/MG01img.jpeg', N'HeadPhone', N'', CAST(800.00 AS Decimal(18, 2)), 1, CAST(800.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (1053, 1002, 1010, N'/Style/ProductImage/1/TSHIRT02img.jpeg', N'Blue T-Shirt', N'', CAST(350.00 AS Decimal(18, 2)), 1, CAST(350.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (1054, 1002, 1010, N'/Style/ProductImage/1/TSHIRT02img.jpeg', N'Blue T-Shirt', N'', CAST(350.00 AS Decimal(18, 2)), 1, CAST(350.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (1055, 1002, 1012, N'/Style/ProductImage/2/IPHN220img.jpeg', N'I Phone6', N'', CAST(85000.00 AS Decimal(18, 2)), 1, CAST(85000.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (1056, 1002, 1012, N'/Style/ProductImage/2/IPHN220img.jpeg', N'I Phone6', N'', CAST(85000.00 AS Decimal(18, 2)), 1, CAST(85000.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (1057, 1002, 1012, N'/Style/ProductImage/2/IPHN220img.jpeg', N'I Phone6', N'', CAST(85000.00 AS Decimal(18, 2)), 1, CAST(85000.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (1058, 1002, 1012, N'/Style/ProductImage/2/IPHN220img.jpeg', N'I Phone6', N'', CAST(85000.00 AS Decimal(18, 2)), 1, CAST(85000.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (1059, 1002, 1012, N'/Style/ProductImage/2/IPHN220img.jpeg', N'I Phone6', N'', CAST(85000.00 AS Decimal(18, 2)), 1, CAST(85000.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (1060, 1002, 1012, N'/Style/ProductImage/2/IPHN220img.jpeg', N'I Phone6', N'', CAST(85000.00 AS Decimal(18, 2)), 1, CAST(85000.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (1061, 1002, 1009, N'/Style/ProductImage/4/MG01img.jpeg', N'HeadPhone', N'', CAST(800.00 AS Decimal(18, 2)), 1, CAST(800.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (1062, 1002, 1009, N'/Style/ProductImage/4/MG01img.jpeg', N'HeadPhone', N'', CAST(800.00 AS Decimal(18, 2)), 1, CAST(800.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (1063, 1002, 1009, N'/Style/ProductImage/4/MG01img.jpeg', N'HeadPhone', N'', CAST(800.00 AS Decimal(18, 2)), 1, CAST(800.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (1064, 1002, 1009, N'/Style/ProductImage/4/MG01img.jpeg', N'HeadPhone', N'', CAST(800.00 AS Decimal(18, 2)), 1, CAST(800.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (1065, 1002, 1009, N'/Style/ProductImage/4/MG01img.jpeg', N'HeadPhone', N'', CAST(800.00 AS Decimal(18, 2)), 1, CAST(800.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (1066, 1002, 1009, N'/Style/ProductImage/4/MG01img.jpeg', N'HeadPhone', N'', CAST(800.00 AS Decimal(18, 2)), 1, CAST(800.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (1067, 1003, 1008, N'/Style/ProductImage/3/DN01img.jpeg', N'3', N'', CAST(50.00 AS Decimal(18, 2)), 1, CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (1068, 1003, 1009, N'/Style/ProductImage/4/MG01img.jpeg', N'HeadPhone', N'', CAST(800.00 AS Decimal(18, 2)), 2, CAST(1600.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (1069, 1006, 1010, N'/Style/ProductImage/1/TSHIRT02img.jpeg', N'Blue T-Shirt', N'', CAST(350.00 AS Decimal(18, 2)), 1, CAST(350.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (2069, 2004, 1010, N'/Style/ProductImage/1/TSHIRT02img.jpeg', N'Blue T-Shirt', N'', CAST(350.00 AS Decimal(18, 2)), 1, CAST(350.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (2070, 2005, 1010, N'/Style/ProductImage/1/TSHIRT02img.jpeg', N'Blue T-Shirt', N'', CAST(350.00 AS Decimal(18, 2)), 1, CAST(350.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (2071, 2005, 1006, N'/Style/ProductImage/1/TSHIRT01img.jpeg', N'Black T-shirt', N'Not Selected', CAST(350.00 AS Decimal(18, 2)), 1, CAST(350.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (2072, 2005, 1006, N'/Style/ProductImage/1/TSHIRT01img.jpeg', N'Black T-shirt', N'Not Selected', CAST(350.00 AS Decimal(18, 2)), 1, CAST(350.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (2073, 2005, 1006, N'/Style/ProductImage/1/TSHIRT01img.jpeg', N'Black T-shirt', N'Not Selected', CAST(350.00 AS Decimal(18, 2)), 1, CAST(350.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (2074, 2005, 1006, N'/Style/ProductImage/1/TSHIRT01img.jpeg', N'Black T-shirt', N'Not Selected', CAST(350.00 AS Decimal(18, 2)), 1, CAST(350.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (2075, 2005, 1006, N'/Style/ProductImage/1/TSHIRT01img.jpeg', N'Black T-shirt', N'Not Selected', CAST(350.00 AS Decimal(18, 2)), 1, CAST(350.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (2076, 2005, 1006, N'/Style/ProductImage/1/TSHIRT01img.jpeg', N'Black T-shirt', N'XL', CAST(350.00 AS Decimal(18, 2)), 1, CAST(350.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (2077, 2006, 1010, N'/Style/ProductImage/1/TSHIRT02img.jpeg', N'Blue T-Shirt', N'', CAST(350.00 AS Decimal(18, 2)), 1, CAST(350.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (2078, 2006, 1006, N'/Style/ProductImage/1/TSHIRT01img.jpeg', N'Black T-shirt', N'Not Selected', CAST(350.00 AS Decimal(18, 2)), 1, CAST(350.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (2079, 2006, 1006, N'/Style/ProductImage/1/TSHIRT01img.jpeg', N'Black T-shirt', N'Not Selected', CAST(350.00 AS Decimal(18, 2)), 1, CAST(350.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (2080, 2006, 1006, N'/Style/ProductImage/1/TSHIRT01img.jpeg', N'Black T-shirt', N'Not Selected', CAST(350.00 AS Decimal(18, 2)), 1, CAST(350.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (2081, 2006, 1006, N'/Style/ProductImage/1/TSHIRT01img.jpeg', N'Black T-shirt', N'Not Selected', CAST(350.00 AS Decimal(18, 2)), 1, CAST(350.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (2082, 2006, 1006, N'/Style/ProductImage/1/TSHIRT01img.jpeg', N'Black T-shirt', N'Not Selected', CAST(350.00 AS Decimal(18, 2)), 1, CAST(350.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (2083, 2006, 1006, N'/Style/ProductImage/1/TSHIRT01img.jpeg', N'Black T-shirt', N'XL', CAST(350.00 AS Decimal(18, 2)), 1, CAST(350.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (3069, 3004, 1012, N'/Style/ProductImage/2/IPHN220img.jpeg', N'I Phone6', N'', CAST(85000.00 AS Decimal(18, 2)), 2, CAST(170000.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (3070, 3004, 1007, N'/Style/ProductImage/2/Mack220img.jpeg', N'Mackbook Pro', N'', CAST(150000.00 AS Decimal(18, 2)), 2, CAST(300000.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (3071, 3005, 1007, N'/Style/ProductImage/2/Mack220img.jpeg', N'Mackbook Pro', N'', CAST(150000.00 AS Decimal(18, 2)), 2, CAST(300000.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (4071, 4005, 1010, N'/Style/ProductImage/1/TSHIRT02img.jpeg', N'Blue T-Shirt', N'', CAST(350.00 AS Decimal(18, 2)), 4, CAST(1400.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (4072, 4005, 2008, N'/Style/ProductImage/2/IMack01img.jpeg', N'IMac', N'', CAST(100000.00 AS Decimal(18, 2)), 1, CAST(100000.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (4073, 4005, 2013, N'/Style/ProductImage/4/MG03img.jpeg', N'MIS2', N'', CAST(15000.00 AS Decimal(18, 2)), 1, CAST(15000.00 AS Decimal(18, 2)))
INSERT [dbo].[CartItems] ([CartItemID], [OrderID], [ProductID], [ProductImage], [ProductName], [ProductSize], [UnitPrice], [Quantity], [Subtotal]) VALUES (4074, 4005, 1012, N'/Style/ProductImage/2/IPHN220img.jpeg', N'I Phone6', N'', CAST(85000.00 AS Decimal(18, 2)), 1, CAST(85000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[CartItems] OFF
SET IDENTITY_INSERT [dbo].[orders] ON 

INSERT [dbo].[orders] ([orderId], [firstName], [lastName], [phone], [address], [state], [city], [userId], [paymentmethod], [total], [date]) VALUES (1, N'yhtyu', N'ytut', N'ytut', N'uytu', N'tyutyu', N'tyuty', 1, N'Card On Delivery', CAST(385000.00 AS Decimal(18, 2)), N'09/25/2018')
INSERT [dbo].[orders] ([orderId], [firstName], [lastName], [phone], [address], [state], [city], [userId], [paymentmethod], [total], [date]) VALUES (2, N'fghfh', N'fghfg', N'hfghfgh', N'fghfghr5y', N'ertrte', N'reter', 1, N'Cash On Delivery', CAST(320000.00 AS Decimal(18, 2)), N'09/25/2018')
INSERT [dbo].[orders] ([orderId], [firstName], [lastName], [phone], [address], [state], [city], [userId], [paymentmethod], [total], [date]) VALUES (1002, N'sdfsd', N'sdfs', N'fsdfsd', N'sdfsd', N'fsdf', N'sdfsdf', 1, N'', CAST(667940.00 AS Decimal(18, 2)), N'09/26/2018')
INSERT [dbo].[orders] ([orderId], [firstName], [lastName], [phone], [address], [state], [city], [userId], [paymentmethod], [total], [date]) VALUES (1003, N'fghfgh', N'gfhfgh', N'fghgfhfg', N'fgh', N'hfghf', N'hfghf', 1, N'Cash On Delivery', CAST(1650.00 AS Decimal(18, 2)), N'09/26/2018')
INSERT [dbo].[orders] ([orderId], [firstName], [lastName], [phone], [address], [state], [city], [userId], [paymentmethod], [total], [date]) VALUES (1004, N'TOufiqul', N'Islam', N'012547996', N'Rangpur', N'kkkk', N'Rangpur', 1, N'Cash On Delivery', CAST(350.00 AS Decimal(18, 2)), N'09/29/2018')
INSERT [dbo].[orders] ([orderId], [firstName], [lastName], [phone], [address], [state], [city], [userId], [paymentmethod], [total], [date]) VALUES (1005, N'dfgd', N'dfgdf', N'dfgdf', N'gdfgdf', N'gdfg', N'dfgd', 1, N'Card On Delivery', CAST(350.00 AS Decimal(18, 2)), N'09/29/2018')
INSERT [dbo].[orders] ([orderId], [firstName], [lastName], [phone], [address], [state], [city], [userId], [paymentmethod], [total], [date]) VALUES (1006, N'ghjg', N'ghjg', N'hjgh', N'ghjg', N'jhgj', N'gh', 1, N'Card On Delivery', CAST(350.00 AS Decimal(18, 2)), N'09/29/2018')
INSERT [dbo].[orders] ([orderId], [firstName], [lastName], [phone], [address], [state], [city], [userId], [paymentmethod], [total], [date]) VALUES (2004, N'', N'', N'', N'', N'', N'', 1, N'', CAST(350.00 AS Decimal(18, 2)), N'10/21/2018')
INSERT [dbo].[orders] ([orderId], [firstName], [lastName], [phone], [address], [state], [city], [userId], [paymentmethod], [total], [date]) VALUES (2005, N'dfgdf', N'dfgdf', N'gdfgdf', N'gdfgd', N'fgdfgd', N'gdfgd', 1, N'Cash On Delivery', CAST(2450.00 AS Decimal(18, 2)), N'10/21/2018')
INSERT [dbo].[orders] ([orderId], [firstName], [lastName], [phone], [address], [state], [city], [userId], [paymentmethod], [total], [date]) VALUES (2006, N'dfgdf', N'dfgdf', N'gdfgdf', N'gdfgd', N'fgdfgd', N'gdfgd', 1, N'Cash On Delivery', CAST(2450.00 AS Decimal(18, 2)), N'10/21/2018')
INSERT [dbo].[orders] ([orderId], [firstName], [lastName], [phone], [address], [state], [city], [userId], [paymentmethod], [total], [date]) VALUES (3004, N'Md. Toufiqul', N'Islam', N'0157896432', N'123, Rampura', N'Dhaka', N'Dhaka', 1, N'Cash On Delivery', CAST(470000.00 AS Decimal(18, 2)), N'10/23/2018')
INSERT [dbo].[orders] ([orderId], [firstName], [lastName], [phone], [address], [state], [city], [userId], [paymentmethod], [total], [date]) VALUES (3005, N'Rafiqul', N'Islam', N'0147856963.', N'Mirpur', N'Dhaka', N'Dhaka', 1, N'Card On Delivery', CAST(300000.00 AS Decimal(18, 2)), N'10/26/2018')
INSERT [dbo].[orders] ([orderId], [firstName], [lastName], [phone], [address], [state], [city], [userId], [paymentmethod], [total], [date]) VALUES (4005, N'Tamim', N'Shahriar', N'0147896563', N'Zigatola', N'Dhaka', N'Dhaka', 2009, N'Card On Delivery', CAST(201400.00 AS Decimal(18, 2)), N'10/26/2018')
SET IDENTITY_INSERT [dbo].[orders] OFF
SET IDENTITY_INSERT [dbo].[products] ON 

INSERT [dbo].[products] ([ProductId], [ProductName], [ProductCode], [SectionId], [Price], [Category], [Description], [ImageLink], [LCount], [MCount], [XLCount], [XXLCount], [Quantity], [BrandName]) VALUES (1006, N'Black T-shirt', N'TSHIRT01', 1, CAST(350.00 AS Decimal(18, 2)), N'T-Shirt', N'Product Type: Casual Printed Shirt
Main Color: Multi Color
Fabrics: Cotton', N'Style/ProductImage/1/TSHIRT01img', 5, 5, 3, 5, NULL, N'Polo')
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductCode], [SectionId], [Price], [Category], [Description], [ImageLink], [LCount], [MCount], [XLCount], [XXLCount], [Quantity], [BrandName]) VALUES (1007, N'Mackbook Pro', N'Mack220', 2, CAST(150000.00 AS Decimal(18, 2)), N'Laptop', N'The MacBook Pro (sometimes abbreviated as MBP) is a line of Macintosh portable computers introduced in January 2006 by Apple Inc. It is the high-end model of the MacBook family and is currently available in 13- and 15-inch screen sizes.', N'Style/ProductImage/2/Mack220img', NULL, NULL, NULL, NULL, 10, N'Apple')
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductCode], [SectionId], [Price], [Category], [Description], [ImageLink], [LCount], [MCount], [XLCount], [XXLCount], [Quantity], [BrandName]) VALUES (1008, N'Lifebuoy HandWash', N'DN01', 3, CAST(50.00 AS Decimal(18, 2)), N'Handwash', N'This is a highly specialized hand wash product from Lifebuoy available in liquid form. ... Lifebuoy is continuously improving its ability to fight germs so that it keeps its promise to you of a healthy family, so you can enjoy your life without the fear of germs.', N'Style/ProductImage/3/DN01img', NULL, NULL, NULL, NULL, 8, N'Lifebuoy')
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductCode], [SectionId], [Price], [Category], [Description], [ImageLink], [LCount], [MCount], [XLCount], [XXLCount], [Quantity], [BrandName]) VALUES (1009, N'HeadPhone', N'MG01', 4, CAST(800.00 AS Decimal(18, 2)), N'Headphone', N'A Headphone', N'Style/ProductImage/4/MG01img', NULL, NULL, NULL, NULL, 1, N'ATech')
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductCode], [SectionId], [Price], [Category], [Description], [ImageLink], [LCount], [MCount], [XLCount], [XXLCount], [Quantity], [BrandName]) VALUES (1010, N'Blue T-Shirt', N'TSHIRT02', 1, CAST(350.00 AS Decimal(18, 2)), N'T-Shirt', N'Product Type: Casual Printed Shirt
Main Color: Multi Color
Fabrics: Cotton', N'Style/ProductImage/1/TSHIRT02img', 10, 10, 10, 10, NULL, N'Polo')
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductCode], [SectionId], [Price], [Category], [Description], [ImageLink], [LCount], [MCount], [XLCount], [XXLCount], [Quantity], [BrandName]) VALUES (1011, N'Long Kamiz', N'Kamiz01', 1, CAST(1590.00 AS Decimal(18, 2)), N'Kamiz', N'Shalwar Kameez, also spelled salwar kameez or shalwar qameez, is a traditional outfit originating in the subcontinent. It is a generic term used to describe different styles of dress. The shalwar kameez can be worn by women. The shalwar and the kameez are two garments which are combined to form the shalwar kameez.
The seller,offers a wide selection of products from renowned brands in Bangladesh with a promise of fast, safe and easy online shopping experience through Daraz. The seller comes closer to the huge customers on this leading online shopping platform of all over Bangladesh and serving to the greater extent for achieving higher customer satisfaction. The brands working with Daraz are not only serving top class products but also are dedicated to acquiring brand loyalty.', N'Style/ProductImage/1/Kamiz01img', 10, 10, 10, 10, NULL, N'10')
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductCode], [SectionId], [Price], [Category], [Description], [ImageLink], [LCount], [MCount], [XLCount], [XXLCount], [Quantity], [BrandName]) VALUES (1012, N'I Phone6', N'IPHN220', 2, CAST(85000.00 AS Decimal(18, 2)), N'IPhone', N'The iPhone is a smartphone made by Apple that combines a computer, iPod, digital camera and cellular phone into one device with a touchscreen interface.', N'Style/ProductImage/2/IPHN220img', NULL, NULL, NULL, NULL, 11, N'Apple')
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductCode], [SectionId], [Price], [Category], [Description], [ImageLink], [LCount], [MCount], [XLCount], [XXLCount], [Quantity], [BrandName]) VALUES (2006, N'Stylish Casual Shirt For Men', N'SHIRT03', 1, CAST(350.00 AS Decimal(18, 2)), N'T-Shirt', N'Product Type: Casual Printed Shirt
Main Color: Multi Color
Fabrics: Cotton', N'Style/ProductImage/1/SHIRT03img', 10, 10, 10, 10, NULL, N'Polo')
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductCode], [SectionId], [Price], [Category], [Description], [ImageLink], [LCount], [MCount], [XLCount], [XXLCount], [Quantity], [BrandName]) VALUES (2007, N'Block Print Unstitched Three Piece For Women', N'Kamiz02', 1, CAST(690.00 AS Decimal(18, 2)), N'Kamiz', N'Shalwar kameez, also spelled salwar kameez or shalwar qameez, is a traditional outfit originating in the Indian subcontinent. It is a generic term used to describe different styles of dress. The shalwar kameez can be worn by women. The shalwar (baggy trousers) and the kameez (long shirt) are two garments which are combined to form the shalwar kameez. There are various types of designs for salwar kameez.', N'Style/ProductImage/1/Kamiz02img', 10, 10, 10, 10, NULL, N'Swapno Chura')
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductCode], [SectionId], [Price], [Category], [Description], [ImageLink], [LCount], [MCount], [XLCount], [XXLCount], [Quantity], [BrandName]) VALUES (2008, N'IMac', N'IMack01', 2, CAST(100000.00 AS Decimal(18, 2)), N'PC', N'Faster and more powerful than ever, iMac is now equipped with seventh-generation Intel Core i5 and i7 processors and the latest high-performance graphics. ... The 27-inch iMac with Retina 5K display is loaded with up to 8GB of dedicated VRAM. And the 21.5-inch iMac with Retina 4K ', N'Style/ProductImage/2/IMack01img', NULL, NULL, NULL, NULL, 9, N'Apple')
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductCode], [SectionId], [Price], [Category], [Description], [ImageLink], [LCount], [MCount], [XLCount], [XXLCount], [Quantity], [BrandName]) VALUES (2009, N'Speaker', N'Speaker01', 2, CAST(600.00 AS Decimal(18, 2)), N'Speaker', N' A speaker is a term used to describe the user who is giving vocal commands to a software program.', N'Style/ProductImage/2/Speaker01img', NULL, NULL, NULL, NULL, 10, N'Microlab')
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductCode], [SectionId], [Price], [Category], [Description], [ImageLink], [LCount], [MCount], [XLCount], [XXLCount], [Quantity], [BrandName]) VALUES (2010, N'Vim Liquid', N'DN02', 3, CAST(60.00 AS Decimal(18, 2)), N'Handwash', N'Launched in 1993, Vim is the original hand dishwashing brand which created the whole category. Vim continues to lead the market and is the biggest player in the category. ... It is also great value for money with one spoon of Vim Gel being enough to clean a full sink of dirty utensils.', N'Style/ProductImage/3/DN02img', NULL, NULL, NULL, NULL, 10, N'Vim')
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductCode], [SectionId], [Price], [Category], [Description], [ImageLink], [LCount], [MCount], [XLCount], [XXLCount], [Quantity], [BrandName]) VALUES (2011, N'Wheel Detergent Powder', N'DN03', 3, CAST(70.00 AS Decimal(18, 2)), N'Detergent', N'Wheel, one of the largest detergent brands in Bangladesh, provides a ... Wheel Laundry Soap (Laundry Soap); Wheel Washing Powder (Detergent powder).', N'Style/ProductImage/3/DN03img', NULL, NULL, NULL, NULL, 10, N'Wheel')
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductCode], [SectionId], [Price], [Category], [Description], [ImageLink], [LCount], [MCount], [XLCount], [XXLCount], [Quantity], [BrandName]) VALUES (2012, N'MI HEadPhone', N'MG02', 4, CAST(500.00 AS Decimal(18, 2)), N'Headphone', N'A Nice headphone', N'Style/ProductImage/4/MG02img', NULL, NULL, NULL, NULL, 10, N'Mi')
INSERT [dbo].[products] ([ProductId], [ProductName], [ProductCode], [SectionId], [Price], [Category], [Description], [ImageLink], [LCount], [MCount], [XLCount], [XXLCount], [Quantity], [BrandName]) VALUES (2013, N'MIS2', N'MG03', 4, CAST(15000.00 AS Decimal(18, 2)), N'Mobile', N'Xiaomi Redmi S2 smartphone was launched in May 2018. The phone comes with a 5.99-inch touchscreen display with a resolution of 720 pixels by 1440 pixels.', N'Style/ProductImage/4/MG03img', NULL, NULL, NULL, NULL, 9, N'MI')
SET IDENTITY_INSERT [dbo].[products] OFF
SET IDENTITY_INSERT [dbo].[promocodes] ON 

INSERT [dbo].[promocodes] ([promoId], [promocode], [email], [discount], [isapplied]) VALUES (2, N'DIS25', N'toufiq.austcse@gmail.com', 25, N'False')
SET IDENTITY_INSERT [dbo].[promocodes] OFF
SET IDENTITY_INSERT [dbo].[sections] ON 

INSERT [dbo].[sections] ([SectionID], [SectionName]) VALUES (1, N'Clothing')
INSERT [dbo].[sections] ([SectionID], [SectionName]) VALUES (2, N'Electronics')
INSERT [dbo].[sections] ([SectionID], [SectionName]) VALUES (3, N'Daily Needs')
INSERT [dbo].[sections] ([SectionID], [SectionName]) VALUES (4, N'Mobile')
INSERT [dbo].[sections] ([SectionID], [SectionName]) VALUES (5, N'Fashion and Beauty')
SET IDENTITY_INSERT [dbo].[sections] OFF
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([UserId], [FirstName], [LastName], [Email], [Password]) VALUES (1, N'Toufiqul', N'Islam', N'toufiq@gmail.com', N'123')
INSERT [dbo].[users] ([UserId], [FirstName], [LastName], [Email], [Password]) VALUES (2, N'Susmoy', N'Chakraborty', N'susmoy@gmail.com', N'123')
INSERT [dbo].[users] ([UserId], [FirstName], [LastName], [Email], [Password]) VALUES (3, N'Nasif', N'Abrar', N'nasif@gmail.com', N'123')
INSERT [dbo].[users] ([UserId], [FirstName], [LastName], [Email], [Password]) VALUES (4, N'Rakibu;', N'Islam', N'rakibul@gmail.com', N'123')
INSERT [dbo].[users] ([UserId], [FirstName], [LastName], [Email], [Password]) VALUES (6, N'alif', N'arman', N'alif@gmail.com', N'123')
INSERT [dbo].[users] ([UserId], [FirstName], [LastName], [Email], [Password]) VALUES (7, N'shakib', N'rahman', N'shakib@gmail.com', N'123')
INSERT [dbo].[users] ([UserId], [FirstName], [LastName], [Email], [Password]) VALUES (8, N'Sadik', N'Rahman', N'sadik@gmail.com', N'123')
INSERT [dbo].[users] ([UserId], [FirstName], [LastName], [Email], [Password]) VALUES (9, N'Arman', N'Rahman', N'arman@gmail.com', N'123')
INSERT [dbo].[users] ([UserId], [FirstName], [LastName], [Email], [Password]) VALUES (11, N'Tamim', N'Rahman', N'tamim@gmail.com', N'123')
INSERT [dbo].[users] ([UserId], [FirstName], [LastName], [Email], [Password]) VALUES (1006, N'Hasan', N'Abdullah', N'hasan@gmail.com', N'123')
INSERT [dbo].[users] ([UserId], [FirstName], [LastName], [Email], [Password]) VALUES (2006, N'', N'', N'', N'')
INSERT [dbo].[users] ([UserId], [FirstName], [LastName], [Email], [Password]) VALUES (2009, N'Tamim', N'Shahriar', N'tamim25@gmail.com', N'123')
SET IDENTITY_INSERT [dbo].[users] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_admins]    Script Date: 10/26/2018 9:25:11 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_admins] ON [dbo].[admins]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_products]    Script Date: 10/26/2018 9:25:11 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_products] ON [dbo].[products]
(
	[ProductCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_users]    Script Date: 10/26/2018 9:25:11 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_users] ON [dbo].[users]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD  CONSTRAINT [FK_CartItems_CartItems] FOREIGN KEY([OrderID])
REFERENCES [dbo].[orders] ([orderId])
GO
ALTER TABLE [dbo].[CartItems] CHECK CONSTRAINT [FK_CartItems_CartItems]
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD  CONSTRAINT [FK_CartItems_CartItems1] FOREIGN KEY([CartItemID])
REFERENCES [dbo].[CartItems] ([CartItemID])
GO
ALTER TABLE [dbo].[CartItems] CHECK CONSTRAINT [FK_CartItems_CartItems1]
GO
ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD  CONSTRAINT [FK_CartItems_products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[products] ([ProductId])
GO
ALTER TABLE [dbo].[CartItems] CHECK CONSTRAINT [FK_CartItems_products]
GO
ALTER TABLE [dbo].[products]  WITH CHECK ADD  CONSTRAINT [FK_products_products] FOREIGN KEY([SectionId])
REFERENCES [dbo].[sections] ([SectionID])
GO
ALTER TABLE [dbo].[products] CHECK CONSTRAINT [FK_products_products]
GO
USE [master]
GO
ALTER DATABASE [BiponeeDB] SET  READ_WRITE 
GO
