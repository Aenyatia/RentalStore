using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentalStore.Api.Core.Commands.Account;
using RentalStore.Api.Infrastructure.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace RentalStore.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;

		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpGet]
		public IActionResult Get()
		{
			var users = _userManager.Users;

			return Ok(users);
		}

		[HttpGet("{email}")]
		public IActionResult Get(string email)
		{
			var user = _userManager.Users.SingleOrDefault(u => u.Email == email);

			return Ok(user);
		}

		[HttpPost("signup")]
		public async Task<IActionResult> Post([FromBody]CreateAppUser command)
		{
			var user = new AppUser
			{
				UserName = command.Name,
				Email = command.Email
			};

			var identityResult = await _userManager.CreateAsync(user, command.Password);

			if (!identityResult.Succeeded)
				return BadRequest(identityResult.Errors);

			return Created($"/api/account/{command.Email}", user);
		}

		[HttpPost("signin")]
		public async Task<IActionResult> Post([FromBody]SignIn command)
		{
			var user = await _userManager.FindByEmailAsync(command.Email);

			if (user == null)
				return BadRequest($"User with email {command.Email} does not exists.");

			await _signInManager.SignOutAsync();

			var signInResult = await _signInManager.PasswordSignInAsync(user, command.Password, false, false);

			if (signInResult.Succeeded)
				return BadRequest("Wrong password.");

			return Ok($"{user.UserName}, you are logged.");
		}

		[HttpPost("logout")]
		public async Task<IActionResult> Post()
		{
			await _signInManager.SignOutAsync();

			return Ok("Logout");
		}
	}
}
