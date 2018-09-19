using System.Collections.Generic;
using System.Linq;

namespace RentalStore.Api.Core.Domain.Order
{
	public class Order
	{
		public int Id { get; set; }
		public ISet<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
		public string UserId { get; set; }
		public Address Address { get; set; }
		public decimal TotalPrice => OrderItems.Sum(orderItem => orderItem.Price * orderItem.Quantity);
	}
}
