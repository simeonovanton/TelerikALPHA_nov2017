USE Company
GO


SELECT d.Name [Department], COUNT(e.EmployeeID) [Employee Count] FROM Departments d
	JOIN Employees e ON d.DepartmentID = e.DepartmentID
	GROUP BY d.Name
	ORDER BY [Employee Count] DESC