using System;
using System.Collections.Generic;
using System.Text;

namespace deBuilding.BookSharingService.Domain.Interfaces
{
	public interface IStatusService
	{
		Guid GetStatusIdByStatusValue(int statusValue);
	}
}
