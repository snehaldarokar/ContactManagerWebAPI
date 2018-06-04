USE [ContactDB]
GO

/****** Object:  Table [dbo].[Contacts]    Script Date: 06/02/2018 13:27:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contacts]') AND type in (N'U'))
DROP TABLE [dbo].[Contacts]
GO

USE [ContactDB]
GO

/****** Object:  Table [dbo].[Contacts]    Script Date: 06/02/2018 13:27:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Contacts](
	[Id] [int] Identity(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


