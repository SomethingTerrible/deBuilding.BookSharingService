using deBuilding.BookSharingService.WebMVC.Models;
using deBuilding.BookSharingService.WebMVC.Services;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace deBuilding.BookSharingService.WebMVC.Controllers
{
	[Authorize(AuthenticationSchemes = OpenIdConnectDefaults.AuthenticationScheme)]
	public class AccountManagerController : Controller
	{
		private readonly IUserService _userService;

		private readonly IIdentityParser<ApplicationUser> _identityUserParser;

		private  ApplicationUser _applicationUser;

		public AccountManagerController(IUserService userService, IIdentityParser<ApplicationUser> identityUserParser)
		{
			_userService = userService;
			_identityUserParser = identityUserParser;
		}

		public IActionResult Profile()
		{
			_applicationUser = _identityUserParser.Parse(HttpContext.User);

			var userProfile = _userService.GetUserById(_applicationUser.UserBaseId).Result; 

			return View(userProfile);
		}
	}
}
