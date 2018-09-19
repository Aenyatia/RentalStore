using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentalStore.Api.Core.Commands.Cart;
using RentalStore.Api.Core.Services.Cart;
using RentalStore.Api.Infrastructure.Identity;
using System.Security.Claims;

namespace RentalStore.Api.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CartController : ControllerBase
	{
		private readonly CartService _cartService;
		private readonly UserManager<User> _userManager;

		public CartController(CartService cartService, UserManager<User> userManager)
		{
			_cartService = cartService;
			_userManager = userManager;
		}

		// GET api/cart
		[HttpGet]
		public IActionResult Get()
		{
			var loggedUserId = GetId(HttpContext.User);
			var cart = _cartService.GetCartAsync(loggedUserId);

			return Ok(cart);
		}

		// POST api/cart
		[HttpPost]
		public IActionResult Post([FromBody]AddProduct command)
		{
			command.UserId = GetId(HttpContext.User);
			var result = _cartService.AddToCartAsync(command);

			if (!result.IsValid)
				return BadRequest(result.Errors);

			return Ok("Item added.");
		}

		private string GetId(ClaimsPrincipal user)
			=> _userManager.GetUserId(user);
	}
}
