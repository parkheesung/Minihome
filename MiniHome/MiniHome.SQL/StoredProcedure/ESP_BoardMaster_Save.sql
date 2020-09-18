CREATE PROCEDURE [dbo].[ESP_BoardMaster_Save]
(
	@Title					nvarchar(100)
,	@BdsCode		        varchar(30)
,	@BoardType			varchar(30)
,	@Category_A			varchar(30) = ''
,	@Category_B			varchar(30) = ''
,	@Category_C			varchar(30) = ''
,	@BoardMasterSeq		bigint     = -1
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
IF Exists(select [BoardMasterSeq] from [BoardMaster] where [BoardMasterSeq] = @BoardMasterSeq)
	BEGIN
        update [BoardMaster] set 
        [Title] = @Title
        ,[Code] = @BdsCode
        ,[LastUpdate] = getdate()
        ,[Category_A] = @Category_A
        ,[Category_B] = @Category_B
        ,[Category_C] = @Category_C
        ,[BoardType] = @BoardType
        where [BoardMasterSeq] = @BoardMasterSeq

        SET @Err = @Err + @@Error

        IF IsNull(@Err,0) = 0
            BEGIN
                SET @Code = @BoardMasterSeq
            END
        ELSE
            BEGIN
                SET @Code = -1
                SET @Msg = '수정하지 못했습니다.'
            END
	END
ELSE
	BEGIN
        insert into [BoardMaster] (
        [Title]
        ,[Code]
        ,[RegistDate]
        ,[LastUpdate]
        ,[IsEnabled]
        ,[Category_A]
        ,[Category_B]
        ,[Category_C]
        ,[BoardType]
        ) values (
        @Title
        ,@BdsCode
        ,getdate()
        ,getdate()
        ,1
        ,@Category_A
        ,@Category_B
        ,@Category_C
        ,@BoardType
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
