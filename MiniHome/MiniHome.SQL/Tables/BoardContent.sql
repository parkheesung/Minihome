CREATE TABLE [BoardContent] (
	[BoardContentSeq] [bigint] NOT NULL IDENTITY, 
	[BoardMasterSeq] [bigint] NOT NULL DEFAULT -1, 
	[Title] [nvarchar](100) NOT NULL, 
	[Content] [nvarchar](max) NOT NULL, 
	[MemberSeq] [bigint] DEFAULT -1, 
	[RegistDate] [datetime2] NOT NULL DEFAULT getdate(), 
	[LastUpdate] [datetime2] NOT NULL DEFAULT getdate(), 
	[IsEnabled] [bit] NOT NULL DEFAULT 0, 
	[LikeCount] [int] NOT NULL DEFAULT 0, 
	[UnLikeCount] [int] NOT NULL DEFAULT 0, 
	[ViewCount] [int] NOT NULL DEFAULT 0, 
	[ShareCount] [int] NOT NULL DEFAULT 0
)
GO
ALTER TABLE [BoardContent]
	ADD
		CONSTRAINT [FK_BoardMaster_TO_BoardContent]
		FOREIGN KEY (
			[BoardMasterSeq]
		)
		REFERENCES [BoardMaster] (
			[BoardMasterSeq]
		)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
GO
ALTER TABLE [BoardContent]
	ADD
		CONSTRAINT [FK_Member_TO_BoardContent]
		FOREIGN KEY (
			[MemberSeq]
		)
		REFERENCES [Member] (
			[MemberSeq]
		)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
GO
ALTER TABLE [BoardContent]
	ADD
		CONSTRAINT [PK_BoardContent]
		PRIMARY KEY NONCLUSTERED (
			[BoardContentSeq] ASC, 
			[BoardMasterSeq] ASC
		)