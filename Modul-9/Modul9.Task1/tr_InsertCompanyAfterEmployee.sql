CREATE TRIGGER tr_InsertCompanyAfterEmployee
ON Employee
AFTER INSERT
AS
BEGIN
    DECLARE @NewAddressId INT;
    DECLARE @NewEmployeeId INT;
    DECLARE @CompanyName NVARCHAR(20);

    SELECT @NewEmployeeId = INSERTED.Id, @CompanyName = INSERTED.CompanyName FROM INSERTED;

    -- Copy the address from the inserted employee record
    INSERT INTO Address (Street, City, State, ZipCode)
    SELECT Street, City, State, ZipCode FROM Address WHERE Id = (SELECT AddressId FROM Employee WHERE Id = @NewEmployeeId);

    SET @NewAddressId = SCOPE_IDENTITY(); -- Get the newly inserted Address.Id

    -- Insert the new company with the copied address
    INSERT INTO Company (Name, AddressId)
    VALUES (@CompanyName, @NewAddressId);
END;