using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FileHandlingDemo
{
    public class Sample { 
    public Sample()
        {
            Console.WriteLine("sample class constructor");
        }
        public void Display()
        {
            Console.WriteLine("display method");
        }
        //~Sample() { Console.WriteLine("sample class destructor"); }
    }
    
    internal class fileinfo
    {
        static void Main(string[] args)
        {
            Sample sample= new Sample();
            sample.Display();
            sample = null;
            GC.Collect();
            Console.WriteLine(GC.GetTotalMemory(false));
            GC.Collect();
            Console.WriteLine(GC.MaxGeneration);
            //FileInfo file = new FileInfo("C:\\Users\\monikak\\Documents\\EXAMPLE2.txt");
            //if (!file.Exists)
            //{
            //    file.Create().Close();
            //}
            //Console.WriteLine(file.FullName);
            //file.CopyTo("C:\\Users\\monikak\\Documents\\EXAMPLE.txt",true);
            ////file.MoveTo("C:\\Users\\monikak\\Documents\\EXAMPLE3.txt");
            //string sourcedir = @"C:\Users\monikak\Documents\project";
            //string targetdir = @"C:\Users\monikak\Documents\sampleDestination";
            //DirectoryInfo sdi=new DirectoryInfo(sourcedir);
            //DirectoryInfo tdi = new DirectoryInfo(targetdir);
            //if (!tdi.Exists)
            //{
            //    tdi.Create();
            //}
            //foreach (FileInfo fi in sdi.GetFiles())
            //{
            //    fi.CopyTo(Path.Combine(tdi.ToString(), fi.Name), true);
            //    Console.WriteLine(@"Copying {0}\{1}", tdi.FullName, fi.Name);
            //}
            //foreach (DirectoryInfo sourceSubDir in sdi.GetDirectories())
            //{
            //    DirectoryInfo targetSubDir = tdi.CreateSubdirectory(sourceSubDir.Name);
            //    foreach (FileInfo fi in sourceSubDir.GetFiles())
            //    {
            //        fi.CopyTo(Path.Combine(targetSubDir.ToString(), fi.Name), true);
            //        Console.WriteLine(@"Copying {0}\{1}", targetSubDir.FullName, fi.Name);
            //    }

            //}
            Console.ReadLine();

        }
    }
}
