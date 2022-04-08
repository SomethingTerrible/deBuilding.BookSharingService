using deBuilding.BookSharingService.WebMVC.Models;
using deBuilding.BookSharingService.WebMVC.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.WebMVC.Controllers
{
	/// <summary>
	/// Контроллер начальной страницы. Содержит Индекс действие для отображения начальной страницы.
	/// </summary>
	public class HomeController : Controller
	{
		private readonly IUserService _userService;

		private readonly IIdentityParser<ApplicationUser> _identityUserParser;

		public HomeController(IIdentityParser<ApplicationUser> identityUserParser, IUserService userService)
		{
			_identityUserParser = identityUserParser;
			_userService = userService;
		}

		public IActionResult Index()
		{
			if (User.Identity.IsAuthenticated)
			{
				var user = _identityUserParser.Parse(HttpContext.User);

				var userCard = _userService.GetUserSmallCard(user.UserBaseId).Result;

				return View(userCard);
			}

			return View();
		}


	}
}
