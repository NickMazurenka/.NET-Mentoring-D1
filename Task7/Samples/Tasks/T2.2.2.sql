SELECT emp.EmployeeID, FirstName +' '+ LastName as Seller, COUNT(ord.OrderID) as Amount
FROM Northwind.Employees emp
JOIN Northwind.Orders ord
ON ord.EmployeeID = emp.EmployeeID
GROUP BY emp.EmployeeID, FirstName, LastName
ORDER BY Amount DESC