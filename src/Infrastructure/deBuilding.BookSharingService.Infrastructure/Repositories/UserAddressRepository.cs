using deBuilding.BookSharingService.Infrastructure.Context;
using deBuilding.BookSharingService.Infrastructure.Interfaces;
using deBuilding.BookSharingService.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.Infrastructure.Repositories
{
    public class UserAddressRepository : IRepository<UserAddress>
    {
        private readonly ApplicationDbContext _db;

        public UserAddressRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(UserAddress entity)
        {
            await _db.UserAddress.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var dbEntity = await _db.UserAddress.FindAsync(id);
            if (dbEntity != null)
            {
                _db.UserAddress.Remove(dbEntity);
            }
        }

        public IEnumerable<UserAddress> GetAll()
        {
            return _db.UserAddress;
        }

        public async Task<UserAddress> GetByIdAsync(Guid id)
        {
            return await _db.UserAddress.FindAsync(id);
        }

        public async Task UpdateAsync(UserAddress entity)
        {
            var dbEntity = await _db.UserAddress.FindAsync(entity.UserAddressId);
            if (dbEntity != null)
            {
                _db.UserAddress.Update(entity);
            }
        }
    }
}
