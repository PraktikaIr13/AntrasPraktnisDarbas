USE [SANDELYS]
GO
/****** Object:  Table [dbo].[Tiekejai]    Script Date: 12/15/2015 9:09:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tiekejai](
	[tiekejo_kodas] [int] NOT NULL,
	[tiekejo_pavadinimas] [text] NULL,
	[sutartis_pasirasyta] [date] NULL,
	[sutartis_pasibaigia] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[tiekejo_kodas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TiekejaiIrProduktai]    Script Date: 12/15/2015 9:09:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiekejaiIrProduktai](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TIEKEJOID] [int] NULL,
	[PRODUKTOID] [int] NULL,
 CONSTRAINT [PK_TiekejaiIrProduktai] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TiekejuProduktai]    Script Date: 12/15/2015 9:09:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TiekejuProduktai](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PAVADINIMAS] [varchar](50) NULL,
 CONSTRAINT [PK_TiekejuProduktai] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
