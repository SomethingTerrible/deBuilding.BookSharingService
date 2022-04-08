using deBuilding.BookSharingService.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace deBuilding.BookSharingService.Infrastructure.Interfaces
{
	/// <summary>
	/// Паттерн UnitOfWork.
	/// </summary>
	public interface IUnitOfWork : IDisposable
	{
		IRepository<Author> Author{ get; }

		IRepository<BookLiterary> BookLiterary { get;  }

		IRepository<BookResponse> BookResponse { get; }

		IRepository<Category> Category { get; }

		IRepository<ExchangeList> ExchangeList { get; }

		IRepository<OfferList> OfferList { get; }

		IRepository<Status> Status { get; }

		IRepository<UserAddress> UserAddress { get; }

		IUserRepository UserBase { get; }
		
		IRepository<UserExchangeList> UserExchangeList { get; }

		IRepository<UserList> UserList { get; }

		IRepository<UserMsg> UserMsg { get; }

		IRepository<UserValueCategory> UserValueCategory { get; }

		IRepository<WishList> WishList { get; }

		void Save();
	}
}
