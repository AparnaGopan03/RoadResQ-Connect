USE [master]
GO
/****** Object:  Database [Roadside Assistance]    Script Date: 03/13/2024 22:45:31 ******/
CREATE DATABASE [Roadside Assistance] ON  PRIMARY 
( NAME = N'Roadside Assistance', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Roadside Assistance.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Roadside Assistance_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Roadside Assistance_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Roadside Assistance] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Roadside Assistance].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Roadside Assistance] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Roadside Assistance] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Roadside Assistance] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Roadside Assistance] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Roadside Assistance] SET ARITHABORT OFF
GO
ALTER DATABASE [Roadside Assistance] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Roadside Assistance] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Roadside Assistance] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Roadside Assistance] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Roadside Assistance] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Roadside Assistance] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Roadside Assistance] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Roadside Assistance] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Roadside Assistance] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Roadside Assistance] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Roadside Assistance] SET  DISABLE_BROKER
GO
ALTER DATABASE [Roadside Assistance] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Roadside Assistance] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Roadside Assistance] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Roadside Assistance] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Roadside Assistance] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Roadside Assistance] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Roadside Assistance] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Roadside Assistance] SET  READ_WRITE
GO
ALTER DATABASE [Roadside Assistance] SET RECOVERY SIMPLE
GO
ALTER DATABASE [Roadside Assistance] SET  MULTI_USER
GO
ALTER DATABASE [Roadside Assistance] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Roadside Assistance] SET DB_CHAINING OFF
GO
USE [Roadside Assistance]
GO
/****** Object:  Table [dbo].[Towing]    Script Date: 03/13/2024 22:45:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Towing](
	[towingid] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](100) NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[name] [varchar](100) NULL,
	[dob] [date] NULL,
	[servicecenter] [varchar](500) NULL,
	[contactnumber] [varchar](50) NULL,
	[latitude] [float] NULL,
	[longitude] [float] NULL,
	[availability] [bit] NULL,
 CONSTRAINT [PK_Towing] PRIMARY KEY CLUSTERED 
(
	[towingid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Services]    Script Date: 03/13/2024 22:45:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Services](
	[ServiceID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceName] [varchar](100) NULL,
	[BaseCost] [decimal](10, 2) NULL,
	[Description] [varchar](255) NULL,
	[AdditionalCharges] [varchar](500) NULL,
 CONSTRAINT [PK__Services__C51BB0EA07020F21] PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 03/13/2024 22:45:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Admin](
	[AdminID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[TotalEarnings] [decimal](10, 2) NULL,
	[TotalPayouts] [decimal](10, 2) NULL,
 CONSTRAINT [PK__Admin__719FE4E825869641] PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ServiceProvider]    Script Date: 03/13/2024 22:45:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ServiceProvider](
	[ProviderID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](255) NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Name] [varchar](100) NULL,
	[dob] [date] NULL,
	[Address] [varchar](255) NULL,
	[ContactNumber] [varchar](20) NULL,
	[YearsofExperience] [int] NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
	[ServiceArea] [varchar](255) NULL,
	[Availability] [bit] NULL,
	[Gender] [varchar](10) NULL,
	[Assistancetype] [varchar](50) NULL,
 CONSTRAINT [PK__ServiceP__B54C689D03317E3D] PRIMARY KEY CLUSTERED 
(
	[ProviderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 03/13/2024 22:45:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](255) NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Name] [varchar](100) NULL,
	[dob] [date] NULL,
	[Gender] [varchar](10) NULL,
	[Address] [varchar](255) NULL,
	[ContactNumber] [varchar](20) NULL,
 CONSTRAINT [PK__Customer__A4AE64B87F60ED59] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CServiceRequest]    Script Date: 03/13/2024 22:45:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CServiceRequest](
	[RequestID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[VehicleType] [varchar](50) NULL,
	[Make] [varchar](50) NULL,
	[Model] [varchar](50) NULL,
	[Year] [int] NULL,
	[LicensePlateNumber] [varchar](150) NULL,
	[Color] [varchar](50) NULL,
	[RequestTime] [datetime] NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
	[ProviderID] [int] NULL,
	[Status] [varchar](50) NULL,
	[assistancetype] [varchar](100) NULL,
 CONSTRAINT [PK_CServiceRequest] PRIMARY KEY CLUSTERED 
(
	[RequestID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Complaints]    Script Date: 03/13/2024 22:45:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Complaints](
	[ComplaintID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[ProviderID] [int] NULL,
	[ComplaintDetails] [varchar](255) NULL,
	[ComplaintStatus] [varchar](20) NULL,
	[ComplaintTime] [datetime] NULL,
 CONSTRAINT [PK__Complain__740D89AF398D8EEE] PRIMARY KEY CLUSTERED 
(
	[ComplaintID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Vehicle]    Script Date: 03/13/2024 22:45:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vehicle](
	[VehicleID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[Make] [varchar](50) NULL,
	[Model] [varchar](50) NULL,
	[Year] [int] NULL,
	[LicensePlateNumber] [varchar](20) NULL,
	[Color] [varchar](50) NULL,
	[VehicleType] [varchar](50) NULL,
 CONSTRAINT [PK__Vehicle__476B54B2145C0A3F] PRIMARY KEY CLUSTERED 
(
	[VehicleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Review]    Script Date: 03/13/2024 22:45:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Review](
	[ReviewID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[ProviderID] [int] NULL,
	[Rating] [int] NULL,
	[Feedback] [varchar](255) NULL,
	[ReviewTime] [datetime] NULL,
 CONSTRAINT [PK__Review__74BC79AE33D4B598] PRIMARY KEY CLUSTERED 
(
	[ReviewID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProviderServices]    Script Date: 03/13/2024 22:45:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProviderServices](
	[ProviderServiceID] [int] IDENTITY(1,1) NOT NULL,
	[ProviderID] [int] NULL,
	[ServiceID] [int] NULL,
 CONSTRAINT [PK__Provider__BC3F66290AD2A005] PRIMARY KEY CLUSTERED 
(
	[ProviderServiceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payout]    Script Date: 03/13/2024 22:45:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payout](
	[PayoutID] [int] IDENTITY(1,1) NOT NULL,
	[ProviderID] [int] NULL,
	[Amount] [decimal](10, 2) NULL,
	[PayoutTime] [datetime] NULL,
 CONSTRAINT [PK__Payout__35C3DFAE2F10007B] PRIMARY KEY CLUSTERED 
(
	[PayoutID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceRequest]    Script Date: 03/13/2024 22:45:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ServiceRequest](
	[RequestID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[VehicleID] [int] NULL,
	[RequestTime] [datetime] NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
	[ProviderID] [int] NULL,
	[Status] [varchar](20) NULL,
 CONSTRAINT [PK__ServiceR__33A8519A1A14E395] PRIMARY KEY CLUSTERED 
(
	[RequestID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 03/13/2024 22:45:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[RequestID] [int] NULL,
	[AdminID] [int] NULL,
	[Amount] [decimal](10, 2) NULL,
	[PaymentTime] [datetime] NULL,
 CONSTRAINT [PK__Payments__9B556A5829572725] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceLogs]    Script Date: 03/13/2024 22:45:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ServiceLogs](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[RequestID] [int] NULL,
	[ServiceDetails] [varchar](255) NULL,
	[Cost] [decimal](10, 2) NULL,
	[CompletionTime] [datetime] NULL,
 CONSTRAINT [PK__ServiceL__5E5499A820C1E124] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_CustomerID]    Script Date: 03/13/2024 22:45:32 ******/
ALTER TABLE [dbo].[CServiceRequest]  WITH CHECK ADD  CONSTRAINT [FK_CustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[CServiceRequest] CHECK CONSTRAINT [FK_CustomerID]
GO
/****** Object:  ForeignKey [FK_ProviderID]    Script Date: 03/13/2024 22:45:32 ******/
ALTER TABLE [dbo].[CServiceRequest]  WITH CHECK ADD  CONSTRAINT [FK_ProviderID] FOREIGN KEY([ProviderID])
REFERENCES [dbo].[ServiceProvider] ([ProviderID])
GO
ALTER TABLE [dbo].[CServiceRequest] CHECK CONSTRAINT [FK_ProviderID]
GO
/****** Object:  ForeignKey [FK__Complaint__Custo__3B75D760]    Script Date: 03/13/2024 22:45:32 ******/
ALTER TABLE [dbo].[Complaints]  WITH CHECK ADD  CONSTRAINT [FK__Complaint__Custo__3B75D760] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Complaints] CHECK CONSTRAINT [FK__Complaint__Custo__3B75D760]
GO
/****** Object:  ForeignKey [FK__Complaint__Provi__3C69FB99]    Script Date: 03/13/2024 22:45:32 ******/
ALTER TABLE [dbo].[Complaints]  WITH CHECK ADD  CONSTRAINT [FK__Complaint__Provi__3C69FB99] FOREIGN KEY([ProviderID])
REFERENCES [dbo].[ServiceProvider] ([ProviderID])
GO
ALTER TABLE [dbo].[Complaints] CHECK CONSTRAINT [FK__Complaint__Provi__3C69FB99]
GO
/****** Object:  ForeignKey [FK__Vehicle__Custome__164452B1]    Script Date: 03/13/2024 22:45:32 ******/
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK__Vehicle__Custome__164452B1] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK__Vehicle__Custome__164452B1]
GO
/****** Object:  ForeignKey [FK__Review__Customer__35BCFE0A]    Script Date: 03/13/2024 22:45:32 ******/
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK__Review__Customer__35BCFE0A] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK__Review__Customer__35BCFE0A]
GO
/****** Object:  ForeignKey [FK__Review__Provider__36B12243]    Script Date: 03/13/2024 22:45:32 ******/
ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK__Review__Provider__36B12243] FOREIGN KEY([ProviderID])
REFERENCES [dbo].[ServiceProvider] ([ProviderID])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK__Review__Provider__36B12243]
GO
/****** Object:  ForeignKey [FK__ProviderS__Provi__0CBAE877]    Script Date: 03/13/2024 22:45:32 ******/
ALTER TABLE [dbo].[ProviderServices]  WITH CHECK ADD  CONSTRAINT [FK__ProviderS__Provi__0CBAE877] FOREIGN KEY([ProviderID])
REFERENCES [dbo].[ServiceProvider] ([ProviderID])
GO
ALTER TABLE [dbo].[ProviderServices] CHECK CONSTRAINT [FK__ProviderS__Provi__0CBAE877]
GO
/****** Object:  ForeignKey [FK__ProviderS__Servi__0DAF0CB0]    Script Date: 03/13/2024 22:45:32 ******/
ALTER TABLE [dbo].[ProviderServices]  WITH CHECK ADD  CONSTRAINT [FK__ProviderS__Servi__0DAF0CB0] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Services] ([ServiceID])
GO
ALTER TABLE [dbo].[ProviderServices] CHECK CONSTRAINT [FK__ProviderS__Servi__0DAF0CB0]
GO
/****** Object:  ForeignKey [FK__Payout__Provider__30F848ED]    Script Date: 03/13/2024 22:45:32 ******/
ALTER TABLE [dbo].[Payout]  WITH CHECK ADD  CONSTRAINT [FK__Payout__Provider__30F848ED] FOREIGN KEY([ProviderID])
REFERENCES [dbo].[ServiceProvider] ([ProviderID])
GO
ALTER TABLE [dbo].[Payout] CHECK CONSTRAINT [FK__Payout__Provider__30F848ED]
GO
/****** Object:  ForeignKey [FK__ServiceRe__Custo__1BFD2C07]    Script Date: 03/13/2024 22:45:32 ******/
ALTER TABLE [dbo].[ServiceRequest]  WITH CHECK ADD  CONSTRAINT [FK__ServiceRe__Custo__1BFD2C07] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[ServiceRequest] CHECK CONSTRAINT [FK__ServiceRe__Custo__1BFD2C07]
GO
/****** Object:  ForeignKey [FK__ServiceRe__Provi__1DE57479]    Script Date: 03/13/2024 22:45:32 ******/
ALTER TABLE [dbo].[ServiceRequest]  WITH CHECK ADD  CONSTRAINT [FK__ServiceRe__Provi__1DE57479] FOREIGN KEY([ProviderID])
REFERENCES [dbo].[ServiceProvider] ([ProviderID])
GO
ALTER TABLE [dbo].[ServiceRequest] CHECK CONSTRAINT [FK__ServiceRe__Provi__1DE57479]
GO
/****** Object:  ForeignKey [FK__ServiceRe__Vehic__1CF15040]    Script Date: 03/13/2024 22:45:32 ******/
ALTER TABLE [dbo].[ServiceRequest]  WITH CHECK ADD  CONSTRAINT [FK__ServiceRe__Vehic__1CF15040] FOREIGN KEY([VehicleID])
REFERENCES [dbo].[Vehicle] ([VehicleID])
GO
ALTER TABLE [dbo].[ServiceRequest] CHECK CONSTRAINT [FK__ServiceRe__Vehic__1CF15040]
GO
/****** Object:  ForeignKey [FK__Payments__AdminI__2C3393D0]    Script Date: 03/13/2024 22:45:32 ******/
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK__Payments__AdminI__2C3393D0] FOREIGN KEY([AdminID])
REFERENCES [dbo].[Admin] ([AdminID])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK__Payments__AdminI__2C3393D0]
GO
/****** Object:  ForeignKey [FK__Payments__Reques__2B3F6F97]    Script Date: 03/13/2024 22:45:32 ******/
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK__Payments__Reques__2B3F6F97] FOREIGN KEY([RequestID])
REFERENCES [dbo].[ServiceRequest] ([RequestID])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK__Payments__Reques__2B3F6F97]
GO
/****** Object:  ForeignKey [FK__ServiceLo__Reque__22AA2996]    Script Date: 03/13/2024 22:45:32 ******/
ALTER TABLE [dbo].[ServiceLogs]  WITH CHECK ADD  CONSTRAINT [FK__ServiceLo__Reque__22AA2996] FOREIGN KEY([RequestID])
REFERENCES [dbo].[ServiceRequest] ([RequestID])
GO
ALTER TABLE [dbo].[ServiceLogs] CHECK CONSTRAINT [FK__ServiceLo__Reque__22AA2996]
GO
