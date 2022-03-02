using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace deBuilding.BookSharingService.Infrastructure.Models
{
	/// <summary>
	/// Характеристики книг, указанные пользователем.
	/// </summary>
	public class UserValueCategory
	{
		public Guid UserValueCategoryId { get; set; }

		[ForeignKey("UserListId")]
		public Guid UserListId { get; set; }
	
		[ForeignKey("Category")]
		public Guid CategoryId { get; set; }
	}
}
