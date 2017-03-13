CREATE TABLE [dbo].[LoginDetails]
(
	[Id] BIGINT NOT NULL PRIMARY KEY,
	[DonorId] BIGINT NOT NULL UNIQUE,
	[Username] NVARCHAR(50) NOT NULL UNIQUE,
	[Password] NVARCHAR(MAX) NOT NULL,
	[Salt] NVARCHAR(50) NOT NULL,
	[RoleId] INT NOT NULL,
	CONSTRAINT [FK_LoginDetails_DonorDetails] FOREIGN KEY ([DonorId]) REFERENCES [DonorDetails]([Id]),
	CONSTRAINT [FK_LoginDetails_Roles] FOREIGN KEY ([RoleId]) REFERENCES [Roles]([Id])
)
