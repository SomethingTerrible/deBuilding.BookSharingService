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

		
		public static async Task SeedAsync(ApplicationDbContext context)
		{
			await context.Database.MigrateAsync();
		}
	}
}
