USE [SendEmail]
GO
/****** Object:  Table [dbo].[tblPostsTime]    Script Date: 08/03/2013 21:44:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPostsTime](
	[EmailID] [nvarchar](50) NOT NULL,
	[TimerSend] [datetime] NOT NULL,
	[IDPosts] [int] NOT NULL,
	[Statust] [bit] NOT NULL,
 CONSTRAINT [PK_tblPostsTime] PRIMARY KEY CLUSTERED 
(
	[EmailID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEvent]    Script Date: 08/03/2013 21:44:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblEvent](
	[EventID] [int] NOT NULL,
	[EventTitle] [nvarchar](250) NOT NULL,
	[EventVoucher] [varchar](50) NOT NULL,
	[EventDescription] [nvarchar](max) NOT NULL,
	[EmailSubscribe] [nvarchar](100) NOT NULL,
	[TimeOut] [datetime] NOT NULL,
 CONSTRAINT [PK_tblEvent] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblCustomer]    Script Date: 08/03/2013 21:44:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCustomer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](200) NOT NULL,
	[Gender] [nvarchar](10) NOT NULL,
	[BirthDay] [datetime] NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Phone] [varchar](15) NOT NULL,
	[Address] [nvarchar](250) NOT NULL,
	[CustomerType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tblCustomer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblContent]    Script Date: 08/03/2013 21:44:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblContent](
	[IDPosts] [int] IDENTITY(1,1) NOT NULL,
	[mSubject] [nvarchar](max) NULL,
	[mBody] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblContent] PRIMARY KEY CLUSTERED 
(
	[IDPosts] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTested]    Script Date: 08/03/2013 21:44:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblTested](
	[Email] [varchar](100) NOT NULL,
	[Optional] [nvarchar](250) NOT NULL,
	[LastUpdate] [datetime] NOT NULL,
 CONSTRAINT [PK_tblTested] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[tblPostsTime_Update]    Script Date: 08/03/2013 21:44:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[tblPostsTime_Update](
	@EmailID nvarchar(50),
	@TimerSend datetime,
	@IDPosts int)
AS
BEGIN
	UPDATE tblPostsTime SET
	TimerSend = @TimerSend,
	IDPosts = @IDPosts	WHERE EmailID = @EmailID
END
GO
/****** Object:  StoredProcedure [dbo].[tblPostsTime_SelectAll]    Script Date: 08/03/2013 21:44:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[tblPostsTime_SelectAll] 
AS 
SELECT * FROM tblPostsTime
GO
/****** Object:  StoredProcedure [dbo].[tblPostsTime_Insert]    Script Date: 08/03/2013 21:44:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[tblPostsTime_Insert](
	@EmailID nvarchar(50),
	@TimerSend datetime,
	@IDPosts int)
AS
BEGIN
	INSERT INTO tblPostsTime VALUES(@EmailID, @TimerSend, @IDPosts)
END
GO
/****** Object:  StoredProcedure [dbo].[tblPostsTime_GetByID]    Script Date: 08/03/2013 21:44:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[tblPostsTime_GetByID](
	@EmailID nvarchar(50))
AS
BEGIN
	SELECT * FROM tblPostsTime WHERE EmailID = @EmailID
END
GO
/****** Object:  StoredProcedure [dbo].[tblPostsTime_Delete]    Script Date: 08/03/2013 21:44:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[tblPostsTime_Delete](
	@EmailID nvarchar(50))
AS
BEGIN
	DELETE FROM tblPostsTime WHERE EmailID = @EmailID
END
GO
/****** Object:  StoredProcedure [dbo].[tblContent_Update]    Script Date: 08/03/2013 21:44:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[tblContent_Update](
	@IDPosts int,
	@mSubject nvarchar(MAX),
	@mBody nvarchar(MAX),
	@mTimeSend datetime)
AS
BEGIN
	UPDATE tblContent SET
	mSubject = @mSubject,
	mBody = @mBody,
	mTimeSend = @mTimeSend	WHERE IDPosts = @IDPosts
END
GO
/****** Object:  StoredProcedure [dbo].[tblContent_SelectAll]    Script Date: 08/03/2013 21:44:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[tblContent_SelectAll] 
AS 
SELECT * FROM tblContent
GO
/****** Object:  StoredProcedure [dbo].[tblContent_Insert]    Script Date: 08/03/2013 21:44:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[tblContent_Insert](
	@mSubject nvarchar(MAX),
	@mBody nvarchar(MAX),
	@mTimeSend datetime)
AS
BEGIN
	INSERT INTO tblContent(mSubject, mBody, mTimeSend)
	VALUES(@mSubject, @mBody, @mTimeSend)
END
GO
/****** Object:  StoredProcedure [dbo].[tblContent_GetByID]    Script Date: 08/03/2013 21:44:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[tblContent_GetByID](
	@IDPosts int)
AS
BEGIN
	SELECT * FROM tblContent WHERE IDPosts = @IDPosts
END
GO
/****** Object:  StoredProcedure [dbo].[tblContent_Delete]    Script Date: 08/03/2013 21:44:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[tblContent_Delete](
	@IDPosts int)
AS
BEGIN
	DELETE FROM tblContent WHERE IDPosts = @IDPosts
END
GO
