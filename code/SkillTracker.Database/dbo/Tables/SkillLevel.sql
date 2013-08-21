CREATE TABLE [dbo].[SkillLevel]
(
	[Id] UNIQUEIDENTIFIER NOT NULL, 
    [Mark] INT NOT NULL, 
	[QuarterId] UNIQUEIDENTIFIER NOT NULL,
	[SkillId] UNIQUEIDENTIFIER NOT NULL,
	[UserId] UNIQUEIDENTIFIER NOT NULL,
    
	CONSTRAINT [FK_SkillLevel_Quarter] FOREIGN KEY ([QuarterId]) REFERENCES dbo.Quarter([Id]),
	CONSTRAINT [FK_SkillLevel_Skill] FOREIGN KEY ([SkillId]) REFERENCES dbo.Skill([Id]),
	CONSTRAINT [FK_SkillLevel_User] FOREIGN KEY ([UserId]) REFERENCES dbo.aspnet_Users([UserId]),
	CONSTRAINT [PK_SkillLevel] PRIMARY KEY (Id),
	CONSTRAINT [IX_SkillLevel] UNIQUE (Id)
)
