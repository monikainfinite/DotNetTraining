using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace Day5_DemoApp2
{
    class Student
    {
        private int age;
        private string name;
        private double salary = 4500;
        private string password="admin123";
        //properties are used to initilize the private variables..
        //get and set are properties..
        public int Age
        {
            get {
                if(age<0 || age > 0)
                {
                    return 100 - age;
                }
                return age; }//getter we are return ing the value
            set { 
            //{  if (value < 0 || value > 100)
            //        throw new Exception("invalid age");
               age = value;//setting the value;
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }
        public double Salary
        {
            get { return salary; }//read only property.
        }
        public string Password
        {
            set
            {
                password = value;//write only property
            }
        }
       



        internal class Program
        {
            static void Main(string[] args)
            {
                Student s = new Student();
                Console.WriteLine("enter age");
                s.Age =Convert.ToInt32( Console.ReadLine());
                s.Name = "monika";
               
               //here we can assign value to salary because it doent have set propeety.
               //and we cant print the password because it doesnt have get property..
                Console.WriteLine($"Student name : {s.Name}");
                Console.WriteLine($"Student age :{s.Age}");
                Console.WriteLine($"student  salary :{s.Salary}");
               
                Console.ReadLine();

            }
        }
    }
}
