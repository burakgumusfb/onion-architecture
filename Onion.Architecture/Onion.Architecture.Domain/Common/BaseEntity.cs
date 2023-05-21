using System;
namespace Onion.Architecture.Domain.Common
{
	public class BaseEntity
	{
		public int Id { get; set; }
		public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateUserId { get; set; }
	}
}

