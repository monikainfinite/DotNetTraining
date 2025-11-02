using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string firstName, lastName, gender;
            //int age;
            //char grade;
            //int score1, score2, score3;
            //Console.WriteLine("enter all details");
            //firstName = Console.ReadLine();
            //lastName = Console.ReadLine();

            //gender = Console.ReadLine();
            //age = Convert.ToInt32(Console.ReadLine());
            //grade = Convert.ToChar(Console.ReadLine());
            //score1 = Convert.ToInt32(Console.ReadLine());
            //score2 = Convert.ToInt32(Console.ReadLine());
            //score3 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("student Info");
            //Console.WriteLine($"Full Name is {firstName} {lastName}");
            //Console.WriteLine($"Gender is {gender}");
            //Console.WriteLine($"age is {age}");
            //Console.WriteLine($"grade is {grade}");
            //Console.WriteLine($"scores are : {score1} \n {score2} \n {score3}");
            //Console.ReadLine();
            //int num = 10;
            //double val = num;//Impilict type conversion
            //Console.WriteLine($"num is {num} \n value is {val}");
            //double pi = 3.14;
            //int intpi = (int)pi; // explicit type conversion.
            //Console.WriteLine($"pi is {pi} and {intpi}");
            ////converting value type to object type or reference type is called Boxing
            ////    converting object type to value type is called unboxing.
            //object obj = num; //Boxing
            ////object accepts all types like int,float,string,char ,double.
            //int myval = (int)obj;//unboxing
            //Console.WriteLine($"object is {obj} and number is {myval}");
            ////value type(int,float,double)
            //int a = 10;
            //int b = a;//separate memnory but copying the value of a .
            //Console.WriteLine($"{a} and {b}");
            //b = 100;
            //Console.WriteLine($"{a} and {b}");
            ////string,class,array,object..
            ////reference type ..Object is a refernece type but it is a base type so that it can any value.
            //string[] names = { "moni", "teja" };
            //string[] copynames = names;//here sharing the same memory.we are referring.
            //Console.Write($"name [0] {names[0]} \t names[1] is {names[1]}");
            //copynames[0] = "sri";
            //Console.Write($"{copynames[0]} and {names[0]}");//for getting on the same line.
            //int employeeId;
            //String employeeName, designation;
            //decimal salary;
            //employeeId = Convert.ToInt32(Console.ReadLine());
            //employeeName = Console.ReadLine();
            //designation = Console.ReadLine();
            //salary=Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Employee Details");
            //Console.WriteLine($"Employee Id:{employeeId} \n Name: {employeeName } \n {designation} \n {salary}");
            //int age;
            //Console.WriteLine("enter your age");
            //age =Convert.ToInt32(Console.ReadLine());

            //if (age < 0 || age>100)

            //  Console.WriteLine("Invalid age");

            //else
            //    Console.WriteLine($"age is {age}");
            //int num1, num2, num3;
            //num1=Convert.ToInt32(Console.ReadLine());
            //num2=Convert.ToInt32(Console.ReadLine());
            //num3=Convert.ToInt32(Console.ReadLine());
            //if (num1 >= num2 && num1 >= num3)
            //    Console.WriteLine("Num 1 greater");
            //else if (num2 >= num1 && num2 >= num3)
            //    Console.WriteLine("num 2 is greater");
            //else
            //    Console.WriteLine("num3 is greater");
            //switch
            //Console.WriteLine("Choose the options 1.add \n 2.subtract \n 3.Multiplication \n 4.Division");
            //double n1, n2;
            //int choice=Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("enter first number");
            //n1=Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine("enter 2nd number");
            //n2=Convert.ToDouble(Console.ReadLine());
            //switch (choice)
            //{
            //    case 1:
            //        Console.WriteLine($"Addition of 2 numbers {n1 + n2}");
            //        break;
            //    case 2:
            //        Console.WriteLine($"Subtraction of 2 numbers {n1 - n2}");
            //        break;
            //    case 3:
            //        Console.WriteLine($"Multiplication of 2 numbers {n1 * n2}");
            //        break;
            //    case 4:
            //        if(n2!=0)
            //        Console.WriteLine($"Division of 2 numbers {n1 / n2}");
            //        else
            //        Console.WriteLine("invalid");
            //        break;
            //    default:
            //        Console.WriteLine("not valid choice");
            //        break;
            int[] numberArray = {1,2,3,4,5,6,7,8,9,10};
            Console.WriteLine(numberArray[0]);
            foreach (int number in numberArray)
                Console.WriteLine(number);

            string[] employeeNames = new string[5];
            for (int i = 0; i < employeeNames.Length; i++)
                employeeNames[i] = Console.ReadLine();
            foreach(string employeeName in employeeNames)
                Console.WriteLine(employeeName);
            Console.ReadLine();


        }
    }
}
