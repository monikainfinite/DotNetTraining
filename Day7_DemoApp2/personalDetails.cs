using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7_DemoApp2
{
    public sealed class PersonalDetails
    {
        public string Email { get; set; }
        public string LockerNumber { get; set; }
        public string GenericPassword {  get; set; }
        public void getPersonDetails()
        {
            Console.WriteLine("enter email,lockernumber,password");
            Email =Console.ReadLine();
            LockerNumber=Console.ReadLine();
            GenericPassword=Console.ReadLine();
           
            Console.WriteLine($"email: {Email}");
            Console.WriteLine($"Lock Number :{LockerNumber}");
            Console.WriteLine($"Generic Password: {GenericPassword}");

        }


    }
    //public class EmployeeDetails : PersonalDetails { 
    //}
    //here we cant inherit personaldetails class because the class is selaed .
    //when we want the class not to be inherited, we will make that class sealed..

}
