using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalStore.Api.Core.Commands.Basket;
using RentalStore.Api.Core.Services;

namespace RentalStore.Api.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class BasketController : ControllerBase
	{
		private readonly BasketService _basketService;

		public BasketController(BasketService basketService)
		{
			_basketService = basketService;
		}

		[HttpGet]
		public IActionResult Get()
		{
			var basket = _basketService.GetBasket(HttpContext.User.Identity.Name);

			return Ok(basket);
		}

		[HttpPost]
		public IActionResult Post([FromBody]AddItemToBasket command)
		{
			command.UserIdentity = HttpContext.User.Identity.Name;
			_basketService.AddToBasket(command);

			return Ok("Item added.");
		}
	}
}
