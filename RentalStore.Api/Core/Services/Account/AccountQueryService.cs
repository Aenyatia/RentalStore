using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RentalStore.Api.Core.Dto;
using RentalStore.Api.Infrastructure.Identity;
using System.Threading.Tasks;

namespace RentalStore.Api.Core.Services.Account
{
	public class AccountQueryService
	{
		private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;

		public AccountQueryService(UserManager<User> userManager, IMapper mapper)
		{
			_userManager = userManager;
			_mapper = mapper;
		}

		public async Task<UserDto> GetUserByEmailAsync(string email)
		{
			var user = await _userManager.FindByEmailAsync(email);

			return _mapper.Map<User, UserDto>(user);
		}
	}
}
