using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WınFormsAttribute.Payment.PaymentTypes
{
	public class CreditCard : IPayment
    {
        public string makePayment(decimal amount)
        {
            return $"{amount} miktarda ücret kartla ödendi.";
		}
    }
}
