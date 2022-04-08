using deBuilding.BookSharingService.Infrastructure.Context;
using deBuilding.BookSharingService.Infrastructure.Interfaces;
using deBuilding.BookSharingService.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.Infrastructure.Repositories
{
	public class UserBaseRepository : IUserRepository
	{
		private readonly ApplicationContext _db;

		public UserBaseRepository(ApplicationContext db)
		{
			_db = db;
		}

		public async Task CreateAsync(UserBase entity)
		{
			await _db.UserBase.AddAsync(entity);
		}

		public async Task DeleteAsync(Guid id)
		{
			var user = await _db.UserBase.FindAsync(id);
			if (user != null)
			{
				_db.UserBase.Remove(user); 
			}
		}

		public IEnumerable<UserBase> GetAll()
		{
			return _db.UserBase;
		}

		public async Task<UserBase> GetByIdAsync(Guid id)
		{
			return await _db.UserBase.FindAsync(id);
		}

		public async Task<UserBase> GetUserCardInfo(Guid userId)
		{
			var user = await _db.UserBase.FindAsync(userId);
			if (user != null)
			{
				return new UserBase
				{
					UserId = user.UserId,
					Avatar = user.Avatar,
					Rating = user.Rating,
					UserName = user.UserName
				};
			}

			throw new ArgumentNullException("Пользователь не найден");
		}

		public async Task UpdateAsync(UserBase entity)
		{
			var user = await _db.UserBase.FindAsync(entity.UserId);
			
			if (user != null)
			{
				_db.UserBase.Update(entity);
			}
		}
	}
}
