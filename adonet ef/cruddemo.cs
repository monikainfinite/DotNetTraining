using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_ef
{ 
    internal class cruddemo
    {
        infinitedbEntities dc=new infinitedbEntities();
        public void showallemployees()
        {
            //it should display all emp from database
            var res=from t in dc.newEmployees
                    select t;
            //by default when u write a linq query it will also load related data
            //is it possible => it should not load related data
            //we can done it by lazy loading + eager loading
            //lazy loading:it will not load
            //eager :it will load
            var res1 = from t in dc.newDepartments
                     select t;
                    //or we can use joins to dispaly both emp and dept

            //foreach (var e in res)
            //{
            //    Console.WriteLine($"{e.EmpID} {e.EmpName} {e.DateOfJoin} {e.Salary} {e.DeptID}");
            //    Console.WriteLine("===============");
            //    Console.WriteLine(e.newDepartment.DeptID + " " + e.newDepartment.DeptName);
            //    Console.WriteLine("============");
            //}
            foreach(var item in res1)
            {
                Console.WriteLine(item.DeptName);
                foreach(var item1 in item.newEmployees)
                {
                    Console.WriteLine(item1.EmpName + " " + item1.Salary);
                }
                Console.WriteLine("============");
            }
        }
        public void searchRecord()
        {
            Console.WriteLine("enter the name");
            string name=Console.ReadLine();
            var res=from t in dc.newEmployees
                    where t.EmpName.Contains(name)
                    select t;
            foreach(var e in res)
            {
                Console.WriteLine($"{e.EmpID} {e.EmpName} {e.DateOfJoin} {e.Salary} {e.DeptID}");

            }
        }
        public void AddRecord()
        {
            //create obj of thetable which u want to add(employee)
            //initialize all the properties (step-1)
            Console.WriteLine("enter the name");
            string name = Console.ReadLine();
            Console.WriteLine("enter the salary");
            decimal salary=Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("enter the doj");
            DateTime doj=Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("enter the deptid");
            int id = Convert.ToInt32(Console.ReadLine());
            newEmployee ob = new newEmployee() { EmpName = name, Salary = salary, DateOfJoin = doj, DeptID = id };
            //attach the object to property(step-2)
            dc.newEmployees.Add(ob);
            //update the changes to the database
            int i=dc.SaveChanges();//update all changes to db
            Console.WriteLine("total rows inserted is " + i);
        }
        public void DeleteRecord()
        {
            //1)search a record you want to delete
            Console.WriteLine("enter empid");
            int id = int.Parse(Console.ReadLine());
            var res = (from t in dc.newEmployees
                       where t.EmpID == id
                       select t).First();

            // Console.WriteLine($"{res.EmpID} {res.EmpName} {res.DateOfJoin} {res.Salary} {res.DeptID}");
            //step-2 attach the property to object 
            dc.newEmployees.Remove(res);
            //step-3update the changes to the database
            int i = dc.SaveChanges();//update all changes to db
            Console.WriteLine("record deleted"+i);

        }
        public void UpdateRecord()
        {
            Console.WriteLine("enter empid");
            int id=int.Parse(Console.ReadLine());
            var res=(from t in dc.newEmployees
                     where t.EmpID==id
                     select t).First();
            res.Salary = 555000;
            int i = dc.SaveChanges();//update all changes to db
            Console.WriteLine("record updated" + i);
        }
        public void SearchDept()
        {
            var res = from e in dc.newEmployees
                      join dep in dc.newDepartments
                      on e.DeptID equals dep.DeptID
                      select new
                      {
                          e.EmpID,
                          e.EmpName,
                          e.DateOfJoin,
                          e.Salary,
                          e.DeptID,
                          dep.DeptName
                      };
            foreach(var e in res)
            {
                Console.WriteLine($"{e.EmpID} {e.EmpName} {e.DateOfJoin} {e.Salary} {e.DeptID}");

            }
        }
        public void Display()
        {
            var res = from e in dc.newEmployees
                      join
                    d in dc.newDepartments
                    on e.DeptID equals d.DeptID
                      select new
                      {
                          e.EmpID,
                          e.EmpName,
                          e.DeptID,
                          d.DeptName,
                          e.Salary
                      };
            foreach (var e in res)
            {
                Console.WriteLine($"{e.EmpID} {e.EmpName} {e.Salary} {e.DeptID} {e.DeptName}");

            }
        }
        public void  Displaydates()
        {
            Console.WriteLine("enter start date ");
            DateTime d1=DateTime.Parse(Console.ReadLine());
            Console.WriteLine("enter end date ");
            DateTime d2 = DateTime.Parse(Console.ReadLine());
            var res = from e in dc.newEmployees
                      where e.DateOfJoin >= d1 && e.DateOfJoin <= d2
                      select new
                      {
                          e.EmpID,
                          e.EmpName,
                          e.DateOfJoin,
                          e.Salary,
                          e.DeptID
                      };
            foreach (var e in res)
            {
                Console.WriteLine($"{e.EmpID} {e.EmpName} {e.DateOfJoin} {e.Salary} {e.DeptID}");
            }
        }
        public void CalBonus()
        {
            var res = from e in dc.newEmployees
                      select new { e.EmpID, e.EmpName, e.Salary, Bonussal = e.Salary * 1.3m };
            foreach( var e in res)
            {
                Console.WriteLine($"{e.EmpID} {e.EmpName} {e.Salary} {e.Bonussal}");
            }
        }
        public void SqlqueryDemo()
        {
            //how to write sql query?
           var res= dc.Database.SqlQuery<newEmployee>("select * from newemployee where empname like 'M%'");

            foreach (var e in res)
            {
                Console.WriteLine($"{e.EmpID} {e.EmpName} {e.DateOfJoin} {e.Salary} {e.DeptID}");

            }
        }
        public void DMLDemo()
        {
            //for insert and delete
            int ra = dc.Database.ExecuteSqlCommand("delete  from newEmployee where empname like 'M%'");
            Console.WriteLine("total records" + ra);
        }
        public void spdemo()
        {
            //how to call the procedure
            //use procedure when u are using join and subqueries heavily
            var res = dc.showbysal(60000);
            foreach(var e in res)
            {
                Console.WriteLine($"{e.EmpID} {e.EmpName} {e.DateOfJoin} {e.Salary} {e.DeptID}");

            }
        }
    }
}
