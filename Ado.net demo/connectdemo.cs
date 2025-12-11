using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Ado.net_demo
{
    internal class connectdemo
    {
        public void showEmployee()
        {//display all records from employee table
            SqlConnection con = new SqlConnection("Integrated security=true; database = infinitedb;server=ICS-LT-6YZYBB4\\SQLEXPRESS");
      
            con.Open();//creates a new connection

            //writes a command
            SqlCommand cmd = new SqlCommand("select * from newEmployee", con);
            SqlDataReader dr=cmd.ExecuteReader();
            while (dr.Read())//run the loop only if record is found
            {
                //it reads row by row
               // Console.WriteLine(dr[0]);//prints only one column
                Console.WriteLine($"{dr[0]} {dr[1]} {dr[2]} {dr[3]} {dr[4]}");



            }
            con.Close();
        }
        public void AddEmployee()
        {
            Console.WriteLine("enter name");
            string name = Console.ReadLine();
            Console.WriteLine("enter salary");
            decimal salary=Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("enter doj");
            string doj=Console.ReadLine();
            Console.WriteLine("enter depid");
            int depid=Convert.ToInt32(Console.ReadLine());
            //add records from employee table
            SqlConnection con = new SqlConnection("Integrated security=true; database = infinitedb;server=ICS-LT-6YZYBB4\\SQLEXPRESS");

            con.Open();//creates a new connection

            //writes a command
            SqlCommand cmd = new SqlCommand($"insert into newEmployee  values ('{name}',{salary} , '{ doj}' , {depid}  )", con);

            int rowaffected = cmd.ExecuteNonQuery();
            Console.WriteLine($"Total Records Inserted is { rowaffected}");
           
          
            con.Close();
        }
        public void DeleteEmployee()
        {
            //delete records from employee table
            Console.WriteLine("enter id to delete record");
            int empid = Convert.ToInt32(Console.ReadLine());
            SqlConnection con = new SqlConnection("Integrated security=true; database = infinitedb;server=ICS-LT-6YZYBB4\\SQLEXPRESS");
            con.Open();
            SqlCommand cmd = new SqlCommand($"delete from newEmployee where EmpId= {empid}"
                , con);
            int del = cmd.ExecuteNonQuery();
            Console.WriteLine($"total records deleted is {del}");
            con.Close();
        }
        public void updateEmployee()
        {
            //update records from employee table
            Console.WriteLine("enter empid to update");
            int id= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter salary");
            decimal sal= Convert.ToDecimal(Console.ReadLine());
            SqlConnection con = new SqlConnection("Integrated security=true; database = infinitedb;server=ICS-LT-6YZYBB4\\SQLEXPRESS");
            con.Open();
            SqlCommand cmd = new SqlCommand($"update newEmployee set Salary = {sal}  where Empid= { id}", con);
            int update = cmd.ExecuteNonQuery();
            Console.WriteLine($"the number of updated records is  {update}");
            con.Close();
        }
        public void showprocedure()
        {//display all records from employee table
            SqlConnection con = new SqlConnection("Integrated security=true; database = infinitedb;server=ICS-LT-6YZYBB4\\SQLEXPRESS");

            con.Open();//creates a new connection

            //writes a command
            SqlCommand cmd = new SqlCommand("sp_getemp", con);//instead of passing paremater in this way we will use parameter class
            SqlParameter p1 = new SqlParameter("@d", 10);
            SqlParameter p2 = new SqlParameter("@sal", 1000);//create a parameter
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);//attaching parameter to procedure
            cmd.CommandType=CommandType.StoredProcedure;//represents type of command you are trying to execute
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())//run the loop only if record is found
            {
                //it reads row by row
                // Console.WriteLine(dr[0]);//prints only one column
                Console.WriteLine($"{dr[0]} {dr[1]} {dr[2]} {dr[3]} {dr[4]}");

            }
            con.Close();
        }
        public void EmpTransaction()
        {
            SqlTransaction tr = null;
            try
            {
                SqlConnection con = new SqlConnection("Integrated security=true; database = infinitedb;server=ICS-LT-6YZYBB4\\SQLEXPRESS");

                con.Open();//creates a new connection
                tr = con.BeginTransaction();
                //writes a command
                SqlCommand cmd1 = new SqlCommand("insert into one values (2,'raj')", con);
                SqlCommand cmd2 = new SqlCommand("insert into two values (2,'raj')", con);
                cmd1.Transaction = tr;
                cmd2.Transaction = tr;
                int rowaffected1 = cmd1.ExecuteNonQuery();
                int rowaffected2 = cmd2.ExecuteNonQuery();
                Console.WriteLine($"Total Records Inserted is {rowaffected1}");
                Console.WriteLine($"Total Records Inserted is {rowaffected2}");

                tr.Commit();
                con.Close();

            }
            catch (Exception ex)
            {
                tr.Rollback();
                Console.WriteLine("could not complete ... try again");
            }
            }
    }
}
