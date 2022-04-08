using System;

namespace deBuilding.BookSharingService.WebMVC.Models
{
	public class UserSmallCardViewModel
	{
		public Guid UserBaseId { get; set; }

		public string UserName { get; set; }

		public byte[] Avatar { get; set; }

		public int Rating { get; set; }	
	}
}
