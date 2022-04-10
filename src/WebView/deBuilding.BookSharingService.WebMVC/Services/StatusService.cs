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

		public StatusService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_baseUrl = "https://localhost:7001/api/v1/Status";
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
