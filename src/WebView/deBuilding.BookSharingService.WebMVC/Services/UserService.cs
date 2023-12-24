using deBuilding.BookSharingService.WebMVC.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.WebMVC.Services
{
	public class UserService : IUserService
	{
		private readonly HttpClient _httpClient;

		private readonly string _baseUrl;

		private readonly IConfiguration _configuration;

		public UserService(HttpClient httpClietn, IConfiguration configuration)
		{
			_httpClient = httpClietn;
			_configuration = configuration;
			_baseUrl = $"{_configuration["WebApiUrl"]}/api/v1/UserBase";
		}

		public async Task<UserBaseViewModel> GetUserById(Guid id)
		{
			var url = $"{_baseUrl}/GetUserById/{id}";
			var responseString = await _httpClient.GetStringAsync(url);

			var userBase = JsonConvert.DeserializeObject<UserBaseViewModel>(responseString);

			return userBase;
		}

		public async Task<UserSmallCardViewModel> GetUserSmallCard(Guid id)
		{
			var url = $"{_baseUrl}/GetUserCardInfo/{id}";
			var responseString = await _httpClient.GetStringAsync(url);

			var userCard = JsonConvert.DeserializeObject<UserSmallCardViewModel>(responseString);
			return userCard;
		}
	}
}
