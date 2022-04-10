using deBuilding.BookSharingService.WebMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.WebMVC.Services
{
	public interface ICategoryService
	{
		Task<IEnumerable<CategoryTree>> GetCategoryTrees();
	}
}
