using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Destiny2.Config;
using Destiny2.Responses;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Destiny2.Services
{
    class Destiny2 : IDestiny2
    {
        private readonly HttpClient _client;
        private readonly BungieCookies _affinitization;
        private readonly ILogger _logger;
        private readonly ITraceWriter _jsonLogWriter;
        private JsonSerializerSettings _settings = new JsonSerializerSettings();

        public Destiny2(HttpClient client, BungieCookies affinitization,
            ILogger<Destiny2> logger, ITraceWriter jsonLogWriter)
        {
            _client = client;
            _affinitization = affinitization;
            _logger = logger;
            _jsonLogWriter = jsonLogWriter;
        }

        public bool DeserializationDebugging
        {
            get { return _settings.TraceWriter != null; }
            set
            {
                if(value)
                {
                    _settings.TraceWriter = _jsonLogWriter;
                }
                else
                {
                    _settings.TraceWriter = null;
                }
            }
        }

        public string BaseUrl => _client.BaseAddress.AbsolutePath;

        public Task<Manifest> GetManifest()
        {
            return Get<Manifest>(string.Empty, "Destiny2/Manifest");
        }

        public Task<DestinyLinkedProfilesResponse> GetLinkedProfiles(string accessToken, long membershipId, BungieMembershipType type = BungieMembershipType.BungieNext)
        {
            return Get<DestinyLinkedProfilesResponse>(accessToken, $"Destiny2/{(int)type}/Profile/{membershipId}/LinkedProfiles");
        }

        public Task<DestinyProfileResponse> GetProfile(string accessToken, BungieMembershipType type, long id)
        {
            return GetProfile(accessToken, type, id, DestinyComponentType.Profiles);
        }

        public Task<DestinyProfileResponse> GetProfile(string accessToken, BungieMembershipType type, long id,
            params DestinyComponentType[] components)
        {
            var query = ConvertComponents(components);
            return Get<DestinyProfileResponse>(accessToken, $"Destiny2/{(int)type}/Profile/{id}", new[] { query });
        }

        public Task<DestinyCharacterResponse> GetCharacterInfo(string accessToken, BungieMembershipType type, long id,
            long characterId, params DestinyComponentType[] infos)
        {
            var query = ConvertComponents(infos);
            return Get<DestinyCharacterResponse>(accessToken, $"Destiny2/{(int)type}/Profile/{id}/Character/{characterId}/", query);
        }

        public Task<DestinyItemResponse> GetItem(string accessToken, BungieMembershipType type, long id, long itemInstanceId,
            params DestinyComponentType[] infos)
        {
            var query = ConvertComponents(infos);
            return Get<DestinyItemResponse>(accessToken, $"Destiny2/{(int)type}/Profile/{id}/Item/{itemInstanceId}/", query);
        }

        public Task<DestinyVendorResponse> GetVendorResponse(string accessToken, BungieMembershipType type, long membershipId,
            long characterId, uint vendorHash, params DestinyComponentType[] infos)
        {
            var query = ConvertComponents(infos);
            return Get<DestinyVendorResponse>(accessToken, $"Destiny2/{(int)type}/Profile/{membershipId}/Character/{characterId}/Vendors/{vendorHash}",
                query);
        }

        public async Task<bool> DownloadFile(string relativePath, string destination)
        {
            try
            {
                using (var inputStream = await _client.GetStreamAsync(relativePath))
                {
                    using (var outputStream = File.Create(destination))
                    {
                        await inputStream.CopyToAsync(outputStream);
                        return true;
                    }
                }
            }
            catch(HttpRequestException ex)
            {
                _logger.LogError($"Error downloading {relativePath}: {ex.Message}");
                return false;
            }
        }

        private Uri BuildUrl(string method, IEnumerable<(string name, string value)> queryItems = null)
        {
            var builder = new UriBuilder(_client.BaseAddress + $"Platform/{method}/");

            if (queryItems != null)
            {
                var translated = from query in queryItems
                                 select $"{query.name}={query.value}";
                builder.Query = string.Join("&", translated);
            }

            return builder.Uri;
        }

        private async Task<T> Get<T>(string accessToken, string method, params (string name, string value)[] queryItems)
        {
            try
            {
                var url = BuildUrl(method, queryItems);
                _logger.LogInformation($"Calling {url}");

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = url,
                };
                if(!string.IsNullOrEmpty(accessToken))
                {
                    request.Headers.Add("Authorization", $"Bearer {accessToken}");
                }

                if(_affinitization.Cookies.Any())
                {
                    var requestCookies = _affinitization.Cookies.Select(cookie =>
                    {
                        return $"{cookie.name}={cookie.value}";
                    });
                    request.Headers.Add("Cookie", string.Join(';', requestCookies));
                }

                var response = await _client.SendAsync(request);

                if(response.Headers.TryGetValues("set-cookie", out var responseCookies))
                {
                    _affinitization.SetCookies(responseCookies);
                };

                var json = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<Response<T>>(json, _settings);

                if (responseObject.ErrorCode != 1)
                {
                    _logger.LogWarning($"Error Code: {responseObject.ErrorCode}; Error Status: {responseObject.ErrorStatus}");
                    return default(T);
                }

                return responseObject.Data;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Error calling {method}: {ex.Message}");
                return default(T);
            }
        }

        private static (string name, string value) ConvertComponents(IEnumerable<DestinyComponentType> components)
        {
            var rawValues = from component in components
                            select (int)component;
            return ("components",  string.Join(",", rawValues));
        }
    }
}
