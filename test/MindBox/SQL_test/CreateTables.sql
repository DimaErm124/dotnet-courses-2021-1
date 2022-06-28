CREATE DATABASE CategoryProducts

USE CategoryProducts

CREATE TABLE Product(
ProductId int IDENTITY(1,1),
Name nvarchar(50) NOT NULL,
CONSTRAINT ProductId_PK PRIMARY KEY (ProductId)
)
GO

CREATE TABLE Category(
CategoryId int IDENTITY(1,1),
Name nvarchar(50) NOT NULL,
CONSTRAINT CategoryId_PK PRIMARY KEY (CategoryId)
)
GO

CREATE TABLE CategoryProduct(
CategoryId int NOT NULL,
ProductId int NOT NULL,
CONSTRAINT CategoryId_ProductId_PK PRIMARY KEY (CategoryId,ProductId),
CONSTRAINT CategoryId_FK FOREIGN KEY (CategoryId) REFERENCES Category(CategoryId),
CONSTRAINT ProductId_FK FOREIGN KEY (ProductId) REFERENCES Product(ProductId)
)
GO