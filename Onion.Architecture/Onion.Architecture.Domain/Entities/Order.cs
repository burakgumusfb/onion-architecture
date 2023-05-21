using System;
using Onion.Architecture.Domain.Common;

namespace Onion.Architecture.Domain.Entities
{
	public class Order:BaseEntity
	{
		public string Description { get; set; }
		public int TotalAmount { get; set; }
	}
}

