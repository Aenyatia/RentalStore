using Microsoft.EntityFrameworkCore;
using RentalStore.Api.Core.Domain;
using RentalStore.Api.Core.Domain.Cart;
using RentalStore.Api.Core.Domain.Order;

namespace RentalStore.Api.Infrastructure.Data
{
	public class RentalStoreContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Cart> Carts { get; set; }
		public DbSet<Order> Orders { get; set; }

		public RentalStoreContext(DbContextOptions<RentalStoreContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Product>().HasData(new Product { ProductId = 1, Title = "Pandora Hearts #1", Description = "...", Genre = "Adventure", Price = 20.00m, InStock = 10 },
				new Product { ProductId = 2, Title = "Pandora Hearts #2", Description = "...", Genre = "Adventure", Price = 18.00m, InStock = 0 },
				new Product { ProductId = 3, Title = "Akame ga Kill #1", Genre = "Fantasy", Price = 19.90m, InStock = 3 },
				new Product { ProductId = 4, Title = "Akame ga Kill #2", Genre = "Fantasy", Price = 19.90m, InStock = 4 },
				new Product { ProductId = 5, Title = "Pamiętnik Przyszłości #1", Genre = "Horror", Price = 23.50m, InStock = 7 },
				new Product { ProductId = 6, Title = "Pamiętnik Przyszłości #2", Genre = "Horror", Price = 35.79m, InStock = 20 },
				new Product { ProductId = 7, Title = "Pandora Hearts #1", Description = "...", Genre = "Adventure", Price = 20.00m, InStock = 10 },
				new Product { ProductId = 8, Title = "Pandora Hearts #2", Description = "...", Genre = "Adventure", Price = 18.00m, InStock = 0 },
				new Product { ProductId = 9, Title = "Pamiętnik Przyszłości #1", Genre = "Horror", Price = 23.50m, InStock = 7 },
				new Product { ProductId = 10, Title = "Pamiętnik Przyszłości #2", Genre = "Horror", Price = 35.79m, InStock = 20 });
		}
	}
}
