USE [master]
GO
/****** Object:  Database [GringottsBankDb]    Script Date: 20.01.2022 13:13:52 ******/
CREATE DATABASE [GringottsBankDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GringottsBankDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\GringottsBankDb.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GringottsBankDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\GringottsBankDb_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [GringottsBankDb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GringottsBankDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GringottsBankDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GringottsBankDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GringottsBankDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GringottsBankDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GringottsBankDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [GringottsBankDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GringottsBankDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GringottsBankDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GringottsBankDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GringottsBankDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GringottsBankDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GringottsBankDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GringottsBankDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GringottsBankDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GringottsBankDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GringottsBankDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GringottsBankDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GringottsBankDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GringottsBankDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GringottsBankDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GringottsBankDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GringottsBankDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GringottsBankDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GringottsBankDb] SET  MULTI_USER 
GO
ALTER DATABASE [GringottsBankDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GringottsBankDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GringottsBankDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GringottsBankDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [GringottsBankDb] SET DELAYED_DURABILITY = DISABLED 
GO
USE [GringottsBankDb]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 20.01.2022 13:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Id] [uniqueidentifier] NOT NULL,
	[CustomerId] [uniqueidentifier] NOT NULL,
	[Description] [nchar](100) NOT NULL,
	[Balance] [money] NULL,
	[CreatedDate] [date] NULL,
	[CreatedBy] [nchar](100) NULL,
	[UpdatedDate] [date] NULL,
	[UpdatedBy] [nchar](100) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customers]    Script Date: 20.01.2022 13:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nchar](50) NOT NULL,
	[Surname] [nchar](50) NOT NULL,
	[PhoneNumber] [nchar](50) NOT NULL,
	[Street] [nchar](50) NOT NULL,
	[City] [nchar](50) NOT NULL,
	[State] [nchar](50) NOT NULL,
	[IdentificationNo] [nchar](50) NOT NULL,
	[CreatedDate] [date] NULL,
	[CreatedBy] [nchar](50) NULL,
	[UpdatedDate] [date] NULL,
	[UpdatedBy] [nchar](50) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 20.01.2022 13:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Id] [uniqueidentifier] NOT NULL,
	[AccountId] [uniqueidentifier] NOT NULL,
	[Amount] [money] NOT NULL,
	[Balance] [money] NOT NULL,
	[Date] [date] NOT NULL,
	[Type] [int] NOT NULL,
	[Description] [nchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TransactionType]    Script Date: 20.01.2022 13:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionType](
	[Id] [int] NOT NULL,
	[Type] [nchar](40) NOT NULL
) ON [PRIMARY]

GO
INSERT [dbo].[Accounts] ([Id], [CustomerId], [Description], [Balance], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (N'7e30618c-3306-4958-a50f-08d9daac6e16', N'a3747cd3-37eb-4508-0727-08d9daa93d86', N'test                                                                                                ', 750.0000, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [Description], [Balance], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (N'6b124245-79d8-4ba2-dd88-08d9daaf5232', N'a3747cd3-37eb-4508-0727-08d9daa93d86', N'test                                                                                                ', 974.0000, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [Description], [Balance], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (N'37c9174d-597d-4387-ced9-08d9dabea5fa', N'a3747cd3-37eb-4508-0727-08d9daa93d86', N'test                                                                                                ', 999.0000, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [Description], [Balance], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (N'd25cb06f-a698-4570-3f97-08d9daceb9b3', N'db5649a9-713b-426c-35af-08d9daceb242', N'test                                                                                                ', 999.0000, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [Description], [Balance], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (N'47d08aca-f6fd-4fa3-92d5-4f3e5f8a2c48', N'db5649a9-713b-426c-35af-08d9daceb242', N'test                                                                                                ', 999.0000, NULL, NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [Description], [Balance], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (N'46e796e7-07eb-46b3-9a13-996f858b6032', N'e0b30fae-5550-43f6-98bd-64f72721ad3a', N'test                                                                                                ', 234452.0000, CAST(N'2022-01-19' AS Date), NULL, NULL, NULL)
INSERT [dbo].[Accounts] ([Id], [CustomerId], [Description], [Balance], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (N'3eaf3bcc-09f5-465b-9835-a07e171b6ea2', N'db5649a9-713b-426c-35af-08d9daceb242', N'test                                                                                                ', 639.0000, CAST(N'2022-01-19' AS Date), NULL, CAST(N'0001-01-01' AS Date), NULL)
INSERT [dbo].[Customers] ([Id], [Name], [Surname], [PhoneNumber], [Street], [City], [State], [IdentificationNo], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (N'db5649a9-713b-426c-35af-08d9daceb242', N'hüseyin                                           ', N'kiziltans                                         ', N'5396184808                                        ', N'yyy                                               ', N'yyy                                               ', N'xxxx                                              ', N'123123212                                         ', NULL, NULL, NULL, NULL)
INSERT [dbo].[Customers] ([Id], [Name], [Surname], [PhoneNumber], [Street], [City], [State], [IdentificationNo], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (N'e0b30fae-5550-43f6-98bd-64f72721ad3a', N'hüseyin                                           ', N'kiziltans                                         ', N'5396184808                                        ', N'yyy                                               ', N'yyy                                               ', N'xxxx                                              ', N'12345678911                                       ', CAST(N'2022-01-19' AS Date), NULL, NULL, NULL)
INSERT [dbo].[Transactions] ([Id], [AccountId], [Amount], [Balance], [Date], [Type], [Description]) VALUES (N'3b70a29d-6b48-4679-e41f-08d9dac01608', N'6b124245-79d8-4ba2-dd88-08d9daaf5232', 125.0000, 2499.0000, CAST(N'0001-01-01' AS Date), 1, N'                                                  ')
INSERT [dbo].[Transactions] ([Id], [AccountId], [Amount], [Balance], [Date], [Type], [Description]) VALUES (N'3e514358-9e91-44d9-e420-08d9dac01608', N'6b124245-79d8-4ba2-dd88-08d9daaf5232', 1250.0000, 1249.0000, CAST(N'0001-01-01' AS Date), 2, N'                                                  ')
INSERT [dbo].[Transactions] ([Id], [AccountId], [Amount], [Balance], [Date], [Type], [Description]) VALUES (N'84c88f35-1706-44e2-e421-08d9dac01608', N'6b124245-79d8-4ba2-dd88-08d9daaf5232', 200.0000, 1049.0000, CAST(N'0001-01-01' AS Date), 2, N'                                                  ')
INSERT [dbo].[Transactions] ([Id], [AccountId], [Amount], [Balance], [Date], [Type], [Description]) VALUES (N'40547d2a-239b-4a97-e422-08d9dac01608', N'6b124245-79d8-4ba2-dd88-08d9daaf5232', 200.0000, 849.0000, CAST(N'0001-01-01' AS Date), 2, N'                                                  ')
INSERT [dbo].[Transactions] ([Id], [AccountId], [Amount], [Balance], [Date], [Type], [Description]) VALUES (N'c589beed-b0bc-4760-e423-08d9dac01608', N'6b124245-79d8-4ba2-dd88-08d9daaf5232', 125.0000, 974.0000, CAST(N'0001-01-01' AS Date), 1, N'                                                  ')
INSERT [dbo].[Transactions] ([Id], [AccountId], [Amount], [Balance], [Date], [Type], [Description]) VALUES (N'953175a2-9959-451a-dd53-08d9dac81adf', N'6b124245-79d8-4ba2-dd88-08d9daaf5232', 125.0000, 1099.0000, CAST(N'0001-01-01' AS Date), 1, N'                                                  ')
INSERT [dbo].[Transactions] ([Id], [AccountId], [Amount], [Balance], [Date], [Type], [Description]) VALUES (N'37b6c289-3473-4f40-0aec-08d9dae50162', N'47d08aca-f6fd-4fa3-92d5-4f3e5f8a2c48', 125.0000, 1124.0000, CAST(N'0001-01-01' AS Date), 1, N'                                                  ')
INSERT [dbo].[Transactions] ([Id], [AccountId], [Amount], [Balance], [Date], [Type], [Description]) VALUES (N'f8571600-7752-4ef0-8326-08d9db67fd57', N'3eaf3bcc-09f5-465b-9835-a07e171b6ea2', 500.0000, 1499.0000, CAST(N'0001-01-01' AS Date), 1, N'                                                  ')
INSERT [dbo].[Transactions] ([Id], [AccountId], [Amount], [Balance], [Date], [Type], [Description]) VALUES (N'2f7d0692-c328-4391-8327-08d9db67fd57', N'3eaf3bcc-09f5-465b-9835-a07e171b6ea2', 128.0000, 1127.0000, CAST(N'0001-01-01' AS Date), 1, N'                                                  ')
INSERT [dbo].[Transactions] ([Id], [AccountId], [Amount], [Balance], [Date], [Type], [Description]) VALUES (N'6714b133-4a89-4b3b-8328-08d9db67fd57', N'3eaf3bcc-09f5-465b-9835-a07e171b6ea2', 128.0000, 1127.0000, CAST(N'0001-01-01' AS Date), 1, N'                                                  ')
INSERT [dbo].[Transactions] ([Id], [AccountId], [Amount], [Balance], [Date], [Type], [Description]) VALUES (N'e4e709ad-4178-4412-8329-08d9db67fd57', N'3eaf3bcc-09f5-465b-9835-a07e171b6ea2', 128.0000, 1127.0000, CAST(N'0001-01-01' AS Date), 1, N'                                                  ')
INSERT [dbo].[Transactions] ([Id], [AccountId], [Amount], [Balance], [Date], [Type], [Description]) VALUES (N'e314c619-d3f1-400f-832a-08d9db67fd57', N'3eaf3bcc-09f5-465b-9835-a07e171b6ea2', 128.0000, 1127.0000, CAST(N'0001-01-01' AS Date), 1, N'                                                  ')
INSERT [dbo].[Transactions] ([Id], [AccountId], [Amount], [Balance], [Date], [Type], [Description]) VALUES (N'fdb666b4-48a5-45ee-832b-08d9db67fd57', N'3eaf3bcc-09f5-465b-9835-a07e171b6ea2', 128.0000, 1127.0000, CAST(N'0001-01-01' AS Date), 1, N'                                                  ')
INSERT [dbo].[Transactions] ([Id], [AccountId], [Amount], [Balance], [Date], [Type], [Description]) VALUES (N'b9ab1225-afef-405d-832c-08d9db67fd57', N'3eaf3bcc-09f5-465b-9835-a07e171b6ea2', 128.0000, 1127.0000, CAST(N'0001-01-01' AS Date), 1, N'                                                  ')
INSERT [dbo].[Transactions] ([Id], [AccountId], [Amount], [Balance], [Date], [Type], [Description]) VALUES (N'cca36b62-14d9-422e-832d-08d9db67fd57', N'3eaf3bcc-09f5-465b-9835-a07e171b6ea2', 128.0000, 1127.0000, CAST(N'0001-01-01' AS Date), 1, N'                                                  ')
INSERT [dbo].[Transactions] ([Id], [AccountId], [Amount], [Balance], [Date], [Type], [Description]) VALUES (N'27444be3-264f-4c0d-0846-08d9db6a6968', N'3eaf3bcc-09f5-465b-9835-a07e171b6ea2', 128.0000, 1127.0000, CAST(N'0001-01-01' AS Date), 1, N'                                                  ')
INSERT [dbo].[Transactions] ([Id], [AccountId], [Amount], [Balance], [Date], [Type], [Description]) VALUES (N'c5512b0e-e74b-4dd3-99a5-08d9db6ac71b', N'3eaf3bcc-09f5-465b-9835-a07e171b6ea2', 1000.0000, 127.0000, CAST(N'0001-01-01' AS Date), 2, N'                                                  ')
INSERT [dbo].[Transactions] ([Id], [AccountId], [Amount], [Balance], [Date], [Type], [Description]) VALUES (N'595c920e-9129-46fc-99a6-08d9db6ac71b', N'3eaf3bcc-09f5-465b-9835-a07e171b6ea2', 128.0000, 255.0000, CAST(N'0001-01-01' AS Date), 1, N'                                                  ')
INSERT [dbo].[Transactions] ([Id], [AccountId], [Amount], [Balance], [Date], [Type], [Description]) VALUES (N'08899b84-6a61-4f0f-9e7d-08d9db6b5c11', N'3eaf3bcc-09f5-465b-9835-a07e171b6ea2', 128.0000, 383.0000, CAST(N'0001-01-01' AS Date), 1, N'                                                  ')
INSERT [dbo].[Transactions] ([Id], [AccountId], [Amount], [Balance], [Date], [Type], [Description]) VALUES (N'2dae2a6b-0a5f-43c9-16d4-08d9db6b8e1f', N'3eaf3bcc-09f5-465b-9835-a07e171b6ea2', 128.0000, 639.0000, CAST(N'2022-01-19' AS Date), 1, N'                                                  ')
INSERT [dbo].[Transactions] ([Id], [AccountId], [Amount], [Balance], [Date], [Type], [Description]) VALUES (N'795a119d-ffbe-4db4-9839-08d9db6ecd9a', N'46e796e7-07eb-46b3-9a13-996f858b6032', 128.0000, 234452.0000, CAST(N'2022-01-19' AS Date), 1, N'                                                  ')
USE [master]
GO
ALTER DATABASE [GringottsBankDb] SET  READ_WRITE 
GO
