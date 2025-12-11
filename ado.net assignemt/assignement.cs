using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ado.net_assignemt
{
    class Databaseoperations
    {
        private SqlConnection con;
        public Databaseoperations()
        {
            try
            {
                con = new SqlConnection("Integrated security=true;database=infinitedb;server=ICS-LT-6YZYBB4\\SQLEXPRESS");
                con.Open();
                if (con.State == ConnectionState.Open)
                    Console.WriteLine("Connection  Successfully");
                else
                    Console.WriteLine(" Connection Not sucessful");
            }
            catch (SqlException ex) 
            {
                Console.WriteLine("SQL Error: " + ex.Message);

            }
        }

        public void GetTransactions(DateTime d1,DateTime d2)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = new SqlParameter("@startDate", d1);
                SqlParameter p2 = new SqlParameter("@endDate", d2);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($"{dr[0]}  {dr[1]}  {dr[2]}  {dr[3]}  {dr[4]}");
                }
                //dr.Close();
            }
            catch(SqlException ex)
            {
                Console.WriteLine("SQL Exception: " + ex.Message);
            }
        }
        public void GetCommonRecords(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "select e.EmpId,e.EmpName,e.salary,e.DateOfJoin ,d.DeptId,d.DeptName from newEmployee e inner join newDepartment d on e.DeptID=d.DeptId where d.DeptId=@DeptId", con);
                SqlParameter p1 = new SqlParameter("@DeptID", id);
                cmd.Parameters.Add(p1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($"{dr[0]}  {dr[1]}  {dr[2]}  {dr[3]}  {dr[4]}  {dr[5]} ");

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
        }
        public void InsertRecordsusingtrans()
        {
            SqlTransaction tr = null;
            try
            {
                
                Console.WriteLine("Enter Employee Name:");
                string empname = Console.ReadLine();
                Console.WriteLine("Enter Employee Salary:");
                decimal salary = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Enter Employee DOJ:");
                DateTime doj = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter Department ID:");
                int deptid = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Department Name:");
                string deptname = Console.ReadLine();
                tr = con.BeginTransaction();
                SqlCommand cmd2 = new SqlCommand($"insert into newDepartment values ({deptid},'{deptname}')",con);
                SqlCommand cmd1 = new SqlCommand($"insert into newEmployee values ('{empname}',{salary},'{doj}',{deptid})", con);

                cmd1.Transaction = tr;
                cmd2.Transaction = tr;
                
                int rowaffected2 = cmd2.ExecuteNonQuery();
                int rowaffected1 = cmd1.ExecuteNonQuery();
                Console.WriteLine("Employee Records Inserted: " + rowaffected1);
                Console.WriteLine("Department Records Inserted: " + rowaffected2);

                tr.Commit(); 
               
            }
            catch (SqlException ex)
            {
                tr.Rollback();
                Console.WriteLine("Could not complete.. try again...");
                Console.WriteLine("SQL Error: " + ex.Message);
            }
        }
       
        
        public void InsertEmployeeAndFetchId()
        {
            SqlTransaction tr = null;
            try
            {
                Console.WriteLine("Enter Employee Name:");
                string empname = Console.ReadLine();

                Console.WriteLine("Enter Employee Salary:");
                decimal salary = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Enter Employee DOJ:");
                DateTime doj = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Enter Department ID:");
                int deptid = Convert.ToInt32(Console.ReadLine());
                tr = con.BeginTransaction();
                SqlCommand cmd1 = new SqlCommand($"insert into newEmployee values ('{empname}',{salary},'{doj}',{deptid});"+ "select scope_identity()", con);
                cmd1.Transaction = tr;
              
                int newEmpID = Convert.ToInt32(cmd1.ExecuteScalar());
                SqlCommand cmd2 = new SqlCommand($"select * from newEmployee where EmpId={newEmpID}", con);
                cmd2.Transaction = tr;
                SqlDataReader dr = cmd2.ExecuteReader();
                if (dr.Read())
                {
                    
                    Console.WriteLine($"{dr[0]}  {dr[1]}  {dr[2]}  {dr[3]}  {dr[4]}");
                }
                dr.Close();
                tr.Commit();
            }
            catch (SqlException ex)
            {
                tr.Rollback();
               
                Console.WriteLine("SQL Error: " + ex.Message);
            }
        }
        public void ShowEmployeesAndDepartments()
        {
            try
            {
                SqlCommand cmd1 = new SqlCommand($"select * from newEmployee;select* from newDepartment",con);
       
                SqlDataReader dr = cmd1.ExecuteReader();
                Console.WriteLine("Employees:");
                while (dr.Read())
                {

                    Console.WriteLine($"{dr[0]}  {dr[1]}  {dr[2]}  {dr[3]}  {dr[4]}");
                }
                if (dr.NextResult())
                {
                    Console.WriteLine("Departmetns:");
                    while (dr.Read())
                    {

                        Console.WriteLine($"{dr[0]}  {dr[1]}  ");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }

        }
        public void Getdetails()
        {
            try
            {
                Console.WriteLine("enter empid");
                int emid = Convert.ToInt32(Console.ReadLine());
                SqlCommand cmd = new SqlCommand("sp_GetEmployeeDet", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@Empid",  emid );
                cmd.Parameters.Add(p1);
                SqlParameter p2 = new SqlParameter("@DateofJoin", SqlDbType.Date);
                p2.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(p2);
                SqlParameter p3 = new SqlParameter("@DeptId", SqlDbType.Int);
                p3.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(p3);
                cmd.ExecuteNonQuery();
                Console.WriteLine(cmd.Parameters["@DateofJoin"].Value);
                Console.WriteLine(cmd.Parameters["@DeptId"].Value);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CloseConnection()
        {
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
                Console.WriteLine(" Connection Closed");
            }
        }
    }
    
}
