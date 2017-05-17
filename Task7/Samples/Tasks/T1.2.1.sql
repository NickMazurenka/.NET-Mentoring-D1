select ContactName, Country from Northwind.Customers
WHERE Country IN ('USA', 'Canada')
ORDER BY Country, ContactName