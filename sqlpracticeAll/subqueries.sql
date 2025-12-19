--sub queries
--query inside the query
--32 (performance will degrade)
--select * from customers ;
select * from orders;
--to return only one value we will use =
select * from customers where custid=
(select custid from orders where product='Mobile')
--to return multiple values we should use IN ..
--dispaly details whose age >30.
select * from orders where custid IN
(select custid from customers where age>10)
--1--
select * from customers where custid IN
(select custid from orders where product='Mobile')
--2--
select * from customers where custid IN
(select custid from orders where product IN('Mobile','Laptop','Tablet'))
--3--
select * from customers where custid NOT IN 
(select custid from orders);
--4--
select max(age) from customers where 
age<(select max(age) from customers);
--5--
select * from orders where custid IN
(select custid from customers where caddress='Bangalore');
--6--
select * from customers where custid IN
(select custid from orders where
qty=(select min(qty) from orders))
--7--
select * from customers where 
age>(select age from customers where custname='surya');
--8--
update customers 
set age=(select age from customers where custid=2)
where custid=1;

--9--
select * from customers 
where custid IN (select custid from orders 
where month(orderdate)=12);
--10--
select * from orders where 
day(orderdate)<16 and custid in(select custid from customers 
where caddress NOT IN ('Bangalore'));
--11--
select * from customers where custid in 
(select custid from orders where qty<3)
and caddress in ('Delhi','Bangalore');
--12--
select * from orders where price >
(select avg(price) from orders);
--13--
update orders 
set price=price*1.10 where 
custid in (select custid from customers where caddress='Bangalore')
and product='Laptop';

--14--
select concat(orderid,'-',orderdate) as [orderID-Date],
(price*qty) as total from orders;