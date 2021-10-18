CREATE DATABASE ShopDB
use ShopDB


CREATE TABLE Seasonal(
SeasonalId int not null identity(1,1) primary key,
SeasonalName varchar(50) not null,
SeasonalStartDate Datetime2 not null,
SeasonalEndDate Datetime2 not null
)

CREATE TABLE Product(
ProductId int not null identity (1,1) primary key,
SeasonalId int FOREIGN KEY REFERENCES Seasonal (SeasonalId),
ProductName varchar(50) not null,
ProductPrice decimal(19,4) not null,
ProductDescription varchar(100) not null,
ProductDiscount decimal (19,4),
CategoryId int not null,
Category nvarchar(50)
)

ALTER TABLE Product
ALTER COLUMN ProductDescription varchar(500) not null


CREATE TABLE UserProduct(
UserProductId int primary key identity(1,1) not null,
UserId uniqueIdentifier,
ProductId int FOREIGN KEY REFERENCES Product (ProductId) not null
)


