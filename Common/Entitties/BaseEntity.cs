using System;
namespace Common.Entitties
{
	public class BaseEntity
	{
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public DateTime? ModifiedAt { get; set; }
	}
}

