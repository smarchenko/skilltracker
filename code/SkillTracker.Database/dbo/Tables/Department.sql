CREATE TABLE [dbo].[Department]
(
	[Id] UNIQUEIDENTIFIER NOT NULL, 
    [Name] NVARCHAR(200) NOT NULL, 
    [Description] NVARCHAR(500) NULL

	CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED (Id), 
    [Code] VARCHAR(10) NOT NULL,
)

GO

CREATE UNIQUE INDEX [IX_Department_Code] ON [dbo].[Department] ([Code])
