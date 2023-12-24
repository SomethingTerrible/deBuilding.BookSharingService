using deBuilding.BookSharingService.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.EventBus.Abstraction
{
	public interface IEventBus
	{
		void Publish(IntegrationEvent integrationEvent);

		void Subscribe<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;

		void Unsubscribe<T, TH>() where TH : IIntegrationEventHandler<T> where T : IntegrationEvent;
	}
}
