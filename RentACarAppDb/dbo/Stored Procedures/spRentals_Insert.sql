CREATE PROCEDURE [dbo].[spRentals_Insert]
	@guestId int, 
	@carId int,
	@startDate date,
	@endDate date,
	@totalCost money
AS
begin
	set nocount on;

	insert dbo.Rentals(GuestId, CarId, StartDate, EndDate, TotalCost)
	values (@guestId, @carId, @startDate, @endDate, @totalCost);
end
