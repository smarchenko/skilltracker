CREATE TABLE [dbo].[SkillGroup]
(
	[Id] UNIQUEIDENTIFIER NOT NULL, 
    [Name] NVARCHAR(200) NOT NULL, 
    [Description] NVARCHAR(500) NULL

	CONSTRAINT [PK_SkillGroup] PRIMARY KEY CLUSTERED (Id), 
    [Title ] NVARCHAR(200) NULL, 
    CONSTRAINT [AK_SkillGroup_Name] UNIQUE ([Name]),
)
