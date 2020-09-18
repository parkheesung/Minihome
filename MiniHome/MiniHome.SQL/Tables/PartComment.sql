CREATE TABLE [PartComment] (
	[PartCommentSeq] [bigint] NOT NULL IDENTITY,
	[RegistDate] [datetime2] NOT NULL DEFAULT getdate(), 
	[AgendaValue] [varchar](30) NOT NULL, 
	[MemberSeq] [bigint] DEFAULT -1, 
	[CommentSeq] [bigint] DEFAULT -1
)
GO
ALTER TABLE [PartComment]
	ADD
		CONSTRAINT [FK_Member_TO_PartComment]
		FOREIGN KEY (
			[MemberSeq]
		)
		REFERENCES [Member] (
			[MemberSeq]
		)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
GO
ALTER TABLE [PartComment]
	ADD
		CONSTRAINT [FK_Comment_TO_PartComment]
		FOREIGN KEY (
			[CommentSeq]
		)
		REFERENCES [Comment] (
			[CommentSeq]
		)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
GO
ALTER TABLE [PartComment]
	ADD
		CONSTRAINT [PK_PartBoard2]
		PRIMARY KEY NONCLUSTERED (
			[PartCommentSeq] ASC
		)