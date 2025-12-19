--how to create simple procedure
create procedure sp_getCustomers
as
select * from customers
--just calling the name instead of wrtiing the query
sp_getCustomers
--how to create procedure with parameters
--who stays in place like vizag etc
--how to alter procedure 
--create procedure getbyaddress (@a varchar(20))
alter procedure getbyaddress (@a varchar(20))
as
select * from customers where caddress=@a
--execution
getbyaddress 'Vizag'
getbyaddress 'Bangalore'
--how to drop
drop procedure getbyaddress

--we can also create procedure for function
create procedure addpro(@a int,@b int)
as
print @a+@b
addpro 20,20
--can procedure return an value
create procedure addpro1(@a int,@b int)
as
return @a+@b
--how to execute with return 
declare @res int
exec @res=addpro1 10,20
print @res

--can procedure return multiple values??
--no so to acheive we will use output parameter
alter procedure Addproc2(@a int,@b int, @c int output, @d int output)
as
begin
set @c= @a+@b
set @d=@a*@b
end

GO
declare @m int
declare @n int

exec Addproc2 10,20,@m output ,@n output 
print @m
print @n

--how to create procedures with try and catch block
create procedure divide(@a int,@b int)
as
begin try
print @a/@b

end try
begin catch
print 'Error occured'+error_message()
end catch
divide 10,0
divide 5,2

sp_depends customers

--how to execute the procedure with insert command
insert into customers exec getbyaddress 'Hyerabad'
select * from customers
select * from customers

--identity
create table testing
(custid int identity(10,10),
custname varchar(30),
age int)
insert into testing values('moni',21)
insert into testing values('monika',23)
select * from testing

alter procedure myproc(@cname varchar(20),@age int) as 
insert into testing values(@cname,@age)
return scope_identity()--read the values that has been assigned
--i want to know what value is assigned to custid
declare @res int
exec @res=myproc 'monikateja',21
print @res


--6)how to pass table names dynamically
--one procedure can work with multiple tables


create procedure displaydata(@tbl varchar(20))
as
declare @myquery nvarchar(100)
set @myquery = 'select * from ' + @tbl
exec sp_executesql @myquery -- runs the select command

displaydata 'employeesales'
displaydata 'customers'

--7.Create a stored procedure to insert a new employee
--Create a table Employees and write a stored procedure:
--• Procedure name: spAddEmployee
--• Inputs: Name, Department, Salary
--• Insert the record into Employees table.
--• Return newly generated CustomerID using SCOPE_IDENTITY().
create table employee(empid int identity(1,1) primary key,


--.10?)Stored procedure with multiple operations
--Create spUpdateSalary
--• Inputs: EmpID, Percentage
--• Increase employee salary by given percentage
--• Return updated salary
create procedure spUpdateSalary
(@empid int,@percentage decimal(5,2),@updatesalary decimal (10,2) output)
as
update employee 
set salary=salary+(salary*@percentage/100)
where empid=@empid
select @updatesalary=salary from employee where empid=@empid

declare @newsalary decimal(10,2)
exec spUpdateSalary 1,15,@newsalary output;
print @newsalary

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
--. Stored procedure using TRY…CATCH
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