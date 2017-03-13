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
MERGE INTO Roles AS Target
USING (VALUES
	(1, 'Admin'),
	(2, 'Donor')
	)
	AS Source (Id, Role)
	ON Target.Id = Source.Id
	WHEN MATCHED THEN 
	UPDATE SET Role = Source.Role
	WHEN NOT MATCHED BY Target THEN
	INSERT (Id, Role)
	VALUES (Id, Role);