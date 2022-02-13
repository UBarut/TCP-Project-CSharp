
go
create proc UserAdd
@name nvarchar(50),
@surname nvarchar(50),
@password nvarchar(50),
@mail nvarchar(50),
@username nvarchar(50),
@age tinyint,
@cardID int
as
begin
	insert into User_Information(Name,Surname,Password,Mail,UserName,Age,CardID)
		values(@name,@surname,@password,@mail,@username,@age,@cardID)
end