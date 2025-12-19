--cursors
--cursor is a database object that allows us to retrive data row by row instead of a single set
--steps to create cursor
--declare all variables and cursor,open,fetch rows,process the row,close ,deallocate the cursor
select * from customers
declare @name varchar(20)
declare @caddress varchar(50)--step1
declare cust_cursor cursor for--step1
select custname,caddress from customers

open cust_cursor--step2

fetch next from cust_cursor into @name,@caddress--3
print @name + @caddress--4
print @@fetch_status--0 because the row is there if not there -1 will come
fetch next from cust_cursor into @name,@caddress
print @name+@caddress
print @@fetch_status--0 because the row is there if not there -1 will come

close cust_cursor--5
deallocate cust_cursor--6

--types of cursors
--static,dynamic,keyset,farward only,fast_farward,read only,scroll
--1)static cursor when a new row is inserted while cursor running ,it will not show it
--2)it will store in temp db
declare @name1 varchar(20)
declare @caddress1 varchar(50)--step1

declare customer_cursor cursor dynamic for--step1
select custname,caddress from customers
open customer_cursor
fetch next from customer_cursor into @name1,@caddress1
while @@FETCH_STATUS=0
begin
waitfor delay '00:00:02'
print 'Static:' +@name1 +@caddress1
fetch next from customer_cursor into @name1,@caddress1
end
close customer_cursor
deallocate customer_cursor--6

--when i used static here no new value is added here 
--when using dynamic we can see it

--At OPEN time ? SQL stores only the IDs (keys)

--During FETCH:

-- It re-reads the row using that ID ? so updates are visible

-- New rows have new IDs, so they were not in the original key list

-- Deleted rows ? key exists but data is gone ? so row disappears
declare @name2 varchar(20)
declare @caddress2 varchar(50)
declare customer_cursor1 cursor keyset for
select custname,caddress from customers where caddress='Vizag'
open customer_cursor1
fetch next from customer_cursor1 into @name2,@caddress2
while @@FETCH_STATUS=0
begin
waitfor delay '00:00:02'
print 'Static:' +@name2 +@caddress2
fetch next from customer_cursor1 into @name2,@caddress2
end
close customer_cursor1
deallocate customer_cursor1--6
--in keyset only update is possible if the row is not fetched yet
--insertetoion not possible

--farward cursor only in one direction

scroll(every direction allowed , every changes are allowed)


DECLARE @Name VARCHAR(100)

DECLARE emp_cursor2 CURSOR SCROLL FOR
SELECT cname FROM test
OPEN emp_cursor2
-- First row
FETCH FIRST FROM emp_cursor2 INTO @Name
PRINT 'FIRST: ' + @Name
-- Last row
FETCH LAST FROM emp_cursor2 INTO @Name
PRINT 'LAST: ' + @Name
-- Previous row
FETCH PRIOR FROM emp_cursor2 INTO @Name
PRINT 'PRIOR: ' + @Name
CLOSE emp_cursor2
DEALLOCATE emp_cursor2

select * from test