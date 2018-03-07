USE TelerikAcademy

SELECT LastName, e.Salary, e.ManagerID, e.HireDate
FROM Employees e


UPDATE Employees
SET LastName = 'Jil' + SUBSTRING(LastName,4,50)
WHERE LastName LIKE 'Gil%'



SELECT * FROM  Employees
--SET LastName = 'Jil' + SUBSTRING(LastName,4,50)
WHERE LastName LIKE 'Gil%'