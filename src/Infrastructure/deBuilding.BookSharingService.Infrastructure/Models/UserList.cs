using System;
using System.Collections.Generic;
using System.Text;

namespace deBuilding.BookSharingService.Infrastructure.Models
{
	/// <summary>
	/// Соответствие между ЗПК и ППК.
	/// </summary>
	public class UserList
	{
		public Guid UserListId { get; set; }	

		public int TypeList { get; set; }
	}
}
