--cursors
--1.Basic Cursor – Print All Employee Names
--Create a cursor on an Employees table to print each employee’s name one by one
declare @empname varchar(40)
declare emp_cursor cursor for 
select Empname from employees
open emp_cursor
fetch next from emp_cursor into @empname
while @@FETCH_STATUS=0
begin
print @empname
fetch next from emp_cursor into @empname
end
close emp_cursor
deallocate emp_cursor
select * from employees

--2. Cursor to Update Salary
--Create a cursor that increases each employee’s salary by 10%.
--Update the table inside the cursor loop.


declare @empid int
declare @salary decimal(10,2)
declare updatesal cursor for
select EmpId,Salary from emp
open updatesal
fetch next from updatesal into @empid,@salary
while @@FETCH_STATUS=0
begin
update emp
set Salary=cast(Salary+(Salary*0.10) as decimal(10,2))
where EmpId=@empid
end
close updatesal
deallocate updatesal
select * from emp

--3.Cursor with Conditional Logic
--Fetch all orders.
--While looping:
--• If quantity > 10 ? give 5% discount
--• If quantity <= 10 ? give 2% discount
select * from orders
declare @orderid int
declare @product varchar(30)
declare @qty int
declare @price decimal(15,2)

declare orders_cursor cursor for
select orderid,product,qty,price from orders
open orders_cursor
fetch next from orders_cursor into @orderid,@product,@qty,@price
while @@FETCH_STATUS=0
begin
if(@qty>10)
begin
update orders set price=@price-(@price*0.05)
where orderid=@orderid
end
else if(@qty<=10)
begin
update orders set price=@price-(@price*0.10)
where orderid=@orderid
end
fetch next from orders_cursor into @orderid,@product,@qty,@price
end
close orders_cursor
deallocate orders_cursor

--4.Cursor to Copy Data From One Table to Another
--Read records from OldProducts table using a cursor and insert them into NewProduct
create table p2 (
   productid int primary key,
    ProductName varchar(50),
    Price decimal(15,2),
    Quantity int
)
declare @pid int
declare @pname varchar(50)
declare @pprice decimal(15,2)
declare @qtyy int
declare copy_cursor cursor for
select ProductId,ProductName,Price,Quantity from p1
open copy_cursor
fetch next from copy_cursor into @pid,@pname,@pprice,@qtyy
while @@FETCH_STATUS=0
begin
insert into p2 values (@pid,@pname,@pprice,@qtyy)
fetch next from copy_cursor into @pid,@pname,@pprice,@qtyy
end
close copy_cursor
deallocate copy_cursor
select * from p2


--5. Cursor to Delete Specific Rows
--Create a cursor that loops through customers.
--Delete customers whose LastOrderDate is more than 2 years old
CREATE TABLE newcustomers (
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(50),
    LastOrderDate DATE
)
INSERT INTO newcustomers (CustomerID, CustomerName, LastOrderDate)
VALUES
(1, 'Ram', '2023-05-10'),
(2, 'Sita', '2021-11-15'),
(3, 'Anil', '2020-09-01'),
(4, 'Monika', '2024-01-20');
declare @custid int
declare @lastorder date
declare del_cursor cursor
for
select CustomerID,LastOrderDate from newcustomers
open del_cursor
fetch next from del_cursor into @custid,@lastorder
while @@FETCH_STATUS=0
begin
if @lastorder<dateadd(year,-2,getdate())
begin 
delete from newcustomers
where CustomerID=@custid
PRINT 'Deleted CustomerID: ' + CAST(@CustomerID AS VARCHAR)
end
fetch next from del_cursor into @custid,@lastorder
end
close del_cursor
deallocate del_cursor