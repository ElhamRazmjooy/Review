-- UNNORMALIZED TABLE
CREATE TABLE Order_Unnormalized
(
	OrderId INT,
    CustomerName NVARCHAR(100),
    CustomerPhone NVARCHAR(20),
    ProductId INT,
    ProductName NVARCHAR(100),
    Quantity INT,
    CityId INT,
    CityName NVARCHAR(100)
);
GO
--NORMALIZED TABLE
CREATE TABLE Customers
(
	Id INT PRIMARY KEY,
	CustomerName NVARCHAR(100) NOT NULL,
    CustomerPhone NVARCHAR(20),
	CityId INT
);
GO
CREATE TABLE CustomerPhones
(
	Id INT PRIMARY KEY,
	CustomerId INT,
	Phone NVARCHAR(20),

	FOREIGN KEY(CustomerId)
		REFERENCES Customers(Id)
);
GO
CREATE TABLE Products
(
	Id INT PRIMARY KEY,
	ProductName NVARCHAR(100) NOT NULL
);
GO
CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY,
	CustomerId INT NOT NULL,

	FOREIGN KEY (CustomerId)
        REFERENCES Customers(Id)
);
GO
CREATE TABLE OrderDetails
(
	OrderId INT NOT NULL,
	ProductId INT NOT NULL,
    Quantity INT NOT NULL,

	PRIMARY KEY (OrderId, ProductId),

    FOREIGN KEY (OrderId)
        REFERENCES Orders(OrderId),

    FOREIGN KEY (ProductId)
        REFERENCES Products(Id)
);
GO
CREATE TABLE Cities
(
	CityId INT PRIMARY KEY,
	CityName NVARCHAR(100) NOT NULL
);
GO
--Customer now references City
ALTER TABLE Customers
ADD CONSTRAINT FK_Customers_Cities
FOREIGN KEY (CityId)
REFERENCES Cities(CityId);
GO