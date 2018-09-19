using Microsoft.EntityFrameworkCore;
using RentalStore.Api.Core.Domain.Order;
using RentalStore.Api.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RentalStore.Api.Core.Services.Order
{
	public class OrderService
	{
		private readonly RentalStoreContext _context;

		public OrderService(RentalStoreContext context)
		{
			_context = context;
		}

		public IEnumerable<Domain.Order.Order> GetOrders(string userId)
		{
			return _context.Orders
				.Include(i => i.Address)
				.Include(i => i.OrderItems)
				.Where(o => o.UserId == userId);
		}

		public void CreateOrder(int cartId, Address address)
		{
			var cart = _context.Carts.SingleOrDefault(b => b.Id == cartId);
			if (cart == null)
				throw new ArgumentException();

			var items = new HashSet<OrderItem>();
			foreach (var cartItem in cart.Items)
			{
				var orderedItem = new OrderItem
				{
					ProductId = cartItem.Product.ProductId,
					Quantity = cartItem.Quantity,
					Price = cartItem.Product.Price
				};
				items.Add(orderedItem);
			}
			var order = new Domain.Order.Order
			{
				UserId = cart.UserId,
				OrderItems = items,
				Address = address,
			};

			_context.Orders.Add(order);
			_context.SaveChanges();
		}
	}
}
