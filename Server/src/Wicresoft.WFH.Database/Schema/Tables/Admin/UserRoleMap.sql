CREATE TABLE [dbo].[UserRoleMap]
(
	[Id]			INT			NOT NULL	PRIMARY KEY	IDENTITY(1, 1),
	[UserId]		INT			NOT NULL	CONSTRAINT [FK_UserRoleMap_UserId_User_Id]	FOREIGN KEY REFERENCES [dbo].[User]([Id]),
	[RoleId]		INT			NOT NULL	CONSTRAINT [FK_UserRoleMap_RoleId_Role_Id]	FOREIGN KEY REFERENCES [dbo].[Role]([Id])
)
