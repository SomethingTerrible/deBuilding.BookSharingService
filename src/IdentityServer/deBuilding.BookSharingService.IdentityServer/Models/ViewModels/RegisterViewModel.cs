using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace deBuilding.BookSharingService.IdentityServer.Models.ViewModels
{
	public class RegisterViewModel
	{
		public byte[] Avatar { get; set; }

		public IFormFile AvatarFile { get; set; }

		[Required]
		[RegularExpression(@"[а-яА-ЯёЁ\s]{1,50}", ErrorMessage = "Фамилия: ввод только символов кирилицы, длина не превышает 50 символов")]
		public string LastName { get; set; }

		[Required]
		[RegularExpression(@"[а-яА-ЯёЁ\s]{1,25}", ErrorMessage = "Имя: ввод только символов кирилицы, длина не превышает 25 символов")]
		public string FirstName { get; set; }

		[RegularExpression(@"[а-яА-ЯёЁ\s]{1,25}", ErrorMessage = "Отчество: ввод только символов кирилицы, длина не превышает 25 символов")]
		public string SecondName { get; set; }

		[Required]
		[EmailAddress]
		[RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
			ErrorMessage = "тест")]
		public string Email { get; set; }

		[Required]
		public string NickName { get; set; }

		[Required]
		[StringLength(100,ErrorMessage = "Минимальная длина пароля должна быть 8, максимальная - 100", MinimumLength = 8)]
        [DataType(DataType.Password)]
		[Display(Name = "Password")]
        public string Password { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display (Name ="Confirm password")]
        [Compare("Password", ErrorMessage = "Пароли должны совпадать, понял?! Черт блять, Ха тьфу на тебя.")]
        public string ConfirmPassword { get; set; }

		[Required]
		[RegularExpression(@"[-а-яА-ЯёЁ\s]+$")] // не добавлено условие: до 15 символов. Я не шарю за Regex.
		public string AddrCity { get; set; }

		[Required]
		[RegularExpression(@"[-а-яА-ЯёЁ\s]+$")]
		public string AddrStreet { get; set; }

		public string AddrStructure { get; set; }

		[Required]
		public string AddrHouse { get; set; }

		public string AddrApart { get; set; }

		[Required]
		[RegularExpression(@"\d{6}")]
		public string AddrIndex { get; set; }
	
		public string ReturnUrl { get; set; }
	}
}
