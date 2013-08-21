CREATE TABLE [dbo].[PositionSkillGroup]
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[PositionId] UNIQUEIDENTIFIER NOT NULL,
	[GroupId] UNIQUEIDENTIFIER NOT NULL,

	CONSTRAINT [FK_PositionSkillGroup_Position] FOREIGN KEY ([PositionId]) REFERENCES dbo.Position([Id]),
	CONSTRAINT [FK_PositionSkillGroup_SkillGroup] FOREIGN KEY ([GroupId]) REFERENCES dbo.SkillGroup([Id]),
	CONSTRAINT [PK_PositionSkillGroup] PRIMARY KEY (Id),
	CONSTRAINT [IX_PositionSkillGroup] UNIQUE (Id)
)
