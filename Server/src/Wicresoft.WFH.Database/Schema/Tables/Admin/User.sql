CREATE TABLE [dbo].[User]
(
	[Id]					INT					NOT NULL	PRIMARY KEY	IDENTITY(1, 1),
	[OrganizationId]		INT					NULL		CONSTRAINT [FK_User_OrganizationId_Organization_Id]	FOREIGN KEY REFERENCES [dbo].[Organization]([Id]),
	[ManagerId]				INT					NULL		CONSTRAINT [FK_User_ManagerId_User_Id]				FOREIGN KEY REFERENCES [dbo].[User]([Id]),
	[Alias]					NVARCHAR(64)		NOT NULL,
	[Name]					NVARCHAR(2048)		NOT NULL,
	[Email]					NVARCHAR(2048)		NOT NULL,
	[Password]				NVARCHAR(64)		NOT NULL,
	[IsEnable]				BIT					NOT NULL	DEFAULT(1),
	[CreatedUserId]			INT					NULL		CONSTRAINT [FK_User_CreatedUserId_User_Id]			FOREIGN KEY REFERENCES [dbo].[User]([Id]),
	[CreatedDateTime]		DATETIME			NOT NULL	DEFAULT(GETUTCDATE()),
	[LastUpdatedUserId]		INT					NULL		CONSTRAINT [FK_User_LastUpdatedUserId_User_Id]		FOREIGN KEY REFERENCES [dbo].[User]([Id]),
	[LastUpdateDateTime]	DATETIME			NOT NULL	DEFAULT(GETUTCDATE()),
	[IsActive]				BIT					NOT NULL	DEFAULT(1)
)
