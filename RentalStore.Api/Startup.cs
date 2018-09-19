using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentalStore.Api.Core.Configurations.AutoMapper;
using RentalStore.Api.Core.Services.Account;
using RentalStore.Api.Core.Services.Cart;
using RentalStore.Api.Core.Services.Catalog;
using RentalStore.Api.Core.Services.Order;
using RentalStore.Api.Infrastructure.Data;
using RentalStore.Api.Infrastructure.Identity;

namespace RentalStore.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc()
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			//.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

			// ef core
			services.AddDbContext<RentalStoreContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("RentalStoreConnection")));
			services.AddDbContext<IdentityContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));

			// ef core identity
			services.AddIdentity<User, IdentityRole>()
				.AddEntityFrameworkStores<IdentityContext>()
				.AddDefaultTokenProviders();

			// auto-mapper
			services.AddSingleton(AutoMapperConfig.Initialize());

			services.AddScoped<AccountCommandService>();
			services.AddScoped<AccountQueryService>();

			services.AddScoped<CatalogService>();
			services.AddScoped<CartService>();
			services.AddScoped<OrderService>();

			services.AddScoped<RentalStoreContext>();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseAuthentication();

			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
