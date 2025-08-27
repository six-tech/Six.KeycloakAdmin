using Microsoft.Extensions.Options;
using Six.KeycloakAdmin.TokenCache;

namespace Six.KeycloakAdmin.AdminClients;

/// <summary>
/// Keycloak admin client implementation using a pre-existing token
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public sealed class TokenKeycloakAdminProvider : KeycloakAdminProviderBase
{
  readonly string _token;

  public TokenKeycloakAdminProvider(
    string token,
    IHttpClientFactory httpClientFactory,
    IOptions<KeycloakAdminOptions> options)
    : base(httpClientFactory, options)
  {
    if(string.IsNullOrEmpty(token))
      throw new ArgumentException("Token cannot be null or empty", nameof(token));

    _token = token;
  }

  protected override Task<string?> GetTokenAsync(
    string? realm, 
    CancellationToken cancellationToken = default)
  {
    // Simply return the pre-existing token
    return Task.FromResult<string?>(_token);
  }
}