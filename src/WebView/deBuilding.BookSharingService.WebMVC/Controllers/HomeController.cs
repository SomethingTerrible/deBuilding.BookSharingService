using deBuilding.BookSharingService.WebMVC.Models;
using deBuilding.BookSharingService.WebMVC.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
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
		public IActionResult Index()
		{
			return View();
		}
	}
}
