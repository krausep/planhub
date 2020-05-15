CREATE TABLE TeamMember (
	[TeamMemberId] UNIQUEIDENTIFIER,
	[FirstName] NVARCHAR(50) NOT NULL,
	[MiddleName] NVARCHAR(50),
	[LastName] NVARCHAR(50) NOT NULL,
	[Title] NVARCHAR(100),
	[IsManager] BIT NOT NULL,
	CONSTRAINT [PK_TeamMember] PRIMARY KEY CLUSTERED
	(
		[TeamMemberId] ASC
	)
)

CREATE TABLE Team (
	[TeamId] UNIQUEIDENTIFIER,
	[TeamName] NVARCHAR(100) NOT NULL,
	CONSTRAINT [PK_Team] PRIMARY KEY CLUSTERED
	(
		[TeamId] ASC
	)
)

-- Team members can belong to only one team
CREATE TABLE TeamMembership (
	[TeamMemberId] UNIQUEIDENTIFIER NOT NULL,
	[TeamId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [PK_TeamMembership] PRIMARY KEY CLUSTERED
	(
		[TeamMemberId] ASC,
		[TeamId] ASC
	)
)

ALTER TABLE TeamMembership WITH CHECK ADD CONSTRAINT [FK_TeamMembership_TeamMemberId] FOREIGN KEY([TeamMemberId])
REFERENCES [dbo].[TeamMember] ([TeamMemberId])

ALTER TABLE TeamMembership WITH CHECK ADD CONSTRAINT [FK_TeamMembership_TeamId] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([TeamId])

-- Team members can have only one manager
CREATE TABLE OrganizationChart (
	[TeamMemberId] UNIQUEIDENTIFIER NOT NULL,
	[ReportsToTeamMemberId] UNIQUEIDENTIFIER NOT NULL
	CONSTRAINT [PK_OrganizationChart] PRIMARY KEY CLUSTERED
	(
		[TeamMemberId], [ReportsToTeamMemberId] ASC
	)
)

ALTER TABLE OrganizationChart WITH CHECK ADD CONSTRAINT [FK_OrganizationChart_TeamMemberId] FOREIGN KEY([TeamMemberId])
REFERENCES [dbo].[TeamMember] ([TeamMemberId])

ALTER TABLE OrganizationChart WITH CHECK ADD CONSTRAINT [FK_OrganizationChart_ReportsToTeamMemberId] FOREIGN KEY([ReportsToTeamMemberId])
REFERENCES [dbo].[TeamMember] ([TeamMemberId])

CREATE TABLE ObjectiveKeyResult (
	[ObjectiveKeyResultId] UNIQUEIDENTIFIER,
	[StartDate] DATE,
	[EndDate] DATE,
	CONSTRAINT [PK_ObjectiveKeyResult] PRIMARY KEY CLUSTERED
	(
		[ObjectiveKeyResultId] ASC
	)
)

CREATE TABLE OrganizationLevel(
	[OrganizationLevelId] INT NOT NULL,
	[Description] NVARCHAR(50),
	CONSTRAINT [PK_OrganizationLevel] PRIMARY KEY CLUSTERED
	(
		[OrganizationLevelId] ASC
	)
)

CREATE TABLE Objective (
	[ObjectiveId] UNIQUEIDENTIFIER,
	[ObjectiveKeyResultId] UNIQUEIDENTIFIER NOT NULL,
	[Description] NVARCHAR(200) NOT NULL,
	[PercentageWeight] DECIMAL(3,0),
	[InheritedFromObjective] UNIQUEIDENTIFIER,
	[OrganizationLevelId] INT NOT NULL,	-- Company, Team, Team Member
	CONSTRAINT [PK_Objective] PRIMARY KEY CLUSTERED
	(
		[ObjectiveId] ASC
	)
)

ALTER TABLE Objective WITH CHECK ADD CONSTRAINT [FK_Objective_ObjectiveKeyResultId] FOREIGN KEY([ObjectiveKeyResultId])
REFERENCES [dbo].[ObjectiveKeyResult] ([ObjectiveKeyResultId])

ALTER TABLE Objective WITH CHECK ADD CONSTRAINT [FK_Objective_OrganzationLevelId] FOREIGN KEY([OrganizationLevelId])
REFERENCES [dbo].[OrganizationLevel] ([OrganizationLevelId])


CREATE TABLE CompanyObjective (
	[CompanyObjectiveId] UNIQUEIDENTIFIER NOT NULL,
	[ObjectiveId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [PK_CompanyObjective] PRIMARY KEY CLUSTERED
	(
		[CompanyObjectiveId] ASC
	)
)

ALTER TABLE CompanyObjective WITH CHECK ADD CONSTRAINT [FK_CompanyObjective_ObjectiveId] FOREIGN KEY([ObjectiveId])
REFERENCES [dbo].[Objective] ([ObjectiveId])


CREATE TABLE TeamObjective (
	[TeamObjectiveId] UNIQUEIDENTIFIER NOT NULL,
	[ObjectiveId] UNIQUEIDENTIFIER NOT NULL,
	[TeamId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [PK_TeamObjective] PRIMARY KEY CLUSTERED
	(
		[TeamObjectiveId] ASC
	)
)

ALTER TABLE TeamObjective WITH CHECK ADD CONSTRAINT [FK_TeamObjective_ObjectiveId] FOREIGN KEY([ObjectiveId])
REFERENCES [dbo].[Objective] ([ObjectiveId])

ALTER TABLE TeamObjective WITH CHECK ADD CONSTRAINT [FK_TeamObjective_TeamId] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([TeamId])

CREATE NONCLUSTERED INDEX [IX_TeamObjective_TeamId] on [dbo].[TeamObjective]
(
	[TeamId] ASC
)

CREATE TABLE TeamMemberObjective (
	[TeamMemberObjectiveId] UNIQUEIDENTIFIER NOT NULL,
	[ObjectiveId] UNIQUEIDENTIFIER NOT NULL,
	[TeamMemberId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [PK_TeamMemberObjective] PRIMARY KEY CLUSTERED
	(
		[TeamMemberObjectiveId] ASC
	)
)

ALTER TABLE TeamMemberObjective WITH CHECK ADD CONSTRAINT [FK_TeamMemberObjective_ObjectiveId] FOREIGN KEY([ObjectiveId])
REFERENCES [dbo].[Objective] ([ObjectiveId])

ALTER TABLE TeamMemberObjective WITH CHECK ADD CONSTRAINT [FK_TeamMemberObjective_TeamMemberId] FOREIGN KEY([TeamMemberId])
REFERENCES [dbo].[TeamMember] ([TeamMemberId])

CREATE NONCLUSTERED INDEX [IX_TeamMemberObjective_ObjectiveId] on [dbo].[TeamMemberObjective]
(
	[ObjectiveId] ASC
)

CREATE NONCLUSTERED INDEX [IX_TeamMemberObjective_TeamMemberId] on [dbo].[TeamMemberObjective]
(
	[TeamMemberId] ASC
)


CREATE TABLE KeyResult(
	[KeyResultId] UNIQUEIDENTIFIER NOT NULL,
	[ObjectiveId] UNIQUEIDENTIFIER NOT NULL,
	[Description] NVARCHAR(200) NOT NULL,
	[DueDate] DATE NOT NULL,
	[Complete] BIT,
	CONSTRAINT [PK_KeyResult] PRIMARY KEY CLUSTERED
	(
		[KeyResultId] ASC
	)
)

ALTER TABLE KeyResult WITH CHECK ADD CONSTRAINT [FK_KeyResult_ObjectiveId] FOREIGN KEY([ObjectiveId])
REFERENCES [dbo].[Objective] ([ObjectiveId])
