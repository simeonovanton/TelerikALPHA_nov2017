
SELECT p.ProductName, P.UnitPrice, c.CategoryName
FROM Products p
FULL OUTER JOIN Categories c
ON c.CategoryID = p.CategoryID
WHERE p.UnitPrice = 
(
SELECT MAX(p1.UnitPrice)
FROM Products p1
JOIN Products p2
ON c.CategoryID = p1.CategoryID
)
ORDER BY p.UnitPrice
