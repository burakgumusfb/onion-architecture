using System;
namespace Onion.Architecture.Domain.Common
{
	public class BaseAuditableEntity:BaseEntity
	{
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateUserId { get; set; }
    }
}

