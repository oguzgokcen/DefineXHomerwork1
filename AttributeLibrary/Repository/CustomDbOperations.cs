using AttributeLibrary.Attributes;
using Microsoft.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace AttributeLibrary.Repository
{
	public class CustomDbOperations
	{
		private readonly string _connectionString;

		public CustomDbOperations(string connectionString)
		{
			_connectionString = connectionString;
		}

		public int Add<T>(T entity) where T : class
		{
			Type tip = typeof(T);
			TabloAttribute tblAtr = ((TabloAttribute[])tip.GetCustomAttributes(typeof(TabloAttribute), false))[0];
			string tabloAdi = tblAtr.TabloAdi;
			string schemaAdi = tblAtr.SchemaAdi;
			StringBuilder insertBuilder = new StringBuilder();
			insertBuilder.Append("Insert into ");
			insertBuilder.Append(schemaAdi);
			insertBuilder.Append(".");
			insertBuilder.Append(tabloAdi);
			insertBuilder.Append(" (");

			// Insert sorgusundaki alan adları çekiliyor.
			foreach (PropertyInfo prp in tip.GetProperties())
			{
				AlanAttribute atr = ((AlanAttribute[])prp.GetCustomAttributes(typeof(AlanAttribute), false))[0];
				if (!atr.Identity)
				{
					string alanAdi = atr.AlanAdi;
					insertBuilder.Append(alanAdi);
					insertBuilder.Append(",");
				}
			}
			// Son eklenen virgülü kaldırmak için.
			insertBuilder.Remove(insertBuilder.Length - 1, 1);
			insertBuilder.Append(") Values (");

			// insert sorgusundaki değerleri çekiliyor.
			foreach (PropertyInfo prp in tip.GetProperties())
			{
				AlanAttribute atr = ((AlanAttribute[])prp.GetCustomAttributes(typeof(AlanAttribute), false))[0];
				if (!atr.Identity)
				{
					object alanDegeri = prp.GetValue(entity, null);
					if ((prp.PropertyType.Name == "String")
							|| (prp.PropertyType.Name == "DateTime"))
						insertBuilder.Append("'" + prp.GetValue(entity, null).ToString() + "',");
					else
						insertBuilder.Append(prp.GetValue(entity, null).ToString() + ",");
				}
			}
			insertBuilder.Remove(insertBuilder.Length - 1, 1);
			insertBuilder.Append(")");

			string sqlQuery = insertBuilder.ToString();

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = new SqlCommand(sqlQuery, connection))
				{
					foreach (var property in tip.GetProperties())
					{
						var columnAttribute = (AlanAttribute)property.GetCustomAttribute(typeof(AlanAttribute));
						if (columnAttribute != null && !columnAttribute.Identity)
						{
							command.Parameters.AddWithValue("@" + columnAttribute.AlanAdi, property.GetValue(entity) ?? DBNull.Value);
						}
					}

					try
					{
						connection.Open();
						return command.ExecuteNonQuery();
					}
					catch (Exception ex)
					{
						Console.WriteLine($"Error inserting entity: {ex.Message}");
						return -1;
					}
				}
			}
		}
	}
}
