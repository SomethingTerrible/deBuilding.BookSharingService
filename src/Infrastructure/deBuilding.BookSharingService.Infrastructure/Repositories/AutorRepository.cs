using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using deBuilding.BookSharingService.Infrastructure.Context;
using deBuilding.BookSharingService.Infrastructure.Interfaces;
using deBuilding.BookSharingService.Infrastructure.Models;

namespace deBuilding.BookSharingService.Infrastructure.Repositories
{
    public class AutorRepository : IRepository<Autor>
    {
        private ApplicationContext _db;

        public AutorRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async void CreateAsync(Autor author)
        {
            await _db.Autor.AddAsync(author);
        }

        public async void DeleteAsync(Autor author)
        {
            var dbEntity = await _db.Autor.FindAsync(author);
            if (dbEntity != null)
            {
                _db.Autor.Remove(author);
            }
        }

        public IEnumerable<Autor> GetAll()
        {
            return _db.Autor;
        }

        public async Task<Autor> GetAsyncById(Guid id)
        {
            return await _db.Autor.FindAsync(id);
        }

        public async void Update(Autor author)
        {
            var dbEntity = await _db.Autor.FindAsync(author);
            if (dbEntity != null)
            {
                _db.Autor.Update(author);
            }
        }
    }
}
