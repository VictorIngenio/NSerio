CREATE PROCEDURE GetProducts
AS
BEGIN
	SET NOCOUNT ON;

	SELECT productid, productname FROM Production.Products
END
GO
-- =============================================
CREATE PROCEDURE GetShippers
AS
BEGIN
	SET NOCOUNT ON;

	SELECT shipperid, companyname FROM Sales.Shippers
END
GO
-- =============================================
CREATE PROCEDURE GetEmployees
AS
BEGIN
	SET NOCOUNT ON;

	SELECT empid, firstname + ' ' + lastname as FullName FROM HR.Employees
END
GO
-- =============================================
CREATE PROCEDURE OrderByCustomerId
	@custid int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT orderid, requireddate, shippeddate, shipname, shipaddress, shipcity FROM Sales.Orders where custid = @custid
END
GO
-- =============================================
CREATE PROCEDURE [dbo].[InsertNewOrder]
	@Custid int,
	@Empid int,
	@Shipperid int,
	@Shipname nvarchar(40),
	@Shipaddress nvarchar(60),
	@Shipcity nvarchar(15),
	@Orderdate datetime,
	@Requireddate datetime,
	@Shippeddate datetime,
	@Freight money,
	@Shipcountry nvarchar(15),
	@Productid int,
	@Unitprice money,
	@Qty smallint,
	@Discount numeric(4,3)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @Orderid int

	INSERT INTO Sales.Orders (custid, empid, shipperid, shipname, shipaddress, shipcity, orderdate, requireddate, shippeddate, 
							  freight, shipcountry)
	VALUES (@Custid, @Empid, @Shipperid, @Shipname, @Shipaddress, @Shipcity, @Orderdate, @Requireddate, @Shippeddate, @Freight, 
			@Shipcountry)

	SET @Orderid = (SELECT SCOPE_IDENTITY());

	INSERT INTO Sales.OrderDetails (orderid, productid, unitprice, qty, discount)
	VALUES (@Orderid, @Productid, @Unitprice, @Qty, CONVERT(numeric(4,3), @Discount))
END
GO