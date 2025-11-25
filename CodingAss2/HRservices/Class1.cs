using HRDataLib;
using CodingAssessment2;

namespace HRservices
{
    public class PayrollProcessor
    {
        private readonly IEmployeeDataReader dataReader;
        private static readonly Dictionary<int, decimal> Salaries = new ()
        {{101,65000m},
            {102,40000m },


          { 103, 80000m }

          };

        public PayrollProcessor(IEmployeeDataReader dataReader)
        {
            this.dataReader = dataReader;
        }
        public decimal CalculateTotalAmount(int employeeId)
        {
            EmployeeRecord emp = dataReader.GetEmployeeRecord(employeeId);
            decimal salary = Salaries.ContainsKey(employeeId) ? Salaries[employeeId] : 40000m;
           
            decimal bonus = emp switch
            {
                { Role: "Manager", Isveteran: true } => 10000m,
                { Role: "Manager", Isveteran: false } => 5000m,
                { Role: "Developer" } => 2000m,
                { Role: "Intern" } => 500m,
                _ => 0m
            };

            return salary + bonus;



        }

    }
}
