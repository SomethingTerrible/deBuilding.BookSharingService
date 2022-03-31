using deBuilding.BookSharingService.IdentityServer.Models.BaseDbModels;
using System;

namespace deBuilding.BookSharingService.IdentityServer.Interfaces
{
	public interface IUserRepository : IRepository<UserBase>
	{
		bool Enabled(Guid userId);
	}
}
