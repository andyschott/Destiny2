using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Destiny2.Config;
using Destiny2.Responses;
using Destiny2.User;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Destiny2
{
    public class Destiny : IDisposable
    {
        private HttpClient _client;
        public const string BaseAddress = "https://www.bungie.net";
        private JsonSerializerSettings _settings = new JsonSerializerSettings();

        public bool DeserializationDebugging
        {
            get { return _settings.TraceWriter != null; }
            set
            {
                if(value)
                {
                    _settings.TraceWriter = new MemoryTraceWriter();
                }
                else
                {
                    _settings.TraceWriter = null;
                }
            }
        }

        public Destiny(string apiKey, string accessToken = "")
        {
            _client = new HttpClient();
            
            if(!string.IsNullOrEmpty(apiKey))
            {
                _client.DefaultRequestHeaders.Add("X-API-Key", apiKey);
            }

            if(!string.IsNullOrEmpty(accessToken))
            {
                _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
            }
        }

        public void Dispose()
        {
            _client?.Dispose();
            _client = null;
        }

        public Task<Manifest> GetManifest()
        {
            return Get<Manifest>("Destiny2/Manifest");
        }

        public Task<UserMembershipData> GetMembershipData(long membershipId, BungieMembershipType type = BungieMembershipType.BungieNext)
        {
            return Get<UserMembershipData>($"User/GetMembershipsById/{membershipId}/{(int)type}");
        }

        public Task<DestinyProfileResponse> GetProfile(BungieMembershipType type, long id)
        {
            return GetProfile(type, id, DestinyComponentType.Profiles);
        }

        public Task<DestinyProfileResponse> GetProfile(BungieMembershipType type, long id, params DestinyComponentType[] components)
        {
            var query = ConvertComponents(components);
            return Get<DestinyProfileResponse>($"Destiny2/{(int)type}/Profile/{id}", new[] { query });
        }

        public Task<DestinyCharacterResponse> GetCharacterInfo(BungieMembershipType type, long id, long characterId, params DestinyComponentType[] infos)
        {
            var query = ConvertComponents(infos);
            return Get<DestinyCharacterResponse>($"Destiny2/{(int)type}/Profile/{id}/Character/{characterId}/", query);
        }

        public Task<DestinyItemResponse> GetItem(BungieMembershipType type, long id, long itemInstanceId, params DestinyComponentType[] infos)
        {
            var query = ConvertComponents(infos);
            return Get<DestinyItemResponse>($"Destiny2/{(int)type}/Profile/{id}/Item/{itemInstanceId}/", query);
        }

        public async Task<bool> DownloadFile(string relativePath, string destination)
        {
            try
            {
                using (var inputStream = await _client.GetStreamAsync(CreateUrl(relativePath)))
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
                Debug.WriteLine($"Error downloading {relativePath}: {ex.Message}");
                return false;
            }
        }

        public static string CreateUrl(string relativeUrl)
        {
            return $"{BaseAddress}{relativeUrl}";
        }

        private Uri BuildUrl(string method, IEnumerable<(string name, string value)> queryItems = null)
        {
            var builder = new UriBuilder($"{BaseAddress}/Platform/{method}/");

            if (queryItems != null)
            {
                var translated = from query in queryItems
                                 select $"{query.name}={query.value}";
                builder.Query = string.Join("&", translated);
            }

            return builder.Uri;
        }

        private async Task<T> Get<T>(string method, params (string name, string value)[] queryItems)
        {
            if (_client == null)
            {
                return default(T);
            }

            try
            {
                var url = BuildUrl(method, queryItems);
                Debug.WriteLine($"Calling {url}");

                var json = await _client.GetStringAsync(url);

                var response = JsonConvert.DeserializeObject<Response<T>>(json, _settings);
                if(DeserializationDebugging)
                {
                    Console.WriteLine(_settings.TraceWriter);
                }

                if (response.ErrorCode != 1)
                {
                    Debug.WriteLine($"Error Code: {response.ErrorCode}; Error Status: {response.ErrorStatus}");
                    return default(T);
                }

                return response.Data;
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"Error calling {method}: {ex.Message}");
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
