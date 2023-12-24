using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace deBuilding.BookSharingService.IdentityServer.Models.BaseDbModels
{
	public class UserAddress
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
