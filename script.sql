USE [master]
GO
/****** Object:  Database [KoiManagement]    Script Date: 11/20/2024 2:58:23 PM ******/
CREATE DATABASE [KoiManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KoiManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\KoiManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'KoiManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\KoiManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [KoiManagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KoiManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KoiManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KoiManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KoiManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KoiManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KoiManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [KoiManagement] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [KoiManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KoiManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KoiManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KoiManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KoiManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KoiManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KoiManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KoiManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KoiManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [KoiManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KoiManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KoiManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KoiManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KoiManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KoiManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KoiManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KoiManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [KoiManagement] SET  MULTI_USER 
GO
ALTER DATABASE [KoiManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KoiManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KoiManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KoiManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [KoiManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [KoiManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [KoiManagement] SET QUERY_STORE = OFF
GO
USE [KoiManagement]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 11/20/2024 2:58:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](255) NULL,
	[password] [varchar](255) NULL,
	[fullname] [varchar](255) NULL,
	[phone] [varchar](10) NULL,
	[address] [varchar](255) NULL,
	[is_active] [tinyint] NULL,
	[role] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Koi Coassignment]    Script Date: 11/20/2024 2:58:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Koi Coassignment](
	[coassignment_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[koi_id] [int] NOT NULL,
	[agreed_price] [decimal](6, 2) NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_KoiCoassignment] PRIMARY KEY CLUSTERED 
(
	[coassignment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Koi Fish]    Script Date: 11/20/2024 2:58:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Koi Fish](
	[koi_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[age] [int] NULL,
	[origin] [varchar](255) NULL,
	[size] [decimal](6, 2) NULL,
	[color] [varchar](255) NULL,
	[stock_quantity] [int] NULL,
	[is_listed] [tinyint] NULL,
	[price] [decimal](10, 2) NULL,
	[breed_type_id] [int] NULL,
 CONSTRAINT [PK_KoiFish] PRIMARY KEY CLUSTERED 
(
	[koi_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KoiBreedType]    Script Date: 11/20/2024 2:58:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KoiBreedType](
	[breed_type_id] [int] IDENTITY(1,1) NOT NULL,
	[breed_name] [varchar](50) NULL,
	[description] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[breed_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KoiImages]    Script Date: 11/20/2024 2:58:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KoiImages](
	[image_id] [int] IDENTITY(1,1) NOT NULL,
	[koi_id] [int] NOT NULL,
	[image_url] [varchar](255) NULL,
	[is_primary] [bit] NULL,
	[upload_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[image_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order Details]    Script Date: 11/20/2024 2:58:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order Details](
	[order_detail_id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NOT NULL,
	[koi_id] [int] NOT NULL,
	[quantity] [int] NULL,
	[price] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[order_detail_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/20/2024 2:58:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[order_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[total_amount] [decimal](18, 2) NULL,
	[created_at] [datetime] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([user_id], [username], [password], [fullname], [phone], [address], [is_active], [role]) VALUES (1, N'test3', N'123', N'Bob', N'1234567890', N'test@gmail.com', 1, N'user')
INSERT [dbo].[Customer] ([user_id], [username], [password], [fullname], [phone], [address], [is_active], [role]) VALUES (2, N'admin', N'123', N'Admin Fullname', N'1234567890', N'test@gmail.com', 1, N'admin')
INSERT [dbo].[Customer] ([user_id], [username], [password], [fullname], [phone], [address], [is_active], [role]) VALUES (3, N'test2', N'123', N'Alex1', N'1234567890', N'test@gmail.com', 0, N'user')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Koi Fish] ON 

INSERT [dbo].[Koi Fish] ([koi_id], [name], [age], [origin], [size], [color], [stock_quantity], [is_listed], [price], [breed_type_id]) VALUES (7, N'Gin Rin Kohaku', 3, N'Japan', CAST(5.50 AS Decimal(6, 2)), N'Orange and White with Gin Rin scales', 1, 1, CAST(50.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Koi Fish] ([koi_id], [name], [age], [origin], [size], [color], [stock_quantity], [is_listed], [price], [breed_type_id]) VALUES (8, N'Sanke', 8, N'Japan', CAST(5.50 AS Decimal(6, 2)), N'Red & White', 10, 1, CAST(100.00 AS Decimal(10, 2)), 2)
INSERT [dbo].[Koi Fish] ([koi_id], [name], [age], [origin], [size], [color], [stock_quantity], [is_listed], [price], [breed_type_id]) VALUES (9, N'Gin Rin Asagi', 3, N'Thailand', CAST(5.00 AS Decimal(6, 2)), N'White', 5, 1, CAST(100.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Koi Fish] ([koi_id], [name], [age], [origin], [size], [color], [stock_quantity], [is_listed], [price], [breed_type_id]) VALUES (10, N'Ochiba Shigure', 5, N'Japan', CAST(5.00 AS Decimal(6, 2)), N'White & Orange', 8, 1, CAST(50.00 AS Decimal(10, 2)), 3)
INSERT [dbo].[Koi Fish] ([koi_id], [name], [age], [origin], [size], [color], [stock_quantity], [is_listed], [price], [breed_type_id]) VALUES (21, N'Kohaku Gin', 7, N'Japan', CAST(8.00 AS Decimal(6, 2)), N'Red', 7, 1, CAST(200.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Koi Fish] ([koi_id], [name], [age], [origin], [size], [color], [stock_quantity], [is_listed], [price], [breed_type_id]) VALUES (22, N'Test', 6, N'Japan', CAST(8.00 AS Decimal(6, 2)), N'Red', 5, 1, CAST(70.00 AS Decimal(10, 2)), 2)
SET IDENTITY_INSERT [dbo].[Koi Fish] OFF
GO
SET IDENTITY_INSERT [dbo].[KoiBreedType] ON 

INSERT [dbo].[KoiBreedType] ([breed_type_id], [breed_name], [description]) VALUES (1, N'Kohaku', NULL)
INSERT [dbo].[KoiBreedType] ([breed_type_id], [breed_name], [description]) VALUES (2, N'Showa', NULL)
INSERT [dbo].[KoiBreedType] ([breed_type_id], [breed_name], [description]) VALUES (3, N'Tancho', NULL)
SET IDENTITY_INSERT [dbo].[KoiBreedType] OFF
GO
SET IDENTITY_INSERT [dbo].[KoiImages] ON 

INSERT [dbo].[KoiImages] ([image_id], [koi_id], [image_url], [is_primary], [upload_date]) VALUES (5, 7, N'./Resources/Koi Images/koi-7-primary.png', 1, CAST(N'2024-11-06T15:11:33.253' AS DateTime))
INSERT [dbo].[KoiImages] ([image_id], [koi_id], [image_url], [is_primary], [upload_date]) VALUES (6, 8, N'./Resources/Koi Images/koi-8-primary.png', 1, CAST(N'2024-11-06T15:11:33.253' AS DateTime))
INSERT [dbo].[KoiImages] ([image_id], [koi_id], [image_url], [is_primary], [upload_date]) VALUES (7, 9, N'./Resources/Koi Images/koi-9-primary.png', 1, CAST(N'2024-11-06T15:11:33.253' AS DateTime))
INSERT [dbo].[KoiImages] ([image_id], [koi_id], [image_url], [is_primary], [upload_date]) VALUES (8, 10, N'./Resources/Koi Images/koi-10-primary.png', 1, CAST(N'2024-11-06T15:11:33.253' AS DateTime))
INSERT [dbo].[KoiImages] ([image_id], [koi_id], [image_url], [is_primary], [upload_date]) VALUES (9, 9, N'./Resources/Koi Images/koi-9-misc1.png', 0, CAST(N'2024-11-06T17:37:11.883' AS DateTime))
INSERT [dbo].[KoiImages] ([image_id], [koi_id], [image_url], [is_primary], [upload_date]) VALUES (10, 9, N'./Resources/Koi Images/koi-9-misc2.png', 0, CAST(N'2024-11-06T17:37:11.883' AS DateTime))
INSERT [dbo].[KoiImages] ([image_id], [koi_id], [image_url], [is_primary], [upload_date]) VALUES (11, 9, N'./Resources/Koi Images/koi-9-misc3.png', 0, CAST(N'2024-11-06T17:37:11.883' AS DateTime))
INSERT [dbo].[KoiImages] ([image_id], [koi_id], [image_url], [is_primary], [upload_date]) VALUES (12, 10, N'./Resources/Koi Images/koi-10-misc1.png', 0, CAST(N'2024-11-14T07:38:22.727' AS DateTime))
INSERT [dbo].[KoiImages] ([image_id], [koi_id], [image_url], [is_primary], [upload_date]) VALUES (13, 10, N'./Resources/Koi Images/koi-10-misc1.png', 0, CAST(N'2024-11-14T07:38:22.727' AS DateTime))
INSERT [dbo].[KoiImages] ([image_id], [koi_id], [image_url], [is_primary], [upload_date]) VALUES (14, 8, N'./Resources/Koi Images/koi-8-misc1.png', 0, CAST(N'2024-11-14T07:42:31.390' AS DateTime))
INSERT [dbo].[KoiImages] ([image_id], [koi_id], [image_url], [is_primary], [upload_date]) VALUES (15, 8, N'./Resources/Koi Images/koi-8-misc2.png', 0, CAST(N'2024-11-14T07:42:31.390' AS DateTime))
INSERT [dbo].[KoiImages] ([image_id], [koi_id], [image_url], [is_primary], [upload_date]) VALUES (16, 8, N'./Resources/Koi Images/koi-8-misc3.png', 0, CAST(N'2024-11-14T07:42:31.390' AS DateTime))
SET IDENTITY_INSERT [dbo].[KoiImages] OFF
GO
SET IDENTITY_INSERT [dbo].[Order Details] ON 

INSERT [dbo].[Order Details] ([order_detail_id], [order_id], [koi_id], [quantity], [price]) VALUES (15, 12, 8, 2, CAST(80.00 AS Decimal(10, 2)))
INSERT [dbo].[Order Details] ([order_detail_id], [order_id], [koi_id], [quantity], [price]) VALUES (16, 12, 7, 1, CAST(50.00 AS Decimal(10, 2)))
INSERT [dbo].[Order Details] ([order_detail_id], [order_id], [koi_id], [quantity], [price]) VALUES (17, 13, 9, 1, CAST(100.00 AS Decimal(10, 2)))
INSERT [dbo].[Order Details] ([order_detail_id], [order_id], [koi_id], [quantity], [price]) VALUES (18, 13, 8, 1, CAST(100.00 AS Decimal(10, 2)))
INSERT [dbo].[Order Details] ([order_detail_id], [order_id], [koi_id], [quantity], [price]) VALUES (19, 13, 7, 1, CAST(50.00 AS Decimal(10, 2)))
INSERT [dbo].[Order Details] ([order_detail_id], [order_id], [koi_id], [quantity], [price]) VALUES (20, 14, 7, 1, CAST(50.00 AS Decimal(10, 2)))
INSERT [dbo].[Order Details] ([order_detail_id], [order_id], [koi_id], [quantity], [price]) VALUES (21, 14, 8, 1, CAST(100.00 AS Decimal(10, 2)))
INSERT [dbo].[Order Details] ([order_detail_id], [order_id], [koi_id], [quantity], [price]) VALUES (22, 15, 7, 2, CAST(50.00 AS Decimal(10, 2)))
INSERT [dbo].[Order Details] ([order_detail_id], [order_id], [koi_id], [quantity], [price]) VALUES (23, 15, 8, 1, CAST(100.00 AS Decimal(10, 2)))
INSERT [dbo].[Order Details] ([order_detail_id], [order_id], [koi_id], [quantity], [price]) VALUES (24, 16, 8, 2, CAST(100.00 AS Decimal(10, 2)))
INSERT [dbo].[Order Details] ([order_detail_id], [order_id], [koi_id], [quantity], [price]) VALUES (25, 17, 8, 1, CAST(100.00 AS Decimal(10, 2)))
INSERT [dbo].[Order Details] ([order_detail_id], [order_id], [koi_id], [quantity], [price]) VALUES (26, 17, 7, 1, CAST(50.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Order Details] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([order_id], [user_id], [total_amount], [created_at]) VALUES (12, 3, CAST(210.00 AS Decimal(18, 2)), CAST(N'2024-11-13T23:27:30.950' AS DateTime))
INSERT [dbo].[Orders] ([order_id], [user_id], [total_amount], [created_at]) VALUES (13, 3, CAST(250.00 AS Decimal(18, 2)), CAST(N'2024-11-14T07:21:36.363' AS DateTime))
INSERT [dbo].[Orders] ([order_id], [user_id], [total_amount], [created_at]) VALUES (14, 3, CAST(150.00 AS Decimal(18, 2)), CAST(N'2024-11-14T07:29:45.290' AS DateTime))
INSERT [dbo].[Orders] ([order_id], [user_id], [total_amount], [created_at]) VALUES (15, 3, CAST(200.00 AS Decimal(18, 2)), CAST(N'2024-11-14T08:14:15.183' AS DateTime))
INSERT [dbo].[Orders] ([order_id], [user_id], [total_amount], [created_at]) VALUES (16, 1, CAST(200.00 AS Decimal(18, 2)), CAST(N'2024-11-14T08:17:34.997' AS DateTime))
INSERT [dbo].[Orders] ([order_id], [user_id], [total_amount], [created_at]) VALUES (17, 1, CAST(150.00 AS Decimal(18, 2)), CAST(N'2024-11-14T08:18:00.053' AS DateTime))
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
/****** Object:  Index [IX_Customer_user_id]    Script Date: 11/20/2024 2:58:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_Customer_user_id] ON [dbo].[Customer]
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[KoiImages] ADD  DEFAULT (getdate()) FOR [upload_date]
GO
ALTER TABLE [dbo].[Order Details] ADD  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[Koi Coassignment]  WITH CHECK ADD  CONSTRAINT [FK_KoiCoassignment_Customer] FOREIGN KEY([user_id])
REFERENCES [dbo].[Customer] ([user_id])
GO
ALTER TABLE [dbo].[Koi Coassignment] CHECK CONSTRAINT [FK_KoiCoassignment_Customer]
GO
ALTER TABLE [dbo].[Koi Coassignment]  WITH CHECK ADD  CONSTRAINT [FK_KoiCoassignment_KoiFish] FOREIGN KEY([koi_id])
REFERENCES [dbo].[Koi Fish] ([koi_id])
GO
ALTER TABLE [dbo].[Koi Coassignment] CHECK CONSTRAINT [FK_KoiCoassignment_KoiFish]
GO
ALTER TABLE [dbo].[Koi Fish]  WITH CHECK ADD  CONSTRAINT [FK_KoiBreedType] FOREIGN KEY([breed_type_id])
REFERENCES [dbo].[KoiBreedType] ([breed_type_id])
GO
ALTER TABLE [dbo].[Koi Fish] CHECK CONSTRAINT [FK_KoiBreedType]
GO
ALTER TABLE [dbo].[KoiImages]  WITH CHECK ADD FOREIGN KEY([koi_id])
REFERENCES [dbo].[Koi Fish] ([koi_id])
GO
ALTER TABLE [dbo].[Order Details]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_KoiFish] FOREIGN KEY([koi_id])
REFERENCES [dbo].[Koi Fish] ([koi_id])
GO
ALTER TABLE [dbo].[Order Details] CHECK CONSTRAINT [FK_OrderDetails_KoiFish]
GO
ALTER TABLE [dbo].[Order Details]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY([order_id])
REFERENCES [dbo].[Orders] ([order_id])
GO
ALTER TABLE [dbo].[Order Details] CHECK CONSTRAINT [FK_OrderDetails_Orders]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customer] FOREIGN KEY([user_id])
REFERENCES [dbo].[Customer] ([user_id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customer]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD CHECK  (([role]='admin' OR [role]='user'))
GO
USE [master]
GO
ALTER DATABASE [KoiManagement] SET  READ_WRITE 
GO
