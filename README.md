# Destiny 2 API Wrapper

This is a .NET Core wrapper around the [Bungie.NET API](https://bungie-net.github.io/multi/index.html), in particular the parts relating to Destiny 2.

# Usage

This can be added to your project via [Nuget](https://www.nuget.org/packages/Destiny2/).

In order to make use of this you will need to your application with Bungie. This is done at the [Bungie.net Application Portal](https://www.bungie.net/en/Application).

To inject all services into the standard dependency injection container, call `services.AddDestiny2()`. This adds the following services:

- `IDestiny2`: wrapper for calling Bungie's Destiny 2 API.
- `IManifestDownloader`: downloads the manifest database.
- `IManifestSettings`: settings for the downloaded manifest database.
- `IManifest`: query the manifest database.

A hosted service is also setup that periodically checks for an updated manifest database. When it detects a new version, it will download it and save it to the local filesystem.

To setup cookie-based OAuth, call `services.AddBungieAuthentication()`. This will add a challenge scheme named `Bungie` that will allow users to authenticate with Bungie using their account. Once authenticated, the user's membership ID can be retrieved from their `User`:

        var value = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        long.TryParse(value, out long membershipId);

# Contributions

This project is not feature complete. Calls were added on an as-needed basis. Additional calls are welcome via pull requests. Try to name any new classes and methods the same as their Bungie.net counterparts as much as possible.
