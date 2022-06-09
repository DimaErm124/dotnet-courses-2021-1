CREATE DATABASE CustomerOrders

USE CustomerOrders

CREATE TABLE Customers(
CustomerId int IDENTITY(1,1),
Name nvarchar(50) NOT NULL,
CONSTRAINT CustomerId_PK PRIMARY KEY (CustomerId)
)
GO

CREATE TABLE Orders(
OrderId int IDENTITY(1,1),
CustomerId int NOT NULL,
CONSTRAINT OrderId_PK PRIMARY KEY (OrderId),
CONSTRAINT CustomerId_FK FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
)
GO

CREATE OR ALTER PROCEDURE InsertCustomer(
	@name nvarchar(50))
AS
	INSERT INTO Customers(Name)
	VALUES(@name)
GO

CREATE OR ALTER PROCEDURE InsertOrder(
	@customerId int)
AS
	INSERT INTO Orders(CustomerId)
	VALUES(@customerId)
GO

EXEC InsertCustomer 'Max'
GO

EXEC InsertCustomer 'Pavel'
GO

EXEC InsertCustomer 'Ivan'
GO

EXEC InsertCustomer 'Leonid'
GO

EXEC InsertOrder 2
GO

EXEC InsertOrder 4
GO

SELECT
	Name
FROM 
	Customers
WHERE 
	Customers.CustomerId NOT IN 
	(
	SELECT 
		Customers.CustomerId
	FROM 
		Customers
	INNER JOIN Orders
		ON Customers.CustomerId= Orders.CustomerId
	)