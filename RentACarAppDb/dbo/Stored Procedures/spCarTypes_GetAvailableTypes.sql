CREATE PROCEDURE [dbo].[spCarTypes_GetAvailableTypes]
	@startDate date,
	@endDate date
AS
begin
	set nocount on;

	select t.Id,t.Make,t.Model, t.Year, t.Description, t.Price
	from dbo.Cars c
	inner join dbo.CarTypes t on t.Id = r.CarTypeId
	--Unvailable car check:
	where r.Id not in (
	select r.CarId
	from dbo.Rentals r
	--Checks outside of booked dates
	where (@startDate < b.StartDate and @endDate > b.EndDate)
	--Check if end date search is within booked room dates
		or (b.StartDate <= @endDate and @endDate < b.EndDate)
	--Check if start date is within booked room dates
		or (b.StartDate <= @startDate and @startDate < b.EndDate)
	) 
	group by t.Id,t.Make,t.Model, t.Year, t.Description, t.Price;
end
