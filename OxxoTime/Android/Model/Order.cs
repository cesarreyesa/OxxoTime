using System;
using System.Collections.Generic;

namespace OxxoTime.Model
{
	public class Order
	{
		public Order ()
		{
		}
		public int OrderId { get; set; }
		public bool Status { get; set; }
		public string Description {get;set;}
		public DateTime DtCreated {get;set;}
		public DateTime DtExpiration {get;set;}
		public User User {get;set;}
		public List<OrderItem> Items {get;set;}

	}
}

