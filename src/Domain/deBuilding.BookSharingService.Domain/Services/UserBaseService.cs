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
		private IUnitOfWork _unitOfWork { get; set; }

		public UserBaseService(IUnitOfWork database)
		{
			_unitOfWork = database;
		}

		public async Task<UserSmallCardDto> GetUserNameAndAvatarAsync(Guid id)
		{
			var user = await _unitOfWork.UserBase.GetUserCardInfo(id);

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
			_unitOfWork.Save();
		}

		public IEnumerable<UserBaseDto> GetAllUsers()
		{
			var mapper = new MapperConfiguration(
				config => config
				.CreateMap<UserBase, UserBaseDto>())
				.CreateMapper();

			return mapper.Map<IEnumerable<UserBase>, IEnumerable<UserBaseDto>>(_unitOfWork.UserBase.GetAll());
		}

		public async Task<UserBaseDto> GetUserByIdAsync(Guid id)
		{
			var mapper = new MapperConfiguration(
				config => config
				.CreateMap<UserBase, UserBaseDto>())
				.CreateMapper();

			return mapper.Map<UserBase, UserBaseDto>(await _unitOfWork.UserBase.GetByIdAsync(id));
		}

		public async Task DeleteUserAsync(Guid id)
		{
			var user = await _unitOfWork.UserBase.GetByIdAsync(id); 
			if (user == null)
			{
				throw new ArgumentNullException("Пользователь не найден");
			}

			await _unitOfWork.UserBase.DeleteAsync(id);
			_unitOfWork.Save();
		}

		public async Task UpdateUserAsync(UserBaseDto user)
		{
			var mapper = new MapperConfiguration(config => config
				.CreateMap<UserBaseDto, UserBase>())
				.CreateMapper();

			await _unitOfWork.UserBase.UpdateAsync(mapper.Map<UserBaseDto, UserBase>(user));
			_unitOfWork.Save();
		}

		public async Task CreateUserAsync(UserBaseDto user)
		{
			var mapper = new MapperConfiguration(config => config
				.CreateMap<UserBaseDto, UserBase>())
				.CreateMapper();
			await _unitOfWork.UserBase.CreateAsync(mapper.Map<UserBaseDto, UserBase>(user));
			SaveChanges();
		}
	}
}
