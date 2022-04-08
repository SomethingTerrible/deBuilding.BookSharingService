using System.Security.Principal;

namespace deBuilding.BookSharingService.WebMVC.Services
{
	public interface IIdentityParser<T>
	{
		T Parse(IPrincipal principal);
	}
}
