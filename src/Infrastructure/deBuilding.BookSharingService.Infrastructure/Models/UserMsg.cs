using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace deBuilding.BookSharingService.Infrastructure.Models
{
	/// <summary>
	/// Обращения пользователей к администратору.
	/// </summary>
	public class UserMsg
	{
		public Guid UserMsgId { get; set; }
		
		[ForeignKey("UserBase")]
		public Guid UserId { get; set; }

		public DateTime CreatedAt { get; set; }

		public string Text { get; set; }

		public string Notes { get; set; }

		public Guid StatusId { get; set; }

		public int Type { get; set; }
	}
}
