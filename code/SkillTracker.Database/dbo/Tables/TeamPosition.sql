CREATE TABLE [dbo].[TeamPosition]
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[TeamId] UNIQUEIDENTIFIER NOT NULL,
	[PositionId] UNIQUEIDENTIFIER NOT NULL,

	CONSTRAINT [FK_TeamPosition_Team] FOREIGN KEY ([TeamId]) REFERENCES dbo.Team([Id]),
	CONSTRAINT [FK_TeamPosition_Position] FOREIGN KEY ([PositionId]) REFERENCES dbo.Position([Id]),
	CONSTRAINT [PK_TeamPosition] PRIMARY KEY (Id),
	CONSTRAINT [IX_TeamPosition] UNIQUE (Id)
)
