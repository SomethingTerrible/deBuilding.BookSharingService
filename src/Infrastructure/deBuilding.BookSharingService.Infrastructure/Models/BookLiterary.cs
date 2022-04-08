using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace deBuilding.BookSharingService.Infrastructure.Models
{
	/// <summary>
	/// Сведение о книге как о литературном произведении.
	/// </summary>
	public class BookLiterary
	{
		[Key]
		public Guid BookLiteraryId { get; set; }

		[ForeignKey("Author")]
		public Guid AuthorId { get; set; }	

		public string BookName { get; set; }

		public string Note { get; set; }
	}
}
