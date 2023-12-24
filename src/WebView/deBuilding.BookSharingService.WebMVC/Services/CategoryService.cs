using deBuilding.BookSharingService.WebMVC.Models;
using Microsoft.Extensions.Configuration;
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

		private readonly IConfiguration _configuration;

		public CategoryService(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_configuration = configuration;
			_baseUrl = $"{_configuration["WebApiUrl"]}/api/v1/Category";
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
