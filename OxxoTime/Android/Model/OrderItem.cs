using System;

namespace OxxoTime.Model
{
	public class OrderItem
	{
		public OrderItem ()
		{
		}

		public int OrderItemId { get; set; }
		public int OrderId {get;set;}
		public int UserId {get;set;}
		public string Description {get;set;}
		public decimal Amount {get;set;}

	}
}

