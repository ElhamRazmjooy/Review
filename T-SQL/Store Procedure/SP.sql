--Basic Store Procedure
CREATE PROCEDURE dbo.GetProducts
AS
BEGIN
	SELECT
		Id, Name, Price
	FROM Products
END;
GO
EXEC dbo.GetProducts;
GO
--SP With Parameters
CREATE PROCEDURE dbo.GetProductsByMinPrice
	@MinPrice DECIMAL(10, 2)
AS
BEGIN
	SELECT
		Id, Name, Price
	FROM Products
	WHERE Price >= @MinPrice
END;
GO
EXEC dbo.GetProductsByMinPrice 1000;
GO
--SP With CRUD
--Create
CREATE PROCEDURE dbo.CreateProduct
	@Name NVARCHAR(100),
    @Price DECIMAL(10, 2)
AS
BEGIN
	INSERT INTO Products (Name, Price)
    VALUES (@Name, @Price);
END;
GO
EXEC dbo.CreateProduct
    @Name = N'Keyboard',
    @Price = 3000;
GO
--Update
CREATE PROCEDURE dbo.UpdateProduct
	@Id INT,
	@Name NVARCHAR(100),
    @Price DECIMAL(10, 2)
AS
BEGIN
	UPDATE Products
	SET
		Name = @Name,
        Price = @Price
    WHERE Id = @Id;
END;
GO
EXEC dbo.UpdateProduct
	@Id = 1,
    @Name = N'Gaming Keyboard',
    @Price = 4500;
GO
--Delete
CREATE PROCEDURE dbo.DeleteProduct
    @Id INT
AS
BEGIN
    DELETE FROM Products
    WHERE Id = @Id;
END;
GO
EXEC dbo.DeleteProduct @Id = 1;
GO
--OUTPUT VS INPUT
CREATE PROCEDURE dbo.GetProductCount
	@Count INT OUTPUT
AS
BEGIN
	SELECT @Count = COUNT(*)
	FROM Products;
END;
GO

DECLARE @ProductCount INT;

EXEC dbo.GetProductCount
	@Count = @ProductCount OUTPUT;

SELECT @ProductCount AS ProductCount;
GO
