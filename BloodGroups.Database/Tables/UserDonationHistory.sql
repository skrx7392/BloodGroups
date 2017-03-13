CREATE TABLE [dbo].[UserDonationHistory]
(
	[Id] BIGINT NOT NULL PRIMARY KEY,
	[DonorId] BIGINT NOT NULL,
	[DonationDate] DATE NOT NULL,
	CONSTRAINT [FK_UserDonationHistory_DonorDetails] FOREIGN KEY ([DonorId]) REFERENCES [DonorDetails]([Id])
)
