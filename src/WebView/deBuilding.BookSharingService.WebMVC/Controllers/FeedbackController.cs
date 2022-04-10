using deBuilding.BookSharingService.WebMVC.Models;
using deBuilding.BookSharingService.WebMVC.Models.Enums;
using deBuilding.BookSharingService.WebMVC.Services;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.WebMVC.Controllers
{
	[Authorize(AuthenticationSchemes = OpenIdConnectDefaults.AuthenticationScheme)]
	public class FeedbackController : Controller
	{
		private readonly IIdentityParser<ApplicationUser> _identityParser;

		private readonly IUserMessageService _userMessageService;

		private readonly IStatusService _statusService;

		public FeedbackController(IIdentityParser<ApplicationUser> identityParser,
			IStatusService statusService, IUserMessageService userMessageService)
		{
			_identityParser = identityParser;
			_statusService = statusService;
			_userMessageService = userMessageService;
		}

		public IActionResult IncomingMessage()
		{
			return View();
		}

		public IActionResult ReceivedMessage()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Feedback()
		{
			var userId = _identityParser.Parse(User).UserBaseId;

			var vm = new UserMessageViewModel
			{
				UserId = userId,
			};

			return View(vm);
		}

		[HttpPost]
		public async Task<IActionResult> Feedback(UserMessageViewModel vm)
		{
			if (ModelState.IsValid)
			{
				var stautsId = _statusService.GetStatusIdByValue((int)UserMessageStatus.New).Result;
				var typeId = (int)UserMessageType.Outgoing;
				var userId = _identityParser.Parse(User).UserBaseId;

				var userMessage = new UserMessageViewModel
				{
					UserMsgId = Guid.NewGuid(),
					UserId = userId,
					CreatedAt = DateTime.Now,
					Notes = vm.Notes,
					UserMessage = vm.UserMessage,
					StatusId = stautsId,
					MessageType = typeId,
				};

				await _userMessageService.CreateMessageAsync(userMessage);

				return RedirectToAction(nameof(HomeController.Index), "Home");
			}

			return View(vm);
		}
	}
}
