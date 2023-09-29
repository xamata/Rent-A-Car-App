CREATE PROCEDURE [dbo].[spRentals_CheckIn]
	@Id int
As
begin
	set nocount on;

	update dbo.Rentals
	set RentalStarted = 1
	where Id = @Id
end