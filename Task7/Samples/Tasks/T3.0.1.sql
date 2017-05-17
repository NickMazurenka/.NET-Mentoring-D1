IF NOT EXISTS (SELECT *
	FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_SCHEMA = 'Northwind'
		AND TABLE_NAME = 'CreditCards')
BEGIN
	CREATE TABLE Northwind.CreditCards
	(CreditCardID INT,
	ExpiryDate DATE,
	CardNumber VARCHAR(20),
	CardHolderName VARCHAR(40),
	EmployeeID INT NOT NULL,
	CONSTRAINT PK_CreditCards PRIMARY KEY (CreditCardID),
	CONSTRAINT PK_CreditCards_Employees FOREIGN KEY (EmployeeID)
		REFERENCES Northwind.Employees (EmployeeID))
END