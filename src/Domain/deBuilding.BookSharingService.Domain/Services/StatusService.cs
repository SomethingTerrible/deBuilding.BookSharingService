using deBuilding.BookSharingService.Domain.Interfaces;
using deBuilding.BookSharingService.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace deBuilding.BookSharingService.Domain.Services
{
	public class StatusService : IStatusService
	{
		public IUnitOfWork Database { get; set; }

		public StatusService(IUnitOfWork database)
		{
			Database = database;
		}

		public Guid GetStatusIdByStatusValue(int statusValue)
		{
			var stat = Database.Status
				.GetAll()
				.Where(item => item.StatusValue == statusValue)
				.FirstOrDefault();

			return stat.StatusId;
		}
	}
}
