CREATE TABLE [dbo].[RoleMenuMap]
(
	[Id]			INT			NOT NULL	PRIMARY KEY	IDENTITY(1, 1),
	[RoleId]		INT			NOT NULL	CONSTRAINT [FK_RoleMenuMap_RoleId_Role_Id]	FOREIGN KEY REFERENCES [dbo].[Role]([Id]),
	[MenuId]		INT			NOT NULL	CONSTRAINT [FK_RoleMenuMap_MenuId_Menu_Id]	FOREIGN KEY REFERENCES [dbo].[Menu]([Id])
)
