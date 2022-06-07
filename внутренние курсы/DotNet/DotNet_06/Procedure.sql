USE Northwind
GO

-- 1.a
CREATE PROC GetMaxOrderForEmployees
	@employeeId INT,
	@year INT
AS
SELECT 
	FirstName+LastName Name,
	Orders.OrderID,
	UnitPrice*Quantity*(1 - Discount) S
FROM 
	Orders
INNER JOIN [Order Details] OrDet
	ON OrDet.OrderID=Orders.OrderID
INNER JOIN Employees
	ON Employees.EmployeeID=Orders.EmployeeID
WHERE 
	Orders.EmployeeID=@employeeId
	AND YEAR(OrderDate)=@year
	AND UnitPrice*Quantity*(1 - Discount)=
		(SELECT 
			MAX(UnitPrice*Quantity*(1 - Discount)) S
		FROM 
			Orders
		INNER JOIN [Order Details] OrDet
			ON OrDet.OrderID=Orders.OrderID
		WHERE 
			EmployeeID=@employeeId
			AND YEAR(OrderDate)=@year
		)
GO

CREATE PROCEDURE GreatestOrdersCur
	@year INT,
	@count INT
AS
   DECLARE @employee INT
   
   DECLARE Curs CURSOR FOR 
     SELECT TOP (@count)
		Orders.EmployeeID
	FROM 
		Orders
	INNER JOIN [Order Details] OrDet
		ON OrDet.OrderID=Orders.OrderID
	INNER JOIN Employees
		ON Employees.EmployeeID=Orders.EmployeeID
	WHERE
		YEAR(OrderDate)=@year
		AND UnitPrice*Quantity*(1 - Discount)=
			(SELECT 
				MAX(UnitPrice*Quantity*(1 - Discount)) S
			FROM 
				Orders O1
			INNER JOIN [Order Details] OrDet1
				ON OrDet1.OrderID=O1.OrderID
			WHERE 
				O1.EmployeeID= Employees.EmployeeID
				AND YEAR(O1.OrderDate)=1996
			)
			ORDER BY UnitPrice*Quantity*(1 - Discount) DESC
   
   OPEN Curs
   FETCH NEXT FROM Curs INTO @employee
   WHILE @@FETCH_STATUS = 0
   BEGIN  
        EXEC GetMaxOrderForEmployees @employee, @year
        FETCH NEXT FROM Curs INTO @employee
   END
   
   CLOSE Curs
   DEALLOCATE Curs
GO

CREATE PROCEDURE GreatestOrders
	@year INT,
	@count INT
AS
SELECT TOP (@count)
	FirstName+LastName Name,
	Orders.OrderID,
	UnitPrice*Quantity*(1 - Discount) S
FROM 
	Orders
INNER JOIN [Order Details] OrDet
	ON OrDet.OrderID=Orders.OrderID
INNER JOIN Employees
	ON Employees.EmployeeID=Orders.EmployeeID
WHERE
	YEAR(OrderDate)=@year
	AND UnitPrice*Quantity*(1 - Discount)=
		(SELECT 
			MAX(UnitPrice*Quantity*(1 - Discount)) S
		FROM 
			Orders O1
		INNER JOIN [Order Details] OrDet1
			ON OrDet1.OrderID=O1.OrderID
		WHERE 
			O1.EmployeeID= Employees.EmployeeID
			AND YEAR(O1.OrderDate)=@year
		)
ORDER BY S DESC
GO

--1.b
CREATE PROCEDURE ShippedOrdersDiff 
	@delay INT = 35
AS
	SELECT
		OrderID,
		OrderDate,
		ShippedDate,
		DATEDIFF(day,OrderDate,ShippedDate) ShippedDelay,
		@delay SpecifiedDelay 
	FROM Orders
	WHERE
		DATEDIFF(day,OrderDate,ShippedDate) > @delay
		OR ShippedDate IS NULL
GO

--1.c
CREATE PROCEDURE SubordinationInfo
	@employeeId INT
AS
   DECLARE @name NVARCHAR(50)
   
   DECLARE Curs CURSOR FOR 
    WITH DirectReports(Name, EmployeeID, EmployeeLevel, Sort)  
	AS 
	(SELECT CONVERT(VARCHAR(255), e.FirstName + ' ' + e.LastName), 
        e.EmployeeID,  
        1,  
        CONVERT(VARCHAR(255), e.FirstName + ' ' + e.LastName)  
    FROM Employees AS e  
    WHERE e.EmployeeID=@employeeId  
    UNION ALL  
    SELECT CONVERT(VARCHAR(255), REPLICATE ('       ' , EmployeeLevel) +  
        e.FirstName + ' ' + e.LastName),  
        e.EmployeeID,  
        EmployeeLevel + 1,  
        CONVERT (VARCHAR(255), RTRIM(Sort) + '       ' + FirstName + ' ' +   
                 LastName)  
    FROM Employees AS e  
    JOIN DirectReports AS d ON e.ReportsTo = d.EmployeeID  
    )  
	SELECT Name  
	FROM DirectReports   
	ORDER BY Sort;  
   
   OPEN Curs
   FETCH NEXT FROM Curs INTO @name
   WHILE @@FETCH_STATUS = 0
   BEGIN  
        PRINT @name
        FETCH NEXT FROM Curs INTO @name
   END
   
   CLOSE Curs
   DEALLOCATE Curs
GO

--1.d
CREATE PROCEDURE IsBoss
	@employeeId INT
AS
	DECLARE @employeeCount INT
	
	SELECT 
		@employeeCount=COUNT(*) 
	FROM 
		Employees 
	WHERE 
		ReportsTo=@employeeId

	IF @employeeCount>0
		RETURN CAST(1 as Bit)
	ELSE
		RETURN CAST(0 as Bit)
GO

CREATE PROCEDURE CheckAllEmployeesBoss
AS  
   DECLARE @employeeID INT
   DECLARE @isBoss BIT
   
   DECLARE Curs CURSOR FOR 
     SELECT EmployeeID
     FROM Employees
   
   OPEN Curs

   FETCH NEXT FROM Curs INTO @employeeID

   WHILE @@FETCH_STATUS = 0
   BEGIN 
		SELECT EmployeeID FROM Employees WHERE EmployeeID=@employeeID
        EXEC @isBoss = IsBoss @employeeId
		PRINT 'EmployeeID: '+CAST(@employeeID as varchar)+'; IsBoss: '+CAST(@isBoss as varchar)
        FETCH NEXT FROM Curs INTO @employeeId
   END
   
   CLOSE Curs
   DEALLOCATE Curs
GO