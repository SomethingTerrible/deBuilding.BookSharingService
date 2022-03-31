using System.Threading.Tasks;

namespace deBuilding.BookSharingService.IdentityServer.Interfaces
{
	public interface IRepository<T> where T : class
	{
		Task CreateAsync(T entity);
	}
}
