using e_commerece_assignment.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerece_assignment.Shipping
{
    public sealed class DeliveryQuoter : ShipmentQuoterBase
    {
        public override decimal Quote(IOrder order)
        {
            decimal price = 50 + 28 * order.TotalWeightKg;
            if (order.ShipToCity == "Remote")
                price *= 1.08M; // 
            return price;
        }
    }
}
