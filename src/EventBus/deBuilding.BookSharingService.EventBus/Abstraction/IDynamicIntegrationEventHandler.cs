using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.EventBus.Abstraction
{
	public interface IDynamicIntegrationEventHandler
	{
		Task Handle(dynamic eventData);
	}
}
