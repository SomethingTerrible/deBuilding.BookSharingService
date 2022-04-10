using System;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.WebMVC.Services
{
	public interface IStatusService
	{
		Task<Guid> GetStatusIdByValue(int statusValue);
	}
}
