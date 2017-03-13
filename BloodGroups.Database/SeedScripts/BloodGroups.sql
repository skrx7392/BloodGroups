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

MERGE INTO BloodGroups AS Target
USING (VALUES
	(1, 'A', 1),
	(2, 'A', 0),
	(3, 'B', 1),
	(4, 'B', 0),
	(5, 'AB', 1),
	(6, 'AB', 0),
	(7, 'O', 1),
	(8, 'O', 0)
	)
	AS Source (Id, BloodType, RhFactor)
	ON Target.Id = Source.Id
	WHEN MATCHED THEN 
	UPDATE SET BloodType = Source.BloodType,
		RhFactor = Source.RhFactor
	WHEN NOT MATCHED BY Target THEN
	INSERT (Id, BloodType, RhFactor)
	VALUES (Id, BloodType, RhFactor);