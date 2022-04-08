using System;
using System.Collections.Generic;
using System.Text;

namespace deBuilding.BookSharingService.Domain.DTO_Models
{
	public class UserSmallCardDto
	{
		public Guid UserBaseId { get; set; }

		public string UserName { get; set; }

		public byte[] Avatar { get; set; }

		public int Rating { get; set; }
	}
}
