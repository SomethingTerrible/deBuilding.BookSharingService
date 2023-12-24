using deBuilding.BookSharingService.WebMVC.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.WebMVC.Services
{
	public class UserMessageService : IUserMessageService
	{
		private readonly HttpClient _httpClient;

		private readonly string _baseUrl;

		private readonly IConfiguration _configuration;

		public UserMessageService(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_configuration = configuration;

			_baseUrl = $"{_configuration["WebApiUrl"]}/api/v1/UserMessage";
		}

		public async Task CreateMessageAsync(UserMessageViewModel vm)
		{
			var url = $"{_baseUrl}/CreateMessage";
			var vmJson = JsonSerializer.Serialize(vm);
			var userMessageContext = new StringContent(vmJson, 
				System.Text.Encoding.UTF8, "application/json");

			var response = await _httpClient.PostAsync(url, userMessageContext);
		}

		public async Task<IEnumerable<UserMessageViewModel>> GetMessages(Guid userId, int messageTypeValue)
		{
			var url = $"{_baseUrl}/GetUserMessageById/{userId}/MessageType/{messageTypeValue}";
			var responserString = await _httpClient.GetStringAsync(url);

			var userMessgaes = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<UserMessageViewModel>>(responserString);

			return userMessgaes;	
		}
	}
}
