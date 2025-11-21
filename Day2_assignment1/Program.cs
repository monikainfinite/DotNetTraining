using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Console;

namespace Day2_assignment1
{
    internal class Program
    {
        public class Student
        {
            public string Name { get; set; }
            public string Class { get; set; }
            public int TotalMarks { get; set; }
            public Char Gender { get; set; }
            public override string ToString() =>
                $"Name :{Name}, Class :{Class}, TotalMarks:{TotalMarks} ,Gender:{Gender}";
        }
        public class StudentDetails
        {//1.Dictionary class
            private Dictionary<int, Student> students = new Dictionary<int, Student>() {
            {1,new Student{Name="Monika",Class="10th",TotalMarks=500,Gender='F' } },
             {2,new Student{Name="Teja",Class="8th",TotalMarks=250,Gender='M' } },
              {3,new Student{Name="sri",Class="10th",TotalMarks=600,Gender='F' } },

        };
            //1a) display all students
            public void ShowAllStudents()
            {
                foreach (var s in students.Values)
                {
                    WriteLine(s.ToString());
                }
            }
            //2)task
            public async Task<Student> GetStudentAsync(int id=0)
            {
                try
                {
                    return await Task.Run(() =>
                    {
                        // Case 1: If user passes invalid id
                        if (id == 0 || !students.ContainsKey(id))
                        {
                            return new Student()
                            {
                                Name = "Default Student",
                                Class = "N/A",
                                TotalMarks = 0,
                                Gender = 'N'
                            };
                        }
                       
                        var stu = students[id];
                        if (stu.TotalMarks < 300)
                        {
                            throw new Exception("Marks are less than 500");
                        }
                        return  stu;

                    });
                }
                catch (Exception ex) when (ex.Message.Contains(" less than 500"))
                {
                    var stu = students[id];
                    await Task.Delay(10); 
                    WriteLine("Exception: Student marks are too low!");
                    return await Task.FromResult(stu); 
                }
                catch (Exception ex)
                {
                    await Task.Delay(10);
                    WriteLine($"General Error: {ex.Message}");
                    return null;
                }
            }
        }
            
        static async Task Main(string[] args)
        {
            StudentDetails sd= new StudentDetails();
            WriteLine("Displaying the student details");
            sd.ShowAllStudents();
            WriteLine("\n enter student Id:");
            int id=Convert.ToInt32(Console.ReadLine());
            var student = await sd.GetStudentAsync(id);
            if (student != null)
                WriteLine($"\nStudent Found: {student}");
            else
                WriteLine("\nNo student returned.");
        }

    }
    
}
