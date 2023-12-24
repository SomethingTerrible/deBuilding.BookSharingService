using deBuilding.BookSharingService.Infrastructure.Context;
using deBuilding.BookSharingService.Infrastructure.Interfaces;
using deBuilding.BookSharingService.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.Infrastructure.Repositories
{
	public class UserListRepository : IRepository<UserList>
	{
		private readonly ApplicationDbContext _db;

		public UserListRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task CreateAsync(UserList entity)
		{
			await _db.UserList.AddAsync(entity);
		}

		public async Task DeleteAsync(Guid id)
		{
			var userList = await _db.UserList.FindAsync(id);
			if (userList != null)
			{
				_db.UserList.Remove(userList);
			}
		}

		public IEnumerable<UserList> GetAll()
		{
			return _db.UserList;
		}

		public async Task<UserList> GetByIdAsync(Guid id)
		{
			return await _db.UserList.FindAsync(id);
		}

		public async Task UpdateAsync(UserList entity)
		{
			var userList = await _db.UserList.FindAsync(entity.UserListId);
			if (userList != null)
			{
				_db.UserList.Update(entity);
			}
		}
	}
}
