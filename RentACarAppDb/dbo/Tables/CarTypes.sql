﻿CREATE TABLE [dbo].[CarTypes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Make] NVARCHAR(50) NOT NULL, 
    [Model] NVARCHAR(50) NOT NULL, 
    [Year] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(200) NOT NULL, 
    [Price] MONEY NOT NULL
)
