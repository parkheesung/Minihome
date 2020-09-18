CREATE PROCEDURE [dbo].[ESP_PartComment_Save]
(
	@AgendaValue			varchar(30)
,	@MemberSeq			bigint
,	@CommentSeq		bigint
,	@PartCommentSeq	bigint     = -1
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
IF Exists(select [PartCommentSeq] from [PartComment] where [PartCommentSeq] = @PartCommentSeq)
	BEGIN
        update [PartComment] set 
        [AgendaValue] = @AgendaValue
        ,[MemberSeq] = @MemberSeq
        ,[CommentSeq] = @CommentSeq
        where [PartCommentSeq] = @PartCommentSeq

        SET @Err = @Err + @@Error

        IF IsNull(@Err,0) = 0
            BEGIN
                SET @Code = @PartCommentSeq
            END
        ELSE
            BEGIN
                SET @Code = -1
                SET @Msg = '수정하지 못했습니다.'
            END
	END
ELSE
	BEGIN
        insert into [PartComment] (
        [RegistDate]
        ,[AgendaValue]
        ,[MemberSeq]
        ,[CommentSeq]
        ) values (
        getdate()
        ,@AgendaValue
        ,@MemberSeq
        ,@CommentSeq
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
