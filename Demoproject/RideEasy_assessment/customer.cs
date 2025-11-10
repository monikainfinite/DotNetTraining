using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideEasy_assessment
{
    internal class customer
    {
        public string customerName;
        public string mobile;
        public int loyaltyPoints;
        public customer(string name,string number,int points)
        {
            this.customerName = name;
            this.mobile = number;
            this.loyaltyPoints = points;

        }
    }
}
