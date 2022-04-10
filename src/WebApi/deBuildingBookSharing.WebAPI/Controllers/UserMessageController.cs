using AutoMapper;
using deBuilding.BookSharingService.Domain.DTO_Models;
using deBuilding.BookSharingService.Domain.Enums;
using deBuilding.BookSharingService.Domain.Interfaces;
using deBuildingBookSharing.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace deBuildingBookSharing.WebAPI.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class UserMessageController : ControllerBase
	{
		private readonly IUserMessageService _userMessageService;

		private readonly IStatusService _statusService;

		public UserMessageController(IUserMessageService userMessageService, IStatusService statusService)
		{
			_userMessageService = userMessageService;
			_statusService = statusService;
		}

		[HttpGet]
		[Route("GetUserMessageById/{userId:guid}/MessageType/{messageTypeValue:int}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserMessagesAPIDto))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<IEnumerable<UserMessagesAPIDto>> GetUserMessages(Guid userId, int messageTypeValue)
		{
			var mapper = new MapperConfiguration(
				config => config
				.CreateMap<UserMessageDto, UserMessagesAPIDto>())
				.CreateMapper();

			var messages = mapper.Map<IEnumerable<UserMessageDto>, 
				IEnumerable<UserMessagesAPIDto>>(_userMessageService.GetUserMessageByStatus(userId, messageTypeValue));
			
			return Ok(messages);
		}

		[HttpPost]
		[Route("CreateMessage")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		public ActionResult CreateMessage([FromBody] UserMessagesAPIDto userMessage)
		{
			try
			{
				var mapper = new MapperConfiguration(
				config => config
				.CreateMap<UserMessagesAPIDto, UserMessageDto>())
				.CreateMapper();

				var message = mapper.Map<UserMessagesAPIDto, UserMessageDto>(userMessage);

				_userMessageService.CreateMessage(message).Wait();

				return Ok();
			}
			catch(Exception ex)
			{
				var message = ex.InnerException.Message;
			}

			return BadRequest();
		}
	}
}
