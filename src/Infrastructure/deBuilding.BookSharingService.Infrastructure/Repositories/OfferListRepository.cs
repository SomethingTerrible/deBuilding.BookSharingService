using deBuilding.BookSharingService.Infrastructure.Context;
using deBuilding.BookSharingService.Infrastructure.Interfaces;
using deBuilding.BookSharingService.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.Infrastructure.Repositories
{
	public class OfferListRepository : IRepository<OfferList>
	{
		private readonly ApplicationDbContext _db;

		public OfferListRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task CreateAsync(OfferList entity)
		{
			await _db.OfferList.AddAsync(entity);
		}

		public async Task DeleteAsync(Guid id)
		{
			var offer = await _db.OfferList.FindAsync(id);
			if (offer != null)
			{
				_db.OfferList.Remove(offer);
			}
		}

		public IEnumerable<OfferList> GetAll()
		{
			return _db.OfferList;
		}

		public async Task<OfferList> GetByIdAsync(Guid id)
		{
			return await _db.OfferList.FindAsync(id);
		}

		public async Task UpdateAsync(OfferList entity)
		{
			var offer = await _db.OfferList.FindAsync(entity.OfferListId); 
			if (offer != null)
			{
				_db.OfferList.Update(entity);
			}
		}
	}
}
