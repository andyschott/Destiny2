using System;
using Destiny2;
using Destiny2.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDestiny(this IServiceCollection services, string baseUrl, string apiKey)
        {
            if(string.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentException("Must specify the base URL", "baseUrl");
            }
            if(string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("Must specify an API Key", "apiKey");
            }

            services.AddHttpClient<IDestiny2, Destiny2.Services.Destiny2>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);
            });
        }

        public static void AddManifestDownloader(this IServiceCollection services)
        {
            services.AddTransient<IManifestDownloader, ManifestDownloader>();
        }
    }
}