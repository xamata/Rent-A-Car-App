CREATE PROCEDURE [dbo].[spCarTypes_GetById]
		@id int
AS
begin
	set nocount on;

	select [Id], [Make], [Model], [Year], [Description], [Price]
	from dbo.CarTypes
	where Id = @id;
end
