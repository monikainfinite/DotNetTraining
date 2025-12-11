using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ado.net_assignemt
{
  
    internal class Disconnecteddemo
    {
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataSet ds = new DataSet();
        SqlDataAdapter da,da1;
        public void showAllEmployee()
        {
            //display all employyees records
            SqlConnection con= new SqlConnection("Integrated security=true;database=infinitedb;server=ICS-LT-6YZYBB4\\SQLEXPRESS");
            //no need to open and close connection
             da = new SqlDataAdapter("select * from newEmployee", con);
            // SqlDataAdapter da1 = new SqlDataAdapter("select * from newDepartment", con);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;//it is property belongs to adapter class
            SqlCommandBuilder sb=new SqlCommandBuilder(da);
            //addwithkey here keys are also copied
           //can hold many outputs
            da.Fill(ds,"emp");//ds contains output of employee table
            //da1.Fill(ds,"dep");//ds contains output of employee +departmetn table

            //Console.WriteLine(ds.Tables["emp"].Rows[1][1]);
            //Console.WriteLine(ds.Tables["dep"].Rows[1][1]);
            
            dt = ds.Tables["emp"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Console.WriteLine(dt.Rows[i][0]);
                Console.WriteLine(dt.Rows[i][1]);
                Console.WriteLine(dt.Rows[i][2]);
                Console.WriteLine(dt.Rows[i][3]);
                Console.WriteLine(dt.Rows[i][4]);
            }
        }
        public void searchEmployee()
        {
            //search employee by id
            Console.WriteLine("enter the id");
            int id = Convert.ToInt32(Console.ReadLine());
            DataRow dr=dt.Rows.Find(id);//returns DataRow  single row
            if (dr != null)
            {
                Console.WriteLine(dr[0]);
                Console.WriteLine(dr[1]);
                Console.WriteLine(dr[2]);
                Console.WriteLine(dr[3]);
                Console.WriteLine(dr[4]);
            }
            else
            {
                Console.WriteLine("No Such Key Exists!!");
            }
        }
        public void AddEmployee()
        {
            //new employee details
            //all curd operation are done using datatable
            //dt.Rows.Count-total rows present in the datatable
            //dt.Rows.Add-adding new rows
            //dt.Rows.Find-search row by primary key
            //dt.Rows.Remove-delete existing row
            Console.WriteLine("Enter Employee Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Salary:");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter Date of Joining (yyyy-mm-dd):");
            DateTime doj =Convert.ToDateTime( Console.ReadLine());

            Console.WriteLine("Enter Dept ID:");
            int deptid = Convert.ToInt32(Console.ReadLine());
            dt.Rows.Add(null,name,salary,doj,deptid);
           // dt.Rows.Add(null,"teja sri", 40000, "11-1-2025", 30);//a new row is added to datatable
            int rowseffected=da.Update(dt);

            Console.WriteLine("total rows inserted" + rowseffected);

        }
        public void DeleteAEmployee()
        {
            Console.WriteLine("enter the id");
            int id =Convert.ToInt32(Console.ReadLine());
            DataRow dr = dt.Rows.Find(id);
            dr.Delete();
            int rowaffected = da.Update(dt);
            Console.WriteLine("no of rows"+ rowaffected);
        }
        public void UpdateEmployee()
        {
            Console.WriteLine("enter the id");
            int id = Convert.ToInt32(Console.ReadLine());
            DataRow dr = dt.Rows.Find(id);
            Console.WriteLine("enter salary");
            decimal salary= Convert.ToDecimal(Console.ReadLine());  
            dr[2] = salary;
            int rowaffected = da.Update(dt);
            Console.WriteLine("no of rows" + rowaffected);

        }
        public void FilterEmployee()
        {
            //how can we search by non primary key col
            DataView dv=new DataView(dt);
            Console.WriteLine("Enter dept id:");
            int deptid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter salary:");
            decimal salary = Convert.ToDecimal(Console.ReadLine());
            dv.RowFilter = $"Salary>{salary} and DeptId={deptid}";
            foreach(DataRowView item in dv)
            {
                Console.WriteLine(item[0]);
                Console.WriteLine(item[1]);
                Console.WriteLine(item[2]);
                Console.WriteLine(item[3]);
                Console.WriteLine(item[4]);
            }
       


        }
        public void StoreinXML()
        { //ds.ReadXml('file name');
          //ds.ReadXml();//reads the xml file and stores in dataset
          //ds.WriteXml(); creates xml file and write all dataset records to xml
            dt.Rows.Add(null, "Raj1", 30000, "1-1-2000", 10);
            dt.Rows.Add(null, "vijay1", 31000, "1-1-2001", 20);
            ds.WriteXml("C:\\DotNetTraining\\employee.xml",XmlWriteMode.DiffGram);
            //shows which rows inserted,deleted or updated
            Console.WriteLine("conected sucessfully");
        }
        public void changes()
        {//to view only records from datatable where new changes happened
            dt.Rows.Add(null, "moni", 34355, "1-1-2025", 10);
            dt.Rows.Add(null, "sri", 34355, "1-1-2025", 10);
            Console.WriteLine("new rows added");
           if(ds.HasChanges())
            {
                DataSet newds=ds.GetChanges();
                for(int i = 0; i < newds.Tables["emp"].Rows.Count; i++)
                {
                    Console.WriteLine(newds.Tables["emp"].Rows[i][0]);
                    Console.WriteLine(newds.Tables["emp"].Rows[i][1]);
                    Console.WriteLine(newds.Tables["emp"].Rows[i][2]);
                    Console.WriteLine(newds.Tables["emp"].Rows[i][3]);
                    Console.WriteLine(newds.Tables["emp"].Rows[i][4]);
                }
            }
            else
            {
                Console.WriteLine("no changes");
            }
        }
        public void relationship()
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=infinitedb;server=ICS-LT-6YZYBB4\\SQLEXPRESS");
            // no need to open and close conn
            da = new SqlDataAdapter("select * from newEmployee", con);

            da1 = new SqlDataAdapter("select * from newDepartment", con);
            da.Fill(ds,"emp");
            da1.Fill(ds, "dept");
            dt = ds.Tables["emp"];
            dt2 = ds.Tables["dept"];
            DataRelation drr = new DataRelation("rel", dt2.Columns[0], dt.Columns[4]);//here dt2 contains department table which is primary key (parent table)and dt contaisn emp which is child table
            ds.Relations.Add(drr);//now it knows which is pk and fk
            dt.Rows.Add(null, "surya", 30000, "02-08-2025", 10);
            Console.WriteLine("done");
            //we will use data relations to check relation at the frontend instead of waiting for database to throw an error
            //here we are not seeing database for relationship we are not using update method.


        }
    }
}
