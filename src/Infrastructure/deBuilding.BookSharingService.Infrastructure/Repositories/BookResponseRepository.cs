using deBuilding.BookSharingService.Infrastructure.Context;
using deBuilding.BookSharingService.Infrastructure.Interfaces;
using deBuilding.BookSharingService.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.Infrastructure.Repositories
{
	public class BookResponseRepository : IRepository<BookResponse>
	{
		private readonly ApplicationContext _db;

		public BookResponseRepository(ApplicationContext db)
		{
			_db = db;
		}

		public async Task CreateAsync(BookResponse entity)
		{
			await _db.BookResponse.AddAsync(entity); 
		}

		public async Task DeleteAsync(Guid id)
		{
			var bookResponse = await _db.BookResponse.FindAsync(id);
			if (bookResponse != null)
			{
				_db.BookResponse.Remove(bookResponse); 
			}
		}

		public IEnumerable<BookResponse> GetAll()
		{
			return _db.BookResponse;
		}

		public async Task<BookResponse> GetByIdAsync(Guid id)
		{
			return await _db.BookResponse.FindAsync(id);
		}

		public async Task UpdateAsync(BookResponse entity)
		{
			var dbEntity = await _db.BookResponse.FindAsync(entity.BookLiteraryId);
			if (dbEntity != null)
			{
				_db.BookResponse.Update(entity);
			}
		}
	}
}
