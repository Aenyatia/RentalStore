using AutoMapper;
using RentalStore.Api.Core.Domain;
using RentalStore.Api.Core.Dto;
using System.Collections.Generic;
using System.Linq;

namespace RentalStore.Api.Core.Services
{
	public class CatalogService
	{
		private readonly IMapper _mapper;

		private static readonly ISet<Product> Manga = new HashSet<Product>
		{
			new Product{ ProductId = 1, Title = "Pandora Hearts #1", Description = "...", Genre = "Adventure", Price = 20.00m, InStock = 10 },
			new Product{ ProductId = 2, Title = "Pandora Hearts #2", Description = "...", Genre = "Adventure", Price = 18.00m, InStock = 0 },
			new Product{ ProductId = 3, Title = "Akame ga Kill #1", Genre = "Fantasy", Price = 19.90m, InStock = 3 },
			new Product{ ProductId = 4, Title = "Akame ga Kill #2", Genre = "Fantasy", Price = 19.90m, InStock = 4 },
			new Product{ ProductId = 5, Title = "Pamiętnik Przyszłości #1", Genre = "Horror", Price = 23.50m, InStock = 7 },
			new Product{ ProductId = 6, Title = "Pamiętnik Przyszłości #2", Genre = "Horror", Price = 35.79m, InStock = 20 },
			new Product{ ProductId = 7, Title = "Pandora Hearts #1", Description = "...", Genre = "Adventure", Price = 20.00m, InStock = 10 },
			new Product{ ProductId = 8, Title = "Pandora Hearts #2", Description = "...", Genre = "Adventure", Price = 18.00m, InStock = 0 },
			new Product{ ProductId = 9, Title = "Pamiętnik Przyszłości #1", Genre = "Horror", Price = 23.50m, InStock = 7 },
			new Product{ ProductId = 10, Title = "Pamiętnik Przyszłości #2", Genre = "Horror", Price = 35.79m, InStock = 20 }
		};

		private const int PageSize = 6;

		public CatalogService(IMapper mapper)
		{
			_mapper = mapper;
		}

		public IEnumerable<ProductDto> MangaList(int page)
		{
			var list = Manga
				.Skip((page - 1) * PageSize)
				.Take(PageSize);

			return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(list);
		}
	}
}
