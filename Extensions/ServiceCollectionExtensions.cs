using System;
using Destiny2;
using Destiny2.Services;
using Microsoft.Extensions.Logging;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDestiny2(this IServiceCollection services, string baseUrl, string apiKey,
            int manifesetCheckTimeout = 5 * 60 * 1000)
        {
            AddDestiny2Service(services, baseUrl, apiKey);
            AddManifestDownloader(services);
            AddManifestSettings(services, manifesetCheckTimeout);
            AddManifestHostedService(services);
            AddManifest(services);
        }

        private static void AddDestiny2Service(IServiceCollection services, string baseUrl, string apiKey)
        {
            if(string.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentException("Must specify the base URL", nameof(baseUrl));
            }
            if(string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("Must specify an API Key", nameof(apiKey));
            }

            services.AddHttpClient<IDestiny2, Destiny2.Services.Destiny2>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);
            });
        }

        private static void AddManifestDownloader(IServiceCollection services)
        {
            services.AddTransient<IManifestDownloader, ManifestDownloader>();
        }

        private static void AddManifestSettings(IServiceCollection services, int manifestCheckTimeout)
        {
            services.AddSingleton<IManifestSettings, ManifestSettings>(sp =>
            {
                var logger = sp.GetService<ILogger<ManifestSettings>>();
                return new ManifestSettings(logger)
                {
                    ManifestCheckTimeout = manifestCheckTimeout,
                };
            });
        }

        private static void AddManifestHostedService(IServiceCollection services)
        {
            services.AddHostedService<DownloadManifestService>();
        }

        private static void AddManifest(IServiceCollection services)
        {
            services.AddScoped<IManifest, ManifestDb>();
        }
    }
}