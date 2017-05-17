SELECT EmployeeID, FirstName, LastName FROM Northwind.Employees
WHERE EmployeeID IN (SELECT EmployeeID FROM Northwind.Orders GROUP BY EmployeeID HAVING COUNT(EmployeeID) > 100 )