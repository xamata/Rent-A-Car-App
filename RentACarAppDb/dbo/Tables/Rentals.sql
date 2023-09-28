CREATE TABLE [dbo].[Rentals]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [GuestId] INT NOT NULL, 
    [CarId] INT NOT NULL, 
    [StartDate] DATE NOT NULL, 
    [EndDate] DATE NOT NULL, 
    [RentalStarted] BIT NOT NULL DEFAULT 0, 
    [TotalCost] MONEY NOT NULL
)
