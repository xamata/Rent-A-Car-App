﻿CREATE PROCEDURE [dbo].[spCarTypes_GetAvailableTypes]
	@startDate date,
	@endDate date
AS
begin
	set nocount on;

	select t.Id,t.Make,t.Model, t.Year, t.Description, t.Price
	from dbo.Cars c
	inner join dbo.CarTypes t on t.Id = c.CarTypeId
	--Unvailable car check:
	where c.Id not in (
	select r.CarId
	from dbo.Rentals r
	--Checks outside of booked dates
	where (@startDate < r.StartDate and @endDate > r.EndDate)
	--Check if end date search is within booked room dates
		or (r.StartDate <= @endDate and @endDate < r.EndDate)
	--Check if start date is within booked room dates
		or (r.StartDate <= @startDate and @startDate < r.EndDate)
	) 
	group by t.Id,t.Make,t.Model, t.Year, t.Description, t.Price;
end
