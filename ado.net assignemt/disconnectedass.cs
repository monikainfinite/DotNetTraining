using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ado.net_assignemt
{
    internal class disconnectedass
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        SqlDataAdapter da;
        SqlDataAdapter da1;
        public void showAllEmployeeAndDept()
        {

            SqlConnection con = new SqlConnection("Integrated security=true;database=infinitedb;server=ICS-LT-6YZYBB4\\SQLEXPRESS");

            da = new SqlDataAdapter("select * from newEmployee", con);
           da1 = new SqlDataAdapter("select * from newDepartment", con);


            da.Fill(ds, "emp");
            da1.Fill(ds, "dep");
            dt = ds.Tables["emp"];
            Console.WriteLine("========employee table=========");
            foreach (DataRow r in dt.Rows)
            {
                Console.WriteLine($"{r[0]} {r[1]} {r[2]} {r[3]} {r[4]} ");

            }
            dt = ds.Tables["dep"];
            Console.WriteLine("=====department table=========");
            foreach (DataRow r in dt.Rows)
            {
                Console.WriteLine($"{r[0]} {r[1]} ");

            }
        }
        public void FilterEmployee()
        {
            dt = ds.Tables["emp"];
            DataView dv = new DataView(dt);
            Console.WriteLine("Enter dept id:");
            int deptid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter salary:");
            decimal salary = Convert.ToDecimal(Console.ReadLine());
            dv.RowFilter = $"Salary>{salary} and DeptId={deptid} and EmpName like 'M%'";
            dv.Sort = "Salary desc";
            foreach (DataRowView item in dv)
            {
                 Console.WriteLine($"{item[0]} {item[1]} {item[2]} {item[3]} {item[4]}");
               
            }

        }
        public void showCount()
        {
            Console.WriteLine("Total number of tables in a dataset= " + ds.Tables.Count);
            foreach (DataTable table in ds.Tables)
            {
                Console.WriteLine(table.TableName);
            }
        }

        public void copytable()
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=infinitedb;server=ICS-LT-6YZYBB4\\SQLEXPRESS");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from newDepartment", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();

            Console.WriteLine("====department table=====");
            foreach (DataRow r in dt.Rows)
            {
                Console.WriteLine($"{r[0]} {r[1]}  ");

            }
        }
        public void showorderscust()
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=infinitedb;server=ICS-LT-6YZYBB4\\SQLEXPRESS");

            da = new SqlDataAdapter("select * from Customers", con);
            da1 = new SqlDataAdapter("select * from Orders", con);
            da.Fill(ds1, "cus");
            da1.Fill(ds2, "ord");
            ds1.Merge(ds2);
            Console.WriteLine("Total Tables in ds1: " + ds1.Tables.Count);
            Console.WriteLine("Customers Table");
            dt = ds1.Tables["cus"];
            foreach (DataRow r in dt.Rows)
            {
                Console.WriteLine($"{r[0]} {r[1]} {r[2]} {r[3]} {r[4]} ");

            }
            Console.WriteLine("orders Table");
            dt = ds1.Tables["ord"];
            foreach (DataRow r in dt.Rows)
            {
                Console.WriteLine($"{r[0]} {r[1]} {r[2]} {r[3]} {r[4]} ");

            }
        }
        public void xmlDemo()
        {
            ds.ReadXml("C:\\DotNetTraining\\CUSTOMER.xml");
            dt = ds.Tables["CUST"];
            foreach (DataRow r in dt.Rows)
            {
                Console.WriteLine($"{r[0]} {r[1]} {r[2]} ");

            }

        }
    }

}

        





       



            
       



    

