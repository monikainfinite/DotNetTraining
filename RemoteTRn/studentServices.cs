using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace RemoteTRn
{
    public class StudentService : MarshalByRefObject, IStudentService
    {
        private Dictionary<int, Student> students = new Dictionary<int, Student>()
        {
            {1, new Student { Name = "Monika", Class = "10th", TotalMarks = 500, Gender = 'F'}},
            {2, new Student { Name = "Teja", Class = "8th", TotalMarks = 250, Gender = 'M'}},
            {3, new Student { Name = "Sri", Class = "10th", TotalMarks = 600, Gender = 'F'}}
        };

        public void ShowAllStudents()
        {
            foreach (var s in students.Values)
                Console.WriteLine(s.ToString());
        }

        public Student GetStudent(int id)
        {
            

                if (id == 0 || !students.ContainsKey(id))
                {
                    return new Student
                    {
                        Name = "Default Student",
                        Class = "N/A",
                        TotalMarks = 0,
                        Gender = 'N'
                    };
                }

                var stu = students[id];

              

                return stu;

            

        }
    }
}
