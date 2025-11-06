using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day6_DemoApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Professor professor = new Professor();
            Professor professor1 = new Professor() { Name = "monika", Course = "Maths" };
            professor.Name = "usha";
            professor.Course = "AWS";
            professor.showName();
            professor.showcourse();
            professor.ConductResearch();
            professor1.ConductResearch();
            Console.ReadLine();
        }
    }
}
