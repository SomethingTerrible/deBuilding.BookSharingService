using deBuilding.BookSharingService.EventBus;
using deBuilding.BookSharingService.EventBus.Abstraction;
using deBuilding.BookSharingService.RabbitMQEventBus;
using deBuilding.BookSharingService.RabbitMQEventBus.RMQEventBus;
using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace deBuilding.BookSharingService.ServicesCommon
{
	public static class CommonServiceExtensions
	{
		/// <summary>
		/// Метод-расширения добавления EventBus RebbitMq.
		/// </summary>
		public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
		{

			var eventBusSection = configuration.GetSection("EventBus");
			if (!eventBusSection.Exists())
			{
				return services;
			}

			services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
			{
				var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();

				var factory = new ConnectionFactory()
				{
					HostName = configuration.GetRequiredConnectionString("EventBus"),
					DispatchConsumersAsync = true
				};

				if (!string.IsNullOrEmpty(eventBusSection["UserName"]))
				{
					factory.UserName = eventBusSection["UserName"];
				}

				if (!string.IsNullOrEmpty(eventBusSection["Password"]))
				{
					factory.Password = eventBusSection["Password"];
				}

				var retryCount = eventBusSection.GetValue("RetryCount", 5);

				return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
			});

			services.AddSingleton<IEventBus, EBRabbitMQ>(sp =>
			{
				var subscriptionClientName = eventBusSection.GetRequiredValue("SubscriptionClientName");
				var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
				var logger = sp.GetRequiredService<ILogger<EBRabbitMQ>>();
				var eventBusSubscriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();
				var retryCount = eventBusSection.GetValue("RetryCount", 5);

				return new EBRabbitMQ(rabbitMQPersistentConnection, logger, sp, eventBusSubscriptionsManager, subscriptionClientName, retryCount);
			});

			services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();
			return services;
		}
	}
}