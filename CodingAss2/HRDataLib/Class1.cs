using CodingAssessment2;
namespace HRDataLib
{
    public interface IEmployeeDataReader
    {
        EmployeeRecord GetEmployeeRecord(int employeeId);
    }
    public class MockEmployeeDataReader : IEmployeeDataReader

    {
        public EmployeeRecord GetEmployeeRecord(int employeeId) {
           
            return employeeId switch
            {
                101 => new EmployeeRecord { Id = 101, Name = "Monika", Role = "Intern", Isveteran = true },
                102 => new EmployeeRecord { Id = 102, Name = "Sri", Role = "Manager", Isveteran = false },
                103 => new EmployeeRecord { Id = 103, Name = "Teja", Role = "Developer", Isveteran = true },
                104 => new EmployeeRecord { Id = 104, Name = "Varshini", Role = "Intern", Isveteran = false },
                _ => new EmployeeRecord { Id = employeeId, Name = "Unknown", Role = "Intern", Isveteran = false }
            };
            }

    }
}

