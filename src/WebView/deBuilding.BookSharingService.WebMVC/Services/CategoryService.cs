using deBuilding.BookSharingService.WebMVC.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.WebMVC.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly HttpClient _httpClient;

		private readonly string _baseUrl;

		public CategoryService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_baseUrl = "https://localhost:7001/api/v1/Category";
		}

		public async Task<IEnumerable<CategoryTree>> GetCategoryTrees()
		{
			var url = $"{_baseUrl}/GetCategoryTrees";
			var responseString = await _httpClient.GetStringAsync(url);

			var categoryTrees = JsonConvert.DeserializeObject<IEnumerable<CategoryTree>>(responseString);

			return categoryTrees;
		}
	}
}
