SELECT DISTINCT emp.EmployeeID, LastName--, ter.TerritoryID, ter.TerritoryDescription
	FROM Northwind.Employees emp
JOIN Northwind.EmployeeTerritories et
ON emp.EmployeeID = et.EmployeeID
JOIN Northwind.Territories ter
ON et.TerritoryID = ter.TerritoryID
JOIN Northwind.Region reg
ON reg.RegionID = ter.RegionID
WHERE reg.RegionDescription = 'Western'