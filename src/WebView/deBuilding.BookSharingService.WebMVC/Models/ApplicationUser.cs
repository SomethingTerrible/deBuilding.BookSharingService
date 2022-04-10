using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace deBuilding.BookSharingService.WebMVC.Models
{
	/// <summary>
	/// Расширение для IdentityUser.
	/// </summary>
	public class ApplicationUser : IdentityUser
	{

		/// <summary>
		/// Ссылка на основную таблицу по ТД.
		/// </summary>
		public Guid UserBaseId { get; set; }

		/// <summary>
		/// Указывает является ли пользователь администратором. Будем использовать для admin panel.
		/// </summary>
		public bool IsSuperUser { get; set; }

		public string UserName { get; set; }

		public byte[] Avatar { get; set; }

		public int Rating { get; set; }
	}
}
