using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WınFormsAttribute.Payment.PaymentTypes
{
	public interface IPayment
    {
        string makePayment(decimal amount);
    }
}
