--SELECT * FROM Northwind.Customers

IF EXISTS (SELECT *
	FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_SCHEMA = 'Northwind'
		AND TABLE_NAME = 'Region')
BEGIN
	EXEC sp_rename 'Northwind.Region', 'Regions'
END

IF NOT EXISTS (SELECT *
	FROM sys.columns
	WHERE Name = 'JoinDate'
		AND Object_ID = Object_ID('Northwind.Customers'))
BEGIN
	ALTER TABLE Northwind.Customers ADD JoinDate DATE NULL
END