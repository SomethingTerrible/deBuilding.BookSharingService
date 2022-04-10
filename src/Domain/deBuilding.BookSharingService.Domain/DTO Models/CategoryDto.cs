using System;
using System.Collections.Generic;
using System.Text;

namespace deBuilding.BookSharingService.Domain.DTO_Models
{
	public class CategoryDto
	{
		public Guid CategoryId { get; set; }

		public string Name { get; set; }

		public Guid ParentCategoryId { get; set; }

		public bool MultiSelect { get; set; }
	}
}
