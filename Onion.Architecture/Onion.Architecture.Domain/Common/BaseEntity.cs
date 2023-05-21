using System;
namespace Onion.Architecture.Domain.Common
{
	public class BaseEntity
	{
		public int Id { get; set; }
		public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime ModifyDate { get; set; }
        public int? ModifyUserId { get; set; }

		public DateTime DeleteDate { get; set; }
		public int? DeleteUserId { get; set; }
		public bool IsDeleted { get; set; }
	}
}

