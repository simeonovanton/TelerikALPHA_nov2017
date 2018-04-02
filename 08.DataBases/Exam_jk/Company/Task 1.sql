USE Company
GO

SELECT FirstName + ' ' + LastName [Employee], YearSalary FROM Employees
	WHERE YearSalary BETWEEN 100000 AND 150000
	ORDER BY YearSalary