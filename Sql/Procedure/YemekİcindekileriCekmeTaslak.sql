
alter proc AccessNutrients
@id int
as
begin
declare @ingredient nvarchar(200)
	select @ingredient=Ingredients from Foods where ID=2
	/*print @ingredient*/
	return select Nutrient_Name from Nutrients Where ID in (select * from string_split(@ingredient,','))
end