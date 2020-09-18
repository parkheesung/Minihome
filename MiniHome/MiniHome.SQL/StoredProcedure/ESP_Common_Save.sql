CREATE PROCEDURE [dbo].[ESP_Common_Save]
(
	@MajorCode			varchar(30)
,	@MinorCode			varchar(30)
,	@CommonCode		varchar(30)
,	@Name					nvarchar(50)
,	@Level					int
,	@MajorName			nvarchar(50)    = ''
,	@MinorName			nvarchar(50)    = ''
,	@CommonSeq			bigint             = -1
,	@Code					bigint				output
,	@Value					varchar(100)		output
,	@Msg					nvarchar(100)	output
)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

Declare @Err int
SET @Err = 0

SET @Code = 0
SET @Value = ''
SET @Msg = ''

BEGIN TRY
IF Exists(select [CommonSeq] from [Common] where [CommonSeq] = @CommonSeq)
	BEGIN
        update [Common] set 
        [MajorCode] = @MajorCode
        ,[MinorCode] = @MinorCode
        ,[Code] = @Code
        ,[MajorName] = @MajorName
        ,[MinorName] = @MinorName
        ,[Name] = @Name
        ,[Level] = @Level
        where [CommonSeq] = @CommonSeq

        SET @Err = @Err + @@Error

        IF IsNull(@Err,0) = 0
            BEGIN
                SET @Code = @CommonSeq
            END
        ELSE
            BEGIN
                SET @Code = -1
                SET @Msg = '수정하지 못했습니다.'
            END
	END
ELSE
	BEGIN
        insert into [Common] (
        [MajorCode]
        ,[MinorCode]
        ,[Code]
        ,[MajorName]
        ,[MinorName]
        ,[Name]
        ,[IsEnabled]
        ,[Level]
        ) values (
        @MajorCode
        ,@MinorCode
        ,@Code
        ,@MajorName
        ,@MinorName
        ,@Name
        ,1
        ,@Level
        )

        SET @Err = @Err + @@Error

        IF IsNull(@Err,0) = 0
            BEGIN
                SET @Code = @@IDENTITY
            END
        ELSE
            BEGIN
                SET @Code = -1
                SET @Msg = '저장하지 못했습니다.'
            END
	END

END TRY
BEGIN CATCH
    SET @Code = -1
    SET @Err = @Err + 1
    SET @Msg = ERROR_MESSAGE()
END CATCH
