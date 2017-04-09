USE master

CREATE DATABASE PhoneStore
ON
(
NAME = 'PhoneStore',
FILENAME = 'D:\Base\PhoneStore.mdf',
SIZE = 10MB,
MAXSIZE = 200MB,
FILEGROWTH = 5MB
)
LOG ON
(
NAME = 'PhoneStoreLog',
FILENAME = 'D:\Base\PhoneStore.ldf',
SIZE = 10MB,
MAXSIZE = 200MB,
FILEGROWTH = 5MB
)
COLLATE Cyrillic_General_CI_AS
GO

USE PhoneStore

CREATE TABLE Users
(
 UserId int NOT NULL IDENTITY
 PRIMARY KEY,
 RegDate datetime2(7) NOT NULL,
 FirstName nvarchar(30) NOT NULL,
 LastName nvarchar(30) NOT NULL,
 [Password] nvarchar(max) NOT NULL,
 Email nvarchar(256) NOT NULL,
 Cookie nvarchar(80) NOT NULL,
 ContactPhone nvarchar(15) NULL,
 IsActive bit NOT NULL
)

CREATE TABLE Phones
(
  PhoneId int NOT NULL IDENTITY
  PRIMARY KEY,
  Model nvarchar(45) NOT NULL,
  Brand nvarchar(15) NOT NULL,
  [Description] nvarchar(250) NOT NULL,
  Price decimal NOT NULL,
  UserId int NOT NULL,
  CONSTRAINT FK_Phone_User FOREIGN KEY (UserId) REFERENCES Users(UserId)
)

CREATE TABLE Images
(
ID int NOT NULL IDENTITY
PRIMARY KEY,
[Image] nvarchar(300) NOT NULL,
PhoneId int NOT NULL
CONSTRAINT FK_Image_Phone FOREIGN KEY (PhoneId) REFERENCES Phones(PhoneId)
)
GO