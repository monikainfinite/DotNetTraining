using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideEasy_assessment
{
    internal class vehicle
    {
        public string type;
        public decimal baseFare;
        public decimal perKmRate;
        public vehicle(string type, decimal baseFare, decimal perKmRate)
        {
            this.type = type;
            this.baseFare = baseFare;
            this.perKmRate = perKmRate;
        }
    }
}
