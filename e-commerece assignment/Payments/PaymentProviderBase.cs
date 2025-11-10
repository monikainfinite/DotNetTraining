using e_commerece_assignment.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerece_assignment.Payments
{
    public abstract class PaymentProviderBase : IPaymentProvider
    {
        protected bool captured = false;
        public abstract bool AuthorizePayment(IOrder order, out string failureReason);
        public abstract bool CapturePayment(IOrder order, ref bool isCaptured);
    }
}
