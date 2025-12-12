using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonetcodingass
{
    internal class Disconnected
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataSet ds = new DataSet();
        SqlDataAdapter da;
        SqlDataAdapter da1;

        //  1) Load Students and Courses into a DataSet
        public void LoadData()
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=infinite;server=ICS-LT-6YZYBB4\\SQLEXPRESS");
            da = new SqlDataAdapter("select * from Students", con);
            da1 = new SqlDataAdapter("select * from Courses", con);
            da.Fill(ds, "stu");
            da1.Fill(ds, "courses");
            dt = ds.Tables["stu"];
            Console.WriteLine("========Students Table=========");
            Console.WriteLine("ID\tFullName\tEmail\tDepartment\tYearOfStudy");
            foreach (DataRow r in dt.Rows)
            {
               
                Console.WriteLine($"{r[0]} {r[1]} {r[2]} {r[3]} {r[4]}");
            }
            dt = ds.Tables["courses"];
            Console.WriteLine("========Courses Table=========");
            Console.WriteLine("ID\tCourseName\tCredits\tSemester");
            foreach (DataRow r in dt.Rows)
            {
               
                Console.WriteLine($"{r[0]} {r[1]} {r[2]} {r[3]} ");
            }

        }
        //2.modify credits
        public void updateCredits()
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=infinite;server=ICS-LT-6YZYBB4\\SQLEXPRESS");
            da = new SqlDataAdapter("select * from Courses",con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.Fill(ds, "courses");
            dt = ds.Tables["courses"];
            Console.WriteLine("enter courseid");
            int id =Convert.ToInt32(Console.ReadLine());
            DataRow row = dt.Rows.Find(id);
            Console.WriteLine("enter credits to update");
            int credits = Convert.ToInt32(Console.ReadLine());
            row[1] = credits;
            int rowsaffected=da.Update(dt);
            Console.WriteLine("the number of rows affected" + rowsaffected);

        }
        //3.add new course
        public void Addcourse()
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=infinite;server=ICS-LT-6YZYBB4\\SQLEXPRESS");
            da = new SqlDataAdapter("select * from Courses", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Fill(ds, "courses");
            dt = ds.Tables["courses"];
            Console.WriteLine("enter course name ");
            string cname=Console.ReadLine();
            Console.WriteLine("enter credits");
            int credits= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter semester");
            string sem=Console.ReadLine();
            dt.Rows.Add(null,cname,credits,sem);
            int rowsaffected=da.Update(dt);
            Console.WriteLine("no of rows affected" + rowsaffected);
        }
        //4.delete student
        public void DelStudent()
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=infinite;server=ICS-LT-6YZYBB4\\SQLEXPRESS");
            da = new SqlDataAdapter("select * from Students", con);
            da1 = new SqlDataAdapter("select * from Enrollments", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            SqlCommandBuilder cb1 = new SqlCommandBuilder(da1);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da1.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            da.Fill(ds, "stu");
            da1.Fill(ds, "enroll");
            dt = ds.Tables["stu"];
            dt1 = ds.Tables["enroll"];
            Console.WriteLine("enter stuid to delete");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (DataRow r in dt1.Rows)
            {
                if (Convert.ToInt32(r["StudentId"]) == id)
                    r.Delete();
            }

            DataRow row = dt.Rows.Find(id);
            row.Delete();
           
            int rowsaffected1 = da1.Update(dt1);
            int rowsaffected = da.Update(dt);
            Console.WriteLine("the no of rows affected in student table" + rowsaffected);
            Console.WriteLine("the no of rows affected in enrolment table" + rowsaffected1);
        }
    }

}
