using deBuilding.BookSharingService.WebMVC.Models;
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
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.WebMVC.Controllers
{
	/// <summary>
	/// Контроллер начальной страницы. Содержит Индекс действие для отображения начальной страницы.
	/// </summary>
	public class HomeController : Controller
	{
		private readonly IHttpClientFactory _httpClient;

		public HomeController(IHttpClientFactory httpClient)
		{
			_httpClient = httpClient;
		}

		public IActionResult Index()
		{
			return View();
		}

		[Authorize(Policy = "IsSuperUser")]
		public async Task<IActionResult> UserInfo()
		{
			var accessToken = await HttpContext.GetTokenAsync("access_token");
			var idtoken = await HttpContext.GetTokenAsync("id_token");

			var _idToken = new JwtSecurityTokenHandler().ReadJwtToken(idtoken);
			var _accesToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);

			return View();
		}
	}
}
