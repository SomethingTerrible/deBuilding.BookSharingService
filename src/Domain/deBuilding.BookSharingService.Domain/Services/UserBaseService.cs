using AutoMapper;
using deBuilding.BookSharingService.Domain.DTO_Models;
using deBuilding.BookSharingService.Domain.Interfaces;
using deBuilding.BookSharingService.Infrastructure.Interfaces;
using deBuilding.BookSharingService.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.Domain.Services
{
	public class UserBaseService : IUserBaseService
	{
		public IUnitOfWork Database { get; set; }

		public UserBaseService(IUnitOfWork database)
		{
			Database = database;
		}

		public async Task<UserSmallCardDto> GetUserNameAndAvatarAsync(Guid id)
		{
			var user = await Database.UserBase.GetUserCardInfo(id);

			var model = new UserSmallCardDto
			{
				Avatar = user.Avatar,
				UserName = user.UserName,
				Rating = user.Rating,
				UserBaseId = user.UserId
			};

			return model;
		}

		public void SaveChanges()
		{
			Database.Save();
		}

		public IEnumerable<UserBaseDto> GetAllUsers()
		{
			var mapper = new MapperConfiguration(
				config => config
				.CreateMap<UserBase, UserBaseDto>())
				.CreateMapper();

			return mapper.Map<IEnumerable<UserBase>, IEnumerable<UserBaseDto>>(Database.UserBase.GetAll());
		}

		public async Task<UserBaseDto> GetUserByIdAsync(Guid id)
		{
			var mapper = new MapperConfiguration(
				config => config
				.CreateMap<UserBase, UserBaseDto>())
				.CreateMapper();

			return mapper.Map<UserBase, UserBaseDto>(await Database.UserBase.GetByIdAsync(id));
		}

		public async Task DeleteUserAsync(Guid id)
		{
			var user = await Database.UserBase.GetByIdAsync(id); 
			if (user == null)
			{
				throw new ArgumentNullException("Пользователь не найден");
			}

			await Database.UserBase.DeleteAsync(id);
			Database.Save();
		}

		public async Task UpdateUserAsync(UserBaseDto user)
		{
			var mapper = new MapperConfiguration(config => config
				.CreateMap<UserBaseDto, UserBase>())
				.CreateMapper();

			await Database.UserBase.UpdateAsync(mapper.Map<UserBaseDto, UserBase>(user));
			Database.Save();
		}

		public async Task CreateUserAsync(UserBaseDto user)
		{
			var mapper = new MapperConfiguration(config => config
				.CreateMap<UserBaseDto, UserBaseDto>())
				.CreateMapper();
			await Database.UserBase.CreateAsync(mapper.Map<UserBaseDto, UserBase>(user));
		}
	}
}
