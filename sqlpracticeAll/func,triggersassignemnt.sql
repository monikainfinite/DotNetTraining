--Functions
--1. create a function to find the greatest of three numbers
create function fn_greatest(@n1 int ,@n2 int,@n3 int)
returns int
as 
begin
declare @max int
set @max=@n1
if @n2>@max
 set @max=@n2
if @n3>@max
set @max=@n3
return @max
end
select dbo.fn_greatest(200,45,90) as maxnumber

--2)create a function to calculate to discount of 10% on price on all 
--the products
alter function fn_disc(@price decimal(10,2))
returns decimal(10,2)
as
begin
declare @final decimal(10,2);
if (@price>0)
set @final=@price*0.90;
else
set @final=@price;
return @final;
end;
select dbo.fn_disc(500);

--3)create a function to calculate the discount on price as following
--if productname = 'books' then 10%
--if productname = toys then 15%
--else
--no discount
create function pd(@pname varchar(50),@price decimal(10,2))
returns decimal(10,2)
as
begin
declare @final decimal(10,2)
if(@pname='books')
set @final=@price-(@price*0.10)
else if(@pname='toys')
set @final=@price-(@price*0.15)
else
set @final=@price
return @final
end
 
select dbo.pd('books',500);


--4)create inline function which accepts number and prints last n
--years of orders made from now.
--(pass n as a parameter)


--triggers
--1)Create a trigger for table customer, which does not allow 
--the user to delete the record who stays in Bangalore, 
--Chennai, delhi

create trigger tr3 on example_cust
for delete as
if exists(select * from deleted where 
caddress in ('Bangalore','Chennai','Delhi'))
begin
print 'cant allowed to delete'
rollback transaction
end
delete from example_cust where caddress='Vizag'
select * from example_cust
delete from example_cust where caddress='Bangalore'


--2)Create a triggers for orders which allows the user to insert 
--only books, cd, mobile 
alter trigger tr4 on orders
for insert as
if exists (select * from inserted where product not in ('books','cd','mobile'))
begin
print 'only products books,cd and mobile are allowed'
rollback transaction
end
select * from orders
insert into orders (orderid,product,price,qty) values
(108,'books',7890,3)
insert into orders (orderid,product,price,qty) values
(109,'toy',7890,3)

--3)Create a trigger for customer table whenever an item is 
--delete from this table. The corresponding item should be 
--added in customerhistory table.
create table customerhistory(custid int,custname varchar(50),city varchar(30))

create trigger tr7 on example_cust
for delete as 
begin
insert into customerhistory select custid,custname,caddress from deleted
end
delete from example_cust where custid=4
select * from customerhistory

--4)Create update trigger for stock. Display old values and new 
--values
create trigger tr8 on Stocks
for update
as 
begin
print 'old values'
select * from deleted
print 'updated values'
select * from inserted
end

update Stocks 
set Qty=3 where StockId=1

--5. Create Instead Of Insert Trigger for Joined View (the user 
--should able to insert record for 2 table using single insert 
--command) Use following table
create table a
(
custid int,
custname varchar(12)
)
create table b
(
custid int,
product varchar(12)
)
create view testview
as
select a.* , b.product from a inner join b on a.custid = 
b.custid
select * from testview

alter trigger tr9 on testview
instead of insert as
begin
insert into a select custid,custname from inserted
insert into b select custid,product from inserted
end

insert into testview values (101,'moni','books')
select * from a
select * from b
 select * from testview
 