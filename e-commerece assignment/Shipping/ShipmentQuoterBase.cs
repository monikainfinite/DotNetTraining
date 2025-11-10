using e_commerece_assignment.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerece_assignment.Shipping
{
    public abstract class ShipmentQuoterBase : IShipmentQuoter
    {
        public abstract decimal Quote(IOrder order);
    }

}
