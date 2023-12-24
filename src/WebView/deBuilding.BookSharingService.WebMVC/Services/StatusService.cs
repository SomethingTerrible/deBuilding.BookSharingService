using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace deBuilding.BookSharingService.WebMVC.Services
{
	public class StatusService : IStatusService
	{
		private readonly HttpClient _httpClient;

		private readonly string _baseUrl;

		private readonly IConfiguration _configuration;

		public StatusService(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_configuration = configuration;
			_baseUrl = $"{_configuration["WebApiUrl"]}/api/v1/Status";
		}

		public async Task<Guid> GetStatusIdByValue(int statusValue)
		{
			var url = $"{_baseUrl}/GetStatusIdByValue/{statusValue}";
			var responseString = await _httpClient.GetStringAsync(url);

			var statusId = JsonConvert.DeserializeObject<Guid>(responseString);

			return statusId;
		}
	}
}
