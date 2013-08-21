CREATE TABLE [dbo].[UserPosition]
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[PositionId] UNIQUEIDENTIFIER NOT NULL,
	[UserId] UNIQUEIDENTIFIER NOT NULL,

	CONSTRAINT [FK_UserPosition_Position] FOREIGN KEY ([PositionId]) REFERENCES dbo.Position([Id]),
	CONSTRAINT [FK_UserPosition_User] FOREIGN KEY ([UserId]) REFERENCES dbo.aspnet_Users([UserId]),
	CONSTRAINT [PK_UserPosition] PRIMARY KEY (Id),
	CONSTRAINT [IX_UserPosition] UNIQUE (Id)
)
