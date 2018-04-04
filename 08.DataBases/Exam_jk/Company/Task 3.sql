USE Company
GO

SELECT e.FirstName + ' ' + e.LastName [Employee], p.Name [Project], d.Name [Department],
	
	ep.StartDate [Project start day], ep.EndDate [Project end date], COUNT(r.Time) [Reports Count]

 FROM Projects p
	JOIN EmployeesProjects ep ON p.ProjectID = ep.ProjectID
	JOIN Employees e ON e.EmployeeID = ep.EmployeeID
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
	JOIN Reports r ON e.EmployeeID = r.EmployeeID 

	WHERE r.Time BETWEEN ep.StartDate AND ep.EndDate
	GROUP BY e.EmployeeID,  p.ProjectID,  e.FirstName,  e.LastName,  p.Name, d.Name, ep.StartDate, ep.EndDate

	ORDER BY e.EmployeeID, p.ProjectID