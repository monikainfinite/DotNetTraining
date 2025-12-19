

create table customers(
custid INT PRIMARY KEY,
custname VARCHAR(50),
age INT,
caddress VARCHAR(100),
cphone VARCHAR(15)
);
INSERT INTO customers VALUES
(1,'Monika',21,'Vizag','123456789'),
(2,'Teja',20,'Bangalore','123456778'),
(3,'Sri',23,'Hyderabad','1234567144'),
(4,'surya',21,'Chennai','123456789'),
(5,'Varshu',22,'Chennai','123456789'),
(6,'Krishna',24,'Bangalore','123456879');
--1--
SELECT * FROM customers
WHERE caddress = 'Bangalore';
--2--
SELECT * FROM customers
WHERE caddress NOT IN ('Bangalore', 'Chennai');
--3--
SELECT * FROM customers WHERE age>50 AND caddress NOT IN ('Bangalore');
--4--
SELECT * FROM customers WHERE custname LIKE 'A%';
--5--
SELECT * FROM customers WHERE custname LIKE '%Br%';
--6--
SELECT * FROM customers WHERE custname>='A' AND custname<'L';
--7--
SELECT * FROM customers WHERE LEN(custname)=5;
--8--
SELECT * FROM customers WHERE custname LIKE 'S_c%e%';
--9--
SELECT DISTINCT custname FROM customers;


CREATE TABLE orders (
    orderid INT PRIMARY KEY,
    custid INT,
    orderdate DATE,
    product VARCHAR(50),
    price DECIMAL(10,2),
    qty INT,
    FOREIGN KEY (custid) REFERENCES customers(custid)
);
INSERT INTO orders VALUES
(101, 1, '2025-01-10', 'Mobile', 15000, 1),
(102, 2, '2025-01-12', 'Laptop', 55000, 1),
(103, 3, '2025-01-15', 'Headphones', 2000, 2),
(104, 1, '2025-01-20', 'Smartwatch', 5000, 1),
(105, 4, '2025-01-22', 'Tablet', 25000, 1),
(106, 5, '2025-01-25', 'Charger', 800, 3),
(107, 6, '2025-01-28', 'Keyboard', 1200, 1);
--10--
SELECT * FROM orders WHERE qty BETWEEN 100 AND 200 OR qty BETWEEN 700 AND 1200;
--11--
SELECT * FROM customers WHERE custname LIKE 'AL%N';
--12--
SELECT custid AS CustomerID ,
price AS Oldprice,
price*1.2 AS Newprice FROM orders;
--13--
SELECT TOP 3 * FROM orders ORDER BY qty DESC;
--14--
SELECT custid ,count(custid) AS Count FROM orders GROUP BY custid;
--15--
SELECT *
FROM orders
WHERE orderdate < DATEADD(YEAR, -5, GETDATE());
--16--
SELECT * FROM customers WHERE custname IS NULL;
--17--

SELECT CONCAT(orderid,'-',FORMAT(orderdate,'dd/MM/yyyy')) AS  [OrderID-Date],
price *qty AS Total FROM orders;

--18--
UPDATE orders SET price=price*1.2 WHERE qty>50;
--19--
SELECT * FROM orders WHERE orderdate='1990-12-01' AND
price BETWEEN 4000 AND 6000 
ORDER BY price DESC;
--20--
SELECT custid AS CustId,SUM(price) AS PriceSumofprice,
sum(qty) AS Countcountofqty FROM orders GROUP BY custid;
--21--
SELECT custid AS CustId,SUM(price) AS PriceSumofprice,
sum(qty) AS Countcountofqty FROM orders GROUP BY custid
HAVING sum(price)>4000;

SELECT * INTO custhistory FROM customers;
SELECT * FROM custhistory;
DELETE FROM custhistory;
INSERT INTO custhistory(custid,custname,age,caddress,cphone)
SELECT custid,custname,age,caddress,cphone FROM customers WHERE age>3;
SELECT * FROM custhistory;

