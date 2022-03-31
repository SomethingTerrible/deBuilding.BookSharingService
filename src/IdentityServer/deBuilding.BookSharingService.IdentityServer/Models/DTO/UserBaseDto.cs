using System;

namespace deBuilding.BookSharingService.IdentityServer.Models.DTO
{
	public class UserBaseDto
	{
		public Guid UserId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string SecondName { get; set; }

		public string Email { get; set; }

		public string UserName { get; set; }

		public int Raiting { get; set; }

		public DateTime CreatedAt { get; set; }

		public bool Enabled { get; set; }

		public byte[] Avatar { get; set; }

		public bool IsStaff { get; set; }

		public bool IsSuperAdmin { get; set; }
	}
}