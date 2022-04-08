using deBuilding.BookSharingService.Infrastructure.Context;
using deBuilding.BookSharingService.Infrastructure.Interfaces;
using deBuilding.BookSharingService.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.Infrastructure.Repositories
{
	public class UserMsgRepository : IRepository<UserMsg>
	{
		private readonly ApplicationContext _db;

		public UserMsgRepository(ApplicationContext db)
		{
			_db = db;
		}

		public async Task CreateAsync(UserMsg entity)
		{
			await _db.UserMsg.AddAsync(entity);
		}

		public async Task DeleteAsync(Guid id)
		{
			var userMsg = await _db.UserMsg.FindAsync(id);
			if (userMsg != null)
			{
				_db.UserMsg.Remove(userMsg);
			}
		}

		public IEnumerable<UserMsg> GetAll()
		{
			return _db.UserMsg;
		}

		public async Task<UserMsg> GetByIdAsync(Guid id)
		{
			return await _db.UserMsg.FindAsync(id);
		}

		public async Task UpdateAsync(UserMsg entity)
		{
			var userMsg = await _db.UserMsg.FindAsync(entity.UserMsgId);
			if (userMsg != null)
			{
				_db.UserMsg.Update(entity);
			}
		}
	}
}
