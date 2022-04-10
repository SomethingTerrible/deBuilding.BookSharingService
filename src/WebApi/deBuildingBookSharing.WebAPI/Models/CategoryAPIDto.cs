using System;

namespace deBuildingBookSharing.WebAPI.Models
{
	public class CategoryAPIDto
	{
		public Guid CategoryId { get; set; }

		public string Name { get; set; }

		public Guid ParentCategoryId { get; set; }

		public bool MultiSelect { get; set; }
	}
}
