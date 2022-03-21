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
        private ApplicationContext _db;

        public UserAddressRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async void CreateAsync(UserAddress entity)
        {
            await _db.UserAddress.AddAsync(entity);
        }

        public async void DeleteAsync(UserAddress entity)
        {
            var dbEntity = await _db.UserAddress.FindAsync(entity);
            if (dbEntity != null)
            {
                _db.UserAddress.Remove(entity);
            }
        }

        public IEnumerable<UserAddress> GetAll()
        {
            return _db.UserAddress;
        }

        public async Task<UserAddress> GetAsyncById(Guid id)
        {
            return await _db.UserAddress.FindAsync(id);
        }

        public async void Update(UserAddress entity)
        {
            var dbEntity = await _db.UserAddress.FindAsync(entity);
            if (dbEntity != null)
            {
                _db.UserAddress.Update(entity);
            }
        }
    }
}
