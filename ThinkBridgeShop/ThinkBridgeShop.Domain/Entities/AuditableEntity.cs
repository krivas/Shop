using System;
namespace ThinkBridgeShop.Domain.Entities
{
	public class AuditableEntity
	{
		public DateTime CreatedDate { get; set; }
		public DateTime LastModifiedDate { get; set; }
	}
}

