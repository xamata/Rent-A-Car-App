CREATE PROCEDURE [dbo].[spRentals_Search]
	@lastName nvarchar(50),
	@startDate date
AS
begin 
	set nocount on;

	select [r].[Id], [r].[GuestId], [r].[CarId], [r].[StartDate], [r].[EndDate], [r].[RentalStarted], [r].[TotalCost], 
	[g].[Id], [g].[FirstName], [g].[LastName], 
	[c].[Id], [c].[License], [c].[CarTypeId], 
	[ct].[Id], [ct].[Make], [ct].[Model], [ct].[Year], [ct].[Description], [ct].[Price]
	from dbo.Rentals r
	inner join dbo.Guests g on r.GuestId = g.Id
	inner join dbo.Cars c on r.CarId = c.Id
	inner join dbo.CarTypes ct on c.CarTypeId = ct.Id
	where r.StartDate = @startDate
	and g.LastName = @lastName;
end