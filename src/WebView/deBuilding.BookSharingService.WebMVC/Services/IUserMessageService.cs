using deBuilding.BookSharingService.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.WebMVC.Services
{
	public interface IUserMessageService
	{
		Task CreateMessageAsync(UserMessageViewModel vm);

		Task<IEnumerable<UserMessageViewModel>> GetMessages(Guid userId, int messageTypeValue);
	}
}
