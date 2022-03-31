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
		/// Имя пользователя.
		/// </summary>
		[RegularExpression(@"[а-яА-ЯёЁ\s]{25}", ErrorMessage = "Имя: ввод только символов кирилицы, длина не превышает 25 символов")]
		public string FirstName { get; set; }

		/// <summary>
		/// Фамилия.
		/// </summary>
		[RegularExpression(@"[а-яА-ЯёЁ\s]{50}", ErrorMessage = "Фамилия: ввод только символов кирилицы, длина не превышает 50 символов")]
		public string LastName { get; set; }

		/// <summary>
		/// Аватар пользователя.
		/// </summary>
		public byte[] Avatar { get; set; }

		/// <summary>
		/// Указывает является ли пользователь администратором. Будем использовать для admin panel.
		/// </summary>
		public bool IsSuperUser { get; set; }
	}
}
