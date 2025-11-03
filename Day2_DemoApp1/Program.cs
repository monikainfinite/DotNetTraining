using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_DemoApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //array declaration and initilization.
            //int[] numArray=new int[5] {1,2,3,4,5};
            ////array declaration
            //int[] myArray=new int[5];
            ////one way of initilization
            ////myArray[0] = 100;
            ////myArray[1] = 200;
            ////myArray[3] = 300;
            ////myArray[4] = 400;
            ////myArray[5] = 500;
            //Console.WriteLine($"enter {myArray.Length}numbers");
            ////another way of initilization
            //for (int i = 0; i < myArray.Length; i++)
            //{
            //    myArray[i] = Convert.ToInt32(Console.ReadLine());
            //}

            //Console.WriteLine("Array elements are");
            ////for initilizing we are not using foreach loop because it doesnt have index.
            //foreach(var item in myArray)
            //{
            //    Console.WriteLine( item);
            //}
            //2-D array declaration and initiliazation
            int[,] marks = new int[2, 5] { { 20, 30, 40, 50, 60 }, { 30, 50, 60, 70, 80 } };
            //outer loop for row 
            Console.WriteLine(marks.GetLength(1));
            //for (int i = 0; i < marks.GetLength(0); i++) { 
            // //inner loop for column
            // for(int j=0;j< marks.GetLength(1); j++)
            //    {
            //        Console.WriteLine(marks[i, j] + '\t');
            //    }
            // Console.WriteLine();
            //}
            Console.ReadLine();

        }
    }
}
