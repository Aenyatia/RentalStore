using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentalStore.Api.Core.Domain.Order;
using RentalStore.Api.Core.Services.Cart;
using RentalStore.Api.Core.Services.Order;
using RentalStore.Api.Infrastructure.Identity;
using System.Security.Claims;

namespace RentalStore.Api.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly OrderService _orderService;
		private readonly UserManager<User> _userManager;
		private readonly CartService _cartService;

		public OrderController(OrderService orderService, UserManager<User> userManager, CartService cartService)
		{
			_orderService = orderService;
			_userManager = userManager;
			_cartService = cartService;
		}

		[HttpGet]
		public IActionResult Get()
		{
			var userId = GetId(HttpContext.User);
			var orders = _orderService.GetOrders(userId);

			return Ok(orders);
		}

		[HttpPost]
		public IActionResult Post()
		{
			var userId = GetId(HttpContext.User);
			var cart = _cartService.GetCartAsync(userId);
			var address = new Address { City = "Warsaw", Street = "Wiejska" };

			_orderService.CreateOrder(cart.Id, address);

			return Created("", null);
		}

		private string GetId(ClaimsPrincipal user)
			=> _userManager.GetUserId(user);
	}
}
