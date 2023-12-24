using deBuilding.BookSharingService.WebMVC.Models;
using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.WebMVC.Services
{
	public class IdentityParser : IIdentityParser<ApplicationUser>
	{
		private readonly IUserService _userService;

		public IdentityParser(IUserService userService)
		{
			_userService = userService;
		}

		public async Task<ApplicationUser> Parse(IPrincipal principal)
		{
			if (principal is ClaimsPrincipal claims)
			{
				var userId = Guid.Parse(claims.Claims.FirstOrDefault(x => x.Type == "UserBaseId")?.Value);
				var userSmall = await _userService.GetUserSmallCard(userId);

				return new ApplicationUser
				{
					UserBaseId = Guid.Parse(claims.Claims.FirstOrDefault(x => x.Type == "UserBaseId")?.Value ?? ""),
					IsSuperUser = Convert.ToBoolean(claims.Claims.FirstOrDefault(x => x.Type == "IsSuperUser")?.Value ?? ""),
					UserName = userSmall.UserName,
					Avatar = userSmall.Avatar,
					Rating = userSmall.Rating,
				};
			}
			throw new ArgumentNullException(message: "", paramName: nameof(principal));
		}
	}
}
