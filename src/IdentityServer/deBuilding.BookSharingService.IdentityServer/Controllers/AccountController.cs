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
					//todo Добавить путь к default
					vm.Avatar = /*System.IO.File.ReadAllBytes("default user image")*/ null;
				}

				var userId = Guid.NewGuid();

				// По-хорошему, тут лучше использовать AutoMapper, но пока так. Возможно в дальнейшем переделаю.

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
					FirstName = vm.FirstName,
					LastName = vm.LastName,
					UserBaseId = userId,
					UserName = vm.NickName,
					Email = vm.Email,
					IsSuperUser = false,
					Avatar = vm.Avatar,
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
	}
}
