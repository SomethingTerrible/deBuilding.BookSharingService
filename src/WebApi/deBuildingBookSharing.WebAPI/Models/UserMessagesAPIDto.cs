using System;

namespace deBuildingBookSharing.WebAPI.Models
{
	public class UserMessagesAPIDto
	{
		public Guid UserMsgId { get; set; }

		public Guid UserId { get; set; }

		public DateTime CreatedAt { get; set; }

		public string UserMessage { get; set; }

		public string Notes { get; set; }

		public Guid StatusId { get; set; }

		public int MessageType { get; set; }
	}
}
