using Microsoft.EntityFrameworkCore;
using RentalStore.Api.Core.Commands.Cart;
using RentalStore.Api.Core.Common;
using RentalStore.Api.Core.Domain.Cart;
using RentalStore.Api.Infrastructure.Data;
using System.Linq;

namespace RentalStore.Api.Core.Services.Cart
{
	public class CartService
	{
		private readonly ServiceCommandResult _serviceCommandResult = new ServiceCommandResult();

		private readonly RentalStoreContext _context;

		public CartService(RentalStoreContext context)
		{
			_context = context;
		}

		public Domain.Cart.Cart GetCartAsync(string userId)
		{
			return _context.Carts
				.Include(c => c.Items)
				.ThenInclude(c => c.Product)
				.SingleOrDefault(c => c.UserId == userId);
		}

		public ServiceCommandResult AddToCartAsync(AddProduct command)
		{
			var product = _context.Products.SingleOrDefault(p => p.ProductId == command.ProductId);
			if (product == null)
			{
				var description = $"Product with id '{command.ProductId}' does not exists.";
				_serviceCommandResult.AddError(ErrorCodes.ProductNotFound, description);
				return _serviceCommandResult;
			}

			var cart = GetCartAsync(command.UserId);
			if (cart == null)
			{
				cart = new Domain.Cart.Cart { UserId = command.UserId };
				_context.Carts.Add(cart);
			}

			var item = cart.Items.SingleOrDefault(i => i.Product.ProductId == product.ProductId);
			if (item == null)
			{
				var cartItem = new CartItem { Product = product, Quantity = command.ProductId };
				cart.Items.Add(cartItem);
			}
			else
				item.Quantity += command.Quantity;

			_context.SaveChanges();
			return _serviceCommandResult;
		}
	}
}
