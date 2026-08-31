USE SampleDb;
GO
CREATE TABLE Orders
(
    Id INT PRIMARY KEY,
    CustomerId INT,
    ProductName NVARCHAR(100),
    Price DECIMAL(10, 2)
);
GO
INSERT INTO Orders (Id, CustomerId, ProductName, Price)
VALUES
    (1, 1, N'Laptop', 50000),
    (2, 1, N'Mouse', 1500),
    (3, 3, N'Keyboard', 3000);
GO
--INNER JOIN
SELECT
	C.Name, C.City, O.ProductName, o.Price
FROM dbo.Customers AS C
INNER JOIN dbo.Orders AS O
	ON C.Id = O.CustomerId;
GO
--LEFT JOIN 1
SELECT
	C.Name, C.City, O.ProductName, o.Price
FROM dbo.Customers AS C
LEFT JOIN dbo.Orders AS O
	ON C.Id = O.CustomerId;
GO
--LEFT JOIN 2
SELECT
	O.ProductName, o.Price, C.Name, C.City
FROM dbo.Orders AS O
LEFT JOIN dbo.Customers AS C
	ON O.CustomerId = C.Id;
GO
