using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeLibrary.Attributes
{
	 [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
	 class TabloAttribute : Attribute
	{
		public string TabloAdi { get; set; }
		public string SchemaAdi { get; set; }

		public TabloAttribute(string tablonunAdi, string schemaninAdi)
		{
			TabloAdi = tablonunAdi;
			SchemaAdi = schemaninAdi;
		}
		public TabloAttribute(string tablonunAdi)
			: this(tablonunAdi, "dbo")
		{
		}
		// Varsayılan yapıcı metod kullanılmadığı zaman bu niteliğin kullanımına bakalım.
		public TabloAttribute()
		{

		}

	}
}
