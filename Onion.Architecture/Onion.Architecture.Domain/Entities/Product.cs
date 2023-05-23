using System;
using Onion.Architecture.Domain.Common;

namespace Onion.Architecture.Domain.Entities
{
	public class Product:BaseEntity
	{
		public int Id { get;  set; }
		public string ProductCode { get; private set; }
		public string ProductName { get; private set; }
		public Product(string productCode,string productName)
		{
			this.ProductCode = productCode;
			this.ProductName = productName;
		}

	}
}

