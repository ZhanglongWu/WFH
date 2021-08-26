CREATE TABLE [dbo].[Permission]
(
	[Id]				INT					NOT NULL	PRIMARY KEY		IDENTITY(1, 1),
	[MenuId]			INT					NULL	CONSTRAINT	[FK_Permission_MenuId_Menu_Id]	FOREIGN KEY REFERENCES [dbo].[Menu]([Id]),
	[ActionId]			SMALLINT			NOT NULL DEFAULT(1), --1: View; 2: Create; 3: Update; 4: Delete;
	[Name]				NVARCHAR(1024)		NOT NULL,
	[DisplayName]		NVARCHAR(1024)		NOT NULL,
	[Description]		NVARCHAR(MAX)		NULL,
	[IsActive]			BIT					NOT NULL DEFAULT(1)
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'自增长字段',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Permission',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'所属模块的权限，若是global则为空',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Permission',
    @level2type = N'COLUMN',
    @level2name = N'MenuId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'相应的Action，1:View; 2:Create; 3:Update; 4:Delete;',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Permission',
    @level2type = N'COLUMN',
    @level2name = N'ActionId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'权限名称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Permission',
    @level2type = N'COLUMN',
    @level2name = N'Name'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'权限页面显示名称',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Permission',
    @level2type = N'COLUMN',
    @level2name = N'DisplayName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'权限描述',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Permission',
    @level2type = N'COLUMN',
    @level2name = N'Description'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否删除',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Permission',
    @level2type = N'COLUMN',
    @level2name = N'IsActive'