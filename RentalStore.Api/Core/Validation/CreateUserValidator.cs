using FluentValidation;
using RentalStore.Api.Core.Commands.Account;

namespace RentalStore.Api.Core.Validation
{
	public class CreateUserValidator : AbstractValidator<CreateUser>
	{
		public CreateUserValidator()
		{
			RuleFor(p => p.Name)
				.NotEmpty();

			RuleFor(p => p.Email)
				.EmailAddress();

			RuleFor(p => p.Password)
				.Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$");
		}
	}
}
