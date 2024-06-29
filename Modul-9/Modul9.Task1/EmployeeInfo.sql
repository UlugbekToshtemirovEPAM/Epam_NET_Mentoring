-- Create View
CREATE VIEW [dbo].[EmployeeInfo]
AS
SELECT
    E.Id AS 'EmployeeId',
    ISNULL(E.EmployeeName, CONCAT(P.FirstName, ' ', P.LastName)) AS 'EmployeeFullName',
    CONCAT(A.ZipCode, '_', A.State, ', ', A.City, '-', A.Street) AS 'EmployeeFullAddress',
    CONCAT(E.CompanyName, '(', E.Position, ')') AS 'EmployeeCompanyInfo'
FROM
    Employee E
    JOIN Person P ON E.PersonId = P.Id
    JOIN Address A ON E.AddressId = A.Id;
GO