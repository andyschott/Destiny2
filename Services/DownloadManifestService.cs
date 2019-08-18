using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Destiny2.Services
{
  class DownloadManifestService : IHostedService, IDisposable
  {
    private readonly IServiceProvider _services;
    private readonly IManifestSettings _manifestSettings;
    private readonly ILogger _logger;

    private Timer _timer = null;

    public DownloadManifestService(IServiceProvider services, IManifestSettings manifestSettings,
        ILogger<DownloadManifestService> logger)
    {
        _services = services;
        _manifestSettings = manifestSettings;
        _logger = logger;
    }

    public void Dispose()
    {
        _timer.Dispose();
        _timer = null;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(async (state) => await CheckManifest(state), cancellationToken,
            TimeSpan.Zero, TimeSpan.FromMilliseconds(_manifestSettings.ManifestCheckTimeout));

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    private async Task CheckManifest(object state)
    {
        _logger?.LogInformation("Checking for an updated manifest.");

        var cancellationToken = (CancellationToken)state;

        using(var scope = _services.CreateScope())
        {
            var downloader = (IManifestDownloader)scope.ServiceProvider.GetRequiredService(typeof(IManifestDownloader));

            var currentVersion = await GetCurrentManifestVersion(cancellationToken);
            var updatedVersion = await downloader.DownloadManifest(_manifestSettings.DbPath.FullName, currentVersion);

            if(!string.IsNullOrEmpty(updatedVersion))
            {
                _logger.LogInformation("Downloaded an updated manifest. Updating the local verison number.");
                Task t = UpdateCurrentManifestVersion(updatedVersion, cancellationToken);
            }
        }
    }

    private async Task<string> GetCurrentManifestVersion(CancellationToken cancellationToken)
    {
        if (!_manifestSettings.VersionPath.Exists)
        {
            _logger?.LogInformation("VersionPath doesn't exist. Returning an empty string.");
            return string.Empty;
        }

        return await Task.Run(() => File.ReadAllText(_manifestSettings.VersionPath.FullName), cancellationToken);
    }

    private Task UpdateCurrentManifestVersion(string updatedVersion, CancellationToken cancellationToken)
    {
        return Task.Run(() => File.WriteAllText(_manifestSettings.VersionPath.FullName, updatedVersion),
            cancellationToken);
    }
  }
}