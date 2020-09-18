CREATE TABLE [PartBoard] (
	[PartBoardSeq] [bigint] NOT NULL IDENTITY, 
	[BoardContentSeq] [bigint] DEFAULT -1, 
	[BoardMasterSeq] [bigint] DEFAULT -1, 
	[MemberSeq] [bigint] DEFAULT -1, 
	[RegistDate] [datetime2] NOT NULL DEFAULT getdate(), 
	[AgendaValue] [varchar](30) NOT NULL
)
GO
ALTER TABLE [PartBoard]
	ADD
		CONSTRAINT [FK_BoardContent_TO_PartBoard]
		FOREIGN KEY (
			[BoardContentSeq], 
			[BoardMasterSeq]
		)
		REFERENCES [BoardContent] (
			[BoardContentSeq], 
			[BoardMasterSeq]
		)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
GO
ALTER TABLE [PartBoard]
	ADD
		CONSTRAINT [FK_Member_TO_PartBoard]
		FOREIGN KEY (
			[MemberSeq]
		)
		REFERENCES [Member] (
			[MemberSeq]
		)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
GO
ALTER TABLE [PartBoard]
	ADD
		CONSTRAINT [PK_PartBoard]
		PRIMARY KEY NONCLUSTERED (
			[PartBoardSeq] ASC
		)