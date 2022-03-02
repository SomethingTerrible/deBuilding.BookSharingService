using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace deBuilding.BookSharingService.Infrastructure.Models
{
	/// <summary>
	/// Подобранные пары для обмена.
	/// </summary>
	public class ExchangeList
	{
		public Guid ExchangeListId { get; set; }

		[ForeignKey("OfferList")]
		public Guid OfferListId_1 { get; set; }

		[ForeignKey("WishList")]
		public Guid WishListId_1 { get; set; }
		
		[ForeignKey("OfferList")]
		public Guid OfferListId_2 { get; set; }

		[ForeignKey("WishList")]
		public Guid WishListId_2 { get; set; }

		public DateTime CreatedAt { get; set; }

		public bool IsBoth { get; set; }
	}
}
