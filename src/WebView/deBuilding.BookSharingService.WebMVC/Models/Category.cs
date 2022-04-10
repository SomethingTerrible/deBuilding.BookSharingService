using System;

namespace deBuilding.BookSharingService.WebMVC.Models
{
	public class Category
	{
		public Guid CategoryId { get; set; }

		public string Name { get; set; }	

		public Guid ParentCategoryId { get; set; }

		public bool MultiSelect { get; set; }
	}
}
