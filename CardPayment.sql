USE [Payments]
GO

/****** Object:  Table [dbo].[CardPayment]    Script Date: 8/20/2021 2:33:35 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CardPayment]') AND type in (N'U'))
DROP TABLE [dbo].[CardPayment]
GO

/****** Object:  Table [dbo].[CardPayment]    Script Date: 8/20/2021 2:33:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CardPayment](
	[Id] [int] NOT NULL,
	[CardNumber] [nvarchar](max) NULL,
	[Cvvnumber] [nvarchar](50) NULL,
	[ExpiryDate] [nvarchar](50) NULL,
	[CardHolderName] [nvarchar](50) NULL,
	[Amount] [decimal](18, 0) NULL,
	[DateModified] [datetime] NULL,
 CONSTRAINT [PK_CardPayment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


