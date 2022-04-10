using deBuilding.BookSharingService.Domain.DTO_Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.Domain.Interfaces
{
	public interface ICategoryService
	{
		IEnumerable<CategoryTreeDto> GetCategoryTrees(); 
	}
}
