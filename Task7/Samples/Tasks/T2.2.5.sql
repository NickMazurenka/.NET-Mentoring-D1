SELECT City, CustomerID FROM Northwind.Customers
WHERE City IN (SELECT City FROM Northwind.Customers GROUP BY City HAVING Count(CustomerID) > 1)
ORDER BY City