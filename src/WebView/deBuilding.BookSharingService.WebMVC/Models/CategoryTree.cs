using System;
using System.Collections.Generic;

namespace deBuilding.BookSharingService.WebMVC.Models
{
	public class CategoryTree
	{
		public Category Parent { get; set; }

		public IEnumerable<Category> Children { get; set; }

	}
}
