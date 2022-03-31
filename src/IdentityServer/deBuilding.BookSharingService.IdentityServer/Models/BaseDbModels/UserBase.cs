using System;
using System.ComponentModel.DataAnnotations;

namespace deBuilding.BookSharingService.IdentityServer.Models.BaseDbModels
{
	public class UserBase
	{
		[Key]
		public Guid UserId { get; set; }

		[Required]
		[RegularExpression(@"[а-яА-ЯёЁ\s]{25}", ErrorMessage = "Имя: ввод только символов кирилицы, длина не превышает 25 символов")]
		public string FirstName { get; set; }

		[Required]
		[RegularExpression(@"[а-яА-ЯёЁ\s]{50}", ErrorMessage = "Фамилия: ввод только символов кирилицы, длина не превышает 50 символов")]
		public string LastName { get; set; }

		[RegularExpression(@"[а-яА-ЯёЁ\s]{25}", ErrorMessage = "Отчество: ввод только символов кирилицы, длина не превышает 25 символов")]
		public string SecondName { get; set; }

		[Required]
		[EmailAddress]
		[RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
			ErrorMessage = "тест")]
		public string Email { get; set; }

		[Required]
		public string UserName { get; set; }

		public int Rating { get; set; }

		public DateTime CreatedAt { get; set; }

		public bool Enabled { get; set; }

		public byte[] Avatar { get; set; }

		public bool IsStaff { get; set; }

		public bool IsSuperUser { get; set; }

	}
}
