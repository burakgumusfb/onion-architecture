using System;
using System.ComponentModel.DataAnnotations.Schema;
using Onion.Architecture.Domain.Common;

namespace Onion.Architecture.Domain.Entities
{
	public class Stock:BaseEntity
	{
		public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

	}
}

