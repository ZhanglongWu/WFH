CREATE TABLE [dbo].[Role]
(
	[Id]					INT					NOT NULL	PRIMARY KEY	IDENTITY(1, 1),
	[Name]					NVARCHAR(512)		NOT NULL,
	[DisplayName]			NVARCHAR(512)		NOT NULL,
	[Description]			NVARCHAR(MAX)		NULL,
	[CreatedUserId]			INT					NOT NULL	CONSTRAINT	[FK_Role_CreatedUserId_User_Id]		FOREIGN KEY REFERENCES [dbo].[User]([Id]),
	[CreatedDateTime]		DATETIME			NOT NULL DEFAULT(GETUTCDATE()),
	[LastUpdatedUserId]		INT					NOT NULL	CONSTRAINT	[FK_Role_LastUpdatedUserId_User_Id]	FOREIGN KEY REFERENCES [dbo].[User]([Id]),
	[LastUpdatedDateTime]	DATETIME			NOT NULL DEFAULT(GETUTCDATE()),
	[IsActive]				BIT					NOT NULL DEFAULT(1)
)
