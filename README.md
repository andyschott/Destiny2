# Destiny 2 API Wrapper

This is a .NET Core wrapper around the [Bungie.NET API](https://bungie-net.github.io/multi/index.html), in particular the parts relating to Destiny 2.

# Usage

In order to make use of this you will need to your application with Bungie. This is done at the [Bungie.net Application Portal](https://www.bungie.net/en/Application).

Once you have registered your application, create a new instance of the `Destiny` class and start making calls:

    using (var destiny = new Destiny(apiKey, accessToken))
    {
        // Make Destiny API calls here
    }

# Contributions

This project is not feature complete. Calls were added on an as-needed basis. Additional calls are welcome via pull requests. Try to name any new classes and methods the same as their Bungie.net counterparts as much as possible.
