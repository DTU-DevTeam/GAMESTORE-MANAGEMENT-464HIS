USE [master]
GO
/****** Object:  Database [ROBOTCITYSTADIUM]    Script Date: 5/23/2025 7:11:54 PM ******/
CREATE DATABASE [ROBOTCITYSTADIUM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ROBOTSTADIUM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ROBOTSTADIUM.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ROBOTSTADIUM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ROBOTSTADIUM_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ROBOTCITYSTADIUM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET ARITHABORT OFF 
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET RECOVERY FULL 
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET  MULTI_USER 
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ROBOTCITYSTADIUM', N'ON'
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET QUERY_STORE = OFF
GO
USE [ROBOTCITYSTADIUM]
GO
/****** Object:  Table [dbo].[ACCOUNT_STORE]    Script Date: 5/23/2025 7:11:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACCOUNT_STORE](
	[MaTaiKhoan] [nvarchar](10) NOT NULL,
	[TenDangNhap] [nvarchar](50) NOT NULL,
	[MatKhau] [varchar](256) NOT NULL,
	[Salt] [varchar](50) NOT NULL,
	[VaiTro] [nvarchar](20) NOT NULL,
	[NgayTao] [datetime] NULL,
	[Email] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 5/23/2025 7:11:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DateCheckIn] [date] NOT NULL,
	[DataCheckOut] [date] NULL,
	[idComputer] [int] NOT NULL,
	[status] [int] NOT NULL,
	[discount] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillInfo]    Script Date: 5/23/2025 7:11:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBill] [int] NOT NULL,
	[idFood] [int] NOT NULL,
	[count] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Food]    Script Date: 5/23/2025 7:11:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ten] [nvarchar](100) NOT NULL,
	[idCategory] [int] NOT NULL,
	[price] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodCategory]    Script Date: 5/23/2025 7:11:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodCategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ten] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mayfood]    Script Date: 5/23/2025 7:11:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mayfood](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ten] [nvarchar](100) NOT NULL,
	[status] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ACCOUNT_STORE] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [Salt], [VaiTro], [NgayTao], [Email]) VALUES (N'AD01', N'admin', N'0887506CB49200FE1833F3D49BC177333235C8F246D97EFC0105C2A5F274D7E1', N'A5CA14D7-A3EA-4799-BA98-A2903C0950FC', N'Admin', CAST(N'2025-05-11T18:54:40.337' AS DateTime), N'admin1@gmail.com')
INSERT [dbo].[ACCOUNT_STORE] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [Salt], [VaiTro], [NgayTao], [Email]) VALUES (N'AD02', N'admin2', N'0E4A2D0B0F44B9BC91A573016744DF3DF5008247F1F2337CF345E43D407F7E3C', N'228c09f9-6712-47ca-91fe-eddbb70a925a', N'Admin', CAST(N'2025-05-22T16:14:52.000' AS DateTime), N'leminhtuank0@gmail.com')
INSERT [dbo].[ACCOUNT_STORE] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [Salt], [VaiTro], [NgayTao], [Email]) VALUES (N'NV01', N'nhanvien1', N'9620DAE6D80587A029780063F14E2A5086ED69346A41942E80ED9E642939C450', N'08829EF2-9DD2-4ED4-9176-B265EED79789', N'Nhân Viên', CAST(N'2025-05-11T18:54:40.340' AS DateTime), N'nhanvien1@gmail.com')
INSERT [dbo].[ACCOUNT_STORE] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [Salt], [VaiTro], [NgayTao], [Email]) VALUES (N'NV02', N'minhtuan1', N'6DF6DD552BEDFFD268D45EB5A0D4645FC3F5D976837CA79D124C5AF910491ECD', N'29d60f46-edb0-475c-817f-a297c6992e07', N'Nhân Viên', CAST(N'2025-05-22T17:55:04.000' AS DateTime), N'jvenn3275@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([id], [DateCheckIn], [DataCheckOut], [idComputer], [status], [discount]) VALUES (5, CAST(N'2025-05-22' AS Date), NULL, 4, 1, 0)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DataCheckOut], [idComputer], [status], [discount]) VALUES (6, CAST(N'2025-05-22' AS Date), NULL, 4, 1, 50)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DataCheckOut], [idComputer], [status], [discount]) VALUES (7, CAST(N'2025-05-22' AS Date), NULL, 3, 1, 10)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DataCheckOut], [idComputer], [status], [discount]) VALUES (8, CAST(N'2025-05-22' AS Date), NULL, 4, 1, 10)
INSERT [dbo].[Bill] ([id], [DateCheckIn], [DataCheckOut], [idComputer], [status], [discount]) VALUES (9, CAST(N'2025-05-22' AS Date), NULL, 4, 1, 10)
SET IDENTITY_INSERT [dbo].[Bill] OFF
GO
SET IDENTITY_INSERT [dbo].[BillInfo] ON 

INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (10, 5, 1, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (11, 6, 1, 1)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (12, 7, 7, 0)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (13, 8, 1, 2)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (14, 8, 7, 5)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (15, 9, 4, 3)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (16, 9, 5, 4)
INSERT [dbo].[BillInfo] ([id], [idBill], [idFood], [count]) VALUES (17, 9, 6, 6)
SET IDENTITY_INSERT [dbo].[BillInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[Food] ON 

INSERT [dbo].[Food] ([id], [ten], [idCategory], [price]) VALUES (1, N'Mỳ Tôm Trứng ', 1, 20000)
INSERT [dbo].[Food] ([id], [ten], [idCategory], [price]) VALUES (2, N'Mỳ Tôm Trứng + Xúc Xích ', 1, 25000)
INSERT [dbo].[Food] ([id], [ten], [idCategory], [price]) VALUES (3, N'Mỳ Xào Bò ', 1, 45000)
INSERT [dbo].[Food] ([id], [ten], [idCategory], [price]) VALUES (4, N'Cơm Chiên', 2, 27000)
INSERT [dbo].[Food] ([id], [ten], [idCategory], [price]) VALUES (5, N'Cơm Chiên Dương Châu ', 2, 30000)
INSERT [dbo].[Food] ([id], [ten], [idCategory], [price]) VALUES (6, N'Cơm Gà ', 2, 65000)
INSERT [dbo].[Food] ([id], [ten], [idCategory], [price]) VALUES (7, N'Nước Lọc', 3, 10000)
INSERT [dbo].[Food] ([id], [ten], [idCategory], [price]) VALUES (8, N'Nước Tăng Lực', 3, 20000)
INSERT [dbo].[Food] ([id], [ten], [idCategory], [price]) VALUES (9, N'Nước Ngọt ', 3, 20000)
SET IDENTITY_INSERT [dbo].[Food] OFF
GO
SET IDENTITY_INSERT [dbo].[FoodCategory] ON 

INSERT [dbo].[FoodCategory] ([id], [ten]) VALUES (1, N'Mỳ Tôm')
INSERT [dbo].[FoodCategory] ([id], [ten]) VALUES (2, N'Cơm')
INSERT [dbo].[FoodCategory] ([id], [ten]) VALUES (3, N'Nước')
SET IDENTITY_INSERT [dbo].[FoodCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[Mayfood] ON 

INSERT [dbo].[Mayfood] ([id], [ten], [status]) VALUES (1, N'Máy0', N'Trống')
INSERT [dbo].[Mayfood] ([id], [ten], [status]) VALUES (2, N'Máy1', N'Trống')
INSERT [dbo].[Mayfood] ([id], [ten], [status]) VALUES (3, N'Máy2', N'Có người')
INSERT [dbo].[Mayfood] ([id], [ten], [status]) VALUES (4, N'Máy3', N'Có người')
INSERT [dbo].[Mayfood] ([id], [ten], [status]) VALUES (5, N'Máy4', N'Trống')
INSERT [dbo].[Mayfood] ([id], [ten], [status]) VALUES (6, N'Máy5', N'Trống')
INSERT [dbo].[Mayfood] ([id], [ten], [status]) VALUES (7, N'Máy6', N'Trống')
INSERT [dbo].[Mayfood] ([id], [ten], [status]) VALUES (8, N'Máy7', N'Trống')
INSERT [dbo].[Mayfood] ([id], [ten], [status]) VALUES (9, N'Máy8', N'Trống')
INSERT [dbo].[Mayfood] ([id], [ten], [status]) VALUES (10, N'Máy9', N'Trống')
INSERT [dbo].[Mayfood] ([id], [ten], [status]) VALUES (11, N'Máy10', N'Trống')
INSERT [dbo].[Mayfood] ([id], [ten], [status]) VALUES (12, N'Máy 11', N'Trống')
INSERT [dbo].[Mayfood] ([id], [ten], [status]) VALUES (13, N'Máy 12', N'Trống')
INSERT [dbo].[Mayfood] ([id], [ten], [status]) VALUES (14, N'Máy 13', N'Trống')
INSERT [dbo].[Mayfood] ([id], [ten], [status]) VALUES (15, N'Máy 14', N'Trống')
INSERT [dbo].[Mayfood] ([id], [ten], [status]) VALUES (16, N'Máy 15', N'Trống')
INSERT [dbo].[Mayfood] ([id], [ten], [status]) VALUES (17, N'Máy 16', N'Trống')
INSERT [dbo].[Mayfood] ([id], [ten], [status]) VALUES (18, N'Máy 17', N'Trống')
INSERT [dbo].[Mayfood] ([id], [ten], [status]) VALUES (19, N'Máy 18', N'Trống')
INSERT [dbo].[Mayfood] ([id], [ten], [status]) VALUES (20, N'Máy 19', N'Trống')
INSERT [dbo].[Mayfood] ([id], [ten], [status]) VALUES (21, N'Máy 20', N'Trống')
INSERT [dbo].[Mayfood] ([id], [ten], [status]) VALUES (22, N'Máy 21', N'Trống')
INSERT [dbo].[Mayfood] ([id], [ten], [status]) VALUES (23, N'Máy 22', N'Trống')
INSERT [dbo].[Mayfood] ([id], [ten], [status]) VALUES (24, N'Máy 23', N'Trống')
SET IDENTITY_INSERT [dbo].[Mayfood] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__ACCOUNT___55F68FC029768306]    Script Date: 5/23/2025 7:11:55 PM ******/
ALTER TABLE [dbo].[ACCOUNT_STORE] ADD UNIQUE NONCLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ACCOUNT_STORE] ADD  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT (getdate()) FOR [DateCheckIn]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[BillInfo] ADD  DEFAULT ((0)) FOR [count]
GO
ALTER TABLE [dbo].[Food] ADD  DEFAULT (N'Chưa Đặt Tên') FOR [ten]
GO
ALTER TABLE [dbo].[Food] ADD  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[FoodCategory] ADD  DEFAULT (N'Chưa Đặt Tên') FOR [ten]
GO
ALTER TABLE [dbo].[Mayfood] ADD  DEFAULT (N'Máy Trống') FOR [ten]
GO
ALTER TABLE [dbo].[Mayfood] ADD  DEFAULT (N'Trống') FOR [status]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([idComputer])
REFERENCES [dbo].[Mayfood] ([id])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([idBill])
REFERENCES [dbo].[Bill] ([id])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([idFood])
REFERENCES [dbo].[Food] ([id])
GO
ALTER TABLE [dbo].[Food]  WITH CHECK ADD FOREIGN KEY([idCategory])
REFERENCES [dbo].[FoodCategory] ([id])
GO
/****** Object:  StoredProcedure [dbo].[USP_GetMayList]    Script Date: 5/23/2025 7:11:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetMayList]
as select * from  dbo.Mayfood
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBill]    Script Date: 5/23/2025 7:11:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[USP_InsertBill]
@idComputer INT
as 
begin
	insert dbo.Bill(DateCheckIn,DataCheckOut,idComputer,status,discount)
	values (getdate(),null, @idComputer, 0,0)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBillInfo]    Script Date: 5/23/2025 7:11:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_InsertBillInfo]
@idBill INT, @idFood int, @count INT 
AS
begin
	
	declare @isExitBillInfo int
	declare @foodCount int =1
	select @isExitBillInfo = id ,@foodCount = b.count  
	from dbo.BillInfo as b 
	where idBill = @idBill and idFood = @idFood
	if(@isExitBillInfo > 0)
	begin
		declare @newCount int = @foodCount + @count
		if(@newCount > 0)
			update dbo.BillInfo set count = @foodCount + @count where  idFood = @idFood
		else
			delete BillInfo where idBill = @idBill and idFood = @idFood
	end
	else
		begin
				insert dbo.BillInfo(idBill,idFood,count)
				values (@idBill,@idFood,@count)
		end
end
GO
USE [master]
GO
ALTER DATABASE [ROBOTCITYSTADIUM] SET  READ_WRITE 
GO
