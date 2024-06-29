CREATE PROCEDURE sp_AddEmployee 
    @EmployeeName NVARCHAR(100) = NULL,
    @FirstName NVARCHAR(50) = NULL,
    @LastName NVARCHAR(50) = NULL,
    @CompanyName NVARCHAR(20),
    @Position NVARCHAR(30) = NULL, 
    @Street NVARCHAR(50),
    @City NVARCHAR(20) = NULL,
    @State NVARCHAR(50) = NULL,
    @ZipCode NVARCHAR(50) = NULL
AS
BEGIN
    -- Check if at least one of EmployeeName, FirstName, or LastName is provided and not empty or not only space
     IF (ISNULL(@EmployeeName,'') = '' OR @EmployeeName = ' ') AND (ISNULL(@FirstName,'') = '' OR @FirstName = ' ') AND (ISNULL(@LastName,'') = '' OR @LastName = ' ')
        RAISERROR('At least one of EmployeeName, FirstName or LastName should be provided and not be empty or spaces.', -- Message text.
               16, -- Severity.
               1 -- State.
        );
    ELSE 
        BEGIN
            -- Truncate CompanyName if its length is more than 20
            SET @CompanyName = SUBSTRING(@CompanyName, 1, 20);

            -- Assume new Address and Person are being entered for each Employee. An existing Address or Person ID is not being passed.
            DECLARE @NewPersonId INT, @NewAddressId INT;

            -- Insert into Person 
            INSERT INTO Person (FirstName, LastName) 
            VALUES (@FirstName, @LastName);

            SET @NewPersonId = SCOPE_IDENTITY(); -- Get the newly inserted Person.ID

            -- Insert into Address
            INSERT INTO Address (Street, City, State, ZipCode) 
            VALUES (@Street, @City, @State, @ZipCode);
    
            SET @NewAddressId = SCOPE_IDENTITY(); -- Get the newly inserted Address.ID

            -- Insert into Employee
            INSERT INTO Employee (AddressId, PersonId, CompanyName, Position, EmployeeName) 
            VALUES (@NewAddressId, @NewPersonId, @CompanyName, @Position, @EmployeeName);
        END
END
GO