using deBuilding.BookSharingService.Infrastructure.Context;
using deBuilding.BookSharingService.Infrastructure.Interfaces;
using deBuilding.BookSharingService.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.Infrastructure.Repositories
{
	public class CategoryRepository : IRepository<Category>
	{
		private readonly ApplicationDbContext _db;

		public CategoryRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task CreateAsync(Category entity)
		{
			await _db.Category.AddAsync(entity);
		}

		public async Task DeleteAsync(Guid id)
		{
			var category = await _db.Category.FindAsync(id);
			if (category != null)
			{
				_db.Category.Remove(category);
			}
		}

		public IEnumerable<Category> GetAll()
		{
			return _db.Category;
		}

		public async Task<Category> GetByIdAsync(Guid id)
		{
			return await _db.Category.FindAsync(id);
		}

		public async Task UpdateAsync(Category entity)
		{
			var category = await _db.Category.FindAsync(entity.CategoryId); 
			if (category != null)
			{
				_db.Category.Update(entity);
			}
		}
	}
}
