using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace deBuilding.BookSharingService.Infrastructure.Models
{
	/// <summary>
	/// Характеристики книг.
	/// </summary>
	public class Category
	{
		[Key]
		public Guid CategoryId { get; set; }

		public string Name { get; set; }

		[ForeignKey("Category")]
		public Guid ParentCategoryId { get; set; }
		
		public bool MultiSelect { get; set; }
	}
}
