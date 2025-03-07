using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributeLibrary.Attributes
{
	[Tablo("Product")]
	public class UrunEntity
	{

		[Alan(AlanAdi = "ProductID", Identity = true, NullIcerebilir = false)]
		public int UrunId { get; set; }

		[Alan("Name", false, false)]
		public string UrunAdi { get; set; }


		[Alan("ListPrice", Identity = false, NullIcerebilir = false)]
		public decimal Fiyat { get; set; }

		[Alan("SellStartDate", false, true)]
		public DateTime SonSatisTarihi { get; set; }


		public UrunEntity(int idsi, string adi, decimal fiyati)
		{
			UrunId = idsi;
			UrunAdi = adi;
			Fiyat = fiyati;
		}
		public UrunEntity()
		{
		}
	}
}
