using Microsoft.EntityFrameworkCore;
using RentalStore.Api.Core.Domain;

namespace RentalStore.Api.Infrastructure.Data
{
	public class RentalStoreContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Basket> Carts { get; set; }

		public RentalStoreContext(DbContextOptions<RentalStoreContext> options)
			: base(options)
		{
		}
	}
}
