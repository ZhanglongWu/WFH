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