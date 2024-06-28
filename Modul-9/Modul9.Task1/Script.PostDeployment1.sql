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
INSERT INTO Person (Id, FirstName, LastName)
VALUES (1, 'Ulugbek', 'Toshtemirov');

INSERT INTO Address (Id, Street, City, State, ZipCode)
VALUES (1, '100 Main St.', 'Samarkand', 'Uzbekistan', '140100');

INSERT INTO Employee (Id, AddressId, PersonId, CompanyName, Position, EmployeeName)
VALUES (1, 1, 1, 'EPAM', 'Software Engeenare', 'Ulugbek Toshtemirov');

INSERT INTO Company (Id, Name, AddressId)
VALUES (1, 'EPAM', 1);