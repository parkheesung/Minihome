CREATE PROCEDURE [dbo].[ESP_BoardContent_Save]
(
	@BoardMasterSeq					    bigint
,	@Title					                nvarchar(100)
,	@Content					            nvarchar(max)
,	@LikeCount					            int
,	@UnLikeCount					        int
,	@ViewCount					        int
,	@ShareCount					        int
,	@MemberSeq					        bigint
,	@BoardContentSeq					bigint     = -1
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
IF Exists(select [BoardContentSeq] from [BoardContent] where [BoardContentSeq] = @BoardContentSeq)
	BEGIN
        update [BoardContent] set 
        [BoardMasterSeq] = @BoardMasterSeq
        ,[Title] = @Title
        ,[Content] = @Content
        ,[MemberSeq] = @MemberSeq
        ,[LastUpdate] = getdate()
        ,[LikeCount] = @LikeCount
        ,[UnLikeCount] = @UnLikeCount
        ,[ViewCount] = @ViewCount
        ,[ShareCount] = @ShareCount
        where [BoardContentSeq] = @BoardContentSeq

        SET @Err = @Err + @@Error

        IF IsNull(@Err,0) = 0
            BEGIN
                SET @Code = @BoardContentSeq
            END
        ELSE
            BEGIN
                SET @Code = -1
                SET @Msg = '수정하지 못했습니다.'
            END
	END
ELSE
	BEGIN
        insert into [BoardContent] (
        [BoardMasterSeq]
        ,[Title]
        ,[Content]
        ,[MemberSeq]
        ,[RegistDate]
        ,[LastUpdate]
        ,[IsEnabled]
        ,[LikeCount]
        ,[UnLikeCount]
        ,[ViewCount]
        ,[ShareCount]
        ) values (
        @BoardMasterSeq
        ,@Title
        ,@Content
        ,@MemberSeq
        ,getdate()
        ,getdate()
        ,1
        ,@LikeCount
        ,@UnLikeCount
        ,@ViewCount
        ,@ShareCount
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
