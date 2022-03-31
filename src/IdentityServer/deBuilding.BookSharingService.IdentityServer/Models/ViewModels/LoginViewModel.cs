using System.ComponentModel.DataAnnotations;

namespace deBuilding.BookSharingService.IdentityServer.Models.ViewModels
{
	/// <summary>
	/// View модель для авторизации пользователя.
	/// </summary>
	public class LoginViewModel 
	{
		[Required]
		[EmailAddress(ErrorMessage = "Invalid email address")]
		public string Email { get; set; }	

		[Required(ErrorMessage ="Пароль не может быть NULL")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public string ReturnUrl { get; set; }

	}
}
