using AutoMapper;
using deBuilding.BookSharingService.Domain.DTO_Models;
using deBuilding.BookSharingService.Domain.Interfaces;
using deBuildingBookSharing.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace deBuildingBookSharing.WebAPI.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet]
		[Route("GetCategoryTrees")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryTreeAPIDto))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<IEnumerable<CategoryTreeAPIDto>> GetCategories()
		{
			var trees = _categoryService.GetCategoryTrees();

			var mapper = new MapperConfiguration(
				config => config
				.CreateMap<CategoryDto, CategoryAPIDto>())
				.CreateMapper();

			var catgeroyTrees = new List<CategoryTreeAPIDto>();

			foreach (var node in trees)
			{
				catgeroyTrees.Add(new CategoryTreeAPIDto
				{
					Parent = mapper.Map<CategoryDto, CategoryAPIDto>(node.Parent),
					Children = mapper.Map<IEnumerable<CategoryDto>, IEnumerable<CategoryAPIDto>>(node.Children)
				});
			}

			return Ok(catgeroyTrees);
		}
	}
}
