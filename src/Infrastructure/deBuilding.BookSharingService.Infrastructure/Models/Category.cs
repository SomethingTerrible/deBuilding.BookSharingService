using System;
using System.Collections.Generic;
using System.Text;

namespace deBuilding.BookSharingService.Infrastructure.Models
{
	/// <summary>
	/// Характеристики книг.
	/// </summary>
	public class Category
	{
		public Guid CategoryId { get; set; }

		public string Name { get; set; }

		public Guid ParentCategoryId { get; set; }
		
		public bool MultiSelect { get; set; }
	}
}
