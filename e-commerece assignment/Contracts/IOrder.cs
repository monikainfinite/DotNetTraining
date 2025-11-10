using e_commerece_assignment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerece_assignment.Contracts
{
    public interface IOrder
    {
        int Id { get; }
        string BuyerEmail { get; }
        string ShipToCity { get; }
        decimal TotalWeightKg { get; }
        ILineItem[] Items { get; }
        OrderStatus Status { get; set; }
    }

}
