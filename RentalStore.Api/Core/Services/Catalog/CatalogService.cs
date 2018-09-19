using AutoMapper;
using RentalStore.Api.Core.Domain;
using RentalStore.Api.Core.Dto;
using RentalStore.Api.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace RentalStore.Api.Core.Services.Catalog
{
	public class CatalogService
	{
		private readonly RentalStoreContext _context;
		private readonly IMapper _mapper;
		private const int PageSize = 6;

		public CatalogService(RentalStoreContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public IEnumerable<ProductDto> MangaList(int page)
		{
			var list = _context.Products
				.Skip((page - 1) * PageSize)
				.Take(PageSize);

			return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(list);
		}
	}
}
