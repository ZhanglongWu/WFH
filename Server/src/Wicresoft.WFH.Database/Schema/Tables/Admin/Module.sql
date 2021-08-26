CREATE TABLE [dbo].[Module]
(
	[Id]					INT				NOT NULL PRIMARY KEY	IDENTITY(1, 1),
	[Order]					SMALLINT		NOT NULL,
	[Key]					NVARCHAR(64)		NOT NULL,
	[Name]					NVARCHAR(64)	NOT NULL,
	[DisplayName]			NVARCHAR(64)	NOT NULL,
	[Description]			NVARCHAR(MAX)	NULL,
	[IsActive]				BIT				NOT NULL	DEFAULT(1)
)