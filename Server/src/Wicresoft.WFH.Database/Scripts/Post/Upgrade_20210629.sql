CREATE TABLE [dbo].[Device]
(
	[Id] INT NOT NULL PRIMARY KEY  IDENTITY(1, 1),
    [Name] NVARCHAR(512) NOT NULL, 
    [Type] NVARCHAR(64) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [CeatedDateTime] DATETIME NOT NULL  DEFAULT (GETUTCDATE()),
    [CreateUserId] INT NOT NULL  CONSTRAINT [FK_Device_CreatedUserId_User_Id] FOREIGN KEY REFERENCES [dbo].[User]([Id]),
    [LastUpdatedDateTime] DATETIME NOT NULL DEFAULT (GETUTCDATE()), 
    [LastUpdatedUerId] INT NOT NULL CONSTRAINT [FK_Device_LastUpdatedUserId_User_Id] FOREIGN KEY REFERENCES [dbo].[User]([Id]),
    [IsActive] BIT NOT NULL DEFAULT (1)
)

SET IDENTITY_INSERT [dbo].[Menu] ON

INSERT INTO [dbo].[Menu]([Id],[ParentId],[ModuleId],[Order],[Key],[Name],[Icon],[Path],[IsEnable],[IsActive])

VALUES (3, NULL, 1, 3, N'admin.device.management',N'Device Manangement', NULL, N'admin/device-management',1,1)

SET IDENTITY_INSERT [dbo].[menu] OFF

SET IDENTITY_INSERT [dbo].[Permission] ON

INSERT INTO [dbo].[Permission]([Id],[MenuId],[ActionId],[Name],[DisplayName],[Description],[IsActive]) VALUES(9,3,1,N'View Device',N'View Device',NULL,1)
INSERT INTO [dbo].[Permission]([Id],[MenuId],[ActionId],[Name],[DisplayName],[Description],[IsActive]) VALUES(10,3,2,N'Create Device',N'Create Device',NULL,1)
INSERT INTO [dbo].[Permission]([Id],[MenuId],[ActionId],[Name],[DisplayName],[Description],[IsActive]) VALUES(11,3,2,N'Update Device',N'Update Device',NULL,1)
INSERT INTO [dbo].[Permission]([Id],[MenuId],[ActionId],[Name],[DisplayName],[Description],[IsActive]) VALUES(12,3,4,N'Delete Device',N'Delete Device',NULL,1)

SET IDENTITY_INSERT [dbo].[Permission] OFF

SET IDENTITY_INSERT [dbo].[RoleMenuMap] ON

INSERT INTO [dbo].[RoleMenuMap]([Id],[MenuId],[RoleId]) VALUES (3,3,1)

SET IDENTITY_INSERT [dbo].[RoleMenuMap] OFF

SET IDENTITY_INSERT [dbo].[RolePermissionMap] ON

INSERT INTO [dbo].[RolePermissionMap]([Id],[PermissionId],[RoleId]) VALUES (9,9,1)
INSERT INTO [dbo].[RolePermissionMap]([Id],[PermissionId],[RoleId]) VALUES (10,10,1)
INSERT INTO [dbo].[RolePermissionMap]([Id],[PermissionId],[RoleId]) VALUES (11,11,1)
INSERT INTO [dbo].[RolePermissionMap]([Id],[PermissionId],[RoleId]) VALUES (12,12,1)

SET IDENTITY_INSERT [dbo].[RolePermissionMap] OFF






