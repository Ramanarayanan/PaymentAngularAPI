USE [Payments]
GO

/****** Object:  Table [dbo].[PostPaid]    Script Date: 8/20/2021 2:34:57 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PostPaid]') AND type in (N'U'))
DROP TABLE [dbo].[PostPaid]
GO

/****** Object:  Table [dbo].[PostPaid]    Script Date: 8/20/2021 2:34:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PostPaid](
	[ProductId] [int] NULL,
	[Id] [nvarchar](50) NULL,
	[MobileNumber] [nvarchar](50) NULL,
	[ConsumerNo] [nvarchar](50) NULL,
	[BillType] [nvarchar](50) NULL,
	[Amount] [decimal](18, 0) NULL,
	[PaidAmount] [decimal](18, 0) NULL,
	[DateModified] [datetime] NULL
) ON [PRIMARY]
GO


