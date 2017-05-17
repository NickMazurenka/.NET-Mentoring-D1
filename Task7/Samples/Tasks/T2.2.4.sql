-- Hard way
SELECT
	CustomerID,
	(SELECT SupplierID FROM Northwind.Suppliers sup WHERE sup.City = cus.City) as SupplierID,
	City
FROM Northwind.Customers cus
WHERE (SELECT SupplierID FROM Northwind.Suppliers sup WHERE sup.City = cus.City) IS NOT NULL
ORDER BY CustomerID

-- join
SELECT CustomerId, SupplierId, cus.City FROM Northwind.Customers cus
JOIN Northwind.Suppliers sup
ON cus.City = sup.City
ORDER BY CustomerID