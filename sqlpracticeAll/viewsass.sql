--employees table
CREATE TABLE Employees
(
 EmpId INT PRIMARY KEY,
 EmpName VARCHAR(100),
 DeptId INT,
 ManagerId INT NULL,
 JoinDate DATE,
 Salary DECIMAL(10,2)
);
INSERT INTO Employees VALUES
(1, 'Amit', 10, NULL, '2020-01-10', 65000),
(2, 'Neha', 10, 1, '2022-02-15', 50000),
(3, 'Ravi', 20, 1, '2023-03-12', 45000),
(4, 'Sana', 20, 3, '2024-01-20', 42000),
(5, 'Karan', 30, 1, '2021-07-18', 55000);--departments tableCREATE TABLE Departments
(
 DeptId INT PRIMARY KEY,
 DeptName VARCHAR(100)
);
INSERT INTO Departments VALUES
(10, 'IT'),
(20, 'HR'),
(30, 'Finance')--sales tableCREATE TABLE Sales
(
 SaleId INT PRIMARY KEY,
 EmpId INT,
 Region VARCHAR(50),
 SaleAmount DECIMAL(10,2),
 SaleDate DATE
);
INSERT INTO Sales VALUES
(1, 1, 'North', 100000, '2024-01-01'),
(2, 2, 'North', 90000, '2024-01-10'),
(3, 3, 'South', 120000, '2024-02-05'),
(4, 4, 'South', 120000, '2024-02-20'),
(5, 5, 'North', 110000, '2024-03-15')
--transactions table

CREATE TABLE Transactions
(
 TransId INT PRIMARY KEY,
 AccountId INT,
 Amount DECIMAL(10,2),
 TransDate DATE
);
INSERT INTO Transactions VALUES
(1, 101, 1000, '2024-01-01'),
(2, 101, 2000, '2024-02-01'),
(3, 101, -500, '2024-03-01'),
(4, 102, 1500, '2024-01-15'),
(5, 102, -200, '2024-03-10');

--1)Write a query using CASE to categorize salary levels on Employees table:
--• <20000 ? Low
--• 20000–50000 ? Medium
--• 50000 ? High
select EmpId,EmpName,Salary,
case
when Salary<20000 then 'Low'
when Salary between 20000 and 50000 then 'Medium'
when Salary>50000 then 'High'
end as SalaryCategory
from Employees

--2)Declare a variable @Age.
--Write logic using IF / ELSE:
--• If Age < 18 ? print “Minor”
--• Else If Age between 18–60 ? “Adult”
--• Else ? “Senior”
declare @Age int
set @Age=45
if(@Age<18)
print 'Minor'
else if (@Age between 18 and 60)
print 'Adult'
else
print 'Senior'

--3)Create an encrypted and schemabound view that:
--• Joins Employees, Departments, and Salaries tables
--• Returns only employees who joined in the last 3 years
--• Includes computed column: AnnualSalary = Salary * 12
--• Prevents updates to base tables that break schema binding
--Tasks
--1. Create the view with WITH SCHEMABINDING, ENCRYPTION.
--2. Try altering an underlying table column ? observe the error
create view empview 
with schemabinding,encryption
as select e.EmpId,e.EmpName,e.DeptId,d.DeptName,
e.Salary,e.JoinDate,AnnualSalary=e.Salary*12
from dbo.Employees e inner join dbo.Departments d
on e.DeptId=d.DeptId where
e.JoinDate>=DATEADD(year,-3,getdate());
alter table Employees drop column Salary;

--4)Create a view that:
--• Joins Employees + Sales
--• Shows total sales per employee
--• Shows rank based on total sales across compan
create view EmployeeSalesRank as
With TotalSales as
(
    select
        e.EmpId,
        e.EmpName,
        SUM(s.SaleAmount) as TotalSales
    from Employees e
    left join Sales s
        on e.EmpId = s.EmpId
    group by e.EmpId, e.EmpName
)
select
    EmpId,
    EmpName,
    TotalSales,
    rank() over (order by TotalSales desc) as SalesRank
from TotalSales;
select * from EmployeeSalesRank

--5)write a block that:
--• Attempts dividing by zero
--• Catches the error
--• Prints error details
begin try
declare @a1 int
set @a1=10
print @a1/0
end try
begin catch
print 'you are trying to divide 0.. pls check'
print error_message()
print error_line()
print error_number()
print error_severity()
print error_procedure()
end catch

--6)Validate salary:
--• If salary < 1000, throw custom error using THROW.
--• Declare variable to simulate salary
declare @salary int
set @salary=500
begin try
if(@salary<1000)
begin 
throw 500010,'Salary should be greater than 1000',1
end
else
print 'salary is valid'
end try
begin catch
print 'error occured'
print error_message();
end catch


--7)Compare Rank / Dense_Rank / Row_Number
--• Identify top 2 per region
WITH SalesRanked AS
(
select EmpId,Region,SaleAmount ,
rank() over (partition by region order by SaleAmount desc) as rank_sales,
dense_rank() over(partition by region order by SaleAmount desc) as denserank_sales,
row_number() over (partition by region order by SaleAmount desc) as rownumber_sales
from sales
)
select  * from SalesRanked where rank_sales<=2
order by Region,SaleAmount desc;
--8)First CTE: Filter only last 1 year sales
--• Second CTE: Compute total sales per region
--• Third CTE: Rank regions based on total sales
--• Output top 3 regions

with LastYearSales as
(
    select *
    from Sales
    where  SaleDate >= DATEADD(YEAR, -1, GETDATE())
),
TotalSalesPerRegion as
(
    select
        Region,
        sum(SaleAmount) AS TotalSales
    from LastYearSales
    group by Region
),
RankedRegions as
(
    select
        Region,
        TotalSales,
        rank() over (order by TotalSales desc) as RegionRank
    from TotalSalesPerRegion
)
select *
from RankedRegions
where RegionRank <= 3;

-- 9)Find Employees With Duplicate SalesAmount in Any Department
select e.EmpId,
       e.EmpName,
       e.DeptId,
       s.SaleAmount,
       count(*) AS DuplicateCount
from Employees e
inner join Sales s
    on e.EmpId = s.EmpId
group by e.EmpId, e.EmpName, e.DeptId, s.SaleAmount
having count(*) > 1
order by e.DeptId, s.SaleAmount desc;

--10)Perform Pagination and list all details from employees who’s page between 6 and 10
with pagination as(
    select  EmpId, EmpName, DeptId,  JoinDate, Salary,
           ROW_NUMBER() over(order by EmpId) as rn
    from Employees
)
select *
from pagination
where rn BETWEEN 6 AND 10
order by  rn;
