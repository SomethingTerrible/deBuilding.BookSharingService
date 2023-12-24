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
	public class UserAddressService : IUserAddressService
	{
		private readonly IUnitOfWork _unitOfWork;

		public UserAddressService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task CreateUserAddressAsync(UserAddressDto userAddress)
		{
			var mapper = new MapperConfiguration(config => config
				.CreateMap<UserAddressDto, UserAddress>())
				.CreateMapper();
			await _unitOfWork.UserAddress.CreateAsync(mapper.Map<UserAddressDto, UserAddress>(userAddress));
			_unitOfWork.Save();
		}
	}
}
