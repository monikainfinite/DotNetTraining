using e_commerece_assignment.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerece_assignment.Shipping
{

    public sealed class BluedartQuoter : ShipmentQuoterBase
    {
        public override decimal Quote(IOrder order)
        {
            decimal price = 60 + 25 * order.TotalWeightKg;
            if (order.ShipToCity == "Vizag")
                price *= 0.9M; 
            return price;
        }
    }
}