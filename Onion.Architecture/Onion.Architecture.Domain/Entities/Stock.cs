using System;
using System.ComponentModel.DataAnnotations.Schema;
using Onion.Architecture.Domain.Common;

namespace Onion.Architecture.Domain.Entities
{
	public class Stock:BaseEntity
	{
		public int Id { get; set; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public Stock(int productId,int quantity)
        {
            ProductId = productId;
            Quantity = quantity; 
        }

	}
}

