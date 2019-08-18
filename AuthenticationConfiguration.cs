namespace Destiny2
{
  public class AuthenticationConfiguration
  {
    public string LoginCookieName { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string AuthorizationEndpoint { get; set; }
    public string TokenEndpoint { get; set; }
    public string CallbackPath { get; set; }

    public bool IsValid => !string.IsNullOrEmpty(LoginCookieName) &&
      !string.IsNullOrEmpty(ClientId) &&
      !string.IsNullOrEmpty(ClientSecret) &&
      !string.IsNullOrEmpty(AuthorizationEndpoint) &&
      !string.IsNullOrEmpty(TokenEndpoint) &&
      !string.IsNullOrEmpty(CallbackPath);
  }
}