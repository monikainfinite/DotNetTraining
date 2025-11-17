using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FileHandlingDemo
{//filehandling has writer and reader functions
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\monikak\\Documents\\EXAMPLE.txt";
            //       using(StreamWriter writer = new StreamWriter(filePath))
            //{
            //           writer.WriteLine("Hello, World!");
            //           writer.WriteLine("This is a sample file.");
            //       }

            //       // Read from a file
            //       using (StreamReader reader = new StreamReader(filePath))
            //       {
            //           string content = reader.ReadToEnd();
            //           Console.WriteLine("File Content:");
            //           Console.WriteLine(content);
            //       }

            //       // Append to a file
            //       using (StreamWriter writer = new StreamWriter(filePath, true))
            //       {
            //           writer.WriteLine("Appending a new line.");
            //       }

            //       // Read the updated file
            //       using (StreamReader reader = new StreamReader(filePath))
            //       {
            //           string content = reader.ReadToEnd();
            //           Console.WriteLine("Updated File Content:");
            //           Console.WriteLine(content);
            //       }
            //if we are using the using block then no need to close the file..
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(filePath);
                string content = reader.ReadToEnd();
                Console.WriteLine(content);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            Console.ReadLine();
        }
    }
}
