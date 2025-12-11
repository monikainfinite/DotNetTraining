select * from customers for xml auto,elements
select * from employees

CREATE TABLE newEmployee (
    EmpID INT IDENTITY(1,1) PRIMARY KEY,
    EmpName VARCHAR(100),
    Salary DECIMAL(10,2),
    DateOfJoin DATE,
    DeptID INT FOREIGN KEY REFERENCES newDepartment(DeptID)
);
CREATE TABLE newDepartment (
    DeptID INT PRIMARY KEY,
    DeptName VARCHAR(50)
);
INSERT INTO newDepartment (DeptID, DeptName)
VALUES
(10, 'HR'),
(20, 'Finance'),
(30, 'IT'),
(40, 'Sales'),
(50, 'Operations');
INSERT INTO newEmployee (EmpName, Salary, DateOfJoin, DeptID)
VALUES
('Aasritha', 52000, '2022-04-15', 30),
('Akshay', 60000, '2021-11-20', 30),
('Anvith Reddy', 48000, '2023-02-10', 10),
('ASHOK', 55000, '2021-07-18', 40),
('Deepalakshmi', 47000, '2022-01-25', 20),
('Deepti', 51000, '2023-03-12', 50),
('Dharani sri', 46000, '2020-09-30', 10),
('Humera', 62000, '2021-12-05', 30),
('Kanishka', 53000, '2022-05-09', 40),
('KEERTHANA', 45000, '2023-04-03', 20),
('Keerthi', 58000, '2021-03-22', 30),
('Keerthickragul', 54000, '2022-06-10', 50),
('Logeshwaran', 50000, '2020-11-17', 40),
('Madavi', 47000, '2023-01-08', 10),
('Manikanta', 61000, '2021-10-14', 30),
('Fatima', 49500, '2022-02-19', 20),
('Monika', 52000, '2023-05-22', 10),
('Nagamani', 47000, '2020-08-27', 50),
('Pooja', 45000, '2022-09-12', 40),
('Hymavathi', 48000, '2021-07-05', 10),
('Sairam Somaraju', 65000, '2020-05-18', 30),
('Sakthivel', 53000, '2022-03-24', 40),
('Usha sri', 45500, '2023-02-14', 20),
('Waseef', 62000, '2021-01-30', 30)
alter procedure sp_getemp(@d int,@sal decimal(10,2))
as
select * from newEmployee where deptid=@d and Salary>@sal
create table one (
cid int primary key,
cname varchar(20)
)
create table two (
cid int primary key,
cname varchar(20)
)
select * from one
select * from two
create procedure GetEmployees (@startdate date,@enddate date)
as 
begin 
select * from newEmployee where  DateOfJoin between
@startdate and @enddate
end
alter procedure sp_GetEmployeeDet(@Empid int,@DateofJoin date output,
@DeptId int output)
as
begin
select @DateofJoin=DateofJoin,@DeptId=DeptID from newEmployee where EmpId=@Empid
end
DECLARE @d DATE, @did INT;

EXEC sp_GetEmployeeDet 
    1,          -- existing EmpId
    @d OUTPUT,
    @did OUTPUT;

SELECT @d AS DateOfJoin, @did AS DeptId;