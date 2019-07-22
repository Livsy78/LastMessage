USE [LastMessage]
GO

/****** Object:  Table [dbo].[Destination]    Script Date: 20.07.2019 16:05:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Destination](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Status] [varchar](16) NOT NULL,
	[RecipientID] [int] NOT NULL,
	[Type] [varchar](16) NOT NULL,
	[Address] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_Destination] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Destination]  WITH CHECK ADD  CONSTRAINT [FK_Destination_Recipient] FOREIGN KEY([RecipientID])
REFERENCES [dbo].[Recipient] ([ID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Destination] CHECK CONSTRAINT [FK_Destination_Recipient]
GO

