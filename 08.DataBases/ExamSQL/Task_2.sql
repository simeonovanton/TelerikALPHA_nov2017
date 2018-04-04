SELECT TOP(5) p.ProductName, s.CompanyName
FROM Products p, Suppliers s
WHERE p.SupplierID = s.SupplierID
ORDER BY p.ProductName