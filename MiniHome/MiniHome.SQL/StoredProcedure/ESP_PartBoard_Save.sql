CREATE PROCEDURE [dbo].[ESP_PartBoard_Save]
(
	@AgendaValue			varchar(30)
,	@BoardContentSeq	bigint
,	@BoardMasterSeq		bigint
,	@MemberSeq			bigint
,	@PartBoardSeq		bigint            = -1
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
IF Exists(select [PartBoardSeq] from [PartBoard] where [PartBoardSeq] = @PartBoardSeq)
	BEGIN
        update [PartBoard] set 
        [BoardContentSeq] = @BoardContentSeq
        ,[BoardMasterSeq] = @BoardMasterSeq
        ,[MemberSeq] = @MemberSeq
        ,[AgendaValue] = @AgendaValue
        where [PartBoardSeq] = @PartBoardSeq

        SET @Err = @Err + @@Error

        IF IsNull(@Err,0) = 0
            BEGIN
                SET @Code = @PartBoardSeq
            END
        ELSE
            BEGIN
                SET @Code = -1
                SET @Msg = '수정하지 못했습니다.'
            END
	END
ELSE
	BEGIN
        insert into [PartBoard] (
        [BoardContentSeq]
        ,[BoardMasterSeq]
        ,[MemberSeq]
        ,[RegistDate]
        ,[AgendaValue]
        ) values (
        @BoardContentSeq
        ,@BoardMasterSeq
        ,@MemberSeq
        ,getdate()
        ,@AgendaValue
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
