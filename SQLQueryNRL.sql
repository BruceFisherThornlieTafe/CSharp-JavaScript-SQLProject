USE [master]
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'nrlladder_erp')
	BEGIN
		CREATE DATABASE nrlladder_erp
    END
    GO
		USE nrlladder_erp
    GO

CREATE TABLE Team (
	PK_TeamId INTEGER NOT NULL IDENTITY(1,1),
	Name VARCHAR(30),
	Played INTEGER,
    Points INTEGER,
    Wins INTEGER,
    Draw INTEGER,
    Lost INTEGER,
    Byes INTEGER,
	PRIMARY KEY(PK_TeamId)
);

CREATE TABLE Season (
	PKFK_TeamID INTEGER,
	Season_For	INTEGER,
	Season_Against INTEGER,
	PRIMARY KEY(PKFK_TeamID),
	FOREIGN KEY (PKFK_TeamID) REFERENCES Team(PK_TeamId)
);

CREATE TABLE Ladder (
	PKFK_TeamID INTEGER,
	Position INTEGER,
    Ladder_Dif INTEGER,
	PRIMARY KEY(PKFK_TeamID),
	FOREIGN KEY (PKFK_TeamID) REFERENCES Team(PK_TeamId)
);