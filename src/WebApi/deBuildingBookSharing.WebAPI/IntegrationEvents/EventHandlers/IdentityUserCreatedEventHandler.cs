using AutoMapper;
using deBuilding.BookSharingService.Domain.DTO_Models;
using deBuilding.BookSharingService.Domain.Interfaces;
using deBuilding.BookSharingService.Domain.Services;
using deBuilding.BookSharingService.EventBus.Abstraction;
using deBuildingBookSharing.WebAPI.IntegrationEvents.Events;
using deBuildingBookSharing.WebAPI.Models;
using System;
using System.Threading.Tasks;

namespace deBuildingBookSharing.WebAPI.IntegrationEvents.EventHandlers
{
	public class IdentityUserCreatedEventHandler : IIntegrationEventHandler<IdentityUserCreatedEvent>
	{
		private readonly IUserBaseService _userBaseService;

		private readonly IUserAddressService _userAddressService;

		public IdentityUserCreatedEventHandler(IUserBaseService userBaseService, IUserAddressService userAddressService)
		{
			_userBaseService = userBaseService;

			_userAddressService = userAddressService;
		}


		public async Task Handle(IdentityUserCreatedEvent integrationEvent)
		{
			var userAddressMapper = new MapperConfiguration(config => config.
				CreateMap<UserAddressAPIDto, UserAddressDto>())
				.CreateMapper();

			var userBaseMapper = new MapperConfiguration(config => config
				.CreateMap<UserBaseAPIDto, UserBaseDto>())
				.CreateMapper();

			try
			{
				await _userBaseService.CreateUserAsync(userBaseMapper.Map<UserBaseAPIDto, UserBaseDto>(integrationEvent.UserBase));

				await _userAddressService.CreateUserAddressAsync(userAddressMapper.Map<UserAddressAPIDto, UserAddressDto>(integrationEvent.UserAddress));
			}
			// Надо что-то делать с ошибкой
			catch (Exception ex)
			{

			}
		}
	}
}
