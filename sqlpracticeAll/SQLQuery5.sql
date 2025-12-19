--1) Create a procedure which accepts input parameter and inserts the data in the customers table

CREATE PROCEDURE custprocedure (@custid INT,@custname VARCHAR(100),@age INT,@caddress VARCHAR(200),@cphone VARCHAR(20))
AS
INSERT INTO customers VALUES (@custid,@custname,@age,@caddress,@cphone);
GO
EXEC custprocedure 901,'Anvith',21,'Vizag','9876543210';

SELECT * FROM customers;

GO
 
 
--2) Create a procedure for orders table, which displays all the purchase made between 1-12-2005 and 2-12-2007 (Accept date as parameter)

CREATE PROCEDURE orderprocedure (@d1 DATE,@d2 DATE)

AS

SELECT * FROM orders WHERE orderdate BETWEEN @d1 AND @d2;

GO

EXEC orderprocedure '2005-12-01','2007-12-02';

GO
 
 
--3) Create a procedure which reads custid as parameter and return qty and product as output parameter

CREATE PROCEDURE getCustOrderSummary (@custid INT,@qty INT OUTPUT,@product VARCHAR(100) OUTPUT)

AS

SELECT TOP 1 @qty = qty,@product = product

FROM orders

WHERE custid = @custid

ORDER BY orderid;

GO

DECLARE @q INT,@p VARCHAR(100);

EXEC getCustOrderSummary 901,@q OUTPUT,@p OUTPUT;

SELECT @q AS qty,@p AS product;

GO
 
 
--4) Write a batch that will check for the existence of the productname “books” if it exists, display the total stock of the book else print “productname books not found”.

DECLARE @TotalStock INT;

IF EXISTS (SELECT 1 FROM products WHERE productname = 'books')

BEGIN

SELECT @TotalStock = SUM(qty) FROM orders WHERE product = 'books';

PRINT 'Total stock of books = ' + CAST(ISNULL(@TotalStock,0) AS VARCHAR(20));

END

ELSE

BEGIN

PRINT 'productname books not found';

END;

GO
 
 
--5) Insert data to customers table via return value of sp_getdata() procedure

CREATE PROCEDURE sp_getdata

AS

BEGIN

DECLARE @NewCustId INT;

SELECT @NewCustId = ISNULL(MAX(custid),0) + 1 FROM customers;

RETURN @NewCustId;

END;

GO

DECLARE @RetCustId INT;

EXEC @RetCustId = sp_getdata;

INSERT INTO customers (custid,custname,age,caddress,cphone)

VALUES (@RetCustId,'Anvith Kumar',21,'Born on 11-04-2004, lives in Vizag','9000000001');

SELECT * FROM customers WHERE custid = @RetCustId;

GO
 
 
--6) Create a procedure to display all customer details where rownumber between 2 to 5 (accept row number as a parameter)

CREATE PROCEDURE getcustdetails (@r1 INT,@r2 INT)

AS

WITH custrow AS

(

SELECT custid,custname,age,caddress,cphone,

ROW_NUMBER() OVER (ORDER BY custid) AS rn

FROM customers

)

SELECT custid,custname,age,caddress,cphone

FROM custrow

WHERE rn BETWEEN @r1 AND @r2;

GO

EXEC getcustdetails 2,5;

GO
 
 
--7) Create a stored procedure to insert a new employee and return newly generated EmpId using SCOPE_IDENTITY()

CREATE TABLE employee

(

EmpId INT IDENTITY(1,1) PRIMARY KEY,

EmpName VARCHAR(100),

DeptId INT,

ManagerId INT,

JoinDate DATE,

Salary DECIMAL(10,2)

);

GO

CREATE PROCEDURE spAddEmployee (@EmpName VARCHAR(100),@DeptId INT,@ManagerId INT,@JoinDate DATE,@Salary DECIMAL(10,2))

AS

BEGIN

INSERT INTO employee (EmpName,DeptId,ManagerId,JoinDate,Salary)

VALUES (@EmpName,@DeptId,@ManagerId,@JoinDate,@Salary);

RETURN SCOPE_IDENTITY();

END;

GO

DECLARE @NewEmpId INT;

EXEC @NewEmpId = spAddEmployee 'Anvith',10,NULL,'2024-06-01',45000.00;

PRINT 'New Employee Id = ' + CAST(@NewEmpId AS VARCHAR(10));

SELECT * FROM employee WHERE EmpId = @NewEmpId;

GO
 
 
--8) Create a stored procedure with default parameter spGetProductsByCategory (WITH ENCRYPTION)

CREATE TABLE Category

(

pid INT IDENTITY(1,1) PRIMARY KEY,

pname VARCHAR(20),

categoryname VARCHAR(40),

price DECIMAL(10,2)

);

GO

INSERT INTO Category (pname,categoryname,price) VALUES

('Laptop','Electronics',55000.00),

('Smartphone','Electronics',22000.00),

('Notebook','Stationery',120.00);

GO

CREATE PROCEDURE spGetProductsByCategory (@CategoryName VARCHAR(40) = 'Electronics')

WITH ENCRYPTION

AS

SELECT pid,pname,categoryname,price

FROM Category

WHERE categoryname = @CategoryName;

GO

EXEC spGetProductsByCategory;

EXEC spGetProductsByCategory 'Stationery';

GO
 
 
--9) Stored procedure using TRY…CATCH Create spSafeOrderInsert; Insert a new order; If any error occurs, insert error details into an ErrorLog table

CREATE TABLE ordertable

(

orderid INT PRIMARY KEY,

custid INT,

orderdate DATE,

product VARCHAR(100),

price DECIMAL(10,2),

qty INT

);

GO

CREATE TABLE Errorlog

(

errorid INT IDENTITY(1,1) PRIMARY KEY,

errornum INT,

errmsg NVARCHAR(4000),

errline INT,

errdate DATETIME

);

GO

CREATE PROCEDURE spSafeOrderInsert (@orderid INT,@custid INT,@od DATE,@pro VARCHAR(100),@price DECIMAL(10,2),@qty INT)

AS

BEGIN TRY

INSERT INTO ordertable (orderid,custid,orderdate,product,price,qty)

VALUES (@orderid,@custid,@od,@pro,@price,@qty);

END TRY

BEGIN CATCH

INSERT INTO Errorlog (errornum,errmsg,errline,errdate)

VALUES (ERROR_NUMBER(),ERROR_MESSAGE(),ERROR_LINE(),GETDATE());

END CATCH;

GO

EXEC spSafeOrderInsert 201,901,'2015-12-02','Books',500.00,2;

EXEC spSafeOrderInsert 201,901,'2015-12-02','Books',500.00,2;

SELECT * FROM ordertable;

SELECT * FROM Errorlog;

GO
 
 
--10) Stored procedure with multiple operations

--Increase employee salary by given percentage and return updated salary

CREATE PROCEDURE spUpdateSalary (@EmpId INT,@Percentage DECIMAL(5,2))

AS

UPDATE Employees

SET Salary = Salary + (Salary * @Percentage / 100.0)

WHERE EmpId = @EmpId;

SELECT EmpId,EmpName,Salary FROM Employees WHERE EmpId = @EmpId;

GO

EXEC spUpdateSalary 1,10.00;

SELECT * FROM Employees;
 