using deBuilding.BookSharingService.IdentityServer.Configuration;
using deBuilding.BookSharingService.IdentityServer.Models.AspNetIdentityCustomModels;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.EntityFramework.Storage;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.IdentityServer.Data
{
	public class SeedData
	{
		public static void EnsureSeedData(string connectionString)
		{
			var service = new ServiceCollection();
			service.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

			service
				.AddIdentity<ApplicationUser,IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			service.AddOperationalDbContext(
				options =>
				{
					options.ConfigureDbContext = db =>
						db.UseSqlServer(connectionString,
						sql => sql.MigrationsAssembly(typeof(SeedData).Assembly.FullName)
					);
				});

			service.AddConfigurationDbContext(
				options =>
				{
					options.ConfigureDbContext = db =>
						db.UseSqlServer(connectionString,
						sql => sql.MigrationsAssembly(typeof(SeedData).Assembly.FullName)
					);
				});

		}

		/// <summary>
		/// Seed ConfigurationDbContextData
		/// </summary>
		public async Task SeedAsync(ConfigurationDbContext context, IConfiguration configuration)
		{
			var clientsUrls = new Dictionary<string, string>();

			clientsUrls.Add("MvcClient", configuration.GetValue<string>("MvcClient"));

			if (!context.Clients.Any())
			{
				foreach (var client in Confi.GetClients())
				{
					context.Clients.Add(client.ToEntity());
				}

				await context.SaveChangesAsync();
			}

			if (!context.IdentityResources.Any())
			{
				foreach (var resource in Confi.GetResourses)
				{
					context.IdentityResources.Add(resource.ToEntity());
				}

				await context.SaveChangesAsync();
			}

			if (!context.ApiResources.Any())
			{
				foreach (var api in Confi.GetApis)
				{
					context.ApiResources.Add(api.ToEntity()); ;
				}

				await context.SaveChangesAsync();
			}
		}
	}
}
