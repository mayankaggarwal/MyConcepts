CREATE TABLE Genre
(
	ID INT IDENTITY(1000,1) CONSTRAINT genre_pk Primary Key
	,Name VARCHAR(200)
);

CREATE TABLE Movie
(
	ID INT IDENTITY(1000,1) CONSTRAINT movie_pk Primary Key
	,Title			VARCHAR(200)
	,[Description]	VARCHAR(200)
	,[Image]		VARCHAR(2000)
	,GenreId		INT
	,Director		VARCHAR(200)
	,Writer			VARCHAR(200)
	,Producer		VARCHAR(200)
	,ReleaseDate	DATETIME
	,Rating			TINYINT
	,TrailerURI		VARCHAR(500)
);

CREATE TABLE Stock
(
	ID INT IDENTITY(1000,1) CONSTRAINT stock_pk Primary Key
	,MovieId	INT
	,UniqueKey	uniqueidentifier
	,IsAvailable	BIT
);

CREATE TABLE Customer
(
	ID INT IDENTITY(1000,1) CONSTRAINT customer_pk Primary Key
	,FirstName	VARCHAR(100)
	,LastName	VARCHAR(100)
	,Email	VARCHAR(100)
	,IdentityCard	VARCHAR(100)
	,UniqueKey	uniqueidentifier
	,DateOfBirth	DATETIME
	,Mobile	VARCHAR(20)
	,RegistrationDate	DATETIME
);

CREATE TABLE Rental
(
	ID INT IDENTITY(1000,1) CONSTRAINT rental_pk Primary Key
	,CustomerId	INT
	,StockId	INT
	,RentalDate	DATETIME
	,ReturnedDate	DATETIME
	,Status	VARCHAR(100)
);

CREATE TABLE Role
(
	ID INT IDENTITY(1000,1) CONSTRAINT role_pk Primary Key
	,Name	VARCHAR(100)
)