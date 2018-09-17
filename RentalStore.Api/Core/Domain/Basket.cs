using System.Collections.Generic;
using System.Linq;

namespace RentalStore.Api.Core.Domain
{
	public class Basket
	{
		public int Id { get; set; }
		public string UserIdentity { get; set; }
		public ISet<BasketItem> Items { get; set; } = new HashSet<BasketItem>();

		public void AddToCart(Product product, int quantity = 1)
		{
			var item = Items.SingleOrDefault(cartItem => cartItem.Product.ProductId == product.ProductId);

			if (item == null)
				Items.Add(new BasketItem { Product = product, Quantity = quantity });
			else
				item.Quantity += quantity;
		}
	}
}
