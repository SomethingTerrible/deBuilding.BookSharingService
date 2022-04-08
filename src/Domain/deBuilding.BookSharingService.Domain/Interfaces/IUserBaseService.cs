using deBuilding.BookSharingService.Domain.DTO_Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.Domain.Interfaces
{
	public interface IUserBaseService
	{
		Task CreateUserAsync(UserBaseDto user);

		Task<UserSmallCardDto> GetUserNameAndAvatarAsync(Guid id);

		IEnumerable<UserBaseDto> GetAllUsers();

		Task<UserBaseDto> GetUserByIdAsync(Guid id);

		Task UpdateUserAsync(UserBaseDto user);

		Task DeleteUserAsync(Guid id);

		void SaveChanges();
	}
}
