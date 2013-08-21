CREATE TABLE [dbo].[Quarter]
(
	[Id] UNIQUEIDENTIFIER NOT NULL, 
    [Name] NVARCHAR(200) NOT NULL, 
    [Number] INT NOT NULL, 
    [Year] INT NOT NULL, 
    [Description] NVARCHAR(500) NULL, 

    CONSTRAINT [PK_Quarter] PRIMARY KEY CLUSTERED (Id),
)
GO
CREATE INDEX IX_Quarter
ON [Quarter] (Id)
GO

