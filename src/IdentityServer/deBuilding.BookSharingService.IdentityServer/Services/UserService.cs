using AutoMapper;
using deBuilding.BookSharingService.IdentityServer.Interfaces;
using deBuilding.BookSharingService.IdentityServer.Models.BaseDbModels;
using deBuilding.BookSharingService.IdentityServer.Models.DTO;
using deBuilding.BookSharingService.IdentityServer.Repositories;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.IdentityServer.Services
{
	public class UserService : IUserService
	{
		public IUnitOfWork UnitOfWork { get; set; }

		public UserService(IUnitOfWork unitOfWork)
		{
			UnitOfWork = unitOfWork;
		}

		public async Task CreateUserAsync(UserBaseDto userDto)
		{
			var mapper = new MapperConfiguration(
				configuration => configuration
				.CreateMap<UserBaseDto, UserBase>())
				.CreateMapper();

			 await UnitOfWork.UserBase.CreateAsync(mapper.Map<UserBaseDto, UserBase>(userDto));
		}
	}
}
