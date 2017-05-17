SELECT EmployeeID, SupplierID FROM Northwind.Employees emp
JOIN Northwind.Suppliers sup
ON emp.ReportsTo = sup.SupplierID