using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace deBuilding.BookSharingService.IdentityServer.Models.DTO
{
	public class UserAddressDto
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
