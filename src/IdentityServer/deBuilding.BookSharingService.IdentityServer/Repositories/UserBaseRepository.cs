using deBuilding.BookSharingService.IdentityServer.Data;
using deBuilding.BookSharingService.IdentityServer.Interfaces;
using deBuilding.BookSharingService.IdentityServer.Models.BaseDbModels;
using System;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.IdentityServer.Repositories
{
	public class UserBaseRepository : IUserRepository
	{
		private readonly ApplicationDbContext _db;

		public UserBaseRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task CreateAsync(UserBase user)
		{
			await _db.UserBase.AddAsync(user);
		}

		public bool Enabled(Guid userId)
		{
			return _db.UserBase.Find(userId).Enabled;
		}
	}
}
