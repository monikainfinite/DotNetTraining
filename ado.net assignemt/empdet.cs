using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ado.net_assignemt
{
    public class empdet
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public decimal Salary { get; set; }
        public DateTime DateOfJoin { get; set; }
        public int DeptId { get; set; }
    }
    public class dept
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }
    class Movies
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Actor { get; set; }
        public string Actress { get; set; }
        public int YOR { get; set; }
    }
    class Products
    {
        public int pid { get; set; }
        public string pname { get; set; }
        public int price { get; set; }
        public int qty { get; set; }
    }
}
