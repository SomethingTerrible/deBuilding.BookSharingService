using deBuilding.BookSharingService.Infrastructure.Context;
using deBuilding.BookSharingService.Infrastructure.Interfaces;
using deBuilding.BookSharingService.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.Infrastructure.Repositories
{
	public class StatusRepository : IRepository<Status>
	{
		private readonly ApplicationContext _db;

		public StatusRepository(ApplicationContext db = null)
		{
			_db = db;
		}

		public async Task CreateAsync(Status entity)
		{
			await _db.Status.AddAsync(entity);
		}

		public async Task DeleteAsync(Guid id)
		{
			var status = await _db.Status.FindAsync(id);
			if (status != null)
			{
				_db.Status.Remove(status); 
			}
		}

		public IEnumerable<Status> GetAll()
		{
			return _db.Status;
		}

		public async Task<Status> GetByIdAsync(Guid id)
		{
			return await _db.Status.FindAsync(id);
		}

		public async Task UpdateAsync(Status entity)
		{
			var status = await _db.Status.FindAsync(entity.StatusId);
			if (status != null)
			{
				_db.Status.Update(entity); 
			}
		}
	}
}
