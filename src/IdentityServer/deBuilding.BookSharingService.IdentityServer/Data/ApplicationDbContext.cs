using deBuilding.BookSharingService.IdentityServer.Models.AspNetIdentityCustomModels;
using deBuilding.BookSharingService.IdentityServer.Models.BaseDbModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace deBuilding.BookSharingService.IdentityServer.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public DbSet<UserBase> UserBase { get; set; }

		public DbSet<UserAddress> UserAddress { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}
