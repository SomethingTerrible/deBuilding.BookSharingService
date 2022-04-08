using System;
using System.ComponentModel.DataAnnotations;

namespace deBuildingBookSharing.WebAPI.Models
{
	public class UserBaseAPIDto
	{
		[Key]
		public Guid UserId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string SecondName { get; set; }

		public string Email { get; set; }

		public string UserName { get; set; }

		public int Rating { get; set; }

		public DateTime CreatedAt { get; set; }

		public bool Enabled { get; set; }

		public byte[] Avatar { get; set; }

		public bool IsStaff { get; set; }

		public bool IsSuperUser { get; set; }
	}
}
