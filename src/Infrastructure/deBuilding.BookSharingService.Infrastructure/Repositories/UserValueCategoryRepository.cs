using deBuilding.BookSharingService.Infrastructure.Context;
using deBuilding.BookSharingService.Infrastructure.Interfaces;
using deBuilding.BookSharingService.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.Infrastructure.Repositories
{
	public class UserValueCategoryRepository : IRepository<UserValueCategory>
	{
		private readonly ApplicationDbContext _db;

		public UserValueCategoryRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task CreateAsync(UserValueCategory entity)
		{
			await _db.UserValueCategory.AddAsync(entity);
		}

		public async Task DeleteAsync(Guid id)
		{
			var userValue = await _db.UserValueCategory.FindAsync(id);
			if (userValue != null)
			{
				_db.UserValueCategory.Remove(userValue);
			}
		}

		public IEnumerable<UserValueCategory> GetAll()
		{
			return _db.UserValueCategory;
		}

		public async Task<UserValueCategory> GetByIdAsync(Guid id)
		{
			return await _db.UserValueCategory.FindAsync(id);
		}

		public async Task UpdateAsync(UserValueCategory entity)
		{
			var userValue = await _db.UserValueCategory.FindAsync(entity.UserValueCategoryId);
			if (userValue != null)
			{
				_db.UserValueCategory.Update(userValue);
			}
		}
	}
}
