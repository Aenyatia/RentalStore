using Microsoft.AspNetCore.Mvc;
using RentalStore.Api.Core.Commands.Account;
using RentalStore.Api.Core.Services.Account;
using System.Threading.Tasks;

namespace RentalStore.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly AccountCommandService _accountCommandService;
		private readonly AccountQueryService _accountQueryService;

		public AccountController(
			AccountCommandService accountCommandService,
			AccountQueryService accountQueryService)
		{
			_accountCommandService = accountCommandService;
			_accountQueryService = accountQueryService;
		}

		// GET api/account/{email}
		[HttpGet("{email}")]
		public async Task<IActionResult> Get(string email)
		{
			var userDto = await _accountQueryService.GetUserByEmailAsync(email);

			if (userDto == null)
				return NotFound();

			return Ok(userDto);
		}

		// POST api/account/signup
		[HttpPost("signup")]
		public async Task<IActionResult> Post([FromBody]CreateUser command)
		{
			var result = await _accountCommandService.SignUpAsync(command);

			if (!result.IsValid)
				return BadRequest(result.Errors);

			return Created($"/api/account/{command.Email}", "Sign up");
		}

		// POST api/account/signin
		[HttpPost("signin")]
		public async Task<IActionResult> Post([FromBody]SignIn command)
		{
			var result = await _accountCommandService.SignInAsync(command);

			if (!result.IsValid)
				return BadRequest(result.Errors);

			return Ok("Sign in.");
		}

		// POST api/account/signout
		[HttpPost("signout")]
		public async Task<IActionResult> Post()
		{
			await _accountCommandService.SignOutAsync();

			return Ok("Sign out.");
		}
	}
}
