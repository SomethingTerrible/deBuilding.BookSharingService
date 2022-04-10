using deBuilding.BookSharingService.Domain.DTO_Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.Domain.Interfaces
{
	public interface IUserMessageService
	{
		IEnumerable<UserMessageDto> GetUserMessageByStatus(Guid userId, int messageType);

		Task CreateMessage(UserMessageDto message);

		void SaveChanges();
	}
}
