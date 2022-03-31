using deBuilding.BookSharingService.IdentityServer.Interfaces;
using deBuilding.BookSharingService.IdentityServer.Models.AspNetIdentityCustomModels;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.IdentityServer.Services
{
	public class ProfileService : IProfileService
	{
		private readonly UserManager<ApplicationUser> _userManager;

		private readonly IUnitOfWork _unitOfWork;

		public ProfileService(UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork)
		{
			_userManager = userManager;
			_unitOfWork = unitOfWork;
		}

		public async Task GetProfileDataAsync(ProfileDataRequestContext context)
		{
			var subject = context.Subject;
			var user = await _userManager.GetUserAsync(subject);

			if (user == null)
			{
				throw new ArgumentException("Пользователь не найден");
			}
			context.IssuedClaims.AddRange(GetClaimsFromUser(user));
		}

		public async Task IsActiveAsync(IsActiveContext context)
		{
			var subject = context.Subject;
			var user = await _userManager.GetUserAsync(subject);

			if (user == null)
			{
				throw new ArgumentException("Пользователь не найден");
			}

			context.IsActive = user.LockoutEnabled
				&& _unitOfWork.UserBase.Enabled(user.UserBaseId);
		}

		public IEnumerable<Claim> GetClaimsFromUser(ApplicationUser user)
		{
			var claims = new List<Claim>
			{
				new Claim(JwtClaimTypes.PreferredUserName, user.UserName),
				new Claim("UserBaseId", user.UserBaseId.ToString()),
				new Claim("IsSuperUser", user.IsSuperUser.ToString()),
			};

			return claims;
		}
	}
}
