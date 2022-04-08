using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace deBuilding.BookSharingService.IdentityServer.Models.AspNetIdentityCustomModels
{
	/// <summary>
	/// Расширение для IdentityUser.
	/// </summary>
	public class ApplicationUser : IdentityUser
	{
		/// <summary>
		/// Идентификатор на таблицу UserBase.
		/// </summary>
		public Guid UserBaseId { get; set; }

		/// <summary>
		/// Указывает является ли пользователь администратором. Будем использовать для admin panel.
		/// </summary>
		public bool IsSuperUser { get; set; }
	}
}
