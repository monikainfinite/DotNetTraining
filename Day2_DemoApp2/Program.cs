using System;

namespace Day2_DemoApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int rowsize, colsize, sum;
            //Console.WriteLine("Enter number of rows or students");
            //rowsize = Convert.ToInt32(Console.ReadLine());
            //colsize = 5;

            //int[,] studentMarks = new int[rowsize, colsize];
            //for (int i = 0; i < rowsize; i++)
            //{
            //    Console.WriteLine($"enter the marks for student {i + 1}");
            //    for (int j = 0; j < colsize; j++)
            //    {
            //        Console.WriteLine($"enter the marks for subject {j + 1}");
            //        studentMarks[i, j] = Convert.ToInt32(Console.ReadLine());
            //    }
            //}
            //Console.WriteLine("dispalying");
            //Array.Reverse(studentMarks);//not supported here
            //for (int i = 0; i < rowsize; i++)
            //{
            //    sum = 0;
            //    Console.WriteLine("\n student marks are \n");
            //    for (int j = 0; j < colsize; j++)
            //    {
            //        Console.Write(studentMarks[i, j] + "\t");
            //        sum += studentMarks[i, j];
            //    }
            //    Console.WriteLine($"\n The total marks for student {i + 1} is {sum} \n");
            //}
            //int[] myArray = new int[5] { 1, 2, 3, 4, 5 };
            //foreach (int item in myArray)
            //{
            //    Console.WriteLine(item);
            //}//array reverse is used for 1D only not for 2D array.
            //Array.Reverse(myArray);

            //Console.WriteLine("reverse of array");
            //foreach (int item in myArray)
            //{
            //    Console.WriteLine(item+"\t");
            //}
            //for varying the col size on ow size we are using jagged array.
            int[][] jaggedArray = new int[4][];
            //4 rows and any no of cols in each row.
            //Initilize the array
            //jaggedArray[0] = new int[2] { 7, 9 };
            //jaggedArray[1] = new int[4] { 1, 2, 3, 4 };
            //jaggedArray[2]= new int[6] {1,2,3,4,5,6};
            //jaggedArray[3] = new int[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
            ////display the elements
            //for(int i = 0; i < jaggedArray.Length; i++)
            //{
            //    Console.WriteLine("Element {0}", i + 1);
            //    for(int j = 0; j < jaggedArray[i].Length; j++)
            //    {
            //        Console.Write(jaggedArray[i][j] + "\t");
            //    }
            //    Console.WriteLine();
            //}
            //for dynamically taking input
            //jaggedArray[0] = new int[2];
            //jaggedArray[1] = new int[4];

            //jaggedArray[2] = new int[2];
            //jaggedArray[3] = new int[3];
            //for (int i = 0; i < 4; i++)
            //{
            //    Console.WriteLine($"enter {jaggedArray[i].Length} in row {i + 1}");
            //    for (int j = 0; j < jaggedArray[i].Length; j++)
            //    {
            //        jaggedArray[i][j] = Convert.ToInt32(Console.ReadLine());

            //    }
            //}
            //for (int i = 0; i < jaggedArray.Length; i++)
            //{
            //    Console.WriteLine("Element {0}", i + 1);
            //    for (int j = 0; j < jaggedArray[i].Length; j++)
            //    {
            //        Console.Write(jaggedArray[i][j] + "\t");
            //    }
            //    Console.WriteLine();
            //}

            //string[][] Members = new string[4][]{
            //   new string[]{"Rocky", "Sam", "Alex"},
            //   new string[]{"Peter", "Sonia", "Prety", "Ronnie", "Dino"},
            //new string[]{"Yomi", "John", "Sandra", "Alex", "Tim", "Shaun"},
            //new string[]{"Teena", "Mathew", "Arnold", "Stallone", "Goddy", "Samson", "Linda"},
            //    };
            //for (int i = 0; i < Members.Length; i++)
            //{
            //    Console.Write("name list {0}", i + 1);
            //    for (int j = 0; j < Members[i].Length; j++)
            //    {
            //        Console.Write(Members[i][j] + "\t");
            //    }
            //    Console.WriteLine();
            //}

            //to create a class we can go to solution explorer or in project 
            //calculator calculator = new calculator();//Instance or object declaration or initilazation.
            //calculator calculator2;//object declaration;
            //calculator2 = new calculator();//object initialization. and memory created.
            //int num1, num2;
            ////every object has diff memory.
            //Console.WriteLine("enter first number");
            //num1 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("enter second number");
            //num2 = Convert.ToInt32(Console.ReadLine());

            //calculator.Addition(num1, num2);
            //calculator.Subtraction(num1, num2);

            //Employee employee = new Employee();
            //employee.AcceptEmployeeDetails();
         
            //Employee employee2 = new Employee();
            //employee2.AcceptEmployeeDetails();
            //employee.DisplayEmployeeDetails();
            //employee2.DisplayEmployeeDetails();
            //Employee employee = new Employee();
            //int empId;
            //string empName;
            //string designation;
            //Console.WriteLine("enter empid,name and designation");
            //empId=Convert.ToInt32(Console.ReadLine());
            //empName=Console.ReadLine();
            //designation = Console.ReadLine();
            //employee.AcceptEmployeeDetails(empId, empName, designation);
            //employee.DisplayEmployeeDetails();
            //employee.AcceptEmployeeDetails(id:empId, designation: designation,name:empName);//named parametes
            //employee.DisplayEmployeeDetails();

            //employee.AcceptEmployeeDetails(designation, empName, empId);//it gives compilation error..
            //because it doesnt follow the order.. for this we will use named parameters..
          
            //calculator calculator = new calculator();

            //calculator.Calculate(20, 10, out int addResult, out int difference, out int productResult, out int divisionResult);
            //Console.WriteLine($"addidition is {addResult} and diif is {difference} and pro is {productResult} and div is {divisionResult}");
            //Console.ReadLine();
            //default parameter or optional parameter must be at end.
            Employee employee = new Employee();
            employee.AcceptEmployeeDetails(101, "monika");
            employee.DisplayEmployeeDetails();
            employee.AcceptEmployeeDetails(101, "monika","qa");//we can also pass value ..
            employee.DisplayEmployeeDetails();



        }
    }
}
