using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace deBuilding.BookSharingService.Infrastructure.Models
{
	/// <summary>
	/// Обращения пользователей к администратору.
	/// </summary>
	public class UserMsg
	{
		[Key]
		public Guid UserMsgId { get; set; }
		
		[ForeignKey("UserBase")]
		public Guid UserId { get; set; }

		public DateTime CreatedAt { get; set; }

		public string UserMessage { get; set; }

		public string Notes { get; set; }

		[ForeignKey("Status")]
		public Guid StatusId { get; set; }

		public int MessageType { get; set; }
	}
}
