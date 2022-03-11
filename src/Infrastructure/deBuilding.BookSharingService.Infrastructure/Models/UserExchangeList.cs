using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace deBuilding.BookSharingService.Infrastructure.Models
{
	/// <summary>
	/// Состояние обмена для пользователя.
	/// </summary>
	public class UserExchangeList
	{
		public Guid UserExchangeListId { get; set; }

		[ForeignKey("ExchangeList")]
		public Guid ExchangeListId { get; set; }

		[ForeignKey("OfferList")]
		public Guid OfferListId { get; set; }
	
		public string TrackNumber { get; set; }

		public bool Receiving { get; set; }
	}
}
