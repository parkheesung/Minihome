CREATE TABLE [BoardMaster] (
	[BoardMasterSeq] [bigint] NOT NULL IDENTITY, 
	[Title] [nvarchar](100) NOT NULL, 
	[Code] [varchar](30) NOT NULL, 
	[RegistDate] [datetime2] NOT NULL DEFAULT getdate(), 
	[LastUpdate] [datetime2] NOT NULL DEFAULT getdate(), 
	[IsEnabled] [bit] NOT NULL DEFAULT 0, 
	[Category_A] [varchar](30), 
	[Category_B] [varchar](30), 
	[Category_C] [varchar](30), 
	[BoardType] [varchar](30) NOT NULL
)
GO
ALTER TABLE [BoardMaster]
	ADD
		CONSTRAINT [PK_BoardMaster]
		PRIMARY KEY NONCLUSTERED (
			[BoardMasterSeq] ASC
		)