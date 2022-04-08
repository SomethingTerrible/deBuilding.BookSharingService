using deBuilding.BookSharingService.IdentityServer.Models.AspNetIdentityCustomModels;
using deBuilding.BookSharingService.IdentityServer.Models.ViewModels;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using deBuilding.BookSharingService.IdentityServer.Interfaces;
using deBuilding.BookSharingService.IdentityServer.Models.BaseDbModels;
using System.IO;
using System.Linq;
using IdentityModel;
using IdentityServer4;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace deBuilding.BookSharingService.IdentityServer.Controllers
{
	public class AccountController : Controller
	{
		private readonly SignInManager<ApplicationUser> _signInManager;

		private readonly UserManager<ApplicationUser> _userManager;

		private readonly IIdentityServerInteractionService _interactionService;

		private readonly IUnitOfWork _unitOfWork;


		public AccountController(SignInManager<ApplicationUser> signInManager,
			UserManager<ApplicationUser> userManager,
			IIdentityServerInteractionService interactionService, IUnitOfWork unitOfWork)
		{
			this._signInManager = signInManager;
			_userManager = userManager;
			_interactionService = interactionService;
			_unitOfWork = unitOfWork;
		}

		[HttpGet]
		public IActionResult Login(string returnUrl)
		{
			var vm = new LoginViewModel
			{
				ReturnUrl = returnUrl
			};

			return View(vm);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByEmailAsync(viewModel.Email);

				if (user == null)
				{
					ViewBag["Message"] = "Пользователь не найден.";
					return View(viewModel);
				}

				var loginResult = await _signInManager.PasswordSignInAsync(
					user.UserName, viewModel.Password, false, false);

				// Необходимо проверить, разрешен ли вход пользователю или нет. 
				// Проверять по 2 полям: у моего класса UserBase и в AspNetUsers

				if (loginResult.Succeeded)
				{
					return Redirect(viewModel.ReturnUrl);
				}
			}
			return View(viewModel);
		}

		[HttpGet]
		public IActionResult Register(string returnUrl)
		{
			var vm = new RegisterViewModel
			{
				ReturnUrl = returnUrl
			};

			return View(vm);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel vm)
		{
			if (ModelState.IsValid)
			{

				if (vm.AvatarFile != null)
				{
					using (var binaryReader = new BinaryReader(vm.AvatarFile.OpenReadStream()))
					{
						vm.Avatar = binaryReader.ReadBytes((int)vm.AvatarFile.Length);
					}
				}
				else
				{
					vm.Avatar = /*System.IO.File.ReadAllBytes("default user image")*/ null;
				}

				var userId = Guid.NewGuid();

				var userBase = new UserBase
				{
					UserId = userId,
					Avatar = vm.Avatar,
					CreatedAt = DateTime.Now,
					Email = vm.Email,
					Enabled = true,
					FirstName = vm.FirstName,
					IsStaff = false,
					IsSuperUser = false,
					LastName = vm.LastName,
					Rating = 0,
					SecondName = vm.SecondName,
					UserName = vm.NickName,
				};

				await _unitOfWork.UserBase.CreateAsync(userBase);
				await _unitOfWork.SaveDb();

				var userAddress = new UserAddress
				{
					UserAddressId = Guid.NewGuid(),
					UserId = userId,
					AddrCity = vm.AddrCity,
					AddrApart = vm.AddrApart,
					AddrHouse = vm.AddrHouse,
					AddrIndex = vm.AddrIndex,
					AddrStreet = vm.AddrStreet,
					AddrStructure = vm.AddrStructure,
					IsDefault = true,
				};

				await _unitOfWork.UserAddress.CreateAsync(userAddress);
				await _unitOfWork.SaveDb();

				var user = new ApplicationUser
				{
					UserBaseId = userId,
					UserName = vm.NickName,
					Email = vm.Email,
					IsSuperUser = false,
				};

				var createUserResult = await _userManager.CreateAsync(user, vm.Password);

				if (createUserResult.Succeeded)
				{
					await _signInManager.SignInAsync(user, false);
					return Redirect(vm.ReturnUrl);
				}
			}
			return View(vm);
		}

		[HttpGet]
		public async Task<IActionResult> Logout(string logoutId)
		{
			if (User.Identity.IsAuthenticated == false)
			{
				return await Logout(new LogoutViewModel { LogoutId = logoutId });
			}

			var vm = new LogoutViewModel
			{
				LogoutId = logoutId
			};

			return View(vm);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Logout(LogoutViewModel model)
		{
			var idp = User?.FindFirst(JwtClaimTypes.IdentityProvider)?.Value;

			if (idp != null && idp != IdentityServerConstants.LocalIdentityProvider)
			{
				if (model.LogoutId == null)
				{
					// if there's no current logout context, we need to create one
					// this captures necessary info from the current logged in user
					// before we signout and redirect away to the external IdP for signout
					model.LogoutId = await _interactionService.CreateLogoutContextAsync();
				}

				string url = "/Account/Logout?logoutId=" + model.LogoutId;

				try
				{

					// hack: try/catch to handle social providers that throw
					await HttpContext.SignOutAsync(idp, new AuthenticationProperties
					{
						RedirectUri = url
					});
				}
				catch (Exception ex)
				{
					
				}
			}

			await HttpContext.SignOutAsync();

			await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

			HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity());

			var logout = await _interactionService.GetLogoutContextAsync(model.LogoutId);

			return Redirect(logout?.PostLogoutRedirectUri);
		}
	}
}
