using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WınFormsAttribute.Payment.Db;
using WınFormsAttribute.Payment.PaymentTypes;

namespace WınFormsAttribute
{
	public partial class Form1 : Form
	{
		private PaymentDb? dbContext;
		public Form1()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			this.dbContext = new PaymentDb();

			this.dbContext.Database.EnsureCreated();
			this.dbContext.PaymentTypes.Load();

			this.comboBox1.DataSource = this.dbContext.PaymentTypes.ToList();
			this.comboBox1.ValueMember = "Id";
			this.comboBox1.DisplayMember = "Name";
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private bool GetDecimalFromTextBox(TextBox textBox,out decimal defaultValue)
		{
			defaultValue = 0;
			if (string.IsNullOrWhiteSpace(textBox.Text))
			{
				return false;
			}
			string text = textBox.Text.Trim();
			if (decimal.TryParse(text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
								 CultureInfo.InvariantCulture, out defaultValue))
			{
				return true;
			}

			return false;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			decimal amount = 0;
			if (!GetDecimalFromTextBox(inputAmount,out amount))
			{
				return;
			}
			var paymentService = new PaymentService();
			int value = (int)comboBox1.SelectedValue;
			label1.Text = paymentService.MakePayment(amount, (PaymentEnum)value);
		}
	}
}
