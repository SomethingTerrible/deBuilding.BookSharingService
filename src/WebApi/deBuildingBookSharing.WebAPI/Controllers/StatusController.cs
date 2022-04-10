using deBuilding.BookSharingService.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace deBuildingBookSharing.WebAPI.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class StatusController : ControllerBase
	{
		private readonly IStatusService _statusService;

		public StatusController(IStatusService statusService)
		{
			_statusService = statusService;
		}

		[HttpGet]
		[Route("GetStatusIdByValue/{value:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<Guid> GetStatusId(int value)
		{
			var statusId = _statusService.GetStatusIdByStatusValue(value);

			if (statusId == null)
			{
				return NotFound();
			}

			return Ok(statusId);
		}
	}
}
