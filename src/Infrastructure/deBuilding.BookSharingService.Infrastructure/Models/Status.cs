using System;
using System.Collections.Generic;
using System.Text;

namespace deBuilding.BookSharingService.Infrastructure.Models
{
	/// <summary>
	/// Таблица состояний.
	/// </summary>
	public class Status
	{
		public Guid StatusId { get; set; }

		public string StatusName { get; set; }

		public int StatusValue { get; set; }
	}
}
