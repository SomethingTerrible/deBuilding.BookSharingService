using deBuilding.BookSharingService.IdentityServer.Models.DTO;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.IdentityServer.Interfaces
{
	public interface IUserAddressService
	{
		Task CreateAddressAsync(UserAddressDto addressDto);
	}
}
