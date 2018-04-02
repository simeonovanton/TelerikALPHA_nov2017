SELECT e.FirstName, e.LastName
FROM Employees e, Employees e1
WHERE e.EmployeeID = e1.ReportsTo
GROUP BY e.FirstName, e.LastName
HAVING COUNT(*) > 2
ORDER BY e.FirstName