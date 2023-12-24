using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.RabbitMQEventBus
{
	public interface IRabbitMQPersistentConnection : IDisposable
	{
		bool IsConnected { get; }

		bool TryConnect();

		IModel CreateModel();
	}
}
