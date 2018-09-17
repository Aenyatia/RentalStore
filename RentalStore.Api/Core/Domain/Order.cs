using System.Collections.Generic;
using System.Linq;

namespace RentalStore.Api.Core.Domain
{
	public class Order
	{
		public ISet<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
		public string UserIdentity { get; set; }
		public Address Address { get; set; }

		public decimal TotalPrice()
		{
			return OrderItems.Sum(orderItem => orderItem.Price * orderItem.Quantity);
		}
	}
}
