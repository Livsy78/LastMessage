USE [LastMessage]
GO

/****** Object:  Table [dbo].[Log]    Script Date: 26.09.2018 12:36:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Log](
    [ID] [int] IDENTITY(1,1) NOT NULL,
    [UserID] [int] NOT NULL,
    [Time] [datetime] NOT NULL,
    [Type] [varchar](32) NOT NULL,
    [Text] [nvarchar](max) NOT NULL,
    [EntityID] [int] NULL,
    [EntityType] [varchar](16) NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
    [ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

