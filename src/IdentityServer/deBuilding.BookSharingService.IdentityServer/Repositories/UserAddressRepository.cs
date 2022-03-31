using deBuilding.BookSharingService.IdentityServer.Data;
using deBuilding.BookSharingService.IdentityServer.Interfaces;
using deBuilding.BookSharingService.IdentityServer.Models.BaseDbModels;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.IdentityServer.Repositories
{
	public class UserAddressRepository : IRepository<UserAddress>
	{
		public readonly ApplicationDbContext _db;

		public UserAddressRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task CreateAsync(UserAddress entity)
		{
			await _db.UserAddress.AddAsync(entity);
		}
	}
}
