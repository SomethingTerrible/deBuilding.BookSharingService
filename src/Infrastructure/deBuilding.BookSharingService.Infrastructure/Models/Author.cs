using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace deBuilding.BookSharingService.Infrastructure.Models
{
	/// <summary>
	/// Авторы произведений.
	/// </summary>
	public class Author
	{
		[Key]
		public Guid AuthorId { get; set; }	

		public string LastName { get; set; }	

		public string FirstName { get; set; }	

	}
}
