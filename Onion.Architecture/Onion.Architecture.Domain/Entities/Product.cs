using System;
using Onion.Architecture.Domain.Common;

namespace Onion.Architecture.Domain.Entities
{
	public class Product:BaseEntity
	{
		public string ProductName { get; set; }
		public string ProductCode { get; set; }

	}
}

