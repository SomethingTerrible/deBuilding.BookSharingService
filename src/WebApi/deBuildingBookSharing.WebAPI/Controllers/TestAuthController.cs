using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace deBuildingBookSharing.WebAPI.Controllers
{
	[Route("api/v1/[controller]")]
	[Authorize]
	[ApiController]
	public class TestAuthController : ControllerBase
	{
		[HttpGet]
		/*[ValidateAntiForgeryToken]*/
		public string GetLineFromTestController()
		{
			return "From Test Controller";
		}
	}
}
