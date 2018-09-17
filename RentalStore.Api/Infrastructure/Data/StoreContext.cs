using Microsoft.EntityFrameworkCore;
using RentalStore.Api.Core.Domain;

namespace RentalStore.Api.Infrastructure.Data
{
	public class StoreContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Basket> Carts { get; set; }

		public StoreContext()
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
