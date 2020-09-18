CREATE TABLE [Member] (
	[MemberSeq] [bigint] NOT NULL IDENTITY, 
	[Email] [varchar](255) NOT NULL, 
	[Name] [nvarchar](30) NOT NULL, 
	[NickName] [nvarchar](50) NOT NULL, 
	[Addr1] [nvarchar](100), 
	[Addr2] [nvarchar](100), 
	[RegistDate] [datetime2] NOT NULL DEFAULT getdate(), 
	[LastUpdate] [datetime2] NOT NULL DEFAULT getdate(), 
	[LastLogin] [datetime2] NOT NULL DEFAULT getdate(), 
	[Password] [varchar](512) NOT NULL, 
	[IsOut] [bit] NOT NULL DEFAULT 0, 
	[IsMailCheck] [bit] NOT NULL DEFAULT 0, 
	[IsEnabled] [bit] NOT NULL DEFAULT 0, 
	[UsingPoint] [int] NOT NULL DEFAULT 0, 
	[UsedPoint] [int] NOT NULL DEFAULT 0, 
	[Area] [nvarchar](100) NOT NULL, 
	[UserType] [varchar](30) NOT NULL, 
	[UserGrade] [varchar](30) NOT NULL
)
GO
ALTER TABLE [Member]
	ADD
		CONSTRAINT [PK_Member]
		PRIMARY KEY NONCLUSTERED (
			[MemberSeq] ASC
		)