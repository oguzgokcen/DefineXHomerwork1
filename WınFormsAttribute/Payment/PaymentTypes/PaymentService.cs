using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WınFormsAttribute.Payment.PaymentTypes
{
	public class PaymentService
	{
		public string MakePayment(decimal amount,PaymentEnum paymentType)
		{
			string className = $"WınFormsAttribute.Payment.PaymentTypes.{paymentType.ToString()}";
			Type type = Assembly.GetExecutingAssembly().GetType(className);

			var payment = (IPayment)Activator.CreateInstance(type);
			var result = payment.makePayment(amount);
			return result;
		}
	}
}
