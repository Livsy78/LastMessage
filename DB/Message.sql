USE [LastMessage]
GO

/****** Object:  Table [dbo].[Message]    Script Date: 20.07.2019 16:05:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Message](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Status] [varchar](16) NOT NULL,
	[UserID] [int] NOT NULL,
	[SendIn_Hours] [int] NOT NULL,
	[SendTime] [datetime] NOT NULL,
	[Title] [nvarchar](64) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[NotifyBefore_Hours] [int] NOT NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Message_NotifyBefore_Hours]  DEFAULT ((0)) FOR [NotifyBefore_Hours]
GO

ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_User]
GO

