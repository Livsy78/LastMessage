USE [LastMessage]
GO

/****** Object:  Table [dbo].[Recipient]    Script Date: 26.09.2018 12:35:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Recipient](
    [ID] [int] IDENTITY(1,1) NOT NULL,
    [Status] [varchar](16) NOT NULL,
    [MessageID] [int] NOT NULL,
    [Name] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_Recipient] PRIMARY KEY CLUSTERED 
(
    [ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Recipient]  WITH CHECK ADD  CONSTRAINT [FK_Recipient_Message] FOREIGN KEY([MessageID])
REFERENCES [dbo].[Message] ([ID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Recipient] CHECK CONSTRAINT [FK_Recipient_Message]
GO

