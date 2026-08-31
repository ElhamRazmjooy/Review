CREATE DATABASE SampleDb;
GO
USE SampleDb;
GO
CREATE TABLE Customers
(
    Id INT PRIMARY KEY,
    Name NVARCHAR(100),
    City NVARCHAR(100)
);
GO
CREATE TABLE Suppliers
(
    Id INT PRIMARY KEY,
    Name NVARCHAR(100),
    City NVARCHAR(100)
);
GO
INSERT INTO Customers (Id, Name, City)
VALUES
    (1, N'Ali',   N'Tehran'),
    (2, N'Sara',  N'Tabriz'),
    (3, N'Reza',  N'Shiraz'),
    (4, N'Mina',  N'Tehran');
GO
INSERT INTO Suppliers (Id, Name, City)
VALUES
    (1, N'Company A', N'Tehran'),
    (2, N'Company B', N'Rasht'),
    (3, N'Company C', N'Shiraz'),
    (4, N'Company D', N'Isfahan');
GO
--UNION
SELECT City FROM Customers
UNION
SELECT City FROM Suppliers;
GO
--UNION ALL
SELECT City FROM Customers
UNION ALL
SELECT City FROM Suppliers;
GO
--INTERSECT
SELECT City FROM Customers
INTERSECT
SELECT City FROM Suppliers;
GO
--EXCEPT
SELECT City FROM Customers
EXCEPT
SELECT City FROM Suppliers;
GO
SELECT City FROM Suppliers
EXCEPT
SELECT City FROM Customers;
GO