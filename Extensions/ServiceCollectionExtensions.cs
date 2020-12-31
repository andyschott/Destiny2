using System;
using System.Net.Http;
using Destiny2;
using Destiny2.Helpers;
using Destiny2.Services;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDestiny2(this IServiceCollection services, Destiny2Config config)
        {
            if(!config.IsValid)
            {
                throw new ArgumentException("config is invalid", nameof(config));
            }

            services.AddTransient<ITraceWriter, JsonLogWriter>();

            AddDestiny2Service(services, config.BaseUrl, config.ApiKey, config.UserAgent);
            AddManifestDownloader(services);
            AddManifestSettings(services, config.ManifestDatabasePath, config.ManifestCheckTimeout);
            AddManifestHostedService(services);
            AddManifest(services);
        }

        private static void AddDestiny2Service(IServiceCollection services, string baseUrl, string apiKey, string userAgent)
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
                client.DefaultRequestHeaders.Add("User-Agent", userAgent);
            }).ConfigurePrimaryHttpMessageHandler(() =>
            {
                return new HttpClientHandler
                {
                    UseCookies = false
                };
            });

            services.AddScoped<BungieCookies>();
        }

        private static void AddManifestDownloader(IServiceCollection services)
        {
            services.AddTransient<IManifestDownloader, ManifestDownloader>();
        }

        private static void AddManifestSettings(IServiceCollection services, string manifestPath, int manifestCheckTimeout)
        {
            services.AddSingleton<IManifestSettings, ManifestSettings>(sp =>
            {
                var logger = sp.GetService<ILogger<ManifestSettings>>();
                return new ManifestSettings(logger, manifestPath)
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