using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace autocare_assignment
{
    class Vehicle
    {
        private string regNumber;
        protected int servicecount;
        private string vehicleType;
        public Vehicle(string regNumber, string vehicleType)
        {
            this.regNumber = regNumber;
            this.vehicleType = vehicleType;
            servicecount = 0;
            Console.WriteLine("Base class constructor");
        }
        private void showregistration()
        {
            Console.WriteLine($"Registration number is {regNumber}");

        }
        protected void DisplayBasicInfo()
        {
            Console.WriteLine($"vehicle Info");
            showregistration();
            Console.WriteLine($"the vehicle type is {vehicleType}");
        }
        public void UpdateServiceCount()
        {
            servicecount++;
            //Console.WriteLine($"service count updated to :{servicecount}");
        }
    }
    class Car : Vehicle
    {
        private string brand;
        private string fuelType;
        private string location;
        public Car(string regNumber,string vehicleType,string brand,string fuelType,string location) : base(regNumber, vehicleType)
        {
            this.brand = brand;
            this.fuelType = fuelType;
            this.location = location;
            Console.WriteLine("Car Constructor initiliazed...");
        }
       public void PerformInspection()
        {
            Console.WriteLine("Performing Inspection");
        }
        public void PerfomMaintance()
        {
            //Console.WriteLine("Performing Maintance");
            UpdateServiceCount();
            Console.WriteLine($"Service count:{servicecount}");
            //Console.WriteLine($"Maintance complete at :{location}");
        }
        public void DisplayCarInfo()
        {
            DisplayBasicInfo();
            Console.WriteLine("car Info");
            Console.WriteLine($"Brand :{brand}");
            Console.WriteLine($"Fuel Type: {fuelType}");

        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string reg, vehicletype, brand, fuelType, location;
            Console.WriteLine("enter registration number");
            reg = Console.ReadLine();
            Console.WriteLine("enter vehicle type");
            vehicletype = Console.ReadLine();
            Console.WriteLine("enter brand name");
            brand = Console.ReadLine();
            Console.WriteLine("enter fuelType");
            fuelType = Console.ReadLine();
            Console.WriteLine("enter maintance location");
            location = Console.ReadLine();
            Car car1 = new Car(reg, vehicletype, brand, fuelType, location);
            car1.DisplayCarInfo();
            car1.PerformInspection();
           
                car1.PerfomMaintance();
           
            Console.WriteLine($"THe location is {location}");

            Console.ReadLine();
        }
    }
}
