using System.Collections.Generic;

namespace RentalStore.Api.Core.Domain.Cart
{
	public class Cart
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public ISet<CartItem> Items { get; set; } = new HashSet<CartItem>();
	}
}
