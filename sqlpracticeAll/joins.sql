select * from customers;
select * from orders;
--inner join common values
select * from customers join orders 
on customers.custid=orders.custid;
--result:display who made orders
--outerjoin (atleast from 1 table it will display all the records)
--all records from left table and matching from right
select * from customers left outer join orders 
on customers.custid = orders.custid;
--result:sidplay customers who made orders + who not made orders
--all records from right and matching from left.
select * from customers right outer join orders 
on customers.custid = orders.custid;
select * from customers full outer join orders
on customers.custid=orders.custid;
--cross join(statistical data)
--u want current year records has to be compared with [revious year records
select * from customers cross join orders 
--self join
select b.* from customers a,customers b
where a.age>b.age and b.custname='varshu';
select a.* from customers a,customers b

select * from customers union
select * from customersTable;
select * from customers union all
select * from customersTable;
select * from customers intersect
select * from customersTable;
select * from customers except
select * from customersTable;
select * from customersTable;


