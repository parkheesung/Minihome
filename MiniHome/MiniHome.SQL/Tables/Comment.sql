CREATE TABLE [Comment] (
	[CommentSeq] [bigint] NOT NULL IDENTITY, 
	[Content] [nvarchar](max) NOT NULL, 
	[MemberSeq] [bigint] NOT NULL DEFAULT -1, 
	[URL] [varchar](255) NOT NULL, 
	[LikeCount] [int] NOT NULL DEFAULT 0, 
	[UnLikeCount] [int] NOT NULL DEFAULT 0, 
	[RegistDate] [datetime2] NOT NULL DEFAULT getdate(), 
	[LastUpdate] [datetime2] NOT NULL DEFAULT getdate(), 
	[IsEnabled] [bit] NOT NULL DEFAULT 0
)
GO
ALTER TABLE [Comment]
	ADD
		CONSTRAINT [FK_Member_TO_Comment]
		FOREIGN KEY (
			[MemberSeq]
		)
		REFERENCES [Member] (
			[MemberSeq]
		)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
GO
ALTER TABLE [Comment]
	ADD
		CONSTRAINT [PK_Comment]
		PRIMARY KEY NONCLUSTERED (
			[CommentSeq] ASC
		)