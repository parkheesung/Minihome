CREATE TABLE [Common] (
	[CommonSeq] [bigint] NOT NULL IDENTITY, 
	[MajorCode] [varchar](30) NOT NULL, 
	[MinorCode] [varchar](30) NOT NULL, 
	[Code] [varchar](30) NOT NULL, 
	[MajorName] [nvarchar](50), 
	[MinorName] [nvarchar](50), 
	[Name] [nvarchar](50) NOT NULL, 
	[IsEnabled] [bit] NOT NULL DEFAULT 0, 
	[Level] [int] NOT NULL DEFAULT 0
)
GO
ALTER TABLE [Common]
	ADD
		CONSTRAINT [PK_Common]
		PRIMARY KEY NONCLUSTERED (
			[CommonSeq] ASC
		)