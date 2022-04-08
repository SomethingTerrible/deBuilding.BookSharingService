using deBuilding.BookSharingService.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.Infrastructure.Interfaces
{
	public interface IUserRepository : IRepository<UserBase>
	{
		Task<UserBase> GetUserCardInfo(Guid userId);
	}
}
