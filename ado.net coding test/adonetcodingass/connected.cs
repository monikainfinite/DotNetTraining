using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace adonetcodingass
{

    class EduTrackDatabase
    {
        private SqlConnection con;
        public EduTrackDatabase()
        {
            try
            {
                con = new SqlConnection("Integrated security=true;database=infinite;server=ICS-LT-6YZYBB4\\SQLEXPRESS");

                con.Open();
                if (con.State == ConnectionState.Open)
                    Console.WriteLine("Connection Successful");
                else
                    Console.WriteLine("Connection Not Successful");
            }

            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //1) //display all courses
        public void DisplayCourses()
        {
            SqlCommand cmd = new SqlCommand("select * from Courses", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine($"{dr[0]} {dr[1]} {dr[2]} {dr[3]} ");
            }
            dr.Close();

        }
        //Add a new student
         public void AddnewStudent()
        {
            Console.WriteLine("enter full name");
            string fullName=Console.ReadLine();
            Console.WriteLine("enter email");
            string email=Console.ReadLine();
            Console.WriteLine("enter departmetnt");
            string dept=Console.ReadLine();
            Console.WriteLine("enter year of study");
            int yos=Convert.ToInt32(Console.ReadLine());
            SqlCommand cmd = new SqlCommand($"insert into Students  values (@FullName, @Email, @Department, @YearOfStudy)", con);
            cmd.Parameters.AddWithValue("@FullName", fullName);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Department", dept);
            cmd.Parameters.AddWithValue("@YearOfStudy", yos);
            int rowaffected = cmd.ExecuteNonQuery();
            Console.WriteLine($"Total Records Inserted is {rowaffected}");


          
        }
     // Search students by department

        public void search()
        {
            Console.WriteLine("enter department");
            string dept = Console.ReadLine();
            SqlCommand cmd = new SqlCommand($"select * from Students where Department='{dept}'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine($"{dr[0]} {dr[1]} {dr[2]} {dr[3]}");
               
            }
            dr.Close();

        }
        // Display enrolled courses for a student


        public void Displayenrollcouress()
        {
            Console.WriteLine("enter student id ");
            int id = Convert.ToInt32(Console.ReadLine());
            SqlCommand cmd = new SqlCommand($"select c.CoursreName,c.Credits,e.EnrollDate,e.Grade from Enrollments e join Courses c on e.CourseId=c.CourseId where e.StudentId={id}", con);
            
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine($"{dr[0]} {dr[1]} {dr[2]} {dr[3]}" );


            }

            dr.Close();
        }
        public void update()
        {
            Console.WriteLine("enter enrollment id ");
            int enrollid= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter grade ");
            string grade=Console.ReadLine();
            SqlCommand cmd = new SqlCommand($"update Enrollments set Grade='{grade}' where EnrollmentId ='{enrollid}'",con);
           
            int rowsAffected = cmd.ExecuteNonQuery();
            Console.WriteLine("number of rows effected"+rowsAffected);

        }
        public void CloseConnection()
        {
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
                Console.WriteLine("Connection Closed");
            }

        }
            //stored procedure usp_GetCoursesBySemester @semester
            public void getstoredprocedure()
            {

            Console.WriteLine("enter semester");
            string sem=Console.ReadLine();
            SqlCommand cmd = new SqlCommand("usp_GetCoursesBySemester", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@semester", sem);
            cmd.Parameters.Add(p1);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"{dr[0]} {dr[1]} {dr[2]} {dr[3]}");
            }
        }
    }
    }
