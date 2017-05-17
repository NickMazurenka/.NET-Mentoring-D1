SELECT EmployeeID, CustomerID, COUNT(*) as Amount FROM Northwind.Orders
WHERE year(OrderDate) = 1998
GROUP BY EmployeeID, CustomerID
--HAVING COUNT(*) > 2 -- Show only those, who have more than 2 orders