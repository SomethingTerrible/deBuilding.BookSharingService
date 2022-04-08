using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace deBuilding.BookSharingService.Infrastructure.Models
{
	/// <summary>
	/// Таблица состояний.
	/// </summary>
	public class Status
	{
		[Key]
		public Guid StatusId { get; set; }

		public string StatusName { get; set; }

		public int StatusValue { get; set; }
	}
}
