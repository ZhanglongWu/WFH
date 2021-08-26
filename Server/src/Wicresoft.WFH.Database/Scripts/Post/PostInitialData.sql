SET IDENTITY_INSERT [dbo].[User] ON

INSERT INTO [dbo].[User]([Id], [OrganizationId], [ManagerId], [Alias], [Name], [Email], [Password], [IsEnable], [CreatedUserId], [CreatedDateTime], [LastUpdatedUserId], [LastUpdateDateTime], [IsActive]) VALUES (1, NULL, NULL, N'admin', N'Administrator', N'admin@wicresoft.com', N'0198F439986FDD5A2BDAF8B1E8A0FD0E', 1, NULL, GETUTCDATE(), NULL, GETUTCDATE(), 1)

SET IDENTITY_INSERT [dbo].[User] OFF

SET IDENTITY_INSERT [dbo].[Module] ON

INSERT INTO [dbo].[Module]([Id], [Order], [Key], [Name], [DisplayName], [Description], [IsActive]) VALUES (1, 1, N'system.maintenance', N'System Maintenance', N'System Maintenance', NULL, 1)

SET IDENTITY_INSERT [dbo].[Module] OFF

SET IDENTITY_INSERT [dbo].[Role] ON

INSERT INTO [dbo].[Role]([Id], [Name], [DisplayName], [Description], [CreatedUserId], [CreatedDateTime], [LastUpdatedUserId], [LastUpdatedDateTime], [IsActive]) VALUES (1, N'Administrator', N'Administrator', NULL, 1, GETUTCDATE(), 1, GETUTCDATE(), 1)

SET IDENTITY_INSERT [dbo].[Role] OFF

SET IDENTITY_INSERT [dbo].[Menu] ON

INSERT INTO [dbo].[Menu]([Id], [ParentId], [ModuleId], [Order], [Key], [Name], [Icon], [Path], [IsEnable], [IsActive]) VALUES (1, NULL, 1, 1, N'admin.user.management', N'User Management', NULL, N'admin/user-management', 1, 1)
INSERT INTO [dbo].[Menu]([Id], [ParentId], [ModuleId], [Order], [Key], [Name], [Icon], [Path], [IsEnable], [IsActive]) VALUES (2, NULL, 1, 2, N'admin.role.management', N'Role Management', NULL, N'admin/role-management', 1, 1)
INSERT INTO [dbo].[Menu]([Id], [ParentId], [ModuleId], [Order], [Key], [Name], [Icon], [Path], [IsEnable], [IsActive]) VALUES (3, NULL, 1, 3, N'admin.device.management',N'Device Manangement', NULL, N'admin/device-management',1,1)

SET IDENTITY_INSERT [dbo].[Menu] OFF

SET IDENTITY_INSERT [dbo].[Permission] ON

INSERT INTO [dbo].[Permission]([Id], [MenuId], [ActionId], [Name], [DisplayName], [Description], [IsActive]) VALUES (1, 1, 1, N'View User', N'View User', NULL, 1)
INSERT INTO [dbo].[Permission]([Id], [MenuId], [ActionId], [Name], [DisplayName], [Description], [IsActive]) VALUES (2, 1, 2, N'Create User', N'Create User', NULL, 1)
INSERT INTO [dbo].[Permission]([Id], [MenuId], [ActionId], [Name], [DisplayName], [Description], [IsActive]) VALUES (3, 1, 3, N'Update User', N'Update User', NULL, 1)
INSERT INTO [dbo].[Permission]([Id], [MenuId], [ActionId], [Name], [DisplayName], [Description], [IsActive]) VALUES (4, 1, 4, N'Delete User', N'Delete User', NULL, 1)

INSERT INTO [dbo].[Permission]([Id], [MenuId], [ActionId], [Name], [DisplayName], [Description], [IsActive]) VALUES (5, 2, 1, N'View Role', N'View Role', NULL, 1)
INSERT INTO [dbo].[Permission]([Id], [MenuId], [ActionId], [Name], [DisplayName], [Description], [IsActive]) VALUES (6, 2, 2, N'Create Role', N'Create Role', NULL, 1)
INSERT INTO [dbo].[Permission]([Id], [MenuId], [ActionId], [Name], [DisplayName], [Description], [IsActive]) VALUES (7, 2, 3, N'Update Role', N'Update Role', NULL, 1)
INSERT INTO [dbo].[Permission]([Id], [MenuId], [ActionId], [Name], [DisplayName], [Description], [IsActive]) VALUES (8, 2, 4, N'Delete Role', N'Delete Role', NULL, 1)

INSERT INTO [dbo].[Permission]([Id], [MenuId], [ActionId], [Name], [DisplayName], [Description], [IsActive]) VALUES(9,3,1,N'View Device',N'View Device',NULL,1)
INSERT INTO [dbo].[Permission]([Id], [MenuId], [ActionId], [Name], [DisplayName], [Description], [IsActive]) VALUES(10,3,2,N'Create Device',N'Create Device',NULL,1)
INSERT INTO [dbo].[Permission]([Id], [MenuId], [ActionId], [Name], [DisplayName], [Description], [IsActive]) VALUES(11,3,2,N'Update Device',N'Update Device',NULL,1)
INSERT INTO [dbo].[Permission]([Id], [MenuId], [ActionId], [Name], [DisplayName], [Description], [IsActive]) VALUES(12,3,4,N'Delete Device',N'Delete Device',NULL,1)

SET IDENTITY_INSERT [dbo].[Permission] OFF

SET IDENTITY_INSERT [dbo].[RoleMenuMap] ON

INSERT INTO [dbo].[RoleMenuMap]([Id], [MenuId], [RoleId]) VALUES (1, 1, 1)
INSERT INTO [dbo].[RoleMenuMap]([Id], [MenuId], [RoleId]) VALUES (2, 2, 1)
INSERT INTO [dbo].[RoleMenuMap]([Id], [MenuId], [RoleId]) VALUES (3, 3, 1)

SET IDENTITY_INSERT [dbo].[RoleMenuMap] OFF

SET IDENTITY_INSERT [dbo].[RolePermissionMap] ON

INSERT INTO [dbo].[RolePermissionMap]([Id], [PermissionId], [RoleId]) VALUES (1, 1, 1)
INSERT INTO [dbo].[RolePermissionMap]([Id], [PermissionId], [RoleId]) VALUES (2, 2, 1)
INSERT INTO [dbo].[RolePermissionMap]([Id], [PermissionId], [RoleId]) VALUES (3, 3, 1)
INSERT INTO [dbo].[RolePermissionMap]([Id], [PermissionId], [RoleId]) VALUES (4, 4, 1)
INSERT INTO [dbo].[RolePermissionMap]([Id], [PermissionId], [RoleId]) VALUES (5, 5, 1)
INSERT INTO [dbo].[RolePermissionMap]([Id], [PermissionId], [RoleId]) VALUES (6, 6, 1)
INSERT INTO [dbo].[RolePermissionMap]([Id], [PermissionId], [RoleId]) VALUES (7, 7, 1)
INSERT INTO [dbo].[RolePermissionMap]([Id], [PermissionId], [RoleId]) VALUES (8, 8, 1)
INSERT INTO [dbo].[RolePermissionMap]([Id], [PermissionId], [RoleId]) VALUES (9, 9, 1)
INSERT INTO [dbo].[RolePermissionMap]([Id], [PermissionId], [RoleId]) VALUES (10, 10, 1)
INSERT INTO [dbo].[RolePermissionMap]([Id], [PermissionId], [RoleId]) VALUES (11, 11, 1)
INSERT INTO [dbo].[RolePermissionMap]([Id], [PermissionId], [RoleId]) VALUES (12, 12, 1)

SET IDENTITY_INSERT [dbo].[RolePermissionMap] OFF

SET IDENTITY_INSERT [dbo].[UserRoleMap] ON

INSERT INTO [dbo].[UserRoleMap]([Id], [UserId], [RoleId]) VALUES (1, 1, 1)

SET IDENTITY_INSERT [dbo].[UserRoleMap] OFF