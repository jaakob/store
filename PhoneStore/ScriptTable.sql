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
 [Password] nvarchar(15) NOT NULL,
 Email nvarchar(25) NOT NULL,
 Phone nvarchar(15) NOT NULL,
 Cookies nvarchar(80) NOT NULL,
 IsActive bit NOT NULL
)

CREATE TABLE Phone
(
  PhoneId int NOT NULL IDENTITY
  PRIMARY KEY,
  Model nvarchar(15) NOT NULL,
  Brand nvarchar(15) NOT NULL,
  [Description] nvarchar(100) NOT NULL,
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
CONSTRAINT FK_Image_Phone FOREIGN KEY (PhoneId) REFERENCES Phone(PhoneId)
)
GO