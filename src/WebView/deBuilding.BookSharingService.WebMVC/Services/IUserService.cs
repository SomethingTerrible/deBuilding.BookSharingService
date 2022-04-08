using deBuilding.BookSharingService.WebMVC.Models;
using System;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.WebMVC.Services
{
	public interface IUserService
	{
		Task<UserBaseViewModel> GetUserById(Guid id);

		Task<UserSmallCardViewModel> GetUserSmallCard(Guid id);
	}	
}
