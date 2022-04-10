using System;
using System.Collections.Generic;
using System.Text;

namespace deBuilding.BookSharingService.Domain.DTO_Models
{
	public class CategoryTreeDto
	{
		public CategoryDto Parent { get; set; }

		public IEnumerable<CategoryDto> Children { get; set; }
	}
}
