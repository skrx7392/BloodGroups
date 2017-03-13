CREATE TABLE [dbo].[BloodGroups]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[BloodType] NVARCHAR(5) NOT NULL,
	[RhFactor] BIT NOT NULL
)
