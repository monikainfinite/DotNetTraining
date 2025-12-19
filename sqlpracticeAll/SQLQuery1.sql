create procedure showbysal(@salary decimal(10,2))
as
begin
select * from newEmployee where Salary>@salary
end

