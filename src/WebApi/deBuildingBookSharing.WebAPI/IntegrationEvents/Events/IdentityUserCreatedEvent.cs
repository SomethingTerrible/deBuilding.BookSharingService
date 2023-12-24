using deBuilding.BookSharingService.EventBus.Events;
using deBuildingBookSharing.WebAPI.Models;

namespace deBuildingBookSharing.WebAPI.IntegrationEvents.Events
{
	public record IdentityUserCreatedEvent : IntegrationEvent
	{
		public UserBaseAPIDto UserBase { get; }

		public UserAddressAPIDto UserAddress { get; }

		public IdentityUserCreatedEvent(UserAddressAPIDto userAddress, UserBaseAPIDto userBase)
		{
			UserAddress = userAddress;
			UserBase = userBase;
		}
	}
}
