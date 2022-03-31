using deBuilding.BookSharingService.Infrastructure.Context;
using deBuilding.BookSharingService.Infrastructure.Interfaces;
using deBuilding.BookSharingService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.Infrastructure.Repositories
{
	public class AutorRepository : IRepository<Autor>
	{
		private ApplicationContext _db;

		public AutorRepository(ApplicationContext dbContext)
		{
			_db = dbContext;
		}

		public async void CreateAsync(Autor autor)
		{
			await _db.Autor.AddAsync(autor);
		}

		public async void DeleteAsync(Autor entity)
		{
			var dbEntity = await _db.Autor.FindAsync(entity);
			if (dbEntity != null)
			{
				_db.Autor.Remove(entity);
			}
		}

		public IEnumerable<Autor> GetAllAsync()
		{
			return _db.Autor; 
		}

		public async Task<Autor> GetAsyncById(Guid id)
		{
			return await _db.Autor.FindAsync(id);
		}

		public async void Update(Autor entity)
		{
			var dbEntity = await _db.Autor.FindAsync(entity);
			if (dbEntity != null)
			{
				_db.Autor.Update(entity);
			}
		}
	}
}
