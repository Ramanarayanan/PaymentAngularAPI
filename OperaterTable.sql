USE [Payments]
GO

/****** Object:  Table [dbo].[OperaterTable]    Script Date: 8/20/2021 2:34:37 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OperaterTable]') AND type in (N'U'))
DROP TABLE [dbo].[OperaterTable]
GO

/****** Object:  Table [dbo].[OperaterTable]    Script Date: 8/20/2021 2:34:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OperaterTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Operater] [nvarchar](50) NULL,
	[Mrp] [decimal](18, 0) NULL,
	[ValidateDays] [int] NULL,
	[Descriptions] [nchar](10) NULL,
	[Roaming] [nchar](10) NULL,
	[Sms] [nchar](10) NULL,
	[Data] [nchar](10) NULL
) ON [PRIMARY]
GO


