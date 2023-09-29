CREATE PROCEDURE [dbo].[spCars_GetAvailableCars]
	@startDate date,
	@endDate date,
	@carTypeId int
AS
begin
	set nocount on;
	select [c].[Id], [c].[License], [c].[CarTypeId]
	from dbo.Cars c
	inner join dbo.CarTypes t on t.Id = c.CarTypeId
	where c.CarTypeId = @carTypeId
	--Avaiable cars check:
	and c.Id not in (
	select r.CarId
	from dbo.Rentals r
	--Checks outside of booked dates
	where (@startDate < r.StartDate and @endDate > r.EndDate)
	--Check if end date search is within booked room dates
		or (r.StartDate <= @endDate and @endDate < r.EndDate)
	--Check if start date is within booked room dates
		or (r.StartDate <= @startDate and @startDate < r.EndDate)
	);
end
