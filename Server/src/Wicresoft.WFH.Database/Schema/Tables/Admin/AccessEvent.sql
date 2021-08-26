CREATE TABLE [dbo].[AccessEvent]
(
	[Id]					INT IDENTITY(1, 1)	NOT NULL PRIMARY KEY,
	[IpAddress]				NVARCHAR(64)			NOT NULL,
	[Path]					NVARCHAR(64)			NULL,
	[UserId]				INT						NULL	CONSTRAINT [FK_AccessEvent_UserId_User_Id]	FOREIGN KEY REFERENCES [dbo].[User]([Id]),
	[YYYYMMDD]				NVARCHAR(64)			NOT NULL,
	[Year]					INT						NOT NULL,
	[Month]					INT						NOT NULL,
	[Days]					INT						NOT NULL,
	[CreatedDateTime]		DATETIME				NOT NULL	DEFAULT(GETUTCDATE()),
	[Comment]				NVARCHAR(MAX)			NULL
)
