using deBuilding.BookSharingService.EventBus.Events;
using deBuilding.BookSharingService.IdentityServer.Models.BaseDbModels;

namespace deBuilding.BookSharingService.IdentityServer.IntegrationEvents
{
	public record IdentityUserCreatedEvent : IntegrationEvent
	{
		public UserBase userBase { get; set; }

		public UserAddress userAddress { get; set; }

		public IdentityUserCreatedEvent(UserBase userBase, UserAddress userAddress)
		{
			this.userBase = userBase;
			this.userAddress = userAddress;
		}
	}
}
