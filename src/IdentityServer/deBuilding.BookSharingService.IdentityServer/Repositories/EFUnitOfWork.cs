using deBuilding.BookSharingService.IdentityServer.Data;
using deBuilding.BookSharingService.IdentityServer.Interfaces;
using deBuilding.BookSharingService.IdentityServer.Models.BaseDbModels;
using System;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.IdentityServer.Repositories
{
	public class EFUnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _db;

		private IUserRepository _userBase;

		private IRepository<UserAddress> _userAddress;

		private bool _disposed = false;

		public EFUnitOfWork(ApplicationDbContext context)
		{
			_db = context;
		}

		public IUserRepository UserBase
		{
			get
			{
				if (_userBase == null)
				{
					_userBase = new UserBaseRepository(_db);
				}

				return _userBase;
			}
		}

		public IRepository<UserAddress> UserAddress
		{
			get
			{
				if (_userAddress == null)
				{
					_userAddress = new UserAddressRepository(_db);
				}

				return _userAddress;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_db.Dispose();
				}
				_disposed = true;
			}
		}

		public async Task SaveDb()
		{
			await _db.SaveChangesAsync();
		}
	}
}
