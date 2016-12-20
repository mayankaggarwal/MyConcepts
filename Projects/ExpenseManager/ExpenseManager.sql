


CREATE TABLE ExpenseUsers
(
	ID INT IDENTITY(1,1) Primary Key,
	FirstName VARCHAR(50),
	LastName VARCHAR(50),
	UserName VARCHAR(100) NOT NULL,
	EmailID	VARCHAR(100) NOT NULL,
	Valid BIT NOT NULL,
	CreationDate DATETIME DEFAULT GETDATE()
);
go
CREATE TABLE Groups
(
	ID INT IDENTITY(1,1) Primary Key,
	GroupName VARCHAR(100) NOT NULL,
	CreationDate DATETIME DEFAULT GETDATE(),
	CreatedBy INT NOT NULL REFERENCES ExpenseUsers(ID)
);
go
CREATE TABLE GpActorRelationship
(
	ID INT IDENTITY(1,1) Primary Key,
	[Group] INT NOT NULL REFERENCES Groups(ID),
	[User] INT NOT NULL REFERENCES ExpenseUsers(ID),
	[Admin] BIT NOT NULL,
	AddedDate DATETIME
);
go
CREATE TABLE Activities
(
	ID INT IDENTITY(1,1) Primary Key,
	[ActivityName] VARCHAR(100),
	[Group] INT NOT NULL REFERENCES Groups(ID),
	CreationDate	DATETIME
);
go
CREATE TABLE Expensors
(
	ID INT IDENTITY(1,1) Primary Key,
	[Activity]	INT NOT NULL REFERENCES Activities(ID),
	Actor INT NOT NULL REFERENCES ExpenseUsers(ID),
	Amount Money NOT NULL,
);
go
CREATE TABLE Participants
(
	ID INT IDENTITY(1,1) Primary Key,
	[Activity]	INT NOT NULL REFERENCES Activities(ID),
	Actor INT NOT NULL REFERENCES ExpenseUsers(ID),
	Amount Money NOT NULL
);
go
