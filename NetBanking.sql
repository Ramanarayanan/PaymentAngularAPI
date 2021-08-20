USE [Payments]
GO

/****** Object:  Table [dbo].[NetBanking]    Script Date: 8/20/2021 2:34:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NetBanking]') AND type in (N'U'))
DROP TABLE [dbo].[NetBanking]
GO

/****** Object:  Table [dbo].[NetBanking]    Script Date: 8/20/2021 2:34:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NetBanking](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Amount] [decimal](18, 0) NULL,
	[DateModified] [datetime] NULL
) ON [PRIMARY]
GO


