CREATE PROCEDURE [dbo].[ESP_Member_Save]
(
	@Email					varchar(255)
,	@Name					nvarchar(30)
,	@NickName			nvarchar(50)
,	@Password				varchar(512)
,	@IsOut					bit
,	@IsMailCheck			bit
,	@UsingPoint			int
,	@UsedPoint				int
,	@Area					nvarchar(100)
,	@UserType				varchar(30)
,	@UserGrade			varchar(30)
,	@Addr1					nvarchar(100)  = ''
,	@Addr2					nvarchar(100)  = ''
,	@MemberSeq			bigint            = -1
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
IF Exists(select [MemberSeq] from [Member] where [MemberSeq] = @MemberSeq)
	BEGIN
        update [Member] set 
        [Email] = @Email
        ,[Name] = @Name
        ,[NickName] = @NickName
        ,[Addr1] = @Addr1
        ,[Addr2] = @Addr2
        ,[LastUpdate] = getdate()
        ,[LastLogin] = getdate()
        ,[Password] = @Password
        ,[IsOut] = @IsOut
        ,[IsMailCheck] = @IsMailCheck
        ,[UsingPoint] = @UsingPoint
        ,[UsedPoint] = @UsedPoint
        ,[Area] = @Area
        ,[UserType] = @UserType
        ,[UserGrade] = @UserGrade
        where [MemberSeq] = @MemberSeq

        SET @Err = @Err + @@Error

        IF IsNull(@Err,0) = 0
            BEGIN
                SET @Code = @MemberSeq
            END
        ELSE
            BEGIN
                SET @Code = -1
                SET @Msg = '수정하지 못했습니다.'
            END
	END
ELSE
	BEGIN
        insert into [Member] (
        [Email]
        ,[Name]
        ,[NickName]
        ,[Addr1]
        ,[Addr2]
        ,[RegistDate]
        ,[LastUpdate]
        ,[LastLogin]
        ,[Password]
        ,[IsOut]
        ,[IsMailCheck]
        ,[IsEnabled]
        ,[UsingPoint]
        ,[UsedPoint]
        ,[Area]
        ,[UserType]
        ,[UserGrade]
        ) values (
        @Email
        ,@Name
        ,@NickName
        ,@Addr1
        ,@Addr2
        ,getdate()
        ,getdate()
        ,getdate()
        ,@Password
        ,@IsOut
        ,@IsMailCheck
        ,1
        ,@UsingPoint
        ,@UsedPoint
        ,@Area
        ,@UserType
        ,@UserGrade
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
