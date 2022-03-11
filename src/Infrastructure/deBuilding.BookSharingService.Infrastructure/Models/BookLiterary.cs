using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace deBuilding.BookSharingService.Infrastructure.Models
{
	/// <summary>
	/// Сведение о книге как о литературном произведении.
	/// </summary>
	public class BookLiterary
	{
		public Guid BookLiteraryId { get; set; }

		[ForeignKey("Autor")]
		public Guid AutorId { get; set; }	

		public string BookName { get; set; }

		public string Note { get; set; }
	}
}
