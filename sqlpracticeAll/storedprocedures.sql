--.1) Create a procedure which accepts input parameter and inserts the 
--data in the customer table

create procedure custprocedure (@custId int,@custname varchar(50),
@Age int,@caddress varchar(100),@cphone varchar(15))
as
insert into customers values (@custId,@custname,@Age,@caddress,@cphone)

exec custprocedure 851,'Monika',22,'Vizag',89374935985
select * from customers



--2)Create a procedure for orders table , which displays all the purchase 
--made between 1-12-2005 and 2-12-2007
--(Accept date as parameter_)


create procedure orderprocedure (@d1 date,@d2 date)
as
select * from orders where orderdate between @d1 and @d2
exec orderprocedure '1-12-2005','2-12-2007'

--.3) create a procedure which reads custid as parameter 
--and return qty and produtid as output parameter
create table neworders (orderid int primary key,
custid int,pid int,qty int,products varchar(30))
INSERT INTO neworders
VALUES 
(3, 101, 501, 2, 'Laptop')
alter procedure spGetOrderDetails(@custid int,@qty int output,@productid int output)
as
select top 1 @qty=qty,
@productid=pid from neworders where custid=@custid;
declare @q int,@p int;
exec spGetOrderDetails 101,@q output,@p output;
PRINT @q
PRINT @p

--4)Write a batch that will check for the existence of the productname 
--“books” if it exists, display the total stock of the book else print 
--“productname books not found”.

if exists (select * from orders where product='Books')
begin
declare @totalqty int
select @totalqty= sum(qty)  from orders where product='Books'
print @totalqty
end
else
print 'product name not found'

--.5)insert data to customer table via return value of sp_getdata()
--procedure

alter procedure sp_getdata as
declare @id int
select @id=isnull(max(custid),0)+1 from customers
return @id

declare @newid int
exec @newid=sp_getdata
insert into customers values(@newid,'moni',23,'hyd',354646)
select * from customers

--6)Create a procedure to display all customer details where rownumber 
--between 2 to 5 (accept row number as a parameter)
create procedure getcustdetails(@r1 int,@r2 int) as
with custrow as 
(
select *,row_number() over (order by custid) as rn
from customers 
)
select custid,custname,age,caddress,cphone from custrow
where rn between @r1 and @r2
exec getcustdetails 2,5


--7)Create a stored procedure to insert a new employee
--Create a table Employees and write a stored procedure:
--• Procedure name: spAddEmployee
--• Inputs: Name, Department, Salary
--• Insert the record into Employees table.
--• Return newly generated empID using SCOPE_IDENTITY().
create table employee(empid int identity(1,1) primary key,
empname varchar(50),dept varchar(50),salary decimal(10,2));

create procedure spAddEmployee(@name varchar(50),@department varchar(50),
@salary decimal(10,2)) as
insert into employee values (@name,@department,@salary)
return scope_identity()
declare @res int
exec @res=spAddEmployee 'moni','IT',35000
print @res

--8)Create a stored procedure with default parameter
--Create spGetProductsByCategory
--• Parameter: CategoryName (default should be ‘Electronics’)
--• Return all products of that category.
--• Create Procedure WITH ENCRYPTION
create table Category(
pid int identity(1,1) primary key,pname varchar(20),categoryname varchar(40),
price decimal(10,2)
);
insert into Category (pname,categoryname,price )values 
('Laptop', 'Electronics', 45000),
('Smartphone', 'Electronics', 20000)
select * from Category
create procedure pGetProductsByCategory
(@categoryname varchar(40)='Electronics')
with encryption
as
select pid,pname,categoryname,price from Category
where categoryname=@categoryname

pGetProductsByCategory

--.9) Stored procedure using TRY…CATCH
--Create spSafeOrderInsert
--• Insert a new order
--• If any error occurs, insert error details into an ErrorLog table
CREATE TABLE ordertable (
    orderid INT PRIMARY KEY,
    custid INT  ,
    orderdate DATE,
    product VARCHAR(50),
    price INT,
    qty INT
);
create table Errorlog (errorid int identity(1,1) primary key,
errrornum int,errmsg nvarchar(4000),errline int)
alter procedure spSafeOrderInsert
(@orderid int,@custid int,@od date,@pro varchar(200),@price decimal(10,2) ,@qty int)
as
begin try
insert into ordertable(orderid,custid,orderdate,product,price,qty) values (@orderid,@custid,@od,@pro,@price,@qty)
end try
begin catch
insert into Errorlog values (error_number(),error_message(),
error_line())
end catch
exec spSafeOrderInsert '201',345,'2015-12-02','Books',500,2
exec spSafeOrderInsert 212,348,'2015-12-02','Books',500,2
select * from ordertable
select * from Errorlog

--10.Stored procedure with multiple operations
--Create spUpdateSalary
--• Inputs: EmpID, Percentage
--• Increase employee salary by given percentage
--• Return updated salary
create procedure spUpdateSalary
(@empid int,@percentage decimal(5,2),@updatesalary decimal (10,2) output)
as
update Employee 
set salary=salary+(salary*@percentage/100)
where empid=@empid
select @updatesalary=salary from employee where empid=@empid
declare @newsalary decimal(10,2)
exec spUpdateSalary 1,15,@newsalary output;
print @newsalary
 
select * from Employee



