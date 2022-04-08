using AutoMapper;
using deBuilding.BookSharingService.Domain.DTO_Models;
using deBuilding.BookSharingService.Domain.Interfaces;
using deBuildingBookSharing.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace deBuildingBookSharing.WebAPI.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class UserBaseController : ControllerBase
	{
		private readonly IUserBaseService _userService;

		public UserBaseController(IUserBaseService userService)
		{
			_userService = userService;
		}

		[HttpGet]
		[Route("GetUserCardInfo/{id:guid}")]
		[ProducesResponseType(StatusCodes.Status200OK,Type = typeof((string,byte[])))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<UserSmallCardAPIDto> GetUserNameAndAvatar(Guid id)
		{
			var mapper = new MapperConfiguration(config => config
				.CreateMap<UserSmallCardDto, UserSmallCardAPIDto>())
				.CreateMapper();

			var card = mapper.Map<UserSmallCardDto, UserSmallCardAPIDto>(_userService.GetUserNameAndAvatarAsync(id).Result);

			return Ok(card);
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserBaseAPIDto))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<IEnumerable<UserBaseAPIDto>> GetAllUsers()
		{
			var mapper = new MapperConfiguration(config => config
			.CreateMap<UserBaseDto, UserBaseAPIDto>())
			.CreateMapper();

			var users = mapper.Map<IEnumerable<UserBaseDto>,
				IEnumerable<UserBaseAPIDto>>(_userService.GetAllUsers());

			return Ok(users);
		}

		[HttpGet]
		[Route("GetUserById/{id:guid}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserBaseAPIDto))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<UserBaseAPIDto>> GetUser(Guid id)
		{
			var mapper = new MapperConfiguration(config => config
				.CreateMap<UserBaseDto, UserBaseAPIDto>())
				.CreateMapper();

			var user = mapper.Map<UserBaseDto, UserBaseAPIDto>(await _userService.GetUserByIdAsync(id));
			
			return Ok(user);
		}
	}
}
