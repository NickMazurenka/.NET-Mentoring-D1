SELECT year(OrderDate) as [Year], COUNT(*) as Total
FROM Northwind.Orders
GROUP BY year(OrderDate)
--Alt
SELECT [Year], COUNT(*) as Total
FROM (SELECT year(OrderDate) as [Year] FROM Northwind.Orders) sub
GROUP BY [Year]