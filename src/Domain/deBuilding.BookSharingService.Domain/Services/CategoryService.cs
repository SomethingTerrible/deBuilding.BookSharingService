using AutoMapper;
using deBuilding.BookSharingService.Domain.DTO_Models;
using deBuilding.BookSharingService.Domain.Interfaces;
using deBuilding.BookSharingService.Infrastructure.Interfaces;
using deBuilding.BookSharingService.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.Domain.Services
{
	public class CategoryService : ICategoryService
	{
		public IUnitOfWork Database { get; set; }

		public CategoryService(IUnitOfWork database)
		{
			Database = database;
		}

		public IEnumerable<CategoryTreeDto> GetCategoryTrees()
		{

			var categories = Database.Category
				.GetAll();

			var parentCategories = categories
				.Where(item => item.CategoryId == item.ParentCategoryId);

			var categoryTrees = new List<CategoryTreeDto>();

			foreach (var elem in parentCategories)
			{
				var parentMapper = new MapperConfiguration(config =>
					config.CreateMap<Category,CategoryDto>())
					.CreateMapper();

				var childCategory = GetChildCategory(elem);

				categoryTrees.Add(new CategoryTreeDto
				{
					Parent = parentMapper.Map<Category, CategoryDto>(elem),
					Children = childCategory
				}); 
			}

			return categoryTrees;
		}

		private IEnumerable<CategoryDto> GetChildCategory(Category category)
		{
			var childMapper = new MapperConfiguration(config =>
				config.CreateMap<Category, CategoryDto>())
				.CreateMapper();

			var childs = Database.Category
				.GetAll()
				.Where(item => (item.ParentCategoryId == category.ParentCategoryId &&
					item.CategoryId != category.CategoryId));

			return childMapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(childs);
		}
	}
}
