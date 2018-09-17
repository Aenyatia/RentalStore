using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentalStore.Api.Core.Commands.Basket;
using RentalStore.Api.Core.Services;
using RentalStore.Api.Infrastructure.Identity;

namespace RentalStore.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BasketController : ControllerBase
	{
		private readonly BasketService _basketService;
		private readonly SignInManager<AppUser> _signInManager;

		public BasketController(BasketService basketService, SignInManager<AppUser> signInManager)
		{
			_basketService = basketService;
			_signInManager = signInManager;
		}

		[HttpGet]
		public IActionResult Get()
		{
			return Ok();
		}

		[HttpPost]
		public IActionResult Post([FromBody]AddItemToBasketCommand command)
		{
			command.UserIdentity = HttpContext.User.Identity.Name;
			_basketService.AddToBasket(command);

			return Created("", null);
		}
	}
}
