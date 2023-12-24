using deBuilding.BookSharingService.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.EventBus.Abstraction
{
	public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
		where TIntegrationEvent : IntegrationEvent
	{

		Task Handle(TIntegrationEvent integrationEvent);
	}

	public interface IIntegrationEventHandler
	{
	}
}
