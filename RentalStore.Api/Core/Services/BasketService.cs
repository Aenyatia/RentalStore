using Microsoft.EntityFrameworkCore;
using RentalStore.Api.Core.Commands.Basket;
using RentalStore.Api.Core.Domain;
using RentalStore.Api.Infrastructure.Data;
using System;
using System.Linq;

namespace RentalStore.Api.Core.Services
{
	public class BasketService
	{
		private readonly RentalStoreContext _context;

		public BasketService(RentalStoreContext context)
		{
			_context = context;
		}

		public Basket GetBasket(string identity)
		{
			return _context.Carts
				.Include(i => i.Items)
				.ThenInclude(i => i.Product)
				.SingleOrDefault(c => c.UserIdentity == identity);
		}

		public void AddToBasket(AddItemToBasket command)
		{
			var product = _context.Products.SingleOrDefault(p => p.ProductId == command.ProductId);

			if (product == null)
				throw new ArgumentException($"Product with id = {command.ProductId} does not exists.");

			var basket = _context.Carts
				.Include(i => i.Items)
				.ThenInclude(i => i.Product)
				.SingleOrDefault(c => c.UserIdentity == command.UserIdentity);

			if (basket == null)
			{
				basket = new Basket { UserIdentity = command.UserIdentity };
				_context.Carts.Add(basket);
			}

			basket.AddToCart(product, command.Quantity);

			_context.SaveChanges();
		}
	}
}
