CREATE TABLE [dbo].[Organization]
(
	[Id]					INT					NOT NULL	PRIMARY KEY		IDENTITY(1, 1),
	[ParentId]				INT					NULL		CONSTRAINT [FK_Organization_ParentId_Organization_Id]	FOREIGN KEY REFERENCES [dbo].[Organization]([Id]),
	[Name]					NVARCHAR(1024)		NOT NULL,
	[Description]			NVARCHAR(MAX)		NULL,
	[CreatedUserId]			INT					NOT NULL	CONSTRAINT [FK_Organization_CreatedUserId_User_Id]		FOREIGN KEY REFERENCES [dbo].[User]([Id]),
	[CreatedDateTime]		DATETIME			NOT NULL	DEFAULT(GETUTCDATE()),
	[LastUpdatedUserId]		INT					NOT NULL	CONSTRAINT [FK_Organization_LastUpdatedUserId_User_Id]	FOREIGN KEY REFERENCES [dbo].[User]([Id]),
	[LastUpdatedDateTime]	DATETIME			NOT NULL	DEFAULT(GETUTCDATE()),
	[IsActive]				BIT					NOT NULL	DEFAULT(1)
)
