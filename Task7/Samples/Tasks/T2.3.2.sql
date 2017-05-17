SELECT cst.CustomerID, cst.ContactName, TotalOrders = COUNT(ord.CustomerID) FROM Northwind.Customers cst
LEFT JOIN Northwind.Orders ord
ON cst.CustomerID = ord.CustomerID
GROUP BY cst.CustomerID, cst.ContactName
ORDER BY TotalOrders