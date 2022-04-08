using System;

namespace deBuildingBookSharing.WebAPI.Models
{
	public class UserSmallCardAPIDto
	{
		public Guid UserBaseId { get; set; }

		public string UserName { get; set; }

		public byte[] Avatar { get; set; }

		public int Rating { get; set; }
	}
}
