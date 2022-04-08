using deBuilding.BookSharingService.Infrastructure.Context;
using deBuilding.BookSharingService.Infrastructure.Interfaces;
using deBuilding.BookSharingService.Infrastructure.Models;
using deBuilding.BookSharingService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace deBuilding.BookSharingService.Infrastructure.UnitOfWork
{
	public class EFUnitOfWork : IUnitOfWork
	{
		#region DbContext
		private readonly ApplicationContext _db;
		#endregion

		#region PrivateFields
		private bool _disposed = false;
		#endregion

		#region Repositories
		private IRepository<Author> _authorRepository;

		private IRepository<BookLiterary> _bookLiteraryRepository;

		private IRepository<BookResponse> _bookResponseRepository;

		private IRepository<Category> _categoryRepository;

		private IRepository<ExchangeList> _exchangeListRepository;

		private IRepository<OfferList> _offerListRepository;

		private IRepository<Status> _statusRepository;

		private IRepository<UserAddress> _userAddressRepository;

		private IUserRepository _userRepository;

		private IRepository<UserExchangeList> _userExchageListRepository;

		private IRepository<UserList> _userListRepository;

		private IRepository<UserMsg> _userMsgRepository;

		private IRepository<UserValueCategory> _userValueCategory;

		private IRepository<WishList> _wishListRepository;
		#endregion


		public EFUnitOfWork()
		{
			var builder = new ConfigurationBuilder();
			var appSetingsJsonFilePath = Directory.GetCurrentDirectory() + "/appsettings.json";
			builder.AddJsonFile(appSetingsJsonFilePath);
			var config = builder.Build();

			var connectionString = config.GetConnectionString("DefaultConnetion");
			var optionBuilder = new DbContextOptionsBuilder<ApplicationContext>();
			var options = optionBuilder
				.UseSqlServer(connectionString)
				.Options;

			_db = new ApplicationContext(options);
		}

		#region Fields
		public IRepository<Author> Author
		{
			get
			{
				if (_authorRepository == null)
				{
					_authorRepository = new AuthorRepository(_db);
				}

				return _authorRepository;
			}
		}

		public IRepository<BookLiterary> BookLiterary
		{
			get
			{
				if (_bookLiteraryRepository == null)
				{
					_bookLiteraryRepository = new BookLiteraryRepository(_db);
				}

				return _bookLiteraryRepository;
			}
		}

		public IRepository<BookResponse> BookResponse
		{
			get
			{
				if (_bookResponseRepository == null)
				{
					_bookResponseRepository = new BookResponseRepository(_db);
				}

				return _bookResponseRepository;
			}
		}

		public IRepository<Category> Category
		{
			get
			{
				if (_categoryRepository == null)
				{
					_categoryRepository = new CategoryRepository(_db);
				}

				return _categoryRepository;
			}
		}

		public IRepository<ExchangeList> ExchangeList
		{
			get
			{
				if (_exchangeListRepository == null)
				{
					_exchangeListRepository = new ExchangeListRepository(_db);
				}

				return _exchangeListRepository;
			}
		}

		public IRepository<OfferList> OfferList
		{
			get
			{
				if (_offerListRepository == null)
				{
					_offerListRepository = new OfferListRepository(_db);
				}

				return _offerListRepository;
			}
		}

		public IRepository<Status> Status
		{
			get
			{
				if (_statusRepository == null)
				{
					_statusRepository = new StatusRepository(_db);
				}

				return _statusRepository;
			}
		}

		public IRepository<UserAddress> UserAddress
		{
			get
			{
				if (_userAddressRepository == null)
				{
					_userAddressRepository = new UserAddressRepository(_db);
				}

				return _userAddressRepository;
			}
		}
		
		public IUserRepository UserBase
		{
			get
			{
				if (_userRepository == null)
				{
					_userRepository = new UserBaseRepository(_db);
				}

				return _userRepository;
			}
		}

		public IRepository<UserExchangeList> UserExchangeList
		{
			get
			{
				if (_userExchageListRepository == null)
				{
					_userExchageListRepository = new UserExchangeListRepository(_db);
				}

				return _userExchageListRepository;
			}
		}

		public IRepository<UserList> UserList
		{
			get
			{
				if (_userListRepository == null)
				{
					_userListRepository = new UserListRepository(_db);
				}

				return _userListRepository;
			}
		}

		public IRepository<UserMsg> UserMsg
		{
			get
			{
				if (_userMsgRepository == null)
				{
					_userMsgRepository = new UserMsgRepository(_db);
				}

				return _userMsgRepository;
			}
		}

		public IRepository<UserValueCategory> UserValueCategory
		{
			get
			{
				if (_userValueCategory == null)
				{
					_userValueCategory = new UserValueCategoryRepository(_db);
				}

				return _userValueCategory;
			}
		}

		public IRepository<WishList> WishList
		{
			get
			{
				if (_wishListRepository == null)
				{
					_wishListRepository = new WishListRepository(_db);
				}

				return _wishListRepository;
			}
		}
		#endregion
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

		public void Save()
		{
			_db.SaveChanges();
		}
	}
}
