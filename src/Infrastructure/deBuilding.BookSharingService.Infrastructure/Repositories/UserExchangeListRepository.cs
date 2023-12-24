using deBuilding.BookSharingService.Infrastructure.Context;
using deBuilding.BookSharingService.Infrastructure.Interfaces;
using deBuilding.BookSharingService.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.Infrastructure.Repositories
{
	public class UserExchangeListRepository : IRepository<UserExchangeList>
	{
		private readonly ApplicationDbContext _db;

		public UserExchangeListRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task CreateAsync(UserExchangeList entity)
		{
			await _db.UserExchangeList.AddAsync(entity);
		}

		public async Task DeleteAsync(Guid id)
		{
			var userExchangeList = await _db.UserExchangeList.FindAsync(id);
			if (userExchangeList != null)
			{
				_db.UserExchangeList.Remove(userExchangeList);
			}
		}

		public IEnumerable<UserExchangeList> GetAll()
		{
			return _db.UserExchangeList;
		}

		public async Task<UserExchangeList> GetByIdAsync(Guid id)
		{
			return await _db.UserExchangeList.FindAsync(id);
		}

		public async Task UpdateAsync(UserExchangeList entity)
		{
			var userExchageList = await _db.UserExchangeList.FindAsync(entity.UserExchangeListId); 
			if (userExchageList != null)
			{
				_db.UserExchangeList.Update(userExchageList);
			}
		}
	}
}
