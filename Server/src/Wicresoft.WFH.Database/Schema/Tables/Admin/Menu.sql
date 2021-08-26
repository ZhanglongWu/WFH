CREATE TABLE [dbo].[Menu]
(
	[Id]				INT					NOT NULL PRIMARY KEY	IDENTITY(1, 1),
	[ParentId]			INT					NULL	CONSTRAINT [FK_Menu_ParentId_Menu_Id]	FOREIGN KEY REFERENCES [dbo].[Menu]([Id]),
	[ModuleId]			INT					NULL	CONSTRAINT	[FK_Menu_ModuleId_Module_Id]	FOREIGN KEY REFERENCES [dbo].[Module]([Id]),
	[Order]				SMALLINT			NOT NULL	DEFAULT(1),
	[Key]				NVARCHAR(64)		NOT NULL,
	[Name]				NVARCHAR(64)		NOT NULL,
	[Icon]				NVARCHAR(64)		NULL,
	[Path]				NVARCHAR(1024)		NOT NULL,
	[IsEnable]			BIT					NOT NULL DEFAULT(1),
	[IsActive]			BIT					NOT NULL DEFAULT(1)
)


GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'自增长数据字段',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Menu',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'父菜单外键，若没有则为空',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Menu',
    @level2type = N'COLUMN',
    @level2name = N'ParentId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'菜单所属模块外键，若没有则为空',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Menu',
    @level2type = N'COLUMN',
    @level2name = N'ModuleId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'菜单序号',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Menu',
    @level2type = N'COLUMN',
    @level2name = N'Order'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'菜单唯一键',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Menu',
    @level2type = N'COLUMN',
    @level2name = N'Key'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'菜单名称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Menu',
    @level2type = N'COLUMN',
    @level2name = N'Name'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'菜单Icon',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Menu',
    @level2type = N'COLUMN',
    @level2name = N'Icon'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'菜单前端路由',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Menu',
    @level2type = N'COLUMN',
    @level2name = N'Path'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否Enable',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Menu',
    @level2type = N'COLUMN',
    @level2name = N'IsEnable'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否删除',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Menu',
    @level2type = N'COLUMN',
    @level2name = N'IsActive'