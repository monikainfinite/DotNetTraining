using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Patterndesignexercises
{
    public abstract class DataExporter
    {
        public void Export()
        {
            Connect();
            FetchData();
            FormatData();
            SaveToFile();
        }
        public void Connect()
        {
            Console.WriteLine("Connecting to data source...");
        }
        public abstract void FetchData();
        public abstract void FormatData();
        public abstract void SaveToFile();
    }
    public class CsvExporter : DataExporter
    {
        public override void FetchData()
        {
            WriteLine("Fetching data for CSV...");
        }
        public override void FormatData()
        {
           WriteLine("Formatting data as CSV...");
        }
        public override void SaveToFile()
        {
           WriteLine("Saving CSV file...");
        }
    }
    public class JsonExporter : DataExporter
    {
        public override void FetchData()
        {
           WriteLine("Fetching data for JSON");
        }
        public override void FormatData()
        {
            WriteLine("Formatting data as JSON");
        }
        public override void SaveToFile()
        {
         WriteLine("Saving JSON file");
        }
    }
    public class XmlExporter : DataExporter
    {
        public override void FetchData()
        {
            WriteLine("Fetching data for XML");
        }
        public override void FormatData()
        {
            WriteLine("Formatting data as XML");
        }
        public override void SaveToFile()
        {
            WriteLine("Saving XML file");
        }
    }
    internal class template_ex_4_
    {
        public static void Main(string[] args)
        {
            DataExporter exporter;
            exporter = new CsvExporter();
            exporter.Export();
            exporter = new JsonExporter();
            exporter.Export();
            exporter = new XmlExporter();
            exporter.Export();
        }
    }
}
