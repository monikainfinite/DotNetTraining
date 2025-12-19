using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databasefirstass
{
  public partial  class EmployeeValidation
    {
        [RegularExpression(@"^E\d{3}$",
            ErrorMessage = "EmpId must start with E followed by 3 digits")]
        public string EmpId { get; set; }

        [Required(ErrorMessage = "Employee Name is required")]
        public string EmpName { get; set; }
        [Required(ErrorMessage = "Department Name is required")]
        public string DepartmentName { get; set; }
        [Range(5000, 50000,
            ErrorMessage = "Salary must be between 5000 and 50000")]
        public int Salary { get; set; }
        [Range(1990, int.MaxValue,
            ErrorMessage = "Year of Joining must be 1990 or later")]
        public int YearOfJoining { get; set; }
    }
}
