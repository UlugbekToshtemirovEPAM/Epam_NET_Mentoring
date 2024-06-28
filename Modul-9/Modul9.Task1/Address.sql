﻿CREATE TABLE [dbo].[Address]
(
	  [Id] INT NOT NULL PRIMARY KEY, 
      [Street] NVARCHAR(50) NOT NULL, 
      [City] NVARCHAR(20), 
      [State] NVARCHAR(50), 
      [ZipCode] NVARCHAR(50)
)
