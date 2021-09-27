DROP DATABASE IF EXISTS Bookish;
CREATE DATABASE Bookish;
GO 

USE Bookish;

CREATE TABLE users(
	User_ID int NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(255) NOT NULL,
	UserName VARCHAR(255) NOT NULL, 
	Password VARCHAR(255) NOT NULL
);

CREATE TABLE book(
	Book_ID int NOT NULL PRIMARY KEY IDENTITY(1,1), 
	Name VARCHAR(255) NOT NULL, 
	Author VARCHAR(255) NOT NULL, 
	Genre VARCHAR (255) NOT NULL, 
	isbn int NOT NULL
);

CREATE TABLE copies (
	copy_ID int NOT NULL PRIMARY KEY IDENTITY(1,1),
	Books_ID int NOT NUll,
	FOREIGN KEY (Books_ID) REFERENCES book(Book_ID),
	Borrowed_By_ID int,
	FOREIGN KEY (Borrowed_By_ID) REFERENCES users(User_ID),
	Due_Date DATE
);

INSERT INTO users(Name) Values ('Rhys');
INSERT INTO users(Name) Values ('Rodney');
INSERT INTO book(Name) Values ('Harry Plopper');

INSERT INTO book(Name, Book_ID) Values('Harry Potter And the Chamber Of Secrets', 1)

SELECT * FROM users WHERE Name = 'Rhys';

SELECT * FROM users;