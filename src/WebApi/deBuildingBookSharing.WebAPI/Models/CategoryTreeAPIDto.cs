using System.Collections.Generic;

namespace deBuildingBookSharing.WebAPI.Models
{
	public class CategoryTreeAPIDto
	{
		public CategoryAPIDto Parent { get; set; }

		public IEnumerable<CategoryAPIDto> Children { get; set; }
	}
}
