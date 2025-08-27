using Microsoft.Extensions.Options;
using Six.KeycloakAdmin.TokenProvider;

namespace Six.KeycloakAdmin.AdminClients;

/// <summary>
/// Keycloak admin client implementation using basic authentication (username/password)
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public sealed class BasicAuthKeycloakAdminProvider : KeycloakAdminProviderBase
{
  readonly BasicAuthTokenProvider _tokenProvider;
  readonly string _username;
  readonly string _password;

  public BasicAuthKeycloakAdminProvider(
    string username,
    string password,
    IHttpClientFactory httpClientFactory,
    IOptions<KeycloakAdminOptions> options,
    BasicAuthTokenProvider tokenProvider)
    : base(httpClientFactory, options)
  {
    if(string.IsNullOrEmpty(username))
      throw new ArgumentException("Username cannot be null or empty", nameof(username));

    if(string.IsNullOrEmpty(password))
      throw new ArgumentException("Password cannot be null or empty", nameof(password));

    _username = username;
    _password = password;
    _tokenProvider = tokenProvider;
  }

  protected override async Task<string?> GetTokenAsync(string realm, CancellationToken cancellationToken = default)
  {
    var currentRealm = realm;
    return await _tokenProvider.GetTokenAsync(currentRealm, _username, _password, cancellationToken);
  }
}