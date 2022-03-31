using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.WebMVC.Controllers
{
	[Authorize(AuthenticationSchemes = OpenIdConnectDefaults.AuthenticationScheme)]
	public class AccountController : Controller
	{
		private readonly IHttpClientFactory _client;

		public AccountController(IHttpClientFactory client)
		{
			_client = client;
		}
		
		[Authorize(AuthenticationSchemes = OpenIdConnectDefaults.AuthenticationScheme)]
		public async Task<IActionResult> SignIn(string returnUrl)
		{
			var user = User as ClaimsPrincipal;
			var token = await HttpContext.GetTokenAsync("access_token");

			if (token != null)
			{
				ViewData["access_token"] = token;
			}

			return RedirectToAction(nameof(HomeController.Index),"Home");
		}

		public async Task<IActionResult> Signout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);

			var homeUrl = Url.Action(nameof(HomeController.Index), "Index");
			return new SignOutResult(OpenIdConnectDefaults.AuthenticationScheme,
				new AuthenticationProperties { RedirectUri = homeUrl });
		}
	}
}
