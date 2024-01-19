using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

namespace Infraestructure.Factories
{
	public static class HttpClientFactory
	{
		private static HttpClient client = new HttpClient();
		private static string? apiKeysFactory;

		public static HttpClient BaseConfigClient(IConfiguration keysFactory)
		{
			apiKeysFactory = keysFactory["ApiKeys:IonosApiKey"];
			client.DefaultRequestHeaders.Clear();
			client.DefaultRequestHeaders.ConnectionClose = true;
			return client;
		}

		public static HttpRequestMessage ConfigRequestIONOS(HttpRequestMessage request)
		{
			client.CancelPendingRequests();
			client.DefaultRequestHeaders.Clear();
			client.DefaultRequestHeaders.ConnectionClose = true;
			request.Headers.Add("X-API-Key", apiKeysFactory);
			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			request.Headers.UserAgent.Add(new ProductInfoHeaderValue("APISkynet", "0.1"));
			return request;
		}
	}
}