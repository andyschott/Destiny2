using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Destiny2;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AuthenticationExtensions
    {
        public static void AddBungieAuthentication(this IServiceCollection services, AuthenticationConfiguration config)
        {
            if(!config.IsValid)
            {
                throw new ArgumentException("config is invalid", nameof(config));
            }

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "Bungie";
            })
            .AddCookie(options => {
                options.Cookie.Name = config.LoginCookieName;
                options.Events = new CookieAuthenticationEvents
                {
                    OnValidatePrincipal = context =>
                    {
                        return HandleRefreshToken(context, config.ClientId, config.ClientSecret,
                            config.TokenEndpoint);
                    }
                };
            })
            .AddOAuth("Bungie", options => {
                options.ClientId = config.ClientId;
                options.ClientSecret = config.ClientSecret;
                options.CallbackPath = new PathString(config.CallbackPath);

                options.AuthorizationEndpoint = config.AuthorizationEndpoint;
                options.TokenEndpoint = config.TokenEndpoint;

                options.SaveTokens = true;

                options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "membership_id");

                options.Events = new OAuthEvents
                {
                    OnCreatingTicket = context =>
                    {
                        context.RunClaimActions(context.TokenResponse.Response);
                        return Task.CompletedTask;
                    },
                    OnRemoteFailure = context =>
                    {
                        return Task.CompletedTask;
                    }
                };
            });
        }

        // https://stackoverflow.com/q/52175302/3857
        private static async Task HandleRefreshToken(CookieValidatePrincipalContext context,
        string clientId, string clientSecret, string tokenEndpoint)
        {
            if(!context.Principal.Identity.IsAuthenticated)
            {
                return;
            }

            var tokens = context.Properties.GetTokens();
            var refreshToken = tokens.FirstOrDefault(t => t.Name == "refresh_token");
            var accessToken = tokens.FirstOrDefault(t => t.Name == "access_token");
            var exp = tokens.FirstOrDefault(t => t.Name == "expires_at");
            var expires = DateTime.Parse(exp.Value);
            if(expires >= DateTime.Now)
            {
                return;
            }

            // Token is expired. Attempt to renew it.
            var request = new RefreshTokenRequest
            {
                Address = tokenEndpoint,
                ClientId = clientId,
                ClientSecret = clientSecret,
                RefreshToken = refreshToken.Value
            };
            TokenResponse tokenResponse;
            using(var client = new HttpClient())
            {
                tokenResponse = await client.RequestRefreshTokenAsync(request);
            }

            if(tokenResponse.IsError)
            {
                context.RejectPrincipal();
                return;
            }

            refreshToken.Value = tokenResponse.RefreshToken;
            accessToken.Value = tokenResponse.AccessToken;

            var newExpires = DateTime.UtcNow + TimeSpan.FromSeconds(tokenResponse.ExpiresIn);
            exp.Value = newExpires.ToString("o", CultureInfo.InvariantCulture);

            context.Properties.StoreTokens(tokens);
            context.ShouldRenew = true;
        }
    }
}