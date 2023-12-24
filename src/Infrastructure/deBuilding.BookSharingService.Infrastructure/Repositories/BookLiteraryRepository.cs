using deBuilding.BookSharingService.Infrastructure.Context;
using deBuilding.BookSharingService.Infrastructure.Interfaces;
using deBuilding.BookSharingService.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.Infrastructure.Repositories
{
	public class BookLiteraryRepository : IRepository<BookLiterary>
	{
		private readonly ApplicationDbContext _db;

		public BookLiteraryRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task CreateAsync(BookLiterary entity)
		{
			await _db.BookLiterary.AddAsync(entity);
		}

		public async Task DeleteAsync(Guid id)
		{
			var bookLiterary = await _db.BookLiterary.FindAsync(id);
			if (bookLiterary != null)
			{
				_db.BookLiterary.Remove(bookLiterary);
			}

		}

		public IEnumerable<BookLiterary> GetAll()
		{
			return _db.BookLiterary;
		}

		public async Task<BookLiterary> GetByIdAsync(Guid id)
		{
			return await _db.BookLiterary.FindAsync(id);
		}

		public async Task UpdateAsync(BookLiterary entity)
		{
			var bookLitarary = await _db.BookLiterary.FindAsync(entity.BookLiteraryId);
			if (bookLitarary != null)
			{
				_db.BookLiterary.Update(entity);
			}
		}
	}
}
