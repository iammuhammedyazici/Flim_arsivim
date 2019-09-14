USE [DboFlimArsivim]
GO
/****** Object:  Table [dbo].[TBL_FLIMLER]    Script Date: 21.04.2019 21:34:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_FLIMLER](
	[ID] [smallint] IDENTITY(1,1) NOT NULL,
	[AD] [varchar](50) NULL,
	[KATEGORI] [varchar](30) NULL,
	[LINK] [varchar](100) NULL,
	[DURUM] [bit] NULL
) ON [PRIMARY]
GO
