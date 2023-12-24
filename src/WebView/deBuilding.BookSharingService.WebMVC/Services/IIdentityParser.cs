using System.Security.Principal;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.WebMVC.Services
{
	public interface IIdentityParser<T>
	{
		Task<T> Parse(IPrincipal principal);
	}
}
