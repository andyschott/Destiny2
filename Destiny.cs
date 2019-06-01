using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Destiny2.Config;
using Newtonsoft.Json;

namespace Destiny2
{
    public class Destiny : IDisposable
    {
        private HttpClient _client;

        private const string BaseUrl = "https://www.bungie.net";

        public Destiny(string apiKey)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("X-API-Key", apiKey);
        }

        public void Dispose()
        {
            _client?.Dispose();
            _client = null;
        }

        public async Task<Manifest> GetManifest()
        {
            var url = $"{BaseUrl}/Platform/Destiny2/Manifest/";
            var json = await _client.GetStringAsync(url);
            var response = JsonConvert.DeserializeObject<Response<Manifest>>(json);

            if (response.ErrorCode != 1)
            {
                Debug.WriteLine($"Error Code: {response.ErrorCode}; Error Status: {response.ErrorStatus}");
                return null;
            }

            return response.Data;
        }
    }
}
