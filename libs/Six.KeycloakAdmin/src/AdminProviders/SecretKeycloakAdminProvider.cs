using Microsoft.Extensions.Options;
using Six.KeycloakAdmin.TokenCache;
using Six.KeycloakAdmin.TokenProvider;

namespace Six.KeycloakAdmin.AdminClients;

/// <summary>
/// Keycloak admin client implementation using client secret authentication
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public sealed class SecretKeycloakAdminProvider : KeycloakAdminProviderBase
{
  readonly ClientSecretTokenProvider _tokenProvider;
  readonly string _clientSecret;

  public SecretKeycloakAdminProvider(
    string clientSecret,
    IHttpClientFactory httpClientFactory,
    IOptions<KeycloakAdminOptions> options,
    ClientSecretTokenProvider tokenProvider)
    : base(httpClientFactory, options)
  {
    if(string.IsNullOrEmpty(clientSecret))
      throw new ArgumentException("Client secret cannot be null or empty", nameof(clientSecret));

    _clientSecret = clientSecret;
    _tokenProvider = tokenProvider;
  }

  protected override async Task<string?> GetTokenAsync(string realm, CancellationToken cancellationToken = default)
  {
    return await _tokenProvider.GetTokenAsync(realm, _clientSecret, cancellationToken);
  }
}