using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databasefirstass
{
    internal class helper
    {
        public static List<string> ValidateEmployee(Employee emp)
        {
            List<string> errors = new List<string>();
            var context = new ValidationContext(emp, null, null);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(emp, context, results, true);
            if (!isValid)
            {
                foreach (var res in results)
                {
                    errors.Add(res.ErrorMessage);
                }
            }
            return errors;
        }
    }
}
