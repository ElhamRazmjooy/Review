--Scalar-Value
CREATE FUNCTION dbo.CalculatePriceWithTax
(
	@Price DECIMAL(10, 2),
	@TaxPercent DECIMAL(5, 2)
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
	RETURN @Price + (@Price * @TaxPercent/100)
END;
GO
SELECT dbo.CalculatePriceWithTax(20000, 10) AS FinalPrice;
GO

CREATE FUNCTION dbo.GetFullName
(
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50)
)
RETURNS NVARCHAR(101)
AS
BEGIN
	RETURN @FirstName + ' ' + @LastName
END;
GO
SELECT dbo.GetFullName('Elham','Razmjooy') AS FullName;
GO
CREATE TABLE Products
(
    Id INT PRIMARY KEY,
    Name NVARCHAR(100),
    Price DECIMAL(10, 2)
);
GO
--InlineTable-Value
CREATE FUNCTION dbo.GetProductsByPriceRange
(
	@MinPrice DECIMAL(10, 2),
	@MaxPrice DECIMAL(10, 2)
)
RETURNS TABLE
AS
RETURN
	(SELECT
		Id, Name, Price
	FROM Products
	WHERE Price BETWEEN @MinPrice AND @MaxPrice);
GO
SELECT * FROM dbo.GetProductsByPriceRange(500, 1000);
GO
--Multi Statement Table-Value
CREATE FUNCTION dbo.GetProductsAbovePrice
(
	@MinPrice DECIMAL(10, 2)
)
RETURNS TABLE
AS
	RETURN
	(SELECT
		Id, Name, Price
	FROM Products
	WHERE Price >= @MinPrice);
GO
SELECT * FROM dbo.GetProductsAbovePrice(100);
GO