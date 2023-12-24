using deBuilding.BookSharingService.Infrastructure.Context;
using deBuilding.BookSharingService.Infrastructure.Interfaces;
using deBuilding.BookSharingService.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.Infrastructure.Repositories
{
	public class WishListRepository : IRepository<WishList>
	{
		private readonly ApplicationDbContext _db;

		public WishListRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task CreateAsync(WishList entity)
		{
			await _db.WishList.AddAsync(entity);
		}

		public async Task DeleteAsync(Guid id)
		{
			var wishList = await _db.WishList.FindAsync(id);
			if (wishList != null)
			{
				_db.WishList.Remove(wishList);
			}
		}

		public IEnumerable<WishList> GetAll()
		{
			return _db.WishList;
		}

		public async Task<WishList> GetByIdAsync(Guid id)
		{
			return await _db.WishList.FindAsync(id);
		}

		public async Task UpdateAsync(WishList entity)
		{
			var wishList = await _db.WishList.FindAsync(entity.WishListId);
			if (wishList != null)
			{
				_db.WishList.Update(entity);
			}
		}
	}
}
