INSERT INTO OrganizationLevel (OrganizationLevelId, Description) VALUES
(1, 'Company'),
(2, 'Team'),
(3, 'Team Member')

INSERT INTO Team(TeamId, TeamName) VALUES
(NEWID(), 'ProductOne Development Team'),
(NEWID(), 'Finance'),
(NEWID(), 'Sales and Marketing')

DECLARE @TeamId UNIQUEIDENTIFIER

-- Development Team
SELECT @TeamId = TeamId FROM Team WHERE TeamName = 'ProductOne Development Team'
INSERT INTO TeamMember(TeamMemberId, TeamId, FirstName, MiddleName, LastName, Title, IsManager) VALUES
(NEWID(), @TeamId, 'Bill', null, 'Smith', 'Senior UX Designer', 0),
(NEWID(), @TeamId, 'Marisol', 'Maria', 'Sanchez', 'Manager of Software Development', 1)

-- Finance Team
SELECT @TeamId = TeamId FROM Team WHERE TeamName = 'Finance'
INSERT INTO TeamMember(TeamMemberId, TeamId, FirstName, MiddleName, LastName, Title, IsManager) VALUES
(NEWID(), @TeamId, 'Maggie', 'Lynn', 'Brown', 'Financial Analyst', 0),
(NEWID(), @TeamId, 'Tim', 'D.', 'Hart', 'Manager of Finance', 1)

-- Finance Team
SELECT @TeamId = TeamId FROM Team WHERE TeamName = 'Sales and Marketing'
INSERT INTO TeamMember(TeamMemberId, TeamId, FirstName, MiddleName, LastName, Title, IsManager) VALUES
(NEWID(), @TeamId, 'Robert', null, 'Knight', 'Account Representative', 0),
(NEWID(), @TeamId, 'Clark', 'Kevin', 'Whitman', 'Manager of Sales', 1)

INSERT INTO ObjectiveKeyResult (ObjectiveKeyResultId, Description, StartDate, EndDate) VALUES
(NEWID(), 'Q1 ProductOne Dev Team OKRs', '2020/01/01', '2020/03/31'),	-- Two OKR groups for each team, Q1 and Q2
(NEWID(), 'Q1 Finance OKRs', '2020/01/01', '2020/03/31'),
(NEWID(), 'Q1 Sales and Marketing OKRs', '2020/01/01', '2020/03/31'),
(NEWID(), 'Q2 ProductOne Dev Team OKRs', '2020/04/01', '2020/06/30'),
(NEWID(), 'Q2 Finance OKRs', '2020/04/01', '2020/06/30'),
(NEWID(), 'Q2 Sales and Marketing OKRs', '2020/04/01', '2020/06/30')

DECLARE @ObjectiveKeyResultId UNIQUEIDENTIFIER
SELECT @ObjectiveKeyResultId = ObjectiveKeyResultId FROM ObjectiveKeyResult WHERE Description = 'Q1 ProductOne Dev Team OKRs'
INSERT INTO Objective (ObjectiveId, ObjectiveKeyResultId, Description, OrganizationLevelId, PercentageWeight) VALUES
(NEWID(), @ObjectiveKeyResultId, 'Improve Customer Experience Through Fast Response to Issues', 1, 20),
(NEWID(), @ObjectiveKeyResultId, 'Improve Quality Feedback Loop', 2, 20)

SELECT @ObjectiveKeyResultId = ObjectiveKeyResultId FROM ObjectiveKeyResult WHERE Description = 'Q1 Finance OKRs'
INSERT INTO Objective (ObjectiveId, ObjectiveKeyResultId, Description, OrganizationLevelId, PercentageWeight) VALUES
(NEWID(), @ObjectiveKeyResultId, 'Close the Books', 1, 20),
(NEWID(), @ObjectiveKeyResultId, 'Timely, Accurate Invoices to Customers', 2, 20)

SELECT @ObjectiveKeyResultId = ObjectiveKeyResultId FROM ObjectiveKeyResult WHERE Description = 'Q1 Sales and Marketing OKRs'
INSERT INTO Objective (ObjectiveId, ObjectiveKeyResultId, Description, OrganizationLevelId, PercentageWeight) VALUES
(NEWID(), @ObjectiveKeyResultId, 'Stay In The Hearts and Minds of Customers', 2, 20),
(NEWID(), @ObjectiveKeyResultId, 'Bi-Weekly Updates to Company Blog', 2, 20)

DECLARE @ObjectiveId UNIQUEIDENTIFIER
SELECT @ObjectiveId = ObjectiveId FROM Objective WHERE Description = 'Improve Customer Experience Through Fast Response to Issues'
INSERT INTO CompanyObjective(CompanyObjectiveId, ObjectiveId) VALUES (NEWID(), @ObjectiveId)

SELECT @ObjectiveId = ObjectiveId FROM Objective WHERE Description = 'Close the Books'
INSERT INTO CompanyObjective(CompanyObjectiveId, ObjectiveId) VALUES (NEWID(), @ObjectiveId)

SELECT @TeamId = TeamId FROM Team WHERE TeamName = 'ProductOne Development Team'
SELECT @ObjectiveId = ObjectiveId FROM Objective WHERE Description = 'Improve Quality Feedback Loop'
INSERT INTO TeamObjective(TeamObjectiveId, ObjectiveId, TeamId) VALUES(NEWID(), @ObjectiveId, @TeamId)

SELECT @TeamId = TeamId FROM Team WHERE TeamName = 'Finance'
SELECT @ObjectiveId = ObjectiveId FROM Objective WHERE Description = 'Timely, Accurate Invoices to Customers'
INSERT INTO TeamObjective(TeamObjectiveId, ObjectiveId, TeamId) VALUES(NEWID(), @ObjectiveId, @TeamId)

SELECT @TeamId = TeamId FROM Team WHERE TeamName = 'Sales and Marketing'
SELECT @ObjectiveId = ObjectiveId FROM Objective WHERE Description = 'Stay In The Hearts and Minds of Customers'
INSERT INTO TeamObjective(TeamObjectiveId, ObjectiveId, TeamId) VALUES(NEWID(), @ObjectiveId, @TeamId)

SELECT @ObjectiveId = ObjectiveId FROM Objective WHERE Description = 'Bi-Weekly Updates to Company Blog'
INSERT INTO TeamObjective(TeamObjectiveId, ObjectiveId, TeamId) VALUES(NEWID(), @ObjectiveId, @TeamId)