CREATE PROCEDURE [dbo].[ESP_Comment_Save]
(
	
	@MemberSeq			bigint
,   @Content				nvarchar(max)
,	@URL					    varchar(255)
,	@LikeCount				int
,	@UnLikeCount			int
,	@CommentSeq		bigint             = -1
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
IF Exists(select [CommentSeq] from [Comment] where [CommentSeq] = @CommentSeq)
	BEGIN
        update [Comment] set 
        [Content] = @Content
        ,[MemberSeq] = @MemberSeq
        ,[URL] = @URL
        ,[LikeCount] = @LikeCount
        ,[UnLikeCount] = @UnLikeCount
        ,[LastUpdate] = getdate()
        where [CommentSeq] = @CommentSeq

        SET @Err = @Err + @@Error

        IF IsNull(@Err,0) = 0
            BEGIN
                SET @Code = @CommentSeq
            END
        ELSE
            BEGIN
                SET @Code = -1
                SET @Msg = '수정하지 못했습니다.'
            END
	END
ELSE
	BEGIN
        insert into [Comment] (
        [Content]
        ,[MemberSeq]
        ,[URL]
        ,[LikeCount]
        ,[UnLikeCount]
        ,[RegistDate]
        ,[LastUpdate]
        ,[IsEnabled]
        ) values (
        @Content
        ,@MemberSeq
        ,@URL
        ,@LikeCount
        ,@UnLikeCount
        ,getdate()
        ,getdate()
        ,1
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
