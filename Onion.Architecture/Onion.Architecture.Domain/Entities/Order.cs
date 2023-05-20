using System;
using Onion.Architecture.Domain.Common;

namespace Onion.Architecture.Domain.Entities
{
	public class Order:BaseEntity
	{
		public int totalAmount { get; set; }
	}
}

