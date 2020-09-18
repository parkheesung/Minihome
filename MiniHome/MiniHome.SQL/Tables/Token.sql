CREATE TABLE [Token] (
	[TokenKey] [char](36) NOT NULL, 
	[RegistDate] [datetime2] NOT NULL DEFAULT getdate(), 
	[ExpiredDate] [datetime2] NOT NULL DEFAULT getdate(), 
	[IsEnabled] [bit] NOT NULL DEFAULT 0, 
	[MemberSeq] [bigint] DEFAULT -1
)
GO
ALTER TABLE [Token]
	ADD
		CONSTRAINT [FK_Member_TO_Token]
		FOREIGN KEY (
			[MemberSeq]
		)
		REFERENCES [Member] (
			[MemberSeq]
		)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
GO
ALTER TABLE [Token]
	ADD
		CONSTRAINT [PK_Token]
		PRIMARY KEY NONCLUSTERED (
			[TokenKey] ASC
		)