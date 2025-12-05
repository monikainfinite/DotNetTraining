create database TechMartDb
use TechMartDb
CREATE TABLE Customers(
CustID INT PRIMARY KEY,
 CustName VARCHAR(100),
 Email VARCHAR(200),
 City VARCHAR(100)
 )
 INSERT INTO Customers (CustID, CustName, Email, City) VALUES
(1, 'Amit Sharma', 'amit.sharma@gmail.com', 'Mumbai'),
(2, 'Ravi Kumar', 'ravi.kumar@yahoo.com', 'Delhi'),
(3, 'Priya Singh', 'priya.singh@gmail.com', 'Pune'),
(4, 'John Mathew', 'john.mathew@hotmail.com', 'Bangalore'),
(5, 'Sara Thomas', 'sara.thomas@gmail.com', 'Kochi'),
(6, 'Nidhi Jain', 'nidhi.jain@gmail.com', NULL);

--PRODUCTS TABLE
CREATE TABLE Products(
 ProductID INT PRIMARY KEY,
 ProductName VARCHAR(100),
 Price DECIMAL(10,2),
 Stock INT CHECK(Stock >= 0)
)
INSERT INTO Products (ProductID, ProductName, Price, Stock) VALUES
(101, 'Laptop Pro 14', 75000, 15),
(102, 'Laptop Air 13', 55000, 8),
(103, 'Wireless Mouse', 800, 50),
(104, 'Mechanical Keyboard', 3000, 20),
(105, 'USB-C Charger', 1200, 5),
(106, '27-inch Monitor', 18000, 10),
(107, 'Pen Drive 64GB', 600, 80);
 --ORDERS TABLE
 CREATE TABLE Customers(
CustID INT PRIMARY KEY,
 CustName VARCHAR(100),
 Email VARCHAR(200),
 City VARCHAR(100)
 )
INSERT INTO Orders (OrderID, CustID, OrderDate, Status) VALUES
(5001, 1, '2025-01-05', 'Pending'),
(5002, 2, '2025-01-10', 'Completed'),
(5003, 1, '2025-01-20', 'Completed'),
(5004, 3, '2025-02-01', 'Pending'),
(5005, 4, '2025-02-15', 'Completed'),
(5006, 5, '2025-02-18', 'Pending')


--ORDERS DETAILS TABLE
CREATE TABLE OrderDetails(
 DetailID INT PRIMARY KEY,
 OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
 ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
 Qty INT CHECK(Qty > 0)
)
INSERT INTO OrderDetails (DetailID, OrderID, ProductID, Qty) VALUES
(9001, 5001, 101, 1),
(9002, 5001, 103, 2),
 
(9003, 5002, 104, 1),
(9004, 5002, 103, 1),
 
(9005, 5003, 102, 1),
(9006, 5003, 105, 1),
(9007, 5003, 103, 3),
(9008, 5004, 106, 1),
(9009, 5005, 107, 4),
(9010, 5005, 104, 1),
(9011, 5006, 101, 1),
(9012, 5006, 107, 2);
 
 --PAYMENTS TABLE
CREATE TABLE Payments(
 PaymentID INT PRIMARY KEY,
 OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
 Amount DECIMAL(10,2),
 PaymentDate DATE
)
INSERT INTO Payments (PaymentID, OrderID, Amount, PaymentDate) VALUES
(7001, 5002, 3300, '2025-01-11'),
(7002, 5003, 62000, '2025-01-22'),
(7003, 5005, 4500, '2025-02-16');

--Q1. List customers who placed an order in the last 30 days.
--(Use joins)
select distinct c.CustId,c.CustName,c.Email,c.City,o.OrderID from Customers c
join Orders o on c.CustId=o.CustId
where O.OrderDate>=dateadd(day,-30,getdate())

--Q2. Display top 3 products that generated the highest total sales amount.
--(Use aggregate + joins)
select top 3 p.ProductId,p.ProductName,sum(o.Qty*p.Price) as Total
from Products p join  OrderDetails  o on p.ProductID=o.ProductID
group by p.ProductID,p.ProductName order by Total Desc

--Q3. For each city, show number of customers and total order count
select c.City ,count(distinct c.CustId) as Total_Customers,count(o.OrderId) as Total_orders
from Customers c left  join Orders o on c.CustID=o.CustId
group by c.City
--4. Retrieve orders that contain more than 2 different products.
select  o.OrderId,o.CustId,o.OrderDate,o.Status,count(distinct od.ProductId) as Total from Orders o
join OrderDetails od on o.OrderId=od.OrderId
group by o.OrderId,o.CustId,o.OrderDate,o.Status
having count(distinct od.ProductId) >2

--Q5. Show orders where total payable amount is greater than 10,000.
--(Hint: SUM(Qty * Price))
select o.OrderId,o.CustId,o.OrderDate,o.Status,sum(od.Qty*p.Price)
as Total from Orders o join OrderDetails od on
o.OrderId=od.OrderID join products p on
od.ProductID=p.ProductId group by 
o.OrderId,o.CustId,o.OrderDate,o.Status having sum(od.Qty*p.Price)>10000
--Q6. List customers who ordered the same product more than once
select c.CustId,c.CustName,p.ProductId,p.ProductName,count(*) as NumberofTimes
from Customers c join Orders o on c.CustId=o.CustID
join OrderDetails od on o.OrderId=od.OrderId
join Products p on od.OrderId=p.ProductID
group by c.CustId,c.CustName,p.ProductId,p.ProductName
having count(*)>1

--7. Display employee-wise order processing details
--(Assume Orders table has EmployeeID column)

alter table  Orders add EmpId int 
update Orders set EmpID=101 where OrderId in (5001,5003)
update Orders set EmpID=102 where OrderId in (5002,5004)
update Orders set EmpID=103 where OrderId in (5005,5006)
select o.EmpId,count(distinct o.OrderId) as Total ,sum(od.Qty*p.Price) as TotalAmount
from orders o
left join OrderDetails od on o.OrderId=od.OrderID
left join Products p on od.ProductID=p.ProductID
group by o.EmpId





--views
--1. Create a view vw_LowStockProducts
--Show only products with stock < 5.
--View should be WITH SCHEMABINDING and Encryption
create view vw_LowStockProducts
with schemabinding,encryption
as
select ProductID,ProductName,Price,Stock  from dbo.Products where Stock<5
select * from dbo.vw_LowStockProducts

--Functions
--1. Create a table-valued function: fn_GetCustomerOrderHistory(@CustID)
--Return: OrderID, OrderDate, TotalAmount
create function fn_GetCustomerOrderHistory(@CustID int)
returns table as
return 
( select o.OrderID,o.OrderDate,sum(od.Qty*p.Price) as TotalAmount
from Orders o join OrderDetails od on o.OrderId=od.OrderID
join Products p on od.ProductID=p.ProductID
where o.CustID=@CustID
group by o.OrderID,o.OrderDate)
select * from fn_GetCustomerOrderHistory(1)

--2. Create a function fn_GetCustomerLevel(@CustID)
--Logic:
--• Total purchase > 1,00,000 → "Platinum"
--• 50,000–1,00,000 → "Gold"
--• Else → "Silver"
create function fn_GetCustomerLevel(@CustID int )
returns varchar(40)
as 
begin 
declare @Totalpurchase decimal(10,2)
declare @level varchar(30)
select @Totalpurchase=sum(od.Qty*p.Price) from
Orders o join OrderDetails od on o.OrderId=od.OrderID
join Products p on od.ProductID=p.ProductID
where o.CustID=@CustID
if @TotalPurchase >100000
set @level='Platinum'
else if @Totalpurchase between 50000 and 100000
set @level='Gold'
else
set @level='Silver'
return @level
end
select dbo.fn_GetCustomerLevel(1)

--Procedures
--1. Create a stored procedure to update product price
--Rules:
--• Old price must be logged in a PriceHistory table
--• New price must be > 0
--• If invalid, throw custom error
create table PriceHistory(
HistoryId int Identity(1,1) primary key,
ProductId int,
OldPrice decimal(10,2),
NewPrice decimal(10,2))
create procedure sp_price
(@productId int,@newprice decimal(10,2))
as
begin
if @newprice<0
begin
throw 89034,'price must be grater than 0',1
return 
end
insert into PriceHistory select ProductId,Price,@newprice
from Products where ProductId=@productId
update Products set price =@newprice where ProductID=@productId
end
exec sp_price 101,1500
exec sp_price 101,-2
select * from PriceHistory


--2. Create a procedure sp_SearchOrders
--Search orders by:
--• Customer Name
--• City
--• Product Name
--• Date range
--(Any parameter can be NULL → Dynamic WHERE)
alter procedure sp_SearchOrders(
@custname varchar(100)=Null,@city varchar(100)=Null,@pname varchar(100)=Null,@startdate date=Null,
@enddate date=Null)
as 
begin
select o.OrderId,c.CustName,c.City,p.ProductName,p.Price,od.Qty,o.OrderDate
from Orders o join Customers c on o.CustID=c.CustID
join OrderDetails od on o.OrderId=od.OrderID
join Products p on od.ProductID=p.ProductID
where (@custname is null or c.CustName like '%'+@custname+'%')
and (@city is null or c.City =@city)
and (@pname is null or p.ProductName like '%'+@pname+'%')
and (@startdate is null or o.OrderDate>=@startdate)
and (@enddate is null or o.OrderDate<=@enddate)
order by o.Orderdate desc
end
exec sp_SearchOrders 'Amit','Mumbai'

--Triggers
--1. Create a trigger on Products
--Prevent deletion of a product if it is part of any OrderDetails.

create trigger del on Products
instead of delete as
begin
if exists(select * from deleted d join 
OrderDetails od on d.ProductID=od.ProductId)
begin
print 'cannot delete'
return
end
delete from products where ProductID in (select productId from deleted)
end
delete from Products where ProductID=101

--2. Create an AFTER UPDATE trigger on Payments
--Log old and new payment values into a PaymentAudit table
create table PaymentAudit(auditid int identity(1,1) primary key,
PaymentId int,oldAmount decimal(10,2),newAmount decimal(10,2))

create trigger trg_payments on Payments 
for update as 
begin 
insert into PaymentAudit select d.PaymentId,d.Amount as oldAmount,
i.Amount as newAmount from deleted d join inserted i on d.PaymentId=i.PaymentId
end 
update Payments set Amount=1500 where PaymentId=7001
select * from PaymentAudit

--3. Create an INSTEAD OF DELETE trigger on Customers
--Logic:
--• If customer has orders → mark status as “Inactive” instead of deleting
--• If no orders → allow deletion

alter trigger tr_Customers on Customers
instead of delete 
as
update Customers set Custname='Inactive' ,Email=NULL,City=NULL
where CustId in (select d.CustId from deleted d where exists (
select * from Orders o where o.CustId=d.CustID))
delete from Customers where CustID in (
select d.CustID from deleted d where not exists (
select * from Orders o where o.CustId=d.CustID))


delete from Customers where CustID=2
select * from Customers where CustId=2