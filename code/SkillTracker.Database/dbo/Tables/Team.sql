CREATE TABLE [dbo].[Team]
(
	[Id] UNIQUEIDENTIFIER NOT NULL, 
    [Name] NVARCHAR(200) NOT NULL, 
    [Description] NVARCHAR(500) NULL, 
    [DepartmentId] UNIQUEIDENTIFIER NOT NULL

	CONSTRAINT [FK_Team_Department] FOREIGN KEY ([DepartmentId]) REFERENCES dbo.Department([Id]),
    CONSTRAINT [PK_Team] PRIMARY KEY (Id),
)
