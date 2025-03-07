using Microsoft.EntityFrameworkCore;
using WınFormsAttribute.Payment.PaymentTypes;

namespace WınFormsAttribute.Payment.Db
{
	public class PaymentDb : DbContext
	{
		public PaymentDb() { }
		public DbSet<PaymentType> PaymentTypes { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseSqlServer("Data Source=LAPTOP-061MDE8T;Initial Catalog=PaymentReflection;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PaymentType>().HasData(
				new PaymentType { Id = 1, Name = "Cash" },
				new PaymentType { Id = 2, Name = "CreditCard" });
		}
	}
}
