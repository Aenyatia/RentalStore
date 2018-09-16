using AutoMapper;
using RentalStore.Api.Core.Domain;
using RentalStore.Api.Core.Dto;

namespace RentalStore.Api.Core.Configurations.AutoMapper
{
	public static class AutoMapperConfig
	{
		public static IMapper Initialize()
			=> new MapperConfiguration(cfg =>
				{
					cfg.CreateMap<Product, ProductDto>();
				})
			.CreateMapper();
	}
}
