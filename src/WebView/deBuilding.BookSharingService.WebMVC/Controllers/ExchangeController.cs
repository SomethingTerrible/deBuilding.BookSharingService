using deBuilding.BookSharingService.WebMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace deBuilding.BookSharingService.WebMVC.Controllers
{
	public class ExchangeController : Controller
	{
		private readonly ICategoryService _categoryService;

		public ExchangeController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public IActionResult WantToExchange()
		{
			var treeView = _categoryService.GetCategoryTrees().Result;
			ViewBag.Trees = treeView;

			return View();
		}

		public IActionResult WantToGet()
		{
			var treeView = _categoryService.GetCategoryTrees().Result;
			ViewBag.Trees = treeView;

			return View();
		}

		public IActionResult DeliveryAddress()
		{
			return View();
		}
	}
}
