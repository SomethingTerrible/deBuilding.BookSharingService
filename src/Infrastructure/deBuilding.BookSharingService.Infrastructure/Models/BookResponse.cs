using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace deBuilding.BookSharingService.Infrastructure.Models
{
	/// <summary>
	/// Отзыв на АПК. АПК - автор и произведение в книге.
	/// </summary>
	public class BookResponse
	{
		public Guid BookResponseId { get; set; }	

		[ForeignKey("BookLiterary")]
		public Guid BookLiteraryId { get; set; }
	
		[ForeignKey("UserBase")]
		public Guid UserId { get; set; }
		
		public string Response { get; set; }

		public string Note { get; set; }
	}
}
