using AutoMapper;
using deBuilding.BookSharingService.Domain.DTO_Models;
using deBuilding.BookSharingService.Domain.Interfaces;
using deBuilding.BookSharingService.Infrastructure.Interfaces;
using deBuilding.BookSharingService.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.Domain.Services
{
	public class UserMessageService : IUserMessageService
	{
		public IUnitOfWork Database { get; set; }

		public UserMessageService(IUnitOfWork database)
		{
			Database = database;
		}

		public async Task CreateMessage(UserMessageDto message)
		{
			var mapper = new MapperConfiguration(
				config => config
				.CreateMap<UserMessageDto, UserMsg>())
				.CreateMapper();

			await Database.UserMsg.CreateAsync(mapper.Map<UserMessageDto, UserMsg>(message));
			SaveChanges();
		}

		public IEnumerable<UserMessageDto> GetUserMessageByStatus(Guid userId, int messageType)
		{
			var mapper = new MapperConfiguration(
				config => config
				.CreateMap<UserMsg, UserMessageDto>())
				.CreateMapper();

			var messages = Database.UserMsg
				.GetAll()
				.Where(item => item.UserId == userId && item.MessageType == messageType);

			return mapper.Map<IEnumerable<UserMsg>, IEnumerable<UserMessageDto>>(messages);
		}

		public void SaveChanges()
		{
			Database.Save();
		}
	}
}
