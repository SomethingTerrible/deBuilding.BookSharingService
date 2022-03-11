using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace deBuilding.BookSharingService.Infrastructure.Models
{
	/// <summary>
	/// Адрес доставки книг.
	/// </summary>
	public class UserAddress
	{
		public Guid UserAddressId { get; set; }

		[ForeignKey("UserBase")]
		public Guid UserId { get; set; }

		public string AddrIndex { get; set; }

		public string AddrCity { get; set; }

		public string AddrStreet { get; set; }

		public string AddrHouse { get; set; }

		public string AddrStucture { get; set; }

		public string AddrApart { get; set; }

		public bool IsDefault { get; set; }
			
	}
}
