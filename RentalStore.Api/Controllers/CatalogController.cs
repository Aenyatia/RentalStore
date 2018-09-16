using Microsoft.AspNetCore.Mvc;
using RentalStore.Api.Core.Services;

namespace RentalStore.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CatalogController : ControllerBase
	{
		private readonly CatalogService _catalogService;

		public CatalogController(CatalogService catalogService)
		{
			_catalogService = catalogService;
		}

		[HttpGet("{page?}")]
		public IActionResult Get(int page = 1)
		{
			var products = _catalogService.MangaList(page);

			return Ok(products);
		}
	}
}
