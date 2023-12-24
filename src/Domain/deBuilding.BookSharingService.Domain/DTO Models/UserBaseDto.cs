using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace deBuilding.BookSharingService.Domain.DTO_Models
{
	public class UserBaseDto
	{
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
