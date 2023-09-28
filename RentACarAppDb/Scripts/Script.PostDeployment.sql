/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
if not exists (select 1 from dbo.CarTypes)
begin
    insert into dbo.CarTypes(Make, Model, Year, Description, Price)
    values ('Scion', 'tC', '2013', 'The Scion tC is a front-wheel-drive coupe available with a six-speed manual or automatic transmission.', 75),
    ('Toyota', 'Rav4', '2018', 'The SUV is packed with a 2231cc engine which gives out a maximum power of 147.5 bhp @ 3600 rpm and gives out a maximum torque of 340 Nm @ 2000 rpm.', 125),
    ('Mercedes-Benz', 'Gt-63','2022','In the AMG GT 63, the engine delivers 577 hp and 590 lb-ft of torque.', 200);
end

if not exists (select 1 from dbo.Cars)
begin
    declare @carTypeId1 int;
    declare @carTypeId2 int;
    declare @carTypeId3 int;

    select @carTypeId1 = Id from dbo.CarTypes where Make = 'Scion' and Model = 'tC';
    select @carTypeId2 = Id from dbo.CarTypes where Make = 'Toyota' and Model = 'Rav4';
    select @carTypeId3 = Id from dbo.CarTypes where Make = 'Mercedes-Benz' and Model = 'Gt-63';

    insert into dbo.Cars(License, CarTypeId)
    values ('KZH5429',@carTypeId1),
    ('S13020',@carTypeId1),
    ('8CPA848',@carTypeId1),
    ('5JNP607',@carTypeId2),
    ('91A818',@carTypeId2),
    ('8HSW094',@carTypeId3);
end