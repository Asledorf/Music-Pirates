CREATE PROCEDURE [dbo].[CreateUser]        
    @ImageStr	NVARCHAR (50)
,   @Username	NVARCHAR (50)
,   @Password	NVARCHAR (50)
,   @Email		NVARCHAR (50)
,   @BirthDay	DATETIME     
AS
	insert into tbl_User values
	(
	NEWID()
,	1
,   @ImageStr    
,   @Username 
,   @Password 
,   @Email    
,   @BirthDay 
	)
RETURN 0