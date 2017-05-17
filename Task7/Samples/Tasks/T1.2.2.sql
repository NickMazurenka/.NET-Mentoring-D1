select ContactName, Country from Northwind.Customers
WHERE Country NOT IN ('USA', 'Canada')
ORDER BY ContactName