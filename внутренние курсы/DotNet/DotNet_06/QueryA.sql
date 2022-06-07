USE Northwind

-- 1.a
-- Выбрать в таблице Orders заказы, которые были доставлены после 6 мая 1998 года (колонка ShippedDate) включительно и которые доставлены с ShipVia >= 2. 
-- Формат указания даты должен быть верным при любых региональных настройках, 
-- согласно требованиям статьи “Writing International Transact-SQL Statements” в Books Online раздел “Accessing and Changing Relational Data Overview”. 
-- Этот метод использовать далее для всех заданий. Запрос должен высвечивать только колонки OrderID, ShippedDate и ShipVia.
-- Пояснить почему сюда не попали заказы с NULL-ом в колонке ShippedDate.
SELECT
	OrderID,
	ShippedDate,
	ShipVia
FROM Orders
WHERE ShipVia>=2
AND ShippedDate>=DATEFROMPARTS(1998,5,6)

-- 1.b
-- Написать запрос, который выводит только недоставленные заказы из таблицы Orders. 
-- В результатах запроса высвечивать для колонки ShippedDate 
-- вместо значений NULL строку ‘Not Shipped’ – использовать системную функцию CASЕ. 
-- Запрос должен высвечивать только колонки OrderID и ShippedDate.
SELECT
	OrderID,
	CASE WHEN ShippedDate IS NULL THEN 'Not Shipped'
	ELSE CAST(ShippedDate AS nvarchar)
	END AS ShippedDate
FROM Orders
WHERE Orders.ShippedDate IS NULL

-- 1.с
-- Выбрать в таблице Orders заказы, 
-- которые были доставлены после 6 мая 1998 года (ShippedDate), 
-- не включая эту дату, или которые еще не доставлены. 
-- В запросе должны высвечиваться только колонки OrderID (переименовать в Order Number)
-- и ShippedDate (переименовать в Shipped Date). В результатах запроса высвечивать для колонки ShippedDate
-- вместо значений NULL строку ‘Not Shipped’, для остальных значений высвечивать дату в формате по умолчанию.
SELECT
	OrderID AS 'Order Number',
	CASE WHEN ShippedDate IS NULL THEN 'Not Shipped'
	ELSE CAST(ShippedDate AS nvarchar)
	END AS 'Shipped Date'
FROM Orders
WHERE Orders.ShippedDate IS NULL
OR Orders.ShippedDate>DATEFROMPARTS(1998,5,6)

-- 2.a
-- Выбрать из таблицы Customers всех заказчиков, проживающих в USA и Canada. 
-- Запрос сделать только с помощью оператора IN. 
-- Высвечивать колонки с именем пользователя и названием страны в результатах запроса. 
-- Упорядочить результаты запроса по имени заказчиков и по месту проживания.
SELECT 
	ContactName,
	Country
FROM Customers
WHERE Country IN ('USA','Canada')
ORDER BY ContactName, Country

-- 2.b
-- Выбрать из таблицы Customers всех заказчиков, не проживающих в USA и Canada. 
-- Запрос сделать с помощью оператора IN. 
-- Высвечивать колонки с именем пользователя и названием страны в результатах запроса. 
-- Упорядочить результаты запроса по имени заказчиков.
SELECT 
	ContactName,
	Country
FROM Customers
WHERE Country NOT IN ('USA','Canada')
ORDER BY ContactName

-- 2.c
-- Выбрать из таблицы Customers все страны, в которых проживают заказчики. 
-- Страна должна быть упомянута только один раз, и список отсортирован по убыванию. 
-- Не использовать предложение GROUP BY. 
-- Высвечивать только одну колонку в результатах запроса.
SELECT 
	DISTINCT Country
FROM Customers
ORDER BY Country DESC

-- 3.a
-- Выбрать все заказы (OrderID) из таблицы Order Details (заказы не должны повторяться),
-- где встречаются продукты с количеством от 3 до 10 включительно – это колонка Quantity в таблице Order Details. 
-- Использовать оператор BETWEEN. Запрос должен высвечивать только колонку OrderID.
SELECT 
	DISTINCT OrderID
FROM [Order Details]
WHERE Quantity BETWEEN 3 AND 10

-- 3.b
-- Выбрать всех заказчиков из таблицы Customers,
-- у которых название страны начинается на буквы из диапазона b и g. 
-- Использовать оператор BETWEEN. Проверить,
-- что в результаты запроса попадает Germany. 
-- Запрос должен высвечивать только колонки CustomerID и Country 
-- и отсортирован по Country.
SELECT 
	CustomerID,
	Country
	FROM Customers
WHERE SUBSTRING(Country,1,1) BETWEEN 'b' AND 'g'
ORDER BY Country

-- 3.c
-- Выбрать всех заказчиков из таблицы Customers,
-- у которых название страны начинается на буквы из диапазона b и g, 
-- не используя оператор BETWEEN. С помощью опции “Execution Plan” определить какой запрос предпочтительнее 3.2 или 3.3
-- – для этого надо ввести в скрипт выполнение текстового Execution Plan-a для двух этих запросов,
-- результаты выполнения Execution Plan надо ввести в скрипт в виде комментария и по их результатам дать ответ на вопрос 
-- – по какому параметру было проведено сравнение. Запрос должен высвечивать только колонки CustomerID и Country и отсортирован по Country.
SELECT 
	CustomerID,
	Country
	FROM Customers
WHERE SUBSTRING(Country,1,1) >= 'b' AND SUBSTRING(Country,1,1) <='g'
ORDER BY Country

-- при сравнении эффектиности запросов результаты статистики были одинаковыми

-- 4.a
-- В таблице Products найти все продукты (колонка ProductName), 
-- где встречается подстрока 'chocolade'. 
-- Известно, что в подстроке 'chocolade' может быть изменена одна буква 'c' в середине - 
-- найти все продукты, которые удовлетворяют этому условию. 
-- Подсказка: результаты запроса должны высвечивать 2 строки.
SELECT * FROM Products
WHERE ProductName LIKE '%cho_olade%'
--WHERE ProductName LIKE '%cho_ola_e%'

-- 5.a
-- Найти общую сумму всех заказов из таблицы Order Details с учетом количества закупленных товаров и скидок по ним. 
-- Результат округлить до сотых и высветить в стиле 1 для типа данных money.  
-- Скидка (колонка Discount) составляет процент из стоимости для данного товара. 
-- Для определения действительной цены на проданный продукт надо вычесть скидку из указанной в колонке UnitPrice цены. 
-- Результатом запроса должна быть одна запись с одной колонкой с названием колонки 'Totals'.
SELECT 
	ROUND(SUM((UnitPrice-(UnitPrice*Discount))*Quantity),2) Totals
FROM [Order Details]

-- 5.b
-- По таблице Orders найти количество заказов, которые еще не были доставлены 
-- (т.е. в колонке ShippedDate нет значения даты доставки). 
-- Использовать при этом запросе только оператор COUNT. 
-- Не использовать предложения WHERE и GROUP.
SELECT
	COUNT(CASE WHEN ShippedDate IS NULL THEN 1 ELSE NULL END) 'Not shipped orders count'
FROM Orders

-- 5.c
-- По таблице Orders найти количество различных покупателей (CustomerID), сделавших заказы. 
-- Использовать функцию COUNT и не использовать предложения WHERE и GROUP
SELECT
	COUNT(DISTINCT CustomerID) 'Customers count'
FROM Orders

-- 6.a
-- По таблице Orders найти количество заказов с группировкой по годам. 
-- В результатах запроса надо высвечивать две колонки c названиями Year и Total. 
-- Написать проверочный запрос, который вычисляет количество всех заказов.
SELECT			-- проверочный запрос
	COUNT(*) Total
FROM Orders

SELECT 
	YEAR(OrderDate) AS YYear,
	COUNT(*) Total
FROM Orders
GROUP BY YEAR(OrderDate)

-- 6.b
-- По таблице Orders найти количество заказов, cделанных каждым продавцом. 
-- Заказ для указанного продавца – это любая запись в таблице Orders, 
-- где в колонке EmployeeID задано значение для данного продавца. 
-- В результатах запроса надо высвечивать колонку с именем продавца 
-- (Должно высвечиваться имя полученное конкатенацией LastName & FirstName. 
-- Эта строка LastName & FirstName должна быть получена отдельным запросом 
-- в колонке основного запроса. Также основной запрос должен использовать 
-- группировку по EmployeeID.) с названием колонки ‘Seller’ и колонку 
-- c количеством заказов высвечивать с названием 'Amount'.
-- Результаты запроса должны быть упорядочены по убыванию количества заказов.
SELECT
(SELECT FirstName+LastName FROM Employees WHERE EmployeeID=Orders.EmployeeID) Seller,
COUNT(*) Amount
FROM Orders
GROUP BY EmployeeID
ORDER BY Amount DESC

-- 6.c
-- По таблице Orders найти количество заказов, cделанных каждым продавцом и для каждого покупателя. 
-- Необходимо определить это только для заказов сделанных в 1998 году. 
-- В результатах запроса надо высвечивать колонку с именем продавца 
-- (название колонки ‘Seller’), колонку с именем покупателя (название колонки ‘Customer’)  
-- и колонку c количеством заказов высвечивать с названием 'Amount'. 
-- В запросе необходимо использовать специальный оператор языка T-SQL 
-- для работы с выражением GROUP (Этот же оператор поможет выводить строку “ALL” 
-- в результатах запроса). Группировки должны быть сделаны по ID продавца и покупателя.
-- Результаты запроса должны быть упорядочены по продавцу, покупателю и по убыванию количества продаж. 
-- В результатах должна быть сводная информация по продажам. 
-- Т.е. в результирующем наборе должны присутствовать дополнительно 
-- к информации о продажах продавца для каждого покупателя следующие строчки:
-- Seller                         Customer                             Amount
-- ALL                            ALL                                  <общее число продаж>
-- <имя>							 ALL                                  <число продаж для данного продавца>
-- ALL                           <имя>                                 <число продаж для данного покупателя>
-- <имя>							<имя>                                 <число продаж данного продавца для данного покупателя>
SELECT
CASE (SELECT FirstName+LastName FROM Employees WHERE EmployeeID=Orders.EmployeeID) WHEN NULL THEN 'ALL' ELSE (SELECT FirstName+LastName FROM Employees WHERE EmployeeID=Orders.EmployeeID) END Seller,
CASE (SELECT ContactName FROM Customers WHERE CustomerID=Orders.CustomerID) WHEN NULL THEN 'ALL' ELSE (SELECT ContactName FROM Customers WHERE CustomerID=Orders.CustomerID) END Customer,
COUNT(*) Amount
FROM Orders
WHERE YEAR(OrderDate)=1998
GROUP BY GROUPING SETS (EmployeeID, CustomerID,())

-- 6.d
-- Найти покупателей и продавцов, которые живут в одном городе. 
-- Если в городе живут только один или несколько продавцов или только один или несколько покупателей, 
-- то информация о таких покупателя и продавцах не должна попадать в результирующий набор. 
-- Не использовать конструкцию JOIN. В результатах запроса необходимо вывести следующие заголовки для результатов запроса: 
-- ‘Person’, ‘Type’ (здесь надо выводить строку ‘Customer’ или  ‘Seller’ в зависимости от типа записи), ‘City’. 
-- Отсортировать результаты запроса по колонке ‘City’ и по ‘Person’.
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
-- Найти всех покупателей, для которых есть другие покупатели, живующие в том же городе. 
-- В запросе использовать соединение таблицы Customers c собой - самосоединение. 
-- Высветить колонки CustomerID и City. Запрос не должен высвечивать дублируемые записи. 
-- Для проверки написать запрос, который высвечивает города, которые встречаются более одного раза в таблице Customers. 
-- Это позволит проверить правильность запроса.
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
-- По таблице Employees найти для каждого продавца его руководителя, 
-- т.е. кому он делает репорты. Высветить колонки с именами 'User Name' (LastName) и 'Boss'. 
-- В колонках должны быть высвечены имена из колонки LastName
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
-- Определить продавцов, которые обслуживают регион 'Western' (таблица Region). 
-- Результаты запроса должны высвечивать два поля: 'LastName' продавца и название обслуживаемой территории ('TerritoryDescription' из таблицы Territories). 
-- Запрос должен использовать JOIN в предложении FROM. 
-- Для определения связей между таблицами Employees и Territories надо использовать графические диаграммы для базы Northwind.
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
-- Высветить в результатах запроса имена всех заказчиков из таблицы Customers и суммарное количество их заказов из таблицы Orders. 
-- Принять во внимание, что у некоторых заказчиков нет заказов, но они также должны быть выведены в результатах запроса. 
-- Упорядочить результаты запроса по возрастанию количества заказов.
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
-- Высветить всех поставщиков колонка CompanyName в таблице Suppliers, 
-- у которых нет хотя бы одного продукта на складе (UnitsInStock в таблице Products равно 0). 
-- Использовать вложенный SELECT для этого запроса с использованием оператора IN. 
-- Можно ли использовать вместо оператора IN оператор '=' ?
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
-- Высветить всех продавцов, которые имеют более 150 заказов. 
-- Использовать вложенный коррелированный SELECT.
SELECT
	LastName
FROM Employees
WHERE
	(SELECT COUNT(*) FROM Orders WHERE Orders.EmployeeID=Employees.EmployeeID)>150

-- 11.a
-- Высветить всех заказчиков (таблица Customers), которые не имеют ни одного заказа (подзапрос по таблице Orders). 
-- Использовать коррелированный SELECT и оператор EXISTS.
SELECT 
	ContactName 
FROM 
	Customers
WHERE
	NOT EXISTS (SELECT * FROM Orders WHERE Orders.CustomerID=Customers.CustomerID)

-- 12.a
-- Для формирования алфавитного указателя Employees высветить из 
-- таблицы Employees список только тех букв алфавита, 
-- с которых начинаются фамилии Employees (колонка LastName ) из этой таблицы. 
-- Алфавитный список должен быть отсортирован по возрастанию.
SELECT
	DISTINCT LEFT(LastName,1) Symbol
FROM
	Employees
ORDER BY Symbol