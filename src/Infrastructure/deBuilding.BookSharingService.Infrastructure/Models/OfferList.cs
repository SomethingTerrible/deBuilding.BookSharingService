using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace deBuilding.BookSharingService.Infrastructure.Interfaces
{
	/// <summary>
	/// ППК. Предлагаемые пользователем книга.
	/// </summary>
	public class OfferList
	{
		public Guid OfferListId { get; set; }

		[ForeignKey("BookLitarary")]
		public Guid BookLitararyId { get; set; }

		[ForeignKey("UserBase")]
		public Guid UserId { get; set; }	
	
		public string ISBN { get; set; }

		public DateTime PublicationYear { get; set; }

		public DateTime CreatedAt { get; set; }
		
		public DateTime UpdatedAt { get; set; }
	
		[ForeignKey("Status")]
		public Guid StatucId { get; set; }
	}
}
