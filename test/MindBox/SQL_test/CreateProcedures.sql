USE CategoryProducts

CREATE OR ALTER PROCEDURE InsertProduct(
	@name nvarchar(50))
AS
	INSERT INTO Product(Name)
	VALUES(@name)
GO

CREATE OR ALTER PROCEDURE InsertCategory(
	@name nvarchar(50))
AS
	INSERT INTO Category(Name)
	VALUES(@name)
GO

CREATE OR ALTER PROCEDURE InsertCategoryProduct(
	@productId int,
	@categoryId int)
AS
	INSERT INTO CategoryProduct(CategoryId,ProductId)
	VALUES(@categoryId, @productId)
GO

EXEC InsertProduct 'Car'
GO
EXEC InsertProduct 'Milk'
GO
EXEC InsertProduct 'Oil'
GO
EXEC InsertProduct 'Axe'
GO

EXEC InsertCategory 'For home'
GO
EXEC InsertCategory 'Food'
GO
EXEC InsertCategory 'Transport'
GO
EXEC InsertCategory 'Durable'
GO

EXEC InsertCategoryProduct 1,3
GO
EXEC InsertCategoryProduct 1,4
GO
EXEC InsertCategoryProduct 2,2
GO
EXEC InsertCategoryProduct 3,1
GO
EXEC InsertCategoryProduct 3,4
GO