CREATE PROCEDURE [dbo].[ESP_Token_Save]
(
	@MemberSeq			bigint
,	@Code					bigint				output
,	@Value					varchar(100)		output
,	@Msg					nvarchar(100)	output
)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

Declare @Err int, @tokenKey char(36)
SET @Err = 0

SET @Code = 0
SET @Value = ''
SET @Msg = ''

BEGIN TRY
IF Exists(select [MemberSeq] from [Token] where [MemberSeq] = @MemberSeq and [ExpiredDate] >= getdate() and [IsEnabled]=1)
	BEGIN
        select Top 1 @tokenKey = [tokenKey] from [Token] where [MemberSeq] = @MemberSeq and [ExpiredDate] >= getdate() and [IsEnabled]=1 order by [ExpiredDate] desc
        SET @Code = 1
        SET @Value = @tokenKey
	END
ELSE
	BEGIN
        SET @tokenKey = newid()

        insert into [Token] (
        [tokenKey]
        ,[ExpiredDate]
        ,[RegistDate]
        ,[IsEnabled]
        ,[MemberSeq]
        ) values (
        @tokenKey
        ,DateAdd(month,3,getdate())
        ,getdate()
        ,1
        ,@MemberSeq
        )

        SET @Err = @Err + @@Error

        IF IsNull(@Err,0) = 0
            BEGIN
                SET @Code = 1
                SET @Value = @tokenKey
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