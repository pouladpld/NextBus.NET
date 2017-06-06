using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NextBus.NET
{
    public class NextBusHttpClient : INextBusHttpClient
    {
        private const string Url = "http://webservices.nextbus.com/service/publicXMLFeed";

        private readonly HttpClient _client = new HttpClient { BaseAddress = new Uri(Url) };

        public async Task<string> Get(string url)
        {
            var response = await _client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}