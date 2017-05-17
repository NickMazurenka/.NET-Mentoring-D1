SELECT CompanyName FROM Northwind.Suppliers
WHERE SupplierID IN (SELECT SupplierID FROM Northwind.Products WHERE UnitsInStock = 0)
-- Alternative
SELECT CompanyName FROM Northwind.Suppliers sup
JOIN Northwind.Products prd
ON sup.SupplierID = prd.SupplierID
WHERE UnitsInStock = 0