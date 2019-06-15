using System;
using Microsoft.Extensions.DependencyInjection;

namespace Destiny2.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDestiny(this IServiceCollection services, string apiKey)
        {
            if(string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("Must specify an API Key", "apiKey");
            }

            services.AddHttpClient<IDestiny, Destiny>(client =>
            {
                client.BaseAddress = new Uri("https://www.bungie.net");
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);
            });
        }

        public static void AddManifestDownloader(this IServiceCollection services)
        {
            services.AddTransient<IManifestDownloader, ManifestDownloader>();
        }
    }
}