using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WınFormsAttribute.Payment.PaymentTypes
{
	public class Cash : IPayment
    {
		public string makePayment(decimal amount)
		{
			return $"{amount} miktarda ücret cash ile ödendi.";

		}
	}
}
