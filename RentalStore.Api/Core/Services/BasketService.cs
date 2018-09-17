using RentalStore.Api.Core.Commands.Basket;
using RentalStore.Api.Core.Domain;
using RentalStore.Api.Infrastructure.Data;
using System;
using System.Linq;

namespace RentalStore.Api.Core.Services
{
	public class BasketService
	{
		private readonly StoreContext _context;

		public BasketService(StoreContext context)
		{
			_context = context;
		}

		public void AddToBasket(AddItemToBasketCommand command)
		{
			var product = _context.Products.SingleOrDefault(p => p.ProductId == command.ProductId);

			if (product == null)
				throw new ArgumentException($"Product with id = {command.ProductId} does not exists.");

			var basket = _context.Carts.SingleOrDefault(c => c.UserIdentity == command.UserIdentity) ??
						 new Basket { UserIdentity = command.UserIdentity };

			basket.AddToCart(product, command.Quantity);
		}
	}
}
