using deBuilding.BookSharingService.WebMVC.Models;
using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace deBuilding.BookSharingService.WebMVC.Services
{
	public class IdentityParser : IIdentityParser<ApplicationUser>
	{
		public ApplicationUser Parse(IPrincipal principal)
		{
			if (principal is ClaimsPrincipal claims)
			{
				return new ApplicationUser
				{
					UserBaseId = Guid.Parse(claims.Claims.FirstOrDefault(x => x.Type == "UserBaseId")?.Value ?? ""),
					IsSuperUser = Convert.ToBoolean(claims.Claims.FirstOrDefault(x => x.Type == "IsSuperUser")?.Value ?? "")
				};
			}
			throw new ArgumentNullException(message: "", paramName: nameof(principal));
		}
	}
}
