CREATE TABLE [dbo].[DonorDetails]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Gender] NVARCHAR(10) NOT NULL,
	[DOB] DATE NOT NULL,
	[BloodGroupId] INT NOT NULL,
	CONSTRAINT [FK_DonorDetails_BloodGroups] FOREIGN KEY ([BloodGroupId]) REFERENCES [BloodGroups]([Id])
)
