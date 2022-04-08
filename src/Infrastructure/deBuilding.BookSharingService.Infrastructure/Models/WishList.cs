using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace deBuilding.BookSharingService.Infrastructure.Models
{
	/// <summary>
	/// ЗПК. Запрашиваемая пользователем книга.
	/// </summary>
	public class WishList
	{
		[Key]
		public Guid WishListId { get; set; }

		[ForeignKey("UserBase")]
		public Guid UserId { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime UpdateAt { get; set; }

		[ForeignKey("Status")]
		public Guid StatusId { get; set; }

		[ForeignKey("UserAddress")]
		public Guid UserAddressId { get; set; }
	}
}
