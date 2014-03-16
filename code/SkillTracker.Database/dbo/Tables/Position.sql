CREATE TABLE [dbo].[Position]
(
	[Id] UNIQUEIDENTIFIER NOT NULL, 
    [Name] NVARCHAR(200) NOT NULL, 
    [Description] NVARCHAR(500) NULL

	CONSTRAINT [PK_Position] PRIMARY KEY (Id),
	[Code] NVARCHAR(10) NOT NULL, 
    CONSTRAINT [IX_Position] UNIQUE (Id), 
    CONSTRAINT [AK_Position_Code] UNIQUE ([Code])
)
