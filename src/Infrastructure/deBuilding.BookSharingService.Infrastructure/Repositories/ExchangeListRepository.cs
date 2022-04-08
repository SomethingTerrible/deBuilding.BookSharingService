using deBuilding.BookSharingService.Infrastructure.Context;
using deBuilding.BookSharingService.Infrastructure.Interfaces;
using deBuilding.BookSharingService.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.Infrastructure.Repositories
{
	public class ExchangeListRepository : IRepository<ExchangeList>
	{
		private readonly ApplicationContext _db;

		public ExchangeListRepository(ApplicationContext db)
		{
			_db = db;
		}

		public async Task CreateAsync(ExchangeList entity)
		{
			await _db.ExchangeList.AddAsync(entity);
		}

		public async Task DeleteAsync(Guid id)
		{
			var exchangeList = await _db.ExchangeList.FindAsync(id); 
			if (exchangeList != null)
			{
				_db.ExchangeList.Remove(exchangeList); 
			}
		}

		public IEnumerable<ExchangeList> GetAll()
		{
			return _db.ExchangeList;
		}

		public async Task<ExchangeList> GetByIdAsync(Guid id)
		{
			return await _db.ExchangeList.FindAsync(id);
		}

		public async Task UpdateAsync(ExchangeList entity)
		{
			var exchangeList = await _db.ExchangeList.FindAsync(entity.ExchangeListId);
			if (exchangeList != null)
			{
				_db.ExchangeList.Update(entity);
			}
		}
	}
}
