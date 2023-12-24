using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using deBuilding.BookSharingService.Infrastructure.Context;
using deBuilding.BookSharingService.Infrastructure.Interfaces;
using deBuilding.BookSharingService.Infrastructure.Models;

namespace deBuilding.BookSharingService.Infrastructure.Repositories
{
    public class AuthorRepository : IRepository<Author>
    {
        private readonly ApplicationDbContext _db;

        public AuthorRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(Author author)
        {
            await _db.Autor.AddAsync(author);
        }

        public async Task DeleteAsync(Guid id)
        {
            var autor = await _db.Autor.FindAsync(id);
            if (autor != null)
            {
                _db.Autor.Remove(autor);
            }
        }

        public IEnumerable<Author> GetAll()
        {
            return _db.Autor;
        }

        public async Task<Author> GetByIdAsync(Guid id)
        {
            return await _db.Autor.FindAsync(id);
        }

        public async Task UpdateAsync(Author author)
        {
            var dbEntity = await _db.Autor.FindAsync(author.AuthorId);
            if (dbEntity != null)
            {
                _db.Autor.Update(author);
            }
        }
    }
}
