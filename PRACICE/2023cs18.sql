-- AVG: Calculate the average unit price of all products
Select AVG(UnitPrice) from Products
-- MIN: Find the minimum unit price among all products
Select Min(UnitPrice) from Products
-- MAX: Retrieve the maximum unit price among all products
Select Max(UnitPrice) from Products
-- SUM: Calculate the total sum of unit prices for all products
Select Sum(UnitPrice) from Products
-- COUNT: Count the number of products in the database
Select count(UnitPrice) from Products
-- STDEV: Determine the standard deviation of unit prices for all products
select STDEV(UnitPrice) from Products
-- STDEVP: Calculate the standard deviation of unit prices for all products using the entire population
Select STDEVP(UnitPrice) from Products
-- VAR: Find the variance of unit prices for all products
select VAR(UnitPrice) from Products
-- VARP: Calculate the variance of unit prices for all products using the entire population
select VARP(UnitPrice) from Products

-----------------------------------------------THE GROUP BY CLAUSE------------------------------------------------



-- Purpose: Retrieve the average unit price for each supplier
SELECT SupplierID, AVG(UnitPrice) AS AverageUnitPrice FROM Products GROUP BY SupplierID;
-- Purpose: Retrieve the average unit price for each supplier, only include those with an average unit price greater than 50
-------------------------------------------------HAVING CLAUSE---------------------------
SELECT SupplierID, AVG(UnitPrice) AS AverageUnitPrice FROM Products GROUP BY SupplierID HAVING AVG(UnitPrice) > 50;

-- Purpose: Find the minimum unit price among all products, only include those with a minimum unit price less than 10
SELECT CategoryID, MIN(UnitPrice) AS MinimumUnitPrice FROM Products GROUP BY CategoryID HAVING MIN(UnitPrice) < 10;



-- Purpose: Count the number of orders for each customer, only include customers with more than 5 orders
SELECT CustomerID, COUNT(*) AS OrderCount FROM Orders GROUP BY CustomerID HAVING COUNT(*) > 5;



------------------------------------------ALIASING TABLES AND COLUMNS--------------------------------


-- Purpose: Determine the standard deviation of unit prices for each supplier, only include those with a standard deviation greater than 10
SELECT SupplierID, STDEV(UnitPrice) AS StdDevUnitPrice FROM Products GROUP BY SupplierID HAVING STDEV(UnitPrice) > 10;

-- Purpose: Calculate the standard deviation of unit prices for each category, only include those with a standard deviation greater than 5
SELECT CategoryID, STDEVP(UnitPrice) AS StdDevPopulationUnitPrice FROM Products GROUP BY CategoryID HAVING STDEVP(UnitPrice) > 5;

-- Purpose: Find the variance of unit prices for each supplier only include those with a variance greater than 100
SELECT SupplierID, VAR(UnitPrice) AS VarianceUnitPrice FROM Products GROUP BY SupplierID HAVING VAR(UnitPrice) > 100;

-- Purpose: Calculate the variance of unit prices for each category include those with a variance greater than 50
SELECT CategoryID, VARP(UnitPrice) AS VariancePopulationUnitPrice FROM Products GROUP BY CategoryID HAVING VARP(UnitPrice) > 50;

-- Purpose: Retrieve the maximum unit price for each supplier
SELECT SupplierID, MAX(UnitPrice) AS MaximumUnitPrice FROM Products GROUP BY SupplierID HAVING MAX(UnitPrice) > 80;


-- Purpose: Grouping customers by the Country column and counting only those with more than 2 orders
SELECT Country, COUNT(*) AS OrderCount FROM Customers

JOIN Orders ON Customers.CustomerID = Orders.CustomerID GROUP BY Country HAVING COUNT(*) > 2;





-----------------------------------------FOOD FOR BRAIN--------------------------------------------
-- Purpose: Extract the year from the OrderDate column in the Orders table
SELECT OrderID, OrderDate, YEAR(OrderDate) AS OrderYear FROM Orders
-- Purpose: Extract the month from the OrderDate column in the Orders table
SELECT OrderID, OrderDate, MONTH(OrderDate) AS OrderMonth FROM Orders