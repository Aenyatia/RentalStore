using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentalStore.Api.Core.Configurations.AutoMapper;
using RentalStore.Api.Core.Services;
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
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			// ef core
			services.AddDbContext<RentalStoreContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("RentalStoreConnection")));
			services.AddDbContext<IdentityContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));

			// ef core identity
			services.AddIdentity<AppUser, IdentityRole>()
				.AddEntityFrameworkStores<IdentityContext>()
				.AddDefaultTokenProviders();

			// auto-mapper
			services.AddSingleton(AutoMapperConfig.Initialize());

			services.AddScoped<CatalogService>();
			services.AddScoped<BasketService>();
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
