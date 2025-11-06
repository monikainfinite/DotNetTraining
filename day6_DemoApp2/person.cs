using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day6_DemoApp2
{
    public class Person1
    {
        public Person1()
        {
            Console.WriteLine("person constructor called");
        }
        public string Name;
        public void showName() => Console.WriteLine($"Name :{Name}");
    }
    class Teacher : Person1
    {
        public Teacher()
        {
            Console.WriteLine("Teacher Constructor");
        }
        public string Course;
        public void showcourse() => Console.WriteLine($"{Name} teaches {Course}");

    }
    class Professor : Teacher
    {
        public Professor()
        {
            Console.WriteLine("Professor constructor called");

        }
        public void ConductResearch() => Console.WriteLine($"{Name} is conducting R&D in {Course}");

        internal class person
        {

        }
    }
}
