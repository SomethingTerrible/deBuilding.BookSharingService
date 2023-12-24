using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.EventBus.Events
{
	public record IntegrationEvent
	{
		[JsonInclude]
		public Guid Id { get; set; }

		[JsonInclude]
		public DateTime CreationDate { get; set; }

		[JsonConstructor]
		public IntegrationEvent(Guid id, DateTime creationDate)
		{
			Id = id;
			CreationDate = creationDate;
		}

        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
			CreationDate = DateTime.UtcNow;
        }
    }
}
