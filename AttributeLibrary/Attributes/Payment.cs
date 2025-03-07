using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WınFormsAttribute.Payment.PaymentTypes
{
	public class Payment
    {
        public IPayment iPayment;

        public Payment(IPayment iLogger)
        {
            this.iPayment = iLogger;
        }   

        public void makePayment(decimal amount)
        {
			iPayment.makePayment(amount);
        }
    }
}
