using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace deBuilding.BookSharingService.WebMVC.Models
{
	/// <summary>
	/// Модель для страницы Хочу обменять. АПК
	/// </summary>
	public class WantToExchangeViewModel
	{
		[Required]
		public string BookName { get; set; }

		[Required]
		public string AuthorLastName { get; set; }

		[Required]
		public string AuthorFirstName { get; set; }

		public int ISBN { get; set; }

		[DataType(DataType.Date)]
		public DateTime ReleaseDate { get; set; }

		public IEnumerable<Category> ParentCategory { get; set; }

		public IEnumerable<Category> ChildrenCategory { get; set; }

	}
}
