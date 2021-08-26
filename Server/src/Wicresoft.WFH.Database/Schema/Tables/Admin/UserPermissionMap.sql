CREATE TABLE [dbo].[UserPermissionMap]
(
	[Id]				INT			NOT NULL	PRIMARY KEY		IDENTITY(1, 1),
	[UserId]			INT			NOT NULL	CONSTRAINT	[FK_UserPermissionMap_UserId_User_Id]		FOREIGN KEY REFERENCES [dbo].[User]([Id]),
	[PermissionId]		INT			NOT NULL	CONSTRAINT	[FK_UserPermissionMap_PermissionId_Permission_Id]	FOREIGN KEY REFERENCES [dbo].[Permission]([Id])
)
