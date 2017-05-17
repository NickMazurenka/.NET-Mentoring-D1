SELECT * FROM Northwind.Customers c
WHERE NOT EXISTS (SELECT * FROM Northwind.Orders o WHERE c.CustomerID = o.CustomerID)
--Alt
SELECT * FROM Northwind.Customers
WHERE CustomerID NOT IN (SELECT CustomerID FROM Northwind.Orders)