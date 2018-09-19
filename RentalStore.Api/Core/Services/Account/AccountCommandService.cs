using Microsoft.AspNetCore.Identity;
using RentalStore.Api.Core.Commands.Account;
using RentalStore.Api.Core.Common;
using RentalStore.Api.Infrastructure.Identity;
using System.Threading.Tasks;

namespace RentalStore.Api.Core.Services.Account
{
	public class AccountCommandService
	{
		private readonly ServiceCommandResult _serviceCommandResult = new ServiceCommandResult();

		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;

		public AccountCommandService(UserManager<User> userManager, SignInManager<User> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public async Task<ServiceCommandResult> SignUpAsync(CreateUser command)
		{
			var user = new User { UserName = command.Name, Email = command.Email };
			var identityResult = await _userManager.CreateAsync(user, command.Password);

			if (identityResult.Succeeded)
				return _serviceCommandResult;

			foreach (var error in identityResult.Errors)
				_serviceCommandResult.AddError(error.Code, error.Description);

			return _serviceCommandResult;
		}

		public async Task<ServiceCommandResult> SignInAsync(SignIn command)
		{
			var user = await _userManager.FindByEmailAsync(command.Email);
			if (user == null)
			{
				_serviceCommandResult.AddError(ErrorCodes.InvalidCredentials);
				return _serviceCommandResult;
			}

			await _signInManager.SignOutAsync();

			var signInResult = await _signInManager.PasswordSignInAsync(user, command.Password, false, false);
			if (!signInResult.Succeeded)
				_serviceCommandResult.AddError(ErrorCodes.InvalidCredentials);

			return _serviceCommandResult;
		}

		public async Task SignOutAsync()
		{
			await _signInManager.SignOutAsync();
		}
	}
}
