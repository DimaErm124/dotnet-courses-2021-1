USE Northwind

-- 1.a
-- ������� � ������� Orders ������, ������� ���� ���������� ����� 6 ��� 1998 ���� (������� ShippedDate) ������������ � ������� ���������� � ShipVia >= 2. 
-- ������ �������� ���� ������ ���� ������ ��� ����� ������������ ����������, 
-- �������� ����������� ������ �Writing International Transact-SQL Statements� � Books Online ������ �Accessing and Changing Relational Data Overview�. 
-- ���� ����� ������������ ����� ��� ���� �������. ������ ������ ����������� ������ ������� OrderID, ShippedDate � ShipVia.
-- �������� ������ ���� �� ������ ������ � NULL-�� � ������� ShippedDate.
SELECT
	OrderID,
	ShippedDate,
	ShipVia
FROM Orders
WHERE ShipVia>=2
AND ShippedDate>=DATEFROMPARTS(1998,5,6)

-- 1.b
-- �������� ������, ������� ������� ������ �������������� ������ �� ������� Orders. 
-- � ����������� ������� ����������� ��� ������� ShippedDate 
-- ������ �������� NULL ������ �Not Shipped� � ������������ ��������� ������� CAS�. 
-- ������ ������ ����������� ������ ������� OrderID � ShippedDate.
SELECT
	OrderID,
	CASE WHEN ShippedDate IS NULL THEN 'Not Shipped'
	ELSE CAST(ShippedDate AS nvarchar)
	END AS ShippedDate
FROM Orders
WHERE Orders.ShippedDate IS NULL

-- 1.�
-- ������� � ������� Orders ������, 
-- ������� ���� ���������� ����� 6 ��� 1998 ���� (ShippedDate), 
-- �� ������� ��� ����, ��� ������� ��� �� ����������. 
-- � ������� ������ ������������� ������ ������� OrderID (������������� � Order Number)
-- � ShippedDate (������������� � Shipped Date). � ����������� ������� ����������� ��� ������� ShippedDate
-- ������ �������� NULL ������ �Not Shipped�, ��� ��������� �������� ����������� ���� � ������� �� ���������.
SELECT
	OrderID AS 'Order Number',
	CASE WHEN ShippedDate IS NULL THEN 'Not Shipped'
	ELSE CAST(ShippedDate AS nvarchar)
	END AS 'Shipped Date'
FROM Orders
WHERE Orders.ShippedDate IS NULL
OR Orders.ShippedDate>DATEFROMPARTS(1998,5,6)

-- 2.a
-- ������� �� ������� Customers ���� ����������, ����������� � USA � Canada. 
-- ������ ������� ������ � ������� ��������� IN. 
-- ����������� ������� � ������ ������������ � ��������� ������ � ����������� �������. 
-- ����������� ���������� ������� �� ����� ���������� � �� ����� ����������.
SELECT 
	ContactName,
	Country
FROM Customers
WHERE Country IN ('USA','Canada')
ORDER BY ContactName, Country

-- 2.b
-- ������� �� ������� Customers ���� ����������, �� ����������� � USA � Canada. 
-- ������ ������� � ������� ��������� IN. 
-- ����������� ������� � ������ ������������ � ��������� ������ � ����������� �������. 
-- ����������� ���������� ������� �� ����� ����������.
SELECT 
	ContactName,
	Country
FROM Customers
WHERE Country NOT IN ('USA','Canada')
ORDER BY ContactName

-- 2.c
-- ������� �� ������� Customers ��� ������, � ������� ��������� ���������. 
-- ������ ������ ���� ��������� ������ ���� ���, � ������ ������������ �� ��������. 
-- �� ������������ ����������� GROUP BY. 
-- ����������� ������ ���� ������� � ����������� �������.
SELECT 
	DISTINCT Country
FROM Customers
ORDER BY Country DESC

-- 3.a
-- ������� ��� ������ (OrderID) �� ������� Order Details (������ �� ������ �����������),
-- ��� ����������� �������� � ����������� �� 3 �� 10 ������������ � ��� ������� Quantity � ������� Order Details. 
-- ������������ �������� BETWEEN. ������ ������ ����������� ������ ������� OrderID.
SELECT 
	DISTINCT OrderID
FROM [Order Details]
WHERE Quantity BETWEEN 3 AND 10

-- 3.b
-- ������� ���� ���������� �� ������� Customers,
-- � ������� �������� ������ ���������� �� ����� �� ��������� b � g. 
-- ������������ �������� BETWEEN. ���������,
-- ��� � ���������� ������� �������� Germany. 
-- ������ ������ ����������� ������ ������� CustomerID � Country 
-- � ������������ �� Country.
SELECT 
	CustomerID,
	Country
	FROM Customers
WHERE SUBSTRING(Country,1,1) BETWEEN 'b' AND 'g'
ORDER BY Country

-- 3.c
-- ������� ���� ���������� �� ������� Customers,
-- � ������� �������� ������ ���������� �� ����� �� ��������� b � g, 
-- �� ��������� �������� BETWEEN. � ������� ����� �Execution Plan� ���������� ����� ������ ���������������� 3.2 ��� 3.3
-- � ��� ����� ���� ������ � ������ ���������� ���������� Execution Plan-a ��� ���� ���� ��������,
-- ���������� ���������� Execution Plan ���� ������ � ������ � ���� ����������� � �� �� ����������� ���� ����� �� ������ 
-- � �� ������ ��������� ���� ��������� ���������. ������ ������ ����������� ������ ������� CustomerID � Country � ������������ �� Country.
SELECT 
	CustomerID,
	Country
	FROM Customers
WHERE SUBSTRING(Country,1,1) >= 'b' AND SUBSTRING(Country,1,1) <='g'
ORDER BY Country

-- ��� ��������� ������������ �������� ���������� ���������� ���� �����������

-- 4.a
-- � ������� Products ����� ��� �������� (������� ProductName), 
-- ��� ����������� ��������� 'chocolade'. 
-- ��������, ��� � ��������� 'chocolade' ����� ���� �������� ���� ����� 'c' � �������� - 
-- ����� ��� ��������, ������� ������������� ����� �������. 
-- ���������: ���������� ������� ������ ����������� 2 ������.
SELECT * FROM Products
WHERE ProductName LIKE '%cho_olade%'
--WHERE ProductName LIKE '%cho_ola_e%'

-- 5.a
-- ����� ����� ����� ���� ������� �� ������� Order Details � ������ ���������� ����������� ������� � ������ �� ���. 
-- ��������� ��������� �� ����� � ��������� � ����� 1 ��� ���� ������ money.  
-- ������ (������� Discount) ���������� ������� �� ��������� ��� ������� ������. 
-- ��� ����������� �������������� ���� �� ��������� ������� ���� ������� ������ �� ��������� � ������� UnitPrice ����. 
-- ����������� ������� ������ ���� ���� ������ � ����� �������� � ��������� ������� 'Totals'.
SELECT 
	ROUND(SUM((UnitPrice-(UnitPrice*Discount))*Quantity),2) Totals
FROM [Order Details]

-- 5.b
-- �� ������� Orders ����� ���������� �������, ������� ��� �� ���� ���������� 
-- (�.�. � ������� ShippedDate ��� �������� ���� ��������). 
-- ������������ ��� ���� ������� ������ �������� COUNT. 
-- �� ������������ ����������� WHERE � GROUP.
SELECT
	COUNT(CASE WHEN ShippedDate IS NULL THEN 1 ELSE NULL END) 'Not shipped orders count'
FROM Orders

-- 5.c
-- �� ������� Orders ����� ���������� ��������� ����������� (CustomerID), ��������� ������. 
-- ������������ ������� COUNT � �� ������������ ����������� WHERE � GROUP
SELECT
	COUNT(DISTINCT CustomerID) 'Customers count'
FROM Orders

-- 6.a
-- �� ������� Orders ����� ���������� ������� � ������������ �� �����. 
-- � ����������� ������� ���� ����������� ��� ������� c ���������� Year � Total. 
-- �������� ����������� ������, ������� ��������� ���������� ���� �������.
SELECT			-- ����������� ������
	COUNT(*) Total
FROM Orders

SELECT 
	YEAR(OrderDate) AS YYear,
	COUNT(*) Total
FROM Orders
GROUP BY YEAR(OrderDate)

-- 6.b
-- �� ������� Orders ����� ���������� �������, c�������� ������ ���������. 
-- ����� ��� ���������� �������� � ��� ����� ������ � ������� Orders, 
-- ��� � ������� EmployeeID ������ �������� ��� ������� ��������. 
-- � ����������� ������� ���� ����������� ������� � ������ �������� 
-- (������ ������������� ��� ���������� ������������� LastName & FirstName. 
-- ��� ������ LastName & FirstName ������ ���� �������� ��������� �������� 
-- � ������� ��������� �������. ����� �������� ������ ������ ������������ 
-- ����������� �� EmployeeID.) � ��������� ������� �Seller� � ������� 
-- c ����������� ������� ����������� � ��������� 'Amount'.
-- ���������� ������� ������ ���� ����������� �� �������� ���������� �������.
SELECT
(SELECT FirstName+LastName FROM Employees WHERE EmployeeID=Orders.EmployeeID) Seller,
COUNT(*) Amount
FROM Orders
GROUP BY EmployeeID
ORDER BY Amount DESC

-- 6.c
-- �� ������� Orders ����� ���������� �������, c�������� ������ ��������� � ��� ������� ����������. 
-- ���������� ���������� ��� ������ ��� ������� ��������� � 1998 ����. 
-- � ����������� ������� ���� ����������� ������� � ������ �������� 
-- (�������� ������� �Seller�), ������� � ������ ���������� (�������� ������� �Customer�)  
-- � ������� c ����������� ������� ����������� � ��������� 'Amount'. 
-- � ������� ���������� ������������ ����������� �������� ����� T-SQL 
-- ��� ������ � ���������� GROUP (���� �� �������� ������� �������� ������ �ALL� 
-- � ����������� �������). ����������� ������ ���� ������� �� ID �������� � ����������.
-- ���������� ������� ������ ���� ����������� �� ��������, ���������� � �� �������� ���������� ������. 
-- � ����������� ������ ���� ������� ���������� �� ��������. 
-- �.�. � �������������� ������ ������ �������������� ������������� 
-- � ���������� � �������� �������� ��� ������� ���������� ��������� �������:
-- Seller                         Customer                             Amount
-- ALL                            ALL                                  <����� ����� ������>
-- <���>							 ALL                                  <����� ������ ��� ������� ��������>
-- ALL                           <���>                                 <����� ������ ��� ������� ����������>
-- <���>							<���>                                 <����� ������ ������� �������� ��� ������� ����������>
SELECT
CASE (SELECT FirstName+LastName FROM Employees WHERE EmployeeID=Orders.EmployeeID) WHEN NULL THEN 'ALL' ELSE (SELECT FirstName+LastName FROM Employees WHERE EmployeeID=Orders.EmployeeID) END Seller,
CASE (SELECT ContactName FROM Customers WHERE CustomerID=Orders.CustomerID) WHEN NULL THEN 'ALL' ELSE (SELECT ContactName FROM Customers WHERE CustomerID=Orders.CustomerID) END Customer,
COUNT(*) Amount
FROM Orders
WHERE YEAR(OrderDate)=1998
GROUP BY GROUPING SETS (EmployeeID, CustomerID,())

-- 6.d
-- ����� ����������� � ���������, ������� ����� � ����� ������. 
-- ���� � ������ ����� ������ ���� ��� ��������� ��������� ��� ������ ���� ��� ��������� �����������, 
-- �� ���������� � ����� ���������� � ��������� �� ������ �������� � �������������� �����. 
-- �� ������������ ����������� JOIN. � ����������� ������� ���������� ������� ��������� ��������� ��� ����������� �������: 
-- �Person�, �Type� (����� ���� �������� ������ �Customer� ���  �Seller� � ����������� �� ���� ������), �City�. 
-- ������������� ���������� ������� �� ������� �City� � �� �Person�.
SELECT  
	ContactName Person,
	'Customer' Type,
	City
FROM 
	Customers
WHERE 
	(SELECT COUNT(*) FROM Employees WHERE Employees.City=Customers.City)>1 
UNION
SELECT  
	FirstName+LastName Person,
	'Seller' Type,
	City
FROM 
	Employees
WHERE 
	(SELECT COUNT(*) FROM Customers WHERE Employees.City=Customers.City)>1 
ORDER BY City

-- 6.e
-- ����� ���� �����������, ��� ������� ���� ������ ����������, �������� � ��� �� ������. 
-- � ������� ������������ ���������� ������� Customers c ����� - ��������������. 
-- ��������� ������� CustomerID � City. ������ �� ������ ����������� ����������� ������. 
-- ��� �������� �������� ������, ������� ����������� ������, ������� ����������� ����� ������ ���� � ������� Customers. 
-- ��� �������� ��������� ������������ �������.
SELECT
	City,
	COUNT(*) CustomersCount
FROM Customers
GROUP BY City
HAVING COUNT(*)>1

SELECT  
	CustomerID,
	City
FROM 
	Customers
WHERE 
	(SELECT COUNT(*) FROM Customers C1 WHERE C1.City=Customers.City)>1
ORDER BY City

-- 6.f
-- �� ������� Employees ����� ��� ������� �������� ��� ������������, 
-- �.�. ���� �� ������ �������. ��������� ������� � ������� 'User Name' (LastName) � 'Boss'. 
-- � �������� ������ ���� ��������� ����� �� ������� LastName
SELECT
	LastName UserName,
	(SELECT LastName Boss FROM Employees Bosses WHERE Bosses.EmployeeID=Employees.ReportsTo)
FROM 
	Employees
EXCEPT
SELECT
	LastName UserName,
	(SELECT LastName Boss FROM Employees Bosses WHERE Bosses.EmployeeID=Employees.ReportsTo)
FROM 
	Employees
WHERE ReportsTo IS NULL

-- 7.a
-- ���������� ���������, ������� ����������� ������ 'Western' (������� Region). 
-- ���������� ������� ������ ����������� ��� ����: 'LastName' �������� � �������� ������������� ���������� ('TerritoryDescription' �� ������� Territories). 
-- ������ ������ ������������ JOIN � ����������� FROM. 
-- ��� ����������� ������ ����� ��������� Employees � Territories ���� ������������ ����������� ��������� ��� ���� Northwind.
SELECT 
	LastName,
	TerritoryDescription
FROM 
	Employees
INNER JOIN EmployeeTerritories
	ON EmployeeTerritories.EmployeeID=Employees.EmployeeID
INNER JOIN Territories
	ON Territories.TerritoryID=EmployeeTerritories.TerritoryID
INNER JOIN Region
	ON Region.RegionID=Territories.RegionID
WHERE Region.RegionDescription='Western'

-- 8.a
-- ��������� � ����������� ������� ����� ���� ���������� �� ������� Customers � ��������� ���������� �� ������� �� ������� Orders. 
-- ������� �� ��������, ��� � ��������� ���������� ��� �������, �� ��� ����� ������ ���� �������� � ����������� �������. 
-- ����������� ���������� ������� �� ����������� ���������� �������.
SELECT 
	ContactName,
	Count(OrderID) OrdersCount
FROM 
	Customers
LEFT JOIN Orders
	ON Customers.CustomerID=Orders.CustomerID
GROUP BY ContactName
ORDER BY OrdersCount

-- 9.a
-- ��������� ���� ����������� ������� CompanyName � ������� Suppliers, 
-- � ������� ��� ���� �� ������ �������� �� ������ (UnitsInStock � ������� Products ����� 0). 
-- ������������ ��������� SELECT ��� ����� ������� � �������������� ��������� IN. 
-- ����� �� ������������ ������ ��������� IN �������� '=' ?
SELECT
	CompanyName
FROM 
	Suppliers
WHERE SupplierID IN 
	(SELECT 
		SupplierID 
	FROM 
		Products 
	WHERE UnitsInStock=0)

-- 10.a
-- ��������� ���� ���������, ������� ����� ����� 150 �������. 
-- ������������ ��������� ��������������� SELECT.
SELECT
	LastName
FROM Employees
WHERE
	(SELECT COUNT(*) FROM Orders WHERE Orders.EmployeeID=Employees.EmployeeID)>150

-- 11.a
-- ��������� ���� ���������� (������� Customers), ������� �� ����� �� ������ ������ (��������� �� ������� Orders). 
-- ������������ ��������������� SELECT � �������� EXISTS.
SELECT 
	ContactName 
FROM 
	Customers
WHERE
	NOT EXISTS (SELECT * FROM Orders WHERE Orders.CustomerID=Customers.CustomerID)

-- 12.a
-- ��� ������������ ����������� ��������� Employees ��������� �� 
-- ������� Employees ������ ������ ��� ���� ��������, 
-- � ������� ���������� ������� Employees (������� LastName ) �� ���� �������. 
-- ���������� ������ ������ ���� ������������ �� �����������.
SELECT
	DISTINCT LEFT(LastName,1) Symbol
FROM
	Employees
ORDER BY Symbol