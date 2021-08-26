CREATE TABLE [dbo].[RolePermissionMap]
(
	[Id]				INT			NOT NULL	PRIMARY KEY	IDENTITY(1, 1),
	[RoleId]			INT			NOT NULL	CONSTRAINT [FK_RolePermissionMap_RoleId_Role_Id]	FOREIGN KEY REFERENCES [dbo].[Role]([Id]),
	[PermissionId]		INT			NOT NULL	CONSTRAINT [FK_RolePermissionMap_PermissionId_Permission_Id]	FOREIGN KEY REFERENCES [dbo].[Permission]([Id])
)
