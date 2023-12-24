using System;
using System.Collections.Generic;
using System.Text;

namespace deBuilding.BookSharingService.Domain.DTO_Models
{
	public class UserAddressDto
	{
		public Guid UserAddressId { get; set; }

		public Guid UserId { get; set; }

		public string AddrIndex { get; set; }

		public string AddrCity { get; set; }

		public string AddrStreet { get; set; }

		public string AddrHouse { get; set; }

		public string AddrStructure { get; set; }

		public string AddrApart { get; set; }

		public bool IsDefault { get; set; }
	}
}
