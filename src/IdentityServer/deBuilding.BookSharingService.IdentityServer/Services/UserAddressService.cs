using AutoMapper;
using deBuilding.BookSharingService.IdentityServer.Interfaces;
using deBuilding.BookSharingService.IdentityServer.Models.BaseDbModels;
using deBuilding.BookSharingService.IdentityServer.Models.DTO;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.IdentityServer.Services
{
	public class UserAddressService : IUserAddressService
	{
		public IUnitOfWork UnitOfWork { get; set; }

		public UserAddressService(IUnitOfWork unitOfWork)
		{
			UnitOfWork = unitOfWork;
		}

		public async Task CreateAddressAsync(UserAddressDto addressDto)
		{
			var mapper = new MapperConfiguration(
				configuration => configuration
				.CreateMap<UserAddressDto, UserAddress>())
				.CreateMapper();

			await UnitOfWork.UserAddress.CreateAsync(mapper.Map<UserAddressDto, UserAddress>(addressDto));
		}
	}
}
