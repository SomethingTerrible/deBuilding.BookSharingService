using deBuilding.BookSharingService.IdentityServer.Models.BaseDbModels;
using System;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.IdentityServer.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IUserRepository UserBase { get; }

		IRepository<UserAddress> UserAddress { get; }

		Task SaveDb();
	}
}
